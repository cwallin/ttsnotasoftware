using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TFAReader
{
    class TFA
    {
        private string[] Sep = new string[] { " " };
        private List<Phone> TmpPhoneList = null;

        public TFA(List<string> TFALines)
        {
            int CollectionMode = 0;//0=LabMode, 1=OrdMode, 2=InfoMode

            Word W;
            Phone P;
            PhoneInfo PI;

            _WordList = new List<Word>();
            _InfoList=new List<PhoneInfo>();

            //Kør linier igennem og analysér
            //Først opsamles alle phoner i en liste af phones
            //Derefter sættes de sammen med de rigtige words

            foreach (string L in TFALines)
            {
                if (L.Contains(".lab\""))//Sætter processen i gang og sender hvad der allerede findes
                {
                    LabPath = L;

                    W = new Word();

                    TmpPhoneList = new List<Phone>();

                    ////Test
                    //if (L.Contains("sn0145/sent013"))
                    //{
                    //    string x = "gf";
                    //}
                    //_TFAName = L;
                    //_TFAPath = L;

                }

                else if (L.Contains(".ord\""))
                {
                    CollectionMode = 1;
                    WordPath = L;
                }

                else if (L.Contains(".info\""))
                {
                    CollectionMode = 2;
                    InfoPath = L;
                }


                switch (CollectionMode)
                {
                    case 0:
                        P = GetPhone(L);
                        if (P != null)
                        {
                            TmpPhoneList.Add(P);
                        }

                        break;

                    case 1:
                        W = GetWord(L);

                        //if (L.Contains("drik"))
                        //{
                        //    string x = "x";
                        //}

                        if (W != null)
                        {
                            //Find korresponderende phoner
                            W.PhoneList = GetPhones(W.StartTime, W.EndTime);
                            _WordList.Add(W);

                        }


                        break;

                    case 2:
                        PhoneInfo PhInf = GetPhoneInfo(L);

                        if(PhInf!=null)
                        {
                            //Find korresponderende Word
                            if(MatchWithWord(PhInf)==false)
                            {
                                //Alarm
                                MessageBox.Show("ALARM!!", "ALARM!!!");
                            }
                            //_InfoList.Add(PhInf);
                        }
                       
                        break;
                }


            }
        }

        private bool MatchWithWord(PhoneInfo p)
        {
            foreach(Word w in _WordList)
            {
                if(w.StartTime == p.StartTime)
                {
                    if(w.EndTime==p.EndTime)
                    {
                        w.Info = p;
                        return true;
                    }
                }
            }

            return false;//Må helst ikke ske
        }

        private PhoneInfo GetPhoneInfo(string Info)
        {
            string[] PhArr = Info.Split(Sep, StringSplitOptions.None);

            if (PhArr.Length > 2)
            {
                PhoneInfo PI = new PhoneInfo();
                PI.StartTime = PhArr[0];
                PI.EndTime = PhArr[1];

                string TheRest = "";
                for(int i=2;i<PhArr.Length;i++)
                {
                    TheRest = TheRest + PhArr[i] + " ";
                }

                PI.Content = TheRest.Trim();

                return PI;
            }

            return null;
        }

        private List<Phone> GetPhones(string StartT, string EndT)
        {
            List<Phone> Retlist = new List<Phone>();
            bool AddMode = false;

            foreach (Phone p in TmpPhoneList)
            {
                if (StartT == p.StartTime)
                {
                    AddMode = true;
                }
                else if (EndT == p.EndTime)
                {
                    Retlist.Add(p);
                    return Retlist;
                }

                if (AddMode)
                {
                    Retlist.Add(p);

                    //Start og End kan være det samme i et phon object
                    if (EndT == p.EndTime)
                    {
                        return Retlist;
                    }
                }
            }

            return null;
        }

        private Word GetWord(string word)
        {
            string[] PhArr = word.Split(Sep, StringSplitOptions.None);

            if (PhArr.Length == 3)
            {
                Word Wrd = new Word();
                Wrd.StartTime = PhArr[0];
                Wrd.EndTime = PhArr[1];
                Wrd.Content = PhArr[2];

                return Wrd;
            }

            return null;
        }

        private Phone GetPhone(string pho)
        {

            string[] PhArr = pho.Split(Sep, StringSplitOptions.None);

            if (PhArr.Length > 2)
            {
                Phone Ph = new Phone();
                Ph.StartTime = PhArr[0];
                Ph.EndTime = PhArr[1];
                Ph.Content = PhArr[2];

                return Ph;
            }

            return null;

        }

        private List<Word> _WordList;
        public List<Word> WordList
        {
            get { return _WordList; }
        }

        private List<PhoneInfo> _InfoList;
        public List<PhoneInfo> InfoList
        {
            get { return _InfoList; }
        }

        public string InfoPath { get; set; }
        public string WordPath { get; set; }
        public string LabPath { get; set; }
        public bool isChanged { get; set; }

    }
}
