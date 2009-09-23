using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Win32;

namespace TortoiseIssueList
{
    partial class MyIssuesForm : Form
    {
        #region Membres

        private readonly PluginRedMine _servicePluginRedmine;
        private IEnumerable<TicketItem> _tickets;
        private readonly List<TicketItem> _ticketsAffected = new List<TicketItem>();
        private readonly Color _couleurSucces;
        private readonly Color _couleurEchec;
        private readonly Color _couleurNeutre;
        private readonly Color _couleurRecent;
        /// <summary>
        /// Couleur des selections courantes (recherchées ou passées)
        /// </summary>
        private Color _couleurSelectionCourante;

        private bool _modeEtendu;

        private readonly string _regAdressBase;
        private readonly string _keyLargeur;
        private readonly string _keyHauteur;
        private readonly string _keyPanelDescription;
        private readonly string _regAdressRecent;
        private readonly string _keyModeEtendu;

        private string _commentaireEntree;

        private AfficheurAide _aideCompo;
        #endregion

        #region Constructeur
        public MyIssuesForm(PluginRedMine plugin, string commentaireBase)
        {
            _servicePluginRedmine = plugin;
            InitializeComponent();

            _regAdressBase = "Software\\Euriware\\PluginTortoise";
            _regAdressRecent = _regAdressBase + "\\RecentID";
            _keyLargeur = "TailleLargeur";
            _keyHauteur = "TailleHauteur";
            _keyPanelDescription = "UseDescription";
            _keyModeEtendu = "Mode etendu";
            _couleurSucces = Color.LightSkyBlue;
            _couleurEchec = Color.LightGray;
            _couleurNeutre = Color.White;
            _couleurRecent = Color.Gainsboro;
            _couleurSelectionCourante = _couleurRecent;
            ModeEtendu = true;
            _commentaireEntree = commentaireBase;

            _aideCompo = new AfficheurAide();
            _aideCompo.AddHelpMessage(btOurvirRedmine, "Ouvre la page Redmine associée aux demandes selectionnées");
            _aideCompo.AddHelpMessage(btPointage, "Ouvre et préremplie la page Redmine permettant de réaliser le pointage sur les demandes selectionnées");
            _aideCompo.AddHelpMessage(btCancel, "Ferme la fenêtre sans modifier le commentaire de la livraison");
            _aideCompo.AddHelpMessage(btOk, "Ferme la fenêtre et mets à jour le commentaire de livraison en fonction des demandes selectionnées");
            _aideCompo.AddHelpMessage(btDescription, "Affiche la fenetre donnant la description de la première demande selectionnée");
            _aideCompo.AddHelpMessage(btNext, "Selectionne la prochaine demande surlignée");
            _aideCompo.AddHelpMessage(btCocher, "Coche/Décoche l'ensemble des demandes surlignées");
            _aideCompo.AddHelpMessage(listeDemandes, "Liste des demandes Redmine (numéro d'ID, type, description)");
            _aideCompo.AddHelpMessage(tbxSearch, "Moteur de recherche");
        }

        #endregion


        #region Propriété

        
        public IEnumerable<TicketItem> TicketsFixed
        {
            get { return _ticketsAffected; }
        }

        private bool ModeEtendu
        {
            get { return _modeEtendu; }
            set
            {
                _modeEtendu = value;
                btDescription.Visible = _modeEtendu;
                panelExpert.Visible = _modeEtendu;
                if (!_modeEtendu && !splitContainer1.Panel2Collapsed)
                    splitContainer1.Panel2Collapsed = true;
            }
        }

        private bool EnabledControlFenetre
        {
            set
            {
                btOk.Enabled = value;
                btCancel.Enabled = value;
                btDescription.Enabled = value;
                //btOurvirRedmine.Enabled = value;
                //btPointage.Enabled = value;
                btNext.Enabled = value;
                btCocher.Enabled = value;
                tbxSearch.Enabled = value;
                btAbout.Enabled = value;
            }
        }

