using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ExtraLex
{
    class AcronymFactory
    {
        private string _ErrMsg = "";
        public string ErrMsg
        {
            get { return _ErrMsg; }
            set { _ErrMsg = value; }
        }

        private string _SAMPAAcronym;

        public string SAMPAAcronym
        {
            get { return _SAMPAAcronym; }
            set { _SAMPAAcronym = value; }
        }
        

        public AcronymFactory(string ACR)
        {
            //Åbn alfabetfil
            string[] Alfa;
            Dictionary<string, string> Alphabet=new Dictionary<string, string>();

            string[] Tab= new string[]{"\t"};

            if(File.Exists(mGeneral.APP_PATH + "\\Alphabet.txt"))
            {
                Alfa = File.ReadAllLines(mGeneral.APP_PATH + "\\Alphabet.txt",Encoding.Default);
            }
            else
            {
                _ErrMsg = mGeneral.APP_PATH + "\\Alphabet.txt blev ikke fundet";
                return;
            }

            foreach(string L in Alfa)
            {
                string[] A = L.Split(Tab, StringSplitOptions.None);
                Alphabet.Add(A[0],A[1]);
            }

            string AudioACR = "";

            for(int i=0;i<ACR.Length;i++)
            {
                string B = ACR.Substring(i, 1);

                //Find lydskrift
                if(Alphabet.ContainsKey(B))
                {
                    string Audio = Alphabet[B];

                    AudioACR = AudioACR + Audio + " $ ";
                }
            }

            if (AudioACR.Length > 3)
            {
                AudioACR = AudioACR.Substring(0, AudioACR.Length - 3);
            }

            _SAMPAAcronym = AudioACR;
        }
    }
}
