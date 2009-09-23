using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;
//using Atom.Core;
using Interop.BugTraqProvider;
using RssToolkit.Rss;

//using Rss;

namespace TortoiseIssueList
{
    [ComVisible(true),
     Guid("5870B3F1-8393-4c83-ACED-1D5E803A4F2B"),
     ClassInterface(ClassInterfaceType.None)]
    public class PluginRedMine : IBugTraqProvider
    {
        #region Membres

        private int _nbItemParPage ;
        private string _keyItemParPage;
        private string _keyNumPage;
        private string _feeds;
        private List<TicketItem> _tickets;
        private string _feedsUrl;
        private RssDocument _rssDoc;

        #endregion

        #region Constructeur

        public PluginRedMine()
        {
            _nbItemParPage = 100; // 25,50,100
            _keyItemParPage = "&per_page=";
            _keyNumPage = "&page=";
            _tickets = new List<TicketItem>();
        }
        #endregion

        #region Proprietes

        
        private string FeedsUrl
        {
            get { return _feedsUrl; }
            set
            {
                _feedsUrl = value;
                if (!_feedsUrl.Contains(_keyItemParPage))
                    _feedsUrl += _keyItemParPage + _nbItemParPage;
            }
        }

        internal List<TicketItem> Tickets
        {
            get { return _tickets; }
        }

        internal string TitreFlux
        {
            get { return _rssDoc.Channel.Title; }
        }
        #endregion

        #region Methodes pour Tortoise


        public bool ValidateParameters(IntPtr hParentWnd, string parameters)
        {
            return true;
        }

        public string GetLinkText(IntPtr hParentWnd, string parameters)
        {
            return " &Demandes Redmine ";
        }

        public string GetCommitMessage(IntPtr hParentWnd, string parameters, string commonRoot, string[] pathList,
                                       string originalMessage)
        {
            //PleaseWait formWait = new PleaseWait();
            //formWait.Show();
            try
            {
                
                FeedsUrl = parameters;

                //Thread thLoadFlux = new Thread(GetRssDoc);
                //thLoadFlux.Start();
                //while ((thLoadFlux.ThreadState != ThreadState.Aborted) && (thLoadFlux.ThreadState != ThreadState.Stopped))
                //{
                //    Thread.Sleep(50);
                //    formWait.QuantumAttente();
                //    Application.DoEvents();
                //}
                
                                
                MyIssuesForm form = new MyIssuesForm(this, originalMessage);
                if (form.ShowDialog() != DialogResult.OK)
                    return originalMessage;

                String resultat = "";
                int cptLigne = 0;
                foreach (TicketItem ticket in form.TicketsFixed)
                {
                    if (cptLigne == 0)
                        resultat += "IssueID #" + ticket.Number;
                        
                    else
                        resultat += ",#" + ticket.Number;

                    cptLigne++;
                }
                resultat += "\n" + originalMessage;
                return resultat;

            }
            catch (Exception ex)
            {
                //formWait.Close();
                MessageBox.Show(ex.ToString());                
                throw;
            }
        }
        #endregion

        internal void GetRssDoc()
        {
            try
            {
                Uri url = new Uri(FeedsUrl);

                _rssDoc = RssDocument.Load(url);

                for (int i = 0; i < _rssDoc.Channel.Items.Count; i++)
                {
                    Tickets.Add(CreerTicketDepuisTitre(_rssDoc.Channel.Items[i].Title,
                                                       _rssDoc.Channel.Items[i].Description,
                                                       _rssDoc.Channel.Items[i].Guid.Text));
                }

                int numPageCourante = 2;
                bool stopSearch = false;
                while (_rssDoc.Channel.Items.Count == _nbItemParPage && !stopSearch)
                {
                    _rssDoc = RssDocument.Load(new Uri(FeedsUrl + _keyNumPage + numPageCourante));
                    for (int i = 0; i < _rssDoc.Channel.Items.Count; i++)
                    {
                        TicketItem nouvTicket = CreerTicketDepuisTitre(_rssDoc.Channel.Items[i].Title,
                                                                       _rssDoc.Channel.Items[i].Description,
                                                                       _rssDoc.Channel.Items[i].Guid.Text);
                        if (Tickets.Contains(nouvTicket))
                        {
                            stopSearch = true;
                            break;
                        }
                        else
                            Tickets.Add(nouvTicket);
                    }
                }
            }
            catch(Exception ex)
            {}

        }

        private TicketItem CreerTicketDepuisTitre(string titre, string contenu, string link)
        {
            int numero;
            string type;
            string description="";

           
            try
            {
                Regex regexObj = new Regex("(?<TypeTache>.*)#(?<IdTache>[0-9]*):(?<DescTache>.*)");
                type = regexObj.Match(titre).Groups["TypeTache"].Value;
                numero = int.Parse( regexObj.Match(titre).Groups["IdTache"].Value);
                description = regexObj.Match(titre).Groups["DescTache"].Value;
            }
            catch (ArgumentException ex)
            {
                throw;
            }


            return new TicketItem(numero, type, description, contenu,link);
        }
    }
}