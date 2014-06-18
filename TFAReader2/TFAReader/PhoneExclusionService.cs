using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TFAReader
{
    class PhoneExclusionService
    {
        private bool _hit;

        public PhoneExclusionService(string[] StringToCheck)
        {
            string SearchFor="[\"%]a6.|a6.";
            Regex RE = new Regex(SearchFor, RegexOptions.Singleline);

            foreach(string s in StringToCheck)
            {

                Match M = RE.Match(s);
                if(M.Success)
                {
                    _hit = true;
                    return;
                }
            }
        }

        public bool Hit{get { return _hit; }}
    }
}
