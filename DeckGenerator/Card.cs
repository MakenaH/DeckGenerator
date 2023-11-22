using System;
using System.Collections.Generic;
using System.Text;

namespace DeckGenerator
{
    internal class Card
    {
        private string _name;
        private string _description;
        public bool _drawn;
        public bool _continue;

        public Card(bool continue_,string name_, string description_)
        {
            _name = name_;
            _description = description_;
            _drawn = false;
            _continue = continue_;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
    }
}