        #endregion

        #region Methodes
        /// <summary>
        /// Appelé lors du chargement de la fenetre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyIssuesForm_Load(object sender, EventArgs e)
        { }


        private void InitialiseListeTickets()
        {
            _tickets = _servicePluginRedmine.Tickets ;
            

            foreach (TicketItem ticketItem in _tickets)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = "";
                lvi.SubItems.Add(ticketItem.Number.ToString());
                lvi.SubItems.Add(ticketItem.Type);
                lvi.SubItems.Add(ticketItem.Summary);
                lvi.Tag = ticketItem;

                listeDemandes.Items.Add(lvi);
            }

            listeDemandes.Columns[0].Width = -1;
            listeDemandes.Columns[1].Width = -1;
            listeDemandes.Columns[2].Width = -1;
            listeDemandes.Columns[3].Width = -1;

            RestorePreference();
        }

        /// <summary>
        /// Appelé à la création de la fenetre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyIssuesForm_Shown(object sender, EventArgs e)
        {
            listeDemandes.Columns.Add("");
            listeDemandes.Columns.Add("#");
            listeDemandes.Columns.Add("Type");
            listeDemandes.Columns.Add("Summary");

            tbxSearch.Focus();

            #region Chargement des paramètres de la fenetre

            try
            {
                #region Ouverture de la cle registre
                RegistryKey MyReg = Registry.CurrentUser.CreateSubKey(_regAdressBase);
                #endregion

                int larg = (int)MyReg.GetValue(_keyLargeur);
                int haut = (int)MyReg.GetValue(_keyHauteur);
                string useDescription = MyReg.GetValue(_keyPanelDescription) as string;

                Size = new Size(larg, haut);
                splitContainer1.Panel2Collapsed = (useDescription != "Yes");
            }
            catch (Exception ex)
            {
                
            }
            #endregion

            #region Lancement du thread de chargement du flux

            EnabledControlFenetre = false;
            labelStatut.Text = "Statut : "+"Chargement du flux Rss ";
            Thread thLoadFlux = new Thread(_servicePluginRedmine.GetRssDoc);
            thLoadFlux.Start();
            while ((thLoadFlux.ThreadState != ThreadState.Aborted) && (thLoadFlux.ThreadState != ThreadState.Stopped))
            {
                Thread.Sleep(50);
                QuantumAttente();
                Application.DoEvents();
            }
            progressBar.Visible = false;
            labelStatut.Text = "Statut : " + "Flux chargé";
            EnabledControlFenetre = true;
            #endregion

            // une fois chargée, on initialise la fenetre
            InitialiseListeTickets();

        }

        private void QuantumAttente()
        {
            progressBar.Value = (progressBar.Value + 1)%100;
        }

        /// <summary>
        /// indique quels sont les anciens items selectionnés
        /// </summary>
        private void RestorePreference()
        {
            RegistryKey MyReg = Registry.CurrentUser.CreateSubKey(_regAdressRecent);
            string[] tabDescription = MyReg.GetValueNames();

            ResetItemBackColor(_couleurNeutre);
            foreach (string itDescription in tabDescription)
            {
                FindIssue(MyReg.GetValue(itDescription) as string, _couleurRecent, _couleurNeutre, true);
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in listeDemandes.Items)
            {
                TicketItem ticketItem = lvi.Tag as TicketItem;
                if (ticketItem != null && lvi.Checked)
                {
                    _ticketsAffected.Add(ticketItem);
                }
            }
            if (_ticketsAffected.Count > 0)
                MiseAjourPreference(_ticketsAffected);
        }

