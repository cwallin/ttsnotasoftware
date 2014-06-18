using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace TFAReader
{
    public partial class frmTFATool : Form
    {
        private string Report;
        private TFAMain T;
        private string FName;

        private int Counter;

        private void frmTFATool_Load(object sender, EventArgs e)
        {
            mGeneral.APP_PATH = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

#if DEBUG
   mGeneral.APP_PATH = @"C:\a_cwa lokal\Aktuelle projekter\Talesyntese\TFAReader2\runtime";
#endif

            //Hent settings
            mGeneral.TFA_LOCATION = Properties.Settings.Default.TFALocation;
            mGeneral.TFA_FILE = Properties.Settings.Default.TFAFile;

            txtTFA.Text = mGeneral.TFA_LOCATION + "\\" + mGeneral.TFA_FILE;
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            RTF.Text = "Henter TFA...";

            Application.DoEvents();

            FName = txtTFA.Text;
            T = new TFAMain(FName);

            RTF.Text = "TFA klar";

            btnSearch.Enabled = true;
            btnReplace.Enabled = true;
            btnSave.Enabled = true;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintFull();
        }

        private void PrintFull()
        {
            List<TFA> _TFAList = T.TFAList;

            //Med stringbuilder

            StringBuilder SB = new StringBuilder();

            foreach (TFA tfa in _TFAList)
            {
                //Gentag 3 gange

                //Udskriv phoner uden at udskrive words
                SB.Append(tfa.LabPath + "\n");
                foreach (Word w in tfa.WordList)
                {
                    //Først labliste
                    foreach (Phone p in w.PhoneList)
                    {
                        SB.Append(p.StartTime + " " + p.EndTime + " " + p.Content + "\n");
                    }

                }

                //Udskriv words
                SB.Append(tfa.WordPath + "\n");
                foreach (Word w in tfa.WordList)
                {
                    SB.Append(w.StartTime + " " + w.EndTime + " " + w.Content + "\n");

                }

                //Udskriv info
                SB.Append(tfa.InfoPath + "\n");
                foreach (Word w in tfa.WordList)
                {

                    SB.Append(w.Info.StartTime + " " + w.Info.EndTime + " " + w.Info.Content + "\n");
                }

            }

            //udskriv til fil
            //File.WriteAllText(@"C:\a_cwa lokal\Aktuelle projekter\Talesyntese\TFAReader\File\test.tfa",SB.ToString(),Encoding.Default);

            RTF.Text = SB.ToString();
        }

        private void PrintChanged()
        {
            bool ShortForm = chkShortForm.Checked;

            List<TFA> _TFAList = T.TFAList;

            //Med stringbuilder

            StringBuilder SB = new StringBuilder();

            if (ShortForm)
            {
                foreach (TFA tfa in _TFAList)
                {
                    if (tfa.isChanged)
                    {

                        //Gentag 3 gange
                        //Udskriv words
                        SB.Append(tfa.WordPath + "\n");
                        foreach (Word w in tfa.WordList)
                        {
                            if (w.IsTouched)
                            {
                                //Find phoner
                                string Phn = "";
                                foreach (Phone p in w.PhoneList)
                                {
                                    Phn = Phn + p.Content + " ";
                                }

                                SB.Append(w.Content + ": " + Phn + "\n");
                            }

                        }

                    }

                }
            }
            else//Lang form
            {
                foreach (TFA tfa in _TFAList)
                {
                    if (tfa.isChanged)
                    {

                        //Gentag 3 gange

                        //Udskriv phoner uden at udskrive words
                        SB.Append(tfa.LabPath + "\n");
                        foreach (Word w in tfa.WordList)
                        {
                            //Først labliste
                            foreach (Phone p in w.PhoneList)
                            {
                                SB.Append(p.StartTime + " " + p.EndTime + " " + p.Content + "\n");
                            }

                        }

                        //Udskriv words
                        SB.Append(tfa.WordPath + "\n");
                        foreach (Word w in tfa.WordList)
                        {
                            SB.Append(w.StartTime + " " + w.EndTime + " " + w.Content + "\n");
                        }

                        //Udskriv info
                        SB.Append(tfa.InfoPath + "\n");
                        foreach (Word w in tfa.WordList)
                        {
                            SB.Append(w.Info.StartTime + " " + w.Info.EndTime + " " + w.Info.Content + "\n");
                        }

                    }

                }
            }

            //udskriv til fil
            //File.WriteAllText(@"C:\a_cwa lokal\Aktuelle projekter\Talesyntese\TFAReader\File\test.tfa",SB.ToString(),Encoding.Default);

            RTF.Text = SB.ToString();
        }

        private Word ChangeWordOfSameLength(Word w, string[] ChangeTo)
        {
            List<Phone> ThisPhoneList = w.PhoneList;

            int i = 0;
            foreach (string s in ChangeTo)
            {
                Phone ThisPhone = ThisPhoneList[i];
                ThisPhone.Content = s;

                i += 1;
            }

            w.IsTouched = true;

            return w;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            string wrd = txtWord.Text;
            string pron = txtSpeech.Text;

            if (wrd == "")
            {
                return;
            }

            Search(wrd, pron, chkExact.Checked, true);

            PrintChanged();
        }

        private void Search(string SearchWord, string PronWord, bool UnExact, bool NewSearch)
        {
            string[] Sep = new String[] { " " };
            string[] WrdSep = new String[] { "|" };

            string[] SWords = SearchWord.Split(WrdSep, StringSplitOptions.None);
            string[] SpArr = null;

            if (PronWord != "")
            {
                SpArr = PronWord.Split(Sep, StringSplitOptions.None);
            }

            List<TFA> _TFAList = T.TFAList;

            foreach (TFA tfa in _TFAList)
            {
                if (NewSearch)
                {
                    tfa.isChanged = false;
                }

                foreach (Word w in tfa.WordList)
                {
                    if (NewSearch)
                    {
                        w.IsTouched = false;
                    }

                    //fjern evt. punktum eller komma, spørgsmålstegn og udråbstegn, semikolon og kolon
                    string WordContent = w.Content;

                    WordContent = WordContent.Replace(".", "");
                    WordContent = WordContent.Replace(",", "");
                    WordContent = WordContent.Replace("?", "");
                    WordContent = WordContent.Replace("!", "");
                    WordContent = WordContent.Replace(";", "");
                    WordContent = WordContent.Replace(":", "");



                    bool GoOn = false;

                    foreach (string wd in SWords)
                    {

                        if (UnExact == false)
                        {

                            if (wd == WordContent)
                            {
                                GoOn = true;

                                if (PronWord != "")
                                {
                                    //Check om udtalen svarer til spch
                                    int i = 0;

                                    foreach (Phone p in w.PhoneList)
                                    {
                                        if (p.Content == SpArr[i])
                                        {
                                            GoOn = true;
                                        }
                                        else
                                        {
                                            GoOn = false;
                                            break;
                                        }

                                        i += 1;
                                    }

                                }
                                else//pron == ""
                                {
                                    w.IsTouched = true;
                                    tfa.isChanged = true;
                                }

                            }
                        }
                        else//UnExact=true
                        {
                            if (WordContent.Contains(wd))
                            {
                                GoOn = true;
                            }
                        }

                        if (GoOn)
                        {
                            tfa.isChanged = true;
                            w.IsTouched = true;
                        }
                    }
                }
            }
        }

        private void btnReplace_Click(object sender, EventArgs e)
        {

            string wrd = txtWord.Text.Trim();
            string pron = txtSpeech.Text.Trim();
            string changeto = txtReplacement.Text.Trim();

            if (wrd == "")
            {
                return;
            }

            if (pron == "")
            {
                return;
            }

            if (changeto == "")
            {
                return;
            }

            pron = pron.Replace("  ", " ");
            changeto = changeto.Replace("  ", " ");

            ReplacePron(wrd, pron, changeto);

            PrintChanged();
        }

        private void ReplacePron(string SearchWord, string PronWord, string PronReplacement)
        {
            string tmpReport = "";

            string[] Sep = new String[] { " " };
            string[] CurrentArr = PronWord.Split(Sep, StringSplitOptions.None);

            string[] ReplaceWithArr = PronReplacement.Split(Sep, StringSplitOptions.None);

            List<TFA> _TFAList = T.TFAList;

            foreach (TFA tfa in _TFAList)
            {
                foreach (Word w in tfa.WordList)
                {
                    //fjern evt. punktum eller komma
                    string WordContent = w.Content;

                    WordContent = WordContent.Replace(".", "");
                    WordContent = WordContent.Replace(",", "");
                    WordContent = WordContent.Replace("?", "");
                    WordContent = WordContent.Replace("!", "");
                    WordContent = WordContent.Replace(";", "");
                    WordContent = WordContent.Replace(":", "");

                    if (SearchWord == WordContent)
                    {
                        //Check om udtalen svarer til spch
                        int i = 0;
                        bool GoOn = false;
                        if (w.PhoneList.Count == CurrentArr.Count())
                        {
                            Counter += 1;

                            foreach (Phone p in w.PhoneList)
                            {
                                if (p.Content == CurrentArr[i])
                                {
                                    GoOn = true;
                                }
                                else
                                {
                                    tmpReport = "! " + SearchWord + ": " + CreateStringFromPhoneList(w.PhoneList) + ", " +
                                                CreateStringFromArray(CurrentArr);

                                    Report = Report + tmpReport + "\n";
                                    GoOn = false;
                                    break;
                                }

                                i += 1;
                            }
                        }

                        if (GoOn)
                        {
                            //Send til ændring

                            tmpReport = SearchWord;

                            if (CurrentArr.Length == ReplaceWithArr.Length)
                            {
                                Word NewWord = ChangeWordOfSameLength(w, ReplaceWithArr);
                                tfa.isChanged = true;

                                string PhoneWord = CreateStringFromArray(ReplaceWithArr);
                                string SpWord = CreateStringFromArray(CurrentArr);
                                tmpReport = tmpReport + ", " + SpWord + " -> " + PhoneWord;
                            }
                            else
                            {
                                tmpReport = tmpReport + ", phonuoverensstemmelse";
                                //Hvis de ikke har samme længde skal de ikke ændres. Det skal måske gøres manuelt?
                                
                            }

                            Report = Report + tmpReport + "\n";
                        }
                    }
                }
            }
        }

        private string CreateStringFromArray(string[] Arr)
        {
            string output = "";
            

           foreach(string s in Arr)
           {
               output = output + s + " ";
           }

            return output.Trim();
        }

        private string CreateStringFromPhoneList(List<Phone> phonelist)
        {
            string output = "";


            foreach (Phone p in phonelist )
            {
                output = output + p.Content + " ";
            }

            return output.Trim();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {

            //Sikkerhedskopi:
            DateTime d = DateTime.Now;
            string CDato = d.ToString("yyyyMMddHHmmss");

            string BackUpFileName = FName + "_" + CDato;

            File.Copy(FName,BackUpFileName);

            List<TFA> _TFAList = T.TFAList;

            //Med stringbuilder

            StringBuilder SB = new StringBuilder();

            foreach (TFA tfa in _TFAList)
            {
                //Gentag 3 gange

                //Udskriv phoner uden at udskrive words
                SB.Append(tfa.LabPath + "\n");
                foreach (Word w in tfa.WordList)
                {
                    //Først labliste
                    foreach (Phone p in w.PhoneList)
                    {
                        SB.Append(p.StartTime + " " + p.EndTime + " " + p.Content + "\n");
                    }

                }

                //Udskriv words
                SB.Append(tfa.WordPath + "\n");
                foreach (Word w in tfa.WordList)
                {
                    SB.Append(w.StartTime + " " + w.EndTime + " " + w.Content + "\n");

                }

                //Udskriv info
                SB.Append(tfa.InfoPath + "\n");
                foreach (Word w in tfa.WordList)
                {

                    SB.Append(w.Info.StartTime + " " + w.Info.EndTime + " " + w.Info.Content + "\n");
                }

            }

            //udskriv til fil
            File.WriteAllText(FName, SB.ToString(), Encoding.Default);
        }

        private void btnListCompare_Click(object sender, EventArgs e)
        {
            string[] AllWords = File.ReadAllLines(@"C:\a_cwa lokal\Aktuelle projekter\Talesyntese\TFAReader\File\Main_Edit1_word_a6.txt",
                                                  Encoding.Default);

            foreach (string w in AllWords)
            {
                Search(w, "", false, false);
            }

            PrintChanged();

        }

        private void btnWordAndPronCompare_Click(object sender, EventArgs e)
        {
            string[] WrdSep = new String[] { "¤" };
            string[] AllWords = File.ReadAllLines(@"C:\a_cwa lokal\Aktuelle projekter\Talesyntese\TFAReader\File\Main_Edit1_word_and_pron.txt",
                                      Encoding.Default);

            foreach (string w in AllWords)
            {
                string[] SplitW = w.Split(WrdSep, StringSplitOptions.None);
                string Pron = SplitW[1];

                Pron = Pron.Replace("- ", "");
                Pron = Pron.Replace("$ ", "");
                Pron = Pron.Replace("| ", "");
                Pron = Pron.Replace("|", " ");
                Pron = Pron.Replace("~ ", " ");

                Search(SplitW[0], Pron, false, false);
            }

            PrintChanged();
        }

        private void btnReplacePron_Click(object sender, EventArgs e)
        {
            string[] WrdSep = new String[] { "\t" };
            string[] AllWords = File.ReadAllLines(@"C:\a_cwa lokal\Aktuelle projekter\Talesyntese\ordbogsrevision\Revision 20140304\Logfile_030314_edit.txt",
                                      Encoding.Default);

            foreach (string w in AllWords)
            {
                string[] SplitW = w.Split(WrdSep, StringSplitOptions.None);
                string Pron = SplitW[1];
                string Replacement = SplitW[2];

                Pron = Pron.Replace("- ", "");
                Pron = Pron.Replace("$ ", "");
                Pron = Pron.Replace("| ", "");
                Pron = Pron.Replace("|", " ");
                Pron = Pron.Replace("~ ", "");

                Replacement = Replacement.Replace("- ", "");
                Replacement = Replacement.Replace("$ ", "");
                Replacement = Replacement.Replace("| ", "");
                Replacement = Replacement.Replace("|", " ");
                Replacement = Replacement.Replace("~ ", "");

                ReplacePron(SplitW[0], Pron, Replacement);

            }

            PrintChanged();

            RTF.AppendText(Report);
        }

        public frmTFATool()
        {
            InitializeComponent();
        }

    }
}
