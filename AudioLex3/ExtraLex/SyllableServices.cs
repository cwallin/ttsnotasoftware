using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExtraLex
{
    class SyllableServices
    {
        public SyllableServices(string Syllable, int SyllableCount)
        {
            string[] Spc = new string[] { " " };
            string[] Phones = Syllable.Split(Spc, StringSplitOptions.RemoveEmptyEntries);

            string SyllableNumber = SyllableCount.ToString();
            string SyllableCountList = "";
            string SyllableDescriptionList = "";

            int SyllableLength = Phones.Count();

            bool NucleusFound = false;

            //Den første vokal der findes er altid "nukleus", efterfølgende vokaler markeres også som nukleus
            //Konsonanter før nukleus markeres "onset"
            //Konsonanter efter nukleus markeres "coda"

            for (int i = 0; i <= Phones.Count() - 1; i++)
            {
                string Phone = Phones[i];

                SyllableCountList = SyllableCountList + SyllableNumber + "_"; //Husk at fjerne det sidste "_"

                string SyllableDescription;//den enkelte stavelsesbeskrivelse: o, n eller c

                if (mGeneral.IsWowel(Phone))
                {
                    NucleusFound = true;

                    SyllableDescription = "n";

                }
                else
                {
                    //Det er en konsontant - er det onset eller coda
                    if (NucleusFound)//Så er det coda
                    {
                        SyllableDescription = "c";
                    }
                    else
                    {
                        //Så er det onset
                        SyllableDescription = "o";
                    }
                }

                SyllableDescriptionList = SyllableDescriptionList + SyllableDescription + "_";

            }
            if (SyllableCountList.Length > 0)
            {
                _SyllableNumberList = SyllableCountList.Substring(0, SyllableCountList.Length - 1);
                _SyllablePositionList = SyllableDescriptionList.Substring(0, SyllableDescriptionList.Length - 1);
            }
        }

        private string _SyllablePositionList;

        public string SyllablePositionList
        {
            get { return _SyllablePositionList; }
            set { _SyllablePositionList = value; }
        }


        private string _SyllableNumberList;

        public string SyllableNumberList
        {
            get { return _SyllableNumberList; }
            set { _SyllableNumberList = value; }
        }

        private string _ErrMsg = "";

        public string ErrMsg
        {
            get { return _ErrMsg = ""; }
            set { _ErrMsg = value; }
        }

    }
}
