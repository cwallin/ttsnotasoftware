using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace TFAReader
{
    class TFAMain
    {
        private List<TFA> _TFAList;
        public List<TFA> TFAList
        {
            get { return _TFAList; }

        }
        public TFAMain(string FileAndPath)
        {
            _TFAList = new List<TFA>();
            ReadTFA(FileAndPath);
        }

        private void ReadTFA(string FName)
        {
            string[] AllLines = File.ReadAllLines(FName, Encoding.Default);

            List<string> Ops = new List<string>();

            foreach (string L in AllLines)
            {
                //Når en linie ender på .lab" skal et nyt TFA object dannes
                //og det opsamlede array sendes til TFA

                if (L.Contains(".lab\""))
                {
                    if (Ops.Count > 0)
                    {
                        TFA T = new TFA(Ops);
                        _TFAList.Add(T);
                        Ops = new List<string>();
                    }
                }

                Ops.Add(L);
            }

            //Den sidste del
            if (Ops.Count > 0)
            {
                TFA T = new TFA(Ops);
                _TFAList.Add(T);
                Ops = new List<string>();
            }
        }

    }
}
