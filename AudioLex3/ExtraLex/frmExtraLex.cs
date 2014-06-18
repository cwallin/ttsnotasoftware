using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace ExtraLex
{
    public partial class frmExtraLex : Form
    {

        private List<LexiconEntry> _Lexicon;
        private int AcceptCount;

        private int _UnKnownCounter;

        private List<string> _UnknownWords;

        private string _AproveList;

        private string _CurrentAudioID;

        private bool _ListWithIDs;

        public frmExtraLex()
        {
            InitializeComponent();
        }


        private void btnPlay_Click(object sender, EventArgs e)
        {
            PlaySampa(0);
            txtSampa.Focus();
        }

        private void btnListenSugg_Click(object sender, EventArgs e)
        {
            PlaySampa(1);
            txtSuggestion.Focus();
        }

        private void PlaySampa(int SAMPAMode)
        {
            //SAMPAmode: 0=sampa, 1=suggestion
            string TextWord = cmbWords.Text;
            string Pos = cmbPos.Text;
            string Lang = cmbLanguage.Text;
            string Spell = cmbSpell.Text;
            string Stress = cmbStress.Text;
            string SampaWord = "";

            if(SAMPAMode==0)
            {
                SampaWord = txtSampa.Text.Trim();    
            }
            else
            {
                SampaWord = txtSuggestion.Text.Trim();    
            }

            if (TextWord == "")
            {
                MessageBox.Show("Udfyld ord", "Afspil SAMPA", MessageBoxButtons.OK);
                return;
            }

            if (SampaWord == "")
            {
                MessageBox.Show("Udfyld SAMPA", "Afspil SAMPA", MessageBoxButtons.OK);
                return;
            }

            if (Pos == "")
            {
                MessageBox.Show("Udfyld POS", "Afspil SAMPA", MessageBoxButtons.OK);
                return;
            }
            else
            {
                Pos = getPosCode(Pos);
            }

            if (Lang == "")
            {
                MessageBox.Show("Udfyld Language", "Afspil SAMPA", MessageBoxButtons.OK);
                return;
            }

            if (Spell == "")
            {
                MessageBox.Show("Udfyld Spelling", "Afspil SAMPA", MessageBoxButtons.OK);
                return;
            }

            if (Stress == "")
            {
                MessageBox.Show("Udfyld Stress", "Afspil SAMPA", MessageBoxButtons.OK);
                return;
            }

            SSMLServices SML = new SSMLServices(TextWord, SampaWord, Pos, Lang, Spell, Stress, false);

            if (SML.ErrMsg != "")
            {
                MessageBox.Show(SML.ErrMsg, "Valideringsfejl");
                return;
            }

            string SSML = SML.SSML;

            txtSSML.Text = SSML;

            //Skriv SSML til fil og afspil denne
            //skriv til fast-navngivet fil
            File.WriteAllText(mGeneral.APP_PATH + "\\tmp.txt", SSML);

            ExecuteCmdLine(mGeneral.FILIBUSTER, mGeneral.APP_PATH + "\\tmp.txt", mGeneral.TMP_PATH);

            //afspil lyden
            if (File.Exists(mGeneral.TMP_PATH + "\\sent001.wav"))
            {
                SoundPlayer SP = new SoundPlayer(mGeneral.TMP_PATH + "\\sent001.wav");
                SP.Play();
            }
            else
            {
                MessageBox.Show("Der er ikke dannet en lydfil til afspilning");
            }
        }

        private void ExecuteCmdLine(string FilibusterLocation, string inputFile, string outputDir)
        {
            string anf = "\"";


            //Slet Outputdir
            DirectoryInfo D = new DirectoryInfo(outputDir);

            FileInfo[] fi = D.GetFiles();

            foreach (FileInfo f in fi)
            {
                f.Delete();
            }

            string CmdLine = anf + FilibusterLocation + anf + " -lang da -mode batch -textfile " + anf + inputFile + anf + " -outdir " + anf + outputDir + anf + " -rate 22050 -print_header DURATION";

            ProcessStartInfo PSI = new ProcessStartInfo(mGeneral.WISH_APP);
            PSI.Arguments = CmdLine;
            PSI.UseShellExecute = false;
            PSI.CreateNoWindow = true;
            //PSI.RedirectStandardError = true;
            //PSI.RedirectStandardOutput = true;

            Process P = new Process();
            P.StartInfo = PSI;
            P.Start();
            P.WaitForExit();

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if(txtSampa.Text!="")
            {
                InsertInDict(0);  
            }
            else if(txtSuggestion.Text!="")
            {
                InsertInDict(1);
                txtSuggestion.Text = "";
            }
            
        }

        private void InsertInDict(int SampaMode)
        {
            //SampaMode: 0=Sampa, 1=suggestion

            bool ToAcronym = false;

            string TextWord = cmbWords.Text;
            string Pos = cmbPos.Text;
            string Lang = cmbLanguage.Text;

            string SampaWord = "";

            if(SampaMode==0)
            {
                SampaWord = txtSampa.Text; 
            }
            else
            {
                SampaWord = txtSuggestion.Text; 
            }

            if (TextWord == "")
            {
                MessageBox.Show("Udfyld ord", "Afspil SAMPA", MessageBoxButtons.OK);
                return;
            }

            if (SampaWord == "")
            {
                MessageBox.Show("Udfyld SAMPA", "Afspil SAMPA", MessageBoxButtons.OK);
                return;
            }
            else
            {
                SampaWord = SampaWord.Trim();
            }

            if (Pos == "")
            {
                MessageBox.Show("Udfyld POS", "Afspil SAMPA", MessageBoxButtons.OK);
                return;
            }
            else
            {
                Pos = getPosCode(Pos);
                Pos = Pos.Replace("_", " ");

                if (Pos == "ACR NOM")
                {
                    ToAcronym = true;
                }
            }

            if (Lang == "")
            {
                MessageBox.Show("Udfyld Language", "Afspil SAMPA", MessageBoxButtons.OK);
                return;
            }

            //Komponér linie til ExtraLex
            string language = "dan";

            if (Lang == "da")
            {
                language = "dan";
            }

            if (Lang == "en")
            {
                language = "eng";
            }

            SSMLServices SML = new SSMLServices(TextWord, SampaWord, Pos, Lang, "", "", true);//For at validere SAMPA

            if (SML.ErrMsg != "")
            {
                MessageBox.Show(SML.ErrMsg, "Valideringsfejl");
                return;
            }

            string ExtraLine;

            if (ToAcronym)
            {
                ExtraLine = TextWord + "\t" + SampaWord + "\t" + Pos;
            }
            else
            {
                ExtraLine = TextWord + "\t" + SampaWord + "\t" + Pos + "\t" + language;
            }

            string[] FileLine = new string[] { ExtraLine };

            if (ToAcronym)
            {
                File.AppendAllLines(mGeneral.ACRONYMS_LEX_PATH + "\\" + mGeneral.ACRONYMS_LEX, FileLine, Encoding.Default);
            }
            else
            {
                File.AppendAllLines(mGeneral.EXTRALEX_LOCATION + "\\danDictExtra.lex", FileLine, Encoding.Default);
            }

            //Læg i _Lexicon
            LexiconEntry LE = new LexiconEntry();

            LE.TextWord = TextWord;
            LE.AudioWord = SampaWord;
            LE.Grammar = Pos;
            LE.LexiconType = "Nyt";

            _Lexicon.Add(LE);


            if (chkKeepText.Checked == false)
            {
                RemoveWord();
                txtSSML.Text = "";
                txtSampa.Text = "";
                //cmbWords.Text = "";
                cmbPos.Text = "";
                cmbSpell.Text = "0";
                AcceptCount = 0;

                btnInsert.UseVisualStyleBackColor = true;


            }
            else
            {
                AcceptCount += 1;

                if (AcceptCount == 1)
                {
                    btnInsert.BackColor = Color.Orange;
                }
                else if (AcceptCount == 2)
                {
                    btnInsert.BackColor = Color.Red;
                }

                else
                {
                    btnInsert.BackColor = Color.ForestGreen;
                }
            }
        }

        private string getPosCode(string FullName)
        {
            string[] Sep = new string[] { " - " };
            string[] Arr = FullName.Split(Sep, StringSplitOptions.None);

            return Arr[0];

        }

        private void cmbPos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string CmbValue = cmbPos.Text;

            switch (CmbValue)
            {
                case "KN":
                    cmbStress.Text = "0";
                    break;

                case "AB":
                    cmbStress.Text = "0";
                    break;

                case "IN":
                    cmbStress.Text = "0";
                    break;
            }

        }

        private void ReadLexicon(string PathAndFile, string LexiName)
        {

            string[] Tab = new string[] { "\t" };
            string[] Lex = File.ReadAllLines(PathAndFile, Encoding.Default);

            foreach (string s in Lex)
            {
                string sx = s;

                if (sx != "")
                {
                    if (sx.StartsWith("#") == false)
                    {
                        if (LexiName == "Whitelist")
                        {
                            sx = sx + "\t\t";
                        }

                        string[] Elements = sx.Split(Tab, StringSplitOptions.None);

                        LexiconEntry LE = new LexiconEntry();

                        LE.TextWord = Elements[0];
                        LE.AudioWord = Elements[1];
                        LE.Grammar = Elements[2];
                        LE.LexiconType = LexiName;

                        string[] tmpArr = new string[Elements.Length - 3];

                        for (int i = 0; i <= Elements.Length - 4; i++)
                        {
                            tmpArr[i] = Elements[i + 3];

                        }

                        LE.TheRest = tmpArr;

                        _Lexicon.Add(LE);
                    }
                }
            }
        }

        private void ReadTextFilter()
        {
            XmlDocument TxF;

            string LexiName = "TextFilter";

            string[] Tab = new string[] { "\t" };

            if (File.Exists(mGeneral.TEXT_FILTER))
            {
                TxF = new XmlDocument();

                try
                {
                    TxF.Load(mGeneral.TEXT_FILTER);
                }
                catch (XmlException ex)
                {
                    MessageBox.Show(mGeneral.TEXT_FILTER + " kunne ikke åbnes: " + ex.Message, "textFilter");
                    return;
                }

                XmlNode Root = TxF.DocumentElement;
                XmlNodeList SearchFields = Root.SelectNodes("textfilters/expression/search");

                if(SearchFields.Count>0)
                {
                    foreach(XmlNode n in SearchFields)
                    {
                        string s = n.InnerText;
                        s = s + "\t\t";

                        string[] Elements = s.Split(Tab, StringSplitOptions.None);

                        LexiconEntry LE = new LexiconEntry();

                        LE.TextWord = Elements[0];
                        LE.AudioWord = Elements[1];
                        LE.Grammar = Elements[2];
                        LE.LexiconType = LexiName;

                        string[] tmpArr = new string[Elements.Length - 3];

                        for (int i = 0; i <= Elements.Length - 4; i++)
                        {
                            tmpArr[i] = Elements[i + 3];

                        }

                        LE.TheRest = tmpArr;

                        _Lexicon.Add(LE);
                    }
                }
            }
        }

        private void frmExtraLex_Shown(object sender, EventArgs e)
        {
            //Læs ordbøger
            _Lexicon = new List<LexiconEntry>();

            lblInfo.Text = "Indlæser " + mGeneral.MAIN_LEX;
            Application.DoEvents();
            string MainLexicon = mGeneral.MAIN_LEX_PATH + "\\" + mGeneral.MAIN_LEX;
            ReadLexicon(MainLexicon, "Main");

            lblInfo.Text = "Indlæser " + mGeneral.NAME_LEX;
            Application.DoEvents();
            string NameLexicon = mGeneral.NAME_LEX_PATH + "\\" + mGeneral.NAME_LEX;
            ReadLexicon(NameLexicon, "Name");

            lblInfo.Text = "Indlæser " + mGeneral.ENGLISH_LEX;
            Application.DoEvents();
            string EngLexicon = mGeneral.ENGLISH_LEX_PATH + "\\" + mGeneral.ENGLISH_LEX;
            ReadLexicon(EngLexicon, "English");

            lblInfo.Text = "Indlæser " + mGeneral.EXTRA_LEX_PATH + "\\" + mGeneral.EXTRA_LEX + "\n";
            Application.DoEvents();
            string ExtraLexicon = mGeneral.EXTRA_LEX_PATH + "\\" + mGeneral.EXTRA_LEX;
            ReadLexicon(ExtraLexicon, "Extra");

            lblInfo.Text = "Indlæser " + mGeneral.APROVED_LIST_PATH + "\\" + mGeneral.APROVED_LIST + "\n";
            Application.DoEvents();
            string AprLst = mGeneral.APROVED_LIST_PATH + "\\" + mGeneral.APROVED_LIST;
            ReadLexicon(AprLst, "Whitelist");

            lblInfo.Text = "Indlæser " + mGeneral.ACRONYMS_LEX_PATH + "\\" + mGeneral.ACRONYMS_LEX + "\n";
            Application.DoEvents();
            string AcroLexicon = mGeneral.ACRONYMS_LEX_PATH + "\\" + mGeneral.ACRONYMS_LEX;
            ReadLexicon(AcroLexicon, "Acronyms");

            lblInfo.Text = "Indlæser " + mGeneral.TEXT_FILTER + "\n";
            Application.DoEvents();
            ReadTextFilter();

            lblInfo.Text = "";

            btnFind.Enabled = true;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            FindInDict();
        }

        private void FindInDict()
        {
            frmDictionary Dict = new frmDictionary();

            Point P = btnFind.Location;

            LexiconEntry Lex = Dict.LoadAndReturn(cmbWords.Text, _Lexicon,P);

            if (Lex != null)
            {
                txtSampa.Text = txtSampa.Text + Lex.AudioWord;
                txtSampa.Focus();
                txtSampa.SelectionLength = 0;
            }
        }

        private void OpenDocAndCreateList(bool WithID)
        {
            _ListWithIDs = WithID;

            OpenFileDialog OFD = new OpenFileDialog();

            OFD.Multiselect = true;

            if (OFD.ShowDialog() == DialogResult.OK)
            {

                UniversalDocumentExtractor UDE;

                if (OFD.FileNames.Length > 1)//Flere filer er valgt
                {
                    string[] FNames = OFD.FileNames;
                    UDE = new UniversalDocumentExtractor(FNames);
                }
                else
                {
                    string FileName = OFD.FileName;
                    UDE = new UniversalDocumentExtractor(FileName);
                }

                if (UDE.WordList.Count > 0)
                {
                    List<string> RawWordList = UDE.WordList;

                    //Dan ordlisten
                    _UnknownWords = new List<string>();
                    CreateUnknownWordsList(RawWordList, WithID);

                    lblInfo.Text = _UnknownWords.Count.ToString() + " ukendte ord blev fundet";
                    Application.DoEvents();
                }
            }
        }

        private void CreateUnknownWordsList(List<string> RawList, bool CreateID)
        {
            string[] Tab = new string[] { "\t" };
            string AllWords = RawList.Count.ToString();

            foreach (string WAndC in RawList)
            {
                _UnKnownCounter += 1;

                string UKCount = _UnKnownCounter.ToString();

                lblInfo.Text = "Checker " + UKCount + " af ialt " + AllWords + " ord";
                Application.DoEvents();

                //Dan 4 former og check hver af dem
                string[] Warr = WAndC.Split(Tab, StringSplitOptions.None);

                string[] Wordcases = CreateCases(Warr[0]);

                bool WordFound = false;

                foreach (string WC in Wordcases)
                {
                    if (WC != "")
                    {

                        if (FindEntries(WC) == true)
                        {
                            WordFound = true;
                            break;
                        }

                    }
                }

                if (WordFound == false)
                {
                    if (CreateID)
                    {
                        string WordID = mGeneral.CreateID();
                        _UnknownWords.Add(WAndC + "\t" + WordID + "_" + _UnKnownCounter.ToString());
                    }
                    else
                    {
                        _UnknownWords.Add(WAndC);
                    }

                }

            }

            //Gem fil
            File.WriteAllLines(mGeneral.COMPLETE_LIST, _UnknownWords, Encoding.Default);

            chkCashed.Checked = CreateID;
        }

        private void CreateUnknownListFromFile()
        {
            if (File.Exists(mGeneral.COMPLETE_LIST))
            {
                string[] AllLines = File.ReadAllLines(mGeneral.COMPLETE_LIST, Encoding.Default);
                _UnknownWords = AllLines.ToList();

                //Check om der er tabs i
                string FirstLine = _UnknownWords[0];

                if(FirstLine.Contains("\t"))
                {
                    _ListWithIDs = true;
                }

                MessageBox.Show("Liste dannet");
            }
            else
            {
                MessageBox.Show(mGeneral.COMPLETE_LIST + " kunne ikke findes");
            }
        }

        private bool FindEntries(string SearchForWord)
        {
            SearchForWord = SearchForWord.Replace("[", "");
            SearchForWord = SearchForWord.Replace("]", "");

            int _ListCounter = 0;


            for (int i = _ListCounter; i < _Lexicon.Count; i++)
            {

                LexiconEntry LE = _Lexicon[i];

                _ListCounter += 1;

                if (LE.TextWord == SearchForWord)
                {
                    return true;
                }

            }

            return false;
        }

        private string[] CreateCases(string W)
        {
            string[] Cases = new string[4];

            Cases[0] = W.ToLower();

            if (Cases[0] == W)//For hastighedens skyld
            {
                Cases[1] = "";
                Cases[2] = "";
                Cases[3] = "";
            }
            else
            {
                Cases[1] = W.ToUpper();

                string FirstChar = W.Substring(0, 1).ToUpper();
                string TheRest = W.Substring(1).ToLower();

                Cases[2] = FirstChar + TheRest;

                bool Use3 = false;

                foreach (string tmp in Cases)
                {
                    if (tmp == W)
                    {
                        Use3 = true;
                    }
                }

                if (Use3)
                {
                    Cases[3] = "";
                }
                else
                {
                    Cases[3] = W;
                }
            }

            return Cases;
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            GetFirstWordFromList();
        }

        private void GetFirstWordFromList()
        {
            string[] Del = new string[] { "\t" };

            if (chkAudio.Checked)
            {
                if (_ListWithIDs)
                {
                    string Ln = _UnknownWords[0];

                    string[] Ln2 = Ln.Split(Del, StringSplitOptions.None);

                    string W = Ln2[0];
                    string WName = Ln2[2];
                    string Context = Ln2[1];

                    _CurrentAudioID = WName;

                    cmbWords.Text = W;

                    txtContext.Text = Context;

                    if (File.Exists(mGeneral.CACHED_AUDIO_PATH + "\\" + WName + ".wav"))
                    {
                        SoundPlayer SP = new SoundPlayer(mGeneral.CACHED_AUDIO_PATH + "\\" + WName + ".wav");
                        SP.Play();
                    }
                    else
                    {
                        MessageBox.Show(mGeneral.CACHED_AUDIO_PATH + "\\" + WName + ".wav kunne ikke findes");
                    }
                }
                else
                {      
                    string SSML = CreateFilibusterSSML(cmbWords.Text);
                    PlaySSML(SSML);
                }

            }
        }

        private void PlaySSML(string SSML)
        {
            File.WriteAllText(mGeneral.APP_PATH + "\\tmp.txt", SSML);

            ExecuteCmdLine(mGeneral.FILIBUSTER, mGeneral.APP_PATH + "\\tmp.txt", mGeneral.TMP_PATH);

            //afspil lyden
            if (File.Exists(mGeneral.TMP_PATH + "\\sent001.wav"))
            {
                SoundPlayer SP = new SoundPlayer(mGeneral.TMP_PATH + "\\sent001.wav");
                SP.Play();
            }
            else
            {
                MessageBox.Show("Der er ikke dannet en lydfil til afspilning");
            }
        }

        private string CreateFilibusterSSML(string W)
        {
            string anf = "\"";

            string Perlpath = Properties.Settings.Default.PerlPath;

            string DanTextProcPath = Properties.Settings.Default.danTextProcPath;

            string SearchWord = W;

            //DirectoryInfo di = new DirectoryInfo(@"C:\FilibusterDa\Filibuster1\da\Textprocessing");

            //Process P = Process.Start("perl.exe", @"C:\FilibusterDa\Filibuster1\da\Textprocessing\danTextprocessing.pl " + anf + "Her er en test" + anf);

            ProcessStartInfo perlStartInfo = new ProcessStartInfo(Perlpath);
            perlStartInfo.Arguments = DanTextProcPath + " " + anf + SearchWord + anf;
            perlStartInfo.UseShellExecute = false;
            perlStartInfo.RedirectStandardOutput = true;
            perlStartInfo.RedirectStandardError = true;
            perlStartInfo.CreateNoWindow = true;

            Process perl = new Process();
            perl.StartInfo = perlStartInfo;
            perl.Start();
            perl.WaitForExit();
            string output = perl.StandardOutput.ReadToEnd();

            return output;
        }

        private void btnAprove_Click(object sender, EventArgs e)
        {
            Aprove();
        }

        private void Aprove()
        {
            if (cmbWords.Text == "")
            {
                MessageBox.Show("Der er ikke noget ord til listen");
                return;
            }

            if (File.Exists(_AproveList))
            {
                File.AppendAllText(_AproveList, cmbWords.Text + "\r\n", Encoding.Default);//Tabs er fjernet

                RemoveWord();

            }
            else
            {
                MessageBox.Show("Listen til godkendte ord kunne ikke findes her: " + _AproveList);
            }
        }

        private void RemoveWord()
        {
            if (_UnknownWords != null)
            {
                int RemoveResult = RemoveWordFromList(cmbWords.Text, txtContext.Text);

                if (RemoveResult == 0)
                {
                    GetFirstWordFromList();
                }
                else if (RemoveResult == 1)
                {
                    MessageBox.Show("Der er ikke flere ord på listen");
                    cmbWords.Text = "";
                }
                else
                {
                    MessageBox.Show(cmbWords.Text + " kunne ikke slettes");
                }

                lblInfo.Text = _UnknownWords.Count.ToString() + " ukendte ord blev fundet";
                Application.DoEvents();
            }

        }

        private int RemoveWordFromList(string W, string C)
        {
            //Return: 0 ord blev fjernet, 1: det sidste ord blev fjernet, 2: Fejl
            if (_CurrentAudioID != "")
            {
                W = W + "\t" + C + "\t" + _CurrentAudioID;
            }

            try
            {
                if (_UnknownWords.Count > 1)
                {
                    _UnknownWords.Remove(W);
                    _CurrentAudioID = "";
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            catch (Exception ex)
            {
                return 2;
            }
        }

        private void btnIgnore_Click(object sender, EventArgs e)
        {
            RemoveWord();
        }

        private void btnToAdvancedList_Click(object sender, EventArgs e)
        {
            string CheckList = mGeneral.CHECK_LIST;

            if (File.Exists(CheckList))
            {
                File.AppendAllText(CheckList, cmbWords.Text + "\r\n", Encoding.Default);
                RemoveWord();
            }
            else
            {
                MessageBox.Show("Checklisten kunne ikke findes her: " + CheckList);
            }
        }

        //private void btnGetCompleteList_Click(object sender, EventArgs e)
        //{
        //    CreateUnknownListFromFile();
        //}

        private void frmExtraLex_Load(object sender, EventArgs e)
        {
            _AproveList = mGeneral.APROVED_LIST_PATH + "\\" + mGeneral.APROVED_LIST;
        }

        private void btnTextFilter_Click(object sender, EventArgs e)
        {
            frmTextFilter TF = new frmTextFilter();
            TF.LoadMe(cmbWords.Text);
        }

        private void cmbWords_DropDown(object sender, EventArgs e)
        {
            if (_UnknownWords == null)
            {
                return;
            }

            if (_UnknownWords.Count==0)
            {
                return;
            }

            cmbWords.Items.Clear();
            string[] Del = new string[] { "\t" };

            for (int i = 0; i < _UnknownWords.Count(); i++)
            {
                string Ln = _UnknownWords[i];

                string[] Ln2 = Ln.Split(Del, StringSplitOptions.None);

                string W = Ln2[0];

                cmbWords.Items.Add(W);

            }
        }

        private void mnuGetWordsOnly_Click(object sender, EventArgs e)
        {
            OpenDocAndCreateList(false);
        }

        private void mnuGetWordsWithID_Click(object sender, EventArgs e)
        {
            OpenDocAndCreateList(true);
        }

        private void mnuGetList_Click(object sender, EventArgs e)
        {
            CreateUnknownListFromFile();
        }

        private void mnuAcronym_Click(object sender, EventArgs e)
        {
            if (cmbWords.Text == "")
            {
                return;
            }

            AcronymFactory AF = new AcronymFactory(cmbWords.Text);

            if (AF.ErrMsg != "")
            {
                MessageBox.Show(AF.ErrMsg, "Akronymer");
                return;
            }

            txtSampa.Text = AF.SAMPAAcronym;

            cmbPos.Text = "ACR_NOM - Akronymer";

            cmbSpell.Text = "1";
        }

        private void chkCashed_CheckedChanged(object sender, EventArgs e)
        {
            if(chkCashed.Checked)
            {
                _ListWithIDs = true;
            }
            else
            {
                _ListWithIDs = false;
            }
        }

        private void frmExtraLex_KeyDown(object sender, KeyEventArgs e)
        {

            if(e.Alt)
            {
                mnuFile.Enabled = false;
                mnuFunctions.Enabled = false;

                mnuFile.Visible = false;
                mnuFunctions.Visible = false;

                if (e.KeyValue == (decimal)Keys.P)
                {
                    cmbPos.Focus();

                    e.SuppressKeyPress = true;
                }
            }

            if(e.Control)
            {
                mnuFile.Visible = true;
                mnuFunctions.Visible = true;

                mnuFile.Enabled = true;
                mnuFunctions.Enabled = true;
            }
        }

        private void txtSampa_TextChanged(object sender, EventArgs e)
        {
            int Pos = txtSampa.SelectionStart;

            string tmp = txtSampa.Text;

            tmp = tmp.Replace("æ", "$");
            tmp = tmp.Replace("ø", "@");
            tmp = tmp.Replace("c", "\"");
            tmp = tmp.Replace("5", "%");
            tmp = tmp.Replace("r ", "R ");

            if(tmp.Contains("å"))
            {
                tmp=tmp.Replace("å", "");
                txtSampa.Text = tmp;
                cmbPos.Focus();
                return;

            }
            else if(tmp.Contains("z"))
            {
                tmp = tmp.Replace("z", "");
                txtSampa.Text = tmp;
                cmbPos.Text = "PM_NOM - navne";
            }

            else if (tmp.Contains("x"))
            {
                tmp = tmp.Replace("x", "");
                txtSampa.Text = tmp;
                cmbPos.Text = "NN - substantiver (navneord)";
            }

            else if (tmp.Contains("<"))
            {
                tmp = tmp.Replace("<", "");
                txtSampa.Text = tmp;
                cmbPos.Text = "JJ - adjektiver (tillægsord)";
            }

            else
            {
                txtSampa.Text = tmp;
                
            }

            txtSampa.SelectionStart = Pos;

        }

        private void txtSuggestion_TextChanged(object sender, EventArgs e)
        {
            int Pos = txtSuggestion.SelectionStart;

            string tmp = txtSuggestion.Text;

            tmp = tmp.Replace("æ", "$");
            tmp = tmp.Replace("ø", "@");
            tmp = tmp.Replace("c", "\"");
            tmp = tmp.Replace("5", "%");
            tmp = tmp.Replace("r ", "R ");

            if (tmp.Contains("å"))
            {
                tmp = tmp.Replace("å", "");
                txtSuggestion.Text = tmp;
                cmbPos.Focus();
                return;

            }
            else if (tmp.Contains("z"))
            {
                tmp = tmp.Replace("z", "");
                txtSuggestion.Text = tmp;
                cmbPos.Text = "PM_NOM - navne";
            }

            else if (tmp.Contains("x"))
            {
                tmp = tmp.Replace("x", "");
                txtSuggestion.Text = tmp;
                cmbPos.Text = "NN - substantiver (navneord)";
            }

            else if (tmp.Contains("<"))
            {
                tmp = tmp.Replace("<", "");
                txtSuggestion.Text = tmp;
                cmbPos.Text = "JJ - adjektiver (tillægsord)";
            }

            else
            {
                txtSuggestion.Text = tmp;

            }

            txtSuggestion.SelectionStart = Pos;
        }

        private void mnuMultiword_Click(object sender, EventArgs e)
        {
            Point P = btnFind.Location;

            frmMultiWord MW=new frmMultiWord();
            MW.LoadMe(_Lexicon,P);
        }

        private void btnSuggestion_Click(object sender, EventArgs e)
        {
            if(cmbWords.Text=="")
            {
                return;
            }

            string SSML = CreateFilibusterSSML(cmbWords.Text);

            if(SSML=="")
            {
                MessageBox.Show("Kunne ikke danne lydord", "SSML");
                return;
            }

            //Hiv lydskrift ud
            string Audio = "";

            try
            {
                XmlDocument D = new XmlDocument();
                D.LoadXml(SSML);
                XmlNode Root = D.DocumentElement;

                XmlNode Ph = Root.FirstChild;

                Audio = mGeneral.GetAttrValueFromNode(Ph, "ph");
            }
            catch(XmlException ex)
            {
                MessageBox.Show("Kunne ikke danne lydord: " + ex.Message, "SSML");
                return;
            }

            txtSuggestion.Text = Audio;

            txtSuggestion.Focus();
            txtSuggestion.SelectionLength = 0;

        }
    }
}
