using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TFAReader
{
    class Word
    {
        private string _StartTime;
        public string StartTime
        {
            get { return _StartTime; }
            set { _StartTime = value; }
        }

        private string _EndTime;
        public string EndTime
        {
            get { return _EndTime; }
            set { _EndTime = value; }
        }

        private string _Content;
        public string Content
        {
            get { return _Content; }
            set { _Content = value; }
        }

        private List<Phone> _PhoneList;
        public List<Phone> PhoneList
        {
            get { return _PhoneList; }
            set { _PhoneList = value; }
        }

        private PhoneInfo _Info;
        public PhoneInfo Info//Kun 1 pr. word
        {
            get { return _Info; }
            set { _Info = value; }
        }

        public bool IsTouched { get; set; }
    }
}
