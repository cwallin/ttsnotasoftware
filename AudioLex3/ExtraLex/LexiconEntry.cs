namespace ExtraLex
{
    public class LexiconEntry
    {
        private string _TextWord;

        public string TextWord
        {
            get { return _TextWord; }
            set { _TextWord = value; }
        }

        private string _AudioWord;

        public string AudioWord
        {
            get { return _AudioWord; }
            set { _AudioWord = value; }
        }

        private string _Grammar;

        public string Grammar
        {
            get { return _Grammar; }
            set { _Grammar = value; }
        }

        private string _LexiType;

        public string LexiconType
        {
            get { return _LexiType; }
            set { _LexiType = value; }
        }

        private string[] _TheRest;

        public string[] TheRest
        {
            get { return _TheRest; }
            set { _TheRest = value; }
        }
    }
}