        /// <summary>
        /// Inscrit dans le registre les éléments selectionnés
        /// </summary>
        /// <param name="listTickets">listes des tickets gagnant</param>
        private void MiseAjourPreference(List<TicketItem> listTickets)
        {
            #region Ouverture de la cle registre
            Registry.CurrentUser.DeleteSubKey(_regAdressRecent, false);
            RegistryKey MyReg = Registry.CurrentUser.CreateSubKey(_regAdressRecent);
            #endregion

            foreach (TicketItem itItem in listTickets)
            {
                MyReg.SetValue("IssueID " + itItem.Number, itItem.Summary);
            }
        }

        private void btAbout_Click(object sender, EventArgs e)
        {
            About fenAbout = new About();
            fenAbout.ShowDialog();
        }

        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            if (tbxSearch.Text == "")
            {
                gbxSearch.Text = "Recherche";
                RestorePreference();
            }
            else
            {
                int nbResu = FindIssue(tbxSearch.Text, _couleurSucces, _couleurEchec, false);
                gbxSearch.Text = "Recherche : " + nbResu + " occurence(s)";
            }
        }

        /// <summary>
        /// Mets tous les éléments à une meme couleur
        /// </summary>
        /// <param name="couleur">la couleur</param>
        private void ResetItemBackColor(Color couleur)
        {
            for (int i = 0; i < listeDemandes.Items.Count; i++)
            {
                listeDemandes.Items[i].BackColor = couleur;
            }
        }

        /// <summary>
        /// Fonction de colorisation de la liste en fonction d'un critère sur le texte
        /// </summary>
        /// <param name="text">texte recherché</param>
        /// <param name="couleurSucces">Couleur des lignes ayant le texte dans la description</param>
        /// <param name="couleurEchec">Couleur des lignes n'ayant pas le texte dans la description</param>
        /// <param name="onlyMatch">Si vrai, seul les lignes "gagnante" sont modifiées</param>
        /// <returns>Nombre de résultats</returns>
        private int FindIssue(string text, Color couleurSucces, Color couleurEchec, bool onlyMatch)
        {
            _couleurSelectionCourante = couleurSucces;
            string textNoCase = UniformisationText(text);
            int nbVal = 0;

            for (int i = 0; i < listeDemandes.Items.Count; i++)
            {
                ListViewItem itItem = listeDemandes.Items[i];
                if (UniformisationText(itItem.SubItems[3].Text).Contains(textNoCase))
                {
                    nbVal++;
                    itItem.BackColor = couleurSucces;
                }
                else
                {
                    if (!onlyMatch)
                        itItem.BackColor = couleurEchec;
                }
            }
            return nbVal;
        }

        private string UniformisationText(string texte)
        {
            string nomFinal = texte.ToLower();

            nomFinal = nomFinal.Replace('à', 'a');
            nomFinal = nomFinal.Replace('â', 'a');

            nomFinal = nomFinal.Replace('ç', 'c');

            nomFinal = nomFinal.Replace('é', 'e');
            nomFinal = nomFinal.Replace('è', 'e');
            nomFinal = nomFinal.Replace('ê', 'e');

            nomFinal = nomFinal.Replace('ï', 'i');
            nomFinal = nomFinal.Replace('î', 'i');

            nomFinal = nomFinal.Replace('ù', 'u');
            nomFinal = nomFinal.Replace('û', 'u');
            nomFinal = nomFinal.Replace('ü', 'u');

            return nomFinal;
        }

        /// <summary>
        /// Fonction appelé pour afficher la description de la demande selectionnée
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listeDemandes.SelectedItems.Count > 0)
            {
                string contenuItem = (listeDemandes.SelectedItems[0].Tag as TicketItem).Contenu;
                webBrowser1.DocumentText = "<html><body>" + contenuItem + "</body></html>";

                btOurvirRedmine.Enabled = true;
                btPointage.Enabled = true;
            }
            else
            {
                btOurvirRedmine.Enabled = false;
                btPointage.Enabled = false;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2Collapsed = !splitContainer1.Panel2Collapsed;
        }

        /// <summary>
        /// Appelé à la fermetture de la fenetre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyIssuesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            #region Enregistrement des paramètres de la fenetre

            try
            {
                #region Ouverture de la cle registre
                RegistryKey MyReg = Registry.CurrentUser.CreateSubKey(_regAdressBase);
                #endregion

                MyReg.SetValue(_keyLargeur, Size.Width);
                MyReg.SetValue(_keyHauteur, Size.Height);

                MyReg.SetValue(_keyPanelDescription, (splitContainer1.Panel2Collapsed ? "No" : "Yes"));
                MyReg.SetValue(_keyModeEtendu, (ModeEtendu ? "Yes" : "No"));
            }
            catch (Exception ex)
            {
                ; // utilisation des paramètres par défauts
            }
            #endregion
        }

        /// <summary>
        /// Coche l'ensemble des lignes surlignées
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btCocher_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listeDemandes.Items.Count; i++)
            {
                ListViewItem itItem = listeDemandes.Items[i];
                if (itItem.BackColor == _couleurSelectionCourante)
                {
                    itItem.Checked = !itItem.Checked;
                }
            }
        }

        private void btNext_Click(object sender, EventArgs e)
        {
            int indiceDepart;
            if (listeDemandes.SelectedItems.Count > 0)
            {
                indiceDepart = listeDemandes.SelectedIndices[listeDemandes.SelectedItems.Count - 1] + 1;
            }
            else
            {
                indiceDepart = 0;
            }

            int indiceResu = FindElementWithGoodColor(indiceDepart, listeDemandes.Items.Count - 1, _couleurSelectionCourante);
            if (indiceResu == -1)
            {
                indiceResu = FindElementWithGoodColor(0, indiceDepart - 2, _couleurSelectionCourante);
            }

            if (indiceResu >= 0)
            {
                listeDemandes.Focus();
                for (int i = 0; i < listeDemandes.SelectedIndices.Count; i++)
                {
                    listeDemandes.Items[listeDemandes.SelectedIndices[i]].Selected = false;
                }
                listeDemandes.Items[indiceResu].EnsureVisible();
                listeDemandes.Items[indiceResu].Selected = true;
            }
        }

        private int FindElementWithGoodColor(int indPremier, int indiceDernier, Color couleurCherche)
        {
            for (int i = indPremier; i <= indiceDernier; i++)
            {
                if (listeDemandes.Items[i].BackColor == couleurCherche)
                {
                    return i;
                }
            }
            return -1;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            for (int i = 0; i < listeDemandes.SelectedItems.Count; i++)
            {
                OuvrirTacheRedmine((listeDemandes.SelectedItems[i].Tag as TicketItem));
            }
        }

        private void OuvrirTacheRedmine(TicketItem ticketItem)
        {
            System.Diagnostics.Process.Start(ticketItem.Lien);
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            for (int i = 0; i < listeDemandes.SelectedItems.Count; i++)
            {
                OuvrirCodePointage((listeDemandes.SelectedItems[i].Tag as TicketItem), _commentaireEntree);
            }
        }

        private void OuvrirCodePointage(TicketItem ticketItem, string commentaire)
        {
            #region Extraction de l'url

            string[] tabMostLien = ticketItem.Lien.Split('/');
            if (tabMostLien.Length < 5) return;

            string nbHeure = "&time_entry[hours]=" + "8";
            string comment = (commentaire == "" ? "" : "&time_entry[comments]=" + commentaire);

            Uri urlBase = new Uri(
                "http://"
                + tabMostLien[2]
                + "/timelog/edit?"
                + "issue_id="
                + ticketItem.Number
                + nbHeure
                + comment);

            System.Diagnostics.Process.Start(Uri.EscapeUriString(urlBase.ToString()));

            #endregion
        }


        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {

            About fenAbout = new About();
            fenAbout.ShowDialog();
        }
        #endregion
    }
}