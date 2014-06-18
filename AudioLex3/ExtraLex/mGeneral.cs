using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace ExtraLex
{
    static class mGeneral
    {
        public static string APP_PATH;
        public static string TMP_PATH;
        public static string FILIBUSTER;
        public static string EXTRALEX_LOCATION;

        //Fra LexiconChanger
        public static string MAIN_LEX_PATH;
        public static string NAME_LEX_PATH;
        public static string ENGLISH_LEX_PATH;
        public static string EXTRA_LEX_PATH;
        public static string ACRONYMS_LEX_PATH;
        public static string APROVED_LIST_PATH;

        public static string MAIN_LEX;
        public static string NAME_LEX;
        public static string ENGLISH_LEX;
        public static string EXTRA_LEX;
        public static string ACRONYMS_LEX;
        public static string APROVED_LIST;
        public static string MULTIWORD_LEX;

        public static string CHECK_LIST;
        public static string COMPLETE_LIST;
        public static string CACHED_AUDIO_PATH;

        public static string TEXT_FILTER;

        public static string WISH_APP;

        public static string[] PhonesW = new string[] { "E", "e", "9", "y", "u", "A", "a", "i", "@", "6", "Q", "2", "O", "o", "2:", "i:", "y:", "A:", "e:", "u:", "o:", "a:", "9:", "E:", "Q:", "O:", "e6", "u6", "o6", "26", "E6", "96", "i6", "y6" };
        public static string[] PhonesC = new string[] { "D", "N", "R", "S", "b", "d", "f", "g", "h", "j", "k", "l", "m", "n", "p", "s", "t", "v", "w","r3","T","r0" };

        private static Random Ran;

        public static string CreateID()
        {
            Ran = new Random();

            string Syl1 = "";
            string Syl2 = "";
            string Syl3 = "";

            Syl1 = GetConsonant() + GetVowel();
            Syl2 = GetConsonant() + GetVowel();
            Syl3 = GetConsonant() + GetVowel() + GetConsonant();

            return Syl1 + Syl2 + Syl3;
 
        }

        private static string GetVowel()
        {

            string Letter = "";
            do
            {
                int x = Ran.Next(97, 122);

                Letter = Char.ConvertFromUtf32(x);
            }

            while (IsLetterWovel(Letter) == false);

            return Letter;
        }

        private static string GetConsonant()
        {

            string Letter = "";
            do
            {
                int x = Ran.Next(97, 122);

                Letter = Char.ConvertFromUtf32(x);
            }

            while (IsLetterWovel(Letter));

            return Letter;
        }

        private static bool IsLetterWovel(string s)
        {
            string Vow = "aeiouy";
            if (Vow.Contains(s))
            {
                return true;
            }

            return false;
        }
        public static string PhoneType(string Phone)
        {
            Phone = CleanPhone(Phone);

            if(PhonesW.Contains(Phone))
            {
                return "Wovel";
            }

            if(PhonesC.Contains(Phone))
            {
                return "Consonant";
            }

            return "Unknown";
        }

        public static bool IsWowel(string Phone)
        {
            Phone = CleanPhone(Phone);

            if(PhonesW.Contains(Phone))
            {
                return true;
            }

            return false;
        }

        private static string CleanPhone(string Phone)
        {
            Phone = Phone.Replace("%", "");
            Phone = Phone.Replace("\"", "");
            Phone = Phone.Replace("?", "");

            return Phone;
        }

        public static string GetAttrValueFromNode(XmlNode n, string Att)
        {

            XmlNode tmpAttNode;

            if (n != null)
            {
                if (n.Attributes.GetNamedItem(Att) == null)
                {
                    return "";
                }

                tmpAttNode = n.Attributes.GetNamedItem(Att);
                return tmpAttNode.InnerText;

            }

            return "";
        }
    }
}
