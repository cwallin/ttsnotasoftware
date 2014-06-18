using System;
using System.Xml;

namespace ExtraLex
{
    internal class SSMLServices
    {

        private string _ErrMsg="";
        private XmlDocument _SpeakDoc;

        public string ErrMsg
        {
            get { return _ErrMsg; }
            set { _ErrMsg = value; }
        }

        private string _SSML;

        public string SSML
        {
            get { return _SSML; }
            set { _SSML = value; }
        }


        public SSMLServices(string TextWord, string SAMPA, string POS, string Language, string Spelling, string Stress,bool ValidationOnly)
        {

            SampaValidator SV = new SampaValidator(SAMPA);

            if (SV.ValidationResult == false)
            {
                //Hvis fejlmeddelelse
                _ErrMsg = SV.ErrMsg;
                return;
            }

            if(ValidationOnly)
            {
                return;
            }

            string Syllables = CreateSyllables(SAMPA);

            SAMPA = SAMPA.Replace("~", "$");

            if(Syllables!="")
            {
                CreateSSML(TextWord, SAMPA,Syllables,Language,Spelling,POS, Stress);
            }
            else
            {
                _ErrMsg = "problem";
            }

        }

        private void CreateSSML(string Text, string Sampa, string Syllables, string Lang, string Spell, string Pos, string Stress)
        {
            _SpeakDoc = new XmlDocument();
            _SpeakDoc.LoadXml("<speak></speak>");

            XmlNode DocRoot = _SpeakDoc.DocumentElement;

            XmlNode phoneme = _SpeakDoc.CreateNode(XmlNodeType.Element, "phoneme", "");

            string info = Syllables + " " + Lang + " " + Spell + " " + Pos + " " + Stress;

            string AttName = "info";
            AddAttribute(ref phoneme,ref AttName,ref info);

            string AttVal = "SAMPA";
            AttName = "alphabet";
            AddAttribute(ref phoneme, ref AttName, ref AttVal);

            string SampaVal = Sampa;//ExemalizeSampa(Sampa);
            AttName = "ph";
            AddAttribute(ref phoneme,ref AttName,ref SampaVal);

            phoneme.InnerText = Text;

            DocRoot.AppendChild(phoneme);

            _SSML = DocRoot.InnerXml;

        }
        
        private string ExemalizeSampa(string Smpa)
        {
            Smpa = Smpa.Replace("\"", "&quot;");

            return Smpa;
        }

        private string CreateSyllables(string SAMPA)
        {
            //tankestrger og tilder skal midlertidigt erstattes af $
            SAMPA = SAMPA.Replace("-", "$");
            SAMPA = SAMPA.Replace("~", "$");

            //Validering gik godt, nu skal Sampa behandles:

            //Dan et array på basis af "$"

            string[] Sep = new string[] { "$" };

            string[] Syllables = SAMPA.Split(Sep, StringSplitOptions.None);

            int Counter = 0;

            string SyllableNumbers = "";
            string SyllablePositions = "";

            foreach (string Syl in Syllables)
            {
                SyllableServices Sys = new SyllableServices(Syl, Counter);

                SyllableNumbers = SyllableNumbers + Sys.SyllableNumberList + "_";
                SyllablePositions = SyllablePositions + Sys.SyllablePositionList + "_";

                Counter += 1;

            }

            SyllableNumbers = SyllableNumbers.Substring(0, SyllableNumbers.Length - 1);
            SyllablePositions = SyllablePositions.Substring(0, SyllablePositions.Length - 1);

            return SyllableNumbers + " " + SyllablePositions;
        }

        private void AddAttribute(ref System.Xml.XmlNode n, ref string att, ref string AttText)
        {
            if (string.IsNullOrEmpty(AttText))
            {
                System.Xml.XmlNamedNodeMap objAttributes = n.Attributes;
                objAttributes.RemoveNamedItem(att);
                return;
            }

            System.Xml.XmlAttribute NewAttr = _SpeakDoc.CreateAttribute(att);
            NewAttr.Value = AttText;
            n.Attributes.SetNamedItem(NewAttr);

        }

    }
}