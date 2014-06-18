using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TFAReader
{
    class Phone
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
    }
}
