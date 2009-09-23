using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace TortoiseIssueList
{
    public partial class AfficheurAide : Component
    {
        private Dictionary<object, string> _listeMessage;

        public AfficheurAide()
        {
            InitializeComponent();
            _listeMessage = new Dictionary<object, string>();
        }

        public AfficheurAide(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            _listeMessage = new Dictionary<object, string>();
        }

        
        public void AddHelpMessage(Control control, string message)
        {
            // enregistrement du message
            _listeMessage[control] = message;
            // abonnement de la méthode affichant l'aide
            control.HelpRequested += Catch_HelpRequested;
        }

        public void Catch_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            string message;
            if (_listeMessage.TryGetValue(sender, out message))
            {
                helpToolTip.Show(message, sender as IWin32Window);
            }
        }
    }
}
