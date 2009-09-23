using System;

namespace TortoiseIssueList
{
    internal class TicketItem : IComparable
    {
        private readonly int _ticketNumber;
        private readonly string _ticketSummary;
        private readonly string _ticketType;
        private readonly string _ticketContenu;
        private readonly string _ticketLink;

        public TicketItem(int ticketNumber, string ticketType, string ticketSummary, string contenu, string link)
        {
            _ticketNumber = ticketNumber;
            _ticketType = ticketType;
            _ticketSummary = ticketSummary;
            _ticketContenu = contenu;
            _ticketLink = link;
        }
        
        public int Number
        {
            get { return _ticketNumber; }
        }

        public string Summary
        {
            get { return _ticketSummary; }
        }

        public string Type
        {
            get {return _ticketType;}
        }

        public string Contenu
        {
            get { return _ticketContenu; }
        }

        public string Lien
        {
            get { return _ticketLink; }
        }

        public int CompareTo(object obj)
        {
            TicketItem objCompare = obj as TicketItem;

            if (objCompare == null)
                return -1 ;

            return objCompare._ticketNumber - _ticketNumber;
                
        }

        public override bool Equals(object obj)
        {
            return CompareTo(obj)==0;
        }
    }
}