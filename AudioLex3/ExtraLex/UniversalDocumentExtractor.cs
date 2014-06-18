using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

namespace ExtraLex
{
    class UniversalDocumentExtractor
    {
        private List<string> _UnreferencedWords;

        string[] _Delimeters = new string[] { "\"", ". ", ",", "!", "?", "-", ";", "«", "»", ":", "–", "(", ")", "/", " ", "&amp;" };

        private List<string> _WordList;
        public List<string> WordList
        {
            get { return _WordList; }
            set { _WordList = value; }
        }

        public UniversalDocumentExtractor(string[] Docs)
        {
            //Åbn filen

                _WordList = new List<string>();
                _UnreferencedWords = new List<string>();

            foreach(string Doc in Docs)
            {
                
                string[] AllLines = File.ReadAllLines(Doc);

                Regex Rgx = new Regex("<.+?>");

                foreach (string Ln in AllLines)
                {
                    //Hvis det er xml eller html skal tags ud af hver linie

                    string L = Rgx.Replace(Ln, "");

                    L = L.Trim();

                    if (L != "")
                    {
                        if (L.Length > 1)
                        {
                            TextAnalyzer(L);
                        }

                    }
                }
            }
        }

        public UniversalDocumentExtractor(string Doc)
        {
            //Åbn filen
            if (File.Exists(Doc))
            {
                _WordList = new List<string>();
                _UnreferencedWords = new List<string>();

                string[] AllLines = File.ReadAllLines(Doc);

                Regex Rgx = new Regex("<.+?>");

                foreach (string Ln in AllLines)
                {
                    //Hvis det er xml eller html skal tags ud af hver linie

                    string L = Rgx.Replace(Ln, "");

                    L = L.Trim();

                    if (L != "")
                    {
                        if (L.Length > 1)
                        {
                            TextAnalyzer(L);
                        }

                    }
                }
            }
        }

        private bool CheckPreviousOccurances(string W)
        {
            if (_UnreferencedWords.Contains(W.ToLower()))
            {
                return true;
            }
            else
            {
                _UnreferencedWords.Add(W.ToLower());
                return false;
            }
        }

        private bool IsNumeric(string S)
        {
            int Num;

            S = S.Replace(".", "");
            S = S.Replace(",", "");

            bool Succes = int.TryParse(S, out  Num);

            return Succes;
        }

        private void TextAnalyzer(string s)
        {
            string[] Words = s.Split(_Delimeters, StringSplitOptions.RemoveEmptyEntries);

            foreach (string Word in Words)
            {
                string Wrd = Word.Trim();

                if (Wrd.EndsWith("."))
                {
                    Wrd = Wrd.Substring(0, Wrd.Length - 1);
                }

                if (Wrd.Length > 1)
                {
                    if (IsNumeric(Wrd) == false)
                    {
                        if (Wrd.Contains("@") == false)
                        {
                            //Check om det allerede er brugt
                            if (CheckPreviousOccurances(Wrd) == false)
                            {
                                _WordList.Add(Wrd + "\t" + s);

                            }
                        }
                    }
                }
            }
        }
    }
}
