using System;
using System.Linq;


namespace ExtraLex
{
    class SampaValidator
    {

        private string[] DelimeterSymbols;
        private string[] Additionals;

        private string _ErrMsg;

        public string ErrMsg
        {
            get { return _ErrMsg; }
            set { _ErrMsg = value; }
        }


        private bool _ValidationResult;

        public bool ValidationResult
        {
            get { return _ValidationResult; }
            set { _ValidationResult = value; }
        }


        public SampaValidator(string Sampa)
        {

            DelimeterSymbols = new string[] { "-", "~", "$" };

            Additionals = new string[] { "?", "\"", "%" };

            //Tryk på alle vokialer undtagen @ og 6
            //Stød på alle lange vokaler og disse konsonanter

            _ValidationResult = ValidateSAMPA(Sampa);

        }

        private bool ValidateSAMPA(string SWord)
        {
            string[] Sp = new string[] { " " };

            string[] SamArr = SWord.Split(Sp, StringSplitOptions.None);

            for (int i = 0; i <= SamArr.Length - 1; i++)
            {
                string Ph = SamArr[i];

                string PhPlusOne = "";
                if (i < SamArr.Length - 1)
                {
                    PhPlusOne = SamArr[i + 1];
                }

                bool ValidationOK = ValidatePhone(Ph, PhPlusOne);

                if (ValidationOK == false)
                {
                    return false;
                }
            }

            return true;//Hvis alle tests er bestået
        }

        private bool ValidatePhone(string phone, string phonePlusOne)
        {
            //Indeholder phonen (Eller er phonen) en af PhoneSymbols?
            string CleanPhone = phone.Replace("\"", "");
            CleanPhone = CleanPhone.Replace("%", "");
            CleanPhone = CleanPhone.Replace("?", "");

            bool Passed = false;

            if (DelimeterSymbols.Contains(CleanPhone))
            {
                Passed = true;
            }

            //Er Phonen på Vokal og konsonantlisten?
            if (mGeneral.PhonesW.Contains(CleanPhone))
            {
                Passed = true;
            }

            if (mGeneral.PhonesC.Contains(CleanPhone))
            {
                Passed = true;
            }

            //Denne test skal være bestået
            if (Passed == false)
            {
                _ErrMsg = "'" + phone + "' blev ikke genkendt som et validt Sampa-symbol";
                return false;
            }

            //Test igen med hele phonen
            if (DelimeterSymbols.Contains(phone))
            {
                return true;
            }

            //Er Phonen på Vokal og konsonantlisten? Phon er ikke sammensat
            if (mGeneral.PhonesW.Contains(phone))
            {
                return true;
            }

            if (mGeneral.PhonesC.Contains(phone))
            {
                return true;
            }

            //Phonen er ikke på en af listerne - så må den være sammensat

            //Tryk må være på alle vokaler, undtagen @. Tryk skal stå før vokalen f.eks. "y

            if(phone.Contains("\""))
            {
                if (mGeneral.IsWowel(phone) == false)
                {
                    _ErrMsg = "'" + phone + "' konsonanter kan ikke indeholde tryk";
                    return false;
                }
            }


            //Check for @
            switch (phone)
            {
                case "\"@":
                    _ErrMsg = "'" + phone + "' kan ikke indeholde tryk";
                    return false;

                case "@\"":
                    _ErrMsg = "'" + phone + "' har forkert tryk";
                    return false;

            }

            //Check rækkefølge
            //Hovedtryk
            //Dan tmpPhon

            //Check uden stød (?)

            string tmpPhon = phone.Replace("\"", "");
            tmpPhon = tmpPhon.Replace("?", "");

            string CorrectPhone = "\"" + tmpPhon;
            string NonCorrectPhone = tmpPhon + "\"";

            if (CorrectPhone == phone)
            {
                return true;
            }

            if (NonCorrectPhone == phone)
            {
                _ErrMsg = "'" + phone + "' har forkert anbragt tryk";
                return false;
            }

            //Bitryk
            tmpPhon = phone.Replace("%", "");
            tmpPhon = tmpPhon.Replace("?", "");

            CorrectPhone = "%" + tmpPhon;
            NonCorrectPhone = tmpPhon + "%";

            if (CorrectPhone == phone)
            {
                return true;
            }

            if (NonCorrectPhone == phone)
            {
                _ErrMsg = "'" + phone + "' har forkert anbragt tryk";
                return false;
            }

            //Check for @
            switch (CorrectPhone)
            {

                case "%@":
                    _ErrMsg = "'" + phone + "' kan ikke indeholde tryk";
                    return false;

                case "@%":
                    _ErrMsg = "'" + phone + "' har forkert tryk";
                    return false;
            }


            if (phone.Contains("?"))
            {
                if (ValidateStoed(phone))
                {
                    return true;
                }
            }

            if (_ErrMsg != "")
            {
                _ErrMsg = "'" + phone + "' blev ikke genkendt som et validt Sampa-symbol";
            }

            return false;
        }

        private bool ValidateStoed(string phn)
        {
            //Stød: Stødbasis: lang vokal, eller kort vokal + [m n l N D w j]
            //Vokal excl. @ 

            string CleanPhone = phn.Replace("\"", "");
            CleanPhone = CleanPhone.Replace("%", "");

            //Er det @
            string tmpPhn = CleanPhone.Replace("?", "");

            //Check placering
            string IncorrectPhone = "?" + tmpPhn;

            if (CleanPhone==IncorrectPhone)
            {
                _ErrMsg = "'" + phn + "' har forkert anbragt stød";
                return false;
            }

            if (phn.Contains("@"))
            {
                _ErrMsg = "'" + phn + "' kan ikke indeholde stød";
                return false;
            }

            //Er det en lang vokal?
            if (mGeneral.IsWowel(phn))
            {
                if (tmpPhn.Length == 2)
                {
                    return true;
                }

                else
                {
                    _ErrMsg = "'" + phn + "' kan ikke indeholde stød";
                    return false;
                }
            }
            else
            {
                //Er det en af følgende: [m n l N D w j]
                
                string[] StoedCons = new string[] { "m", "n", "l", "N", "D", "w", "j" };

                if (StoedCons.Contains(tmpPhn))
                {
                    return true;
                }
                else
                {
                    _ErrMsg = "'" + phn + "' kan ikke indeholde stød";
                    return false;
                }

            }
        }

    }
}
