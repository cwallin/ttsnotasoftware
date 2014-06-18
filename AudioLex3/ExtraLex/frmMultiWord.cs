using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ExtraLex
{
    public partial class frmMultiWord : Form
    {

        private int _ListCounter;
        private List<LexiconEntry> _Lexicon;
        //private LexiconEntry _CurrentEntry;//Den til enhver tid aktive entry

        public void LoadMe(List<LexiconEntry> Lexicon, Point P)
        {
            _Lexicon = Lexicon;
            this.Location = P;
            this.Show();
        }

        public frmMultiWord()
        {
            InitializeComponent();
        }

        private void btnSearchAll_Click(object sender, EventArgs e)
        {
            string SearchFor = txtInput.Text;

            if(SearchFor=="")
            {
                return;
            }

            if(SearchFor.Contains(" ")==false)
            {
                MessageBox.Show("Teksten skal indeholde mellemrum", "Multiword");
                return;
            }

            SearchFor = SearchFor.Replace("^", "");
            SearchFor = SearchFor.Replace("$", "");

            string[] Sep = new string[] { " " };
            string[] SWords = SearchFor.Split(Sep, StringSplitOptions.None);

            foreach (string W in SWords)
            {
                FindEntries("^" + W + "$", 0, true);
            }
        }

        private void FindEntries(string SearchForWord, int LexiCounter, bool MultiSearch)
        {
            _ListCounter = LexiCounter;

            RegexOptions options = RegexOptions.IgnoreCase;

            Regex RE_Word;

            try
            {
                RE_Word = new Regex(SearchForWord, options);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fejl i søgeudtryk: " + ex.Message, "Søgefejl");
                return;
            }

            for (int i = _ListCounter; i < _Lexicon.Count; i++)
            {

                LexiconEntry LE = _Lexicon[i];

                _ListCounter += 1;

                string TextWord = LE.TextWord;

                //Først skal det checkes om der er bid på ordet
                if (RE_Word.IsMatch(TextWord))
                {
                    string Sampa = LE.AudioWord;

                    if (MultiSearch)//Altid multisearch!
                    {
                        //string DictText = txtDictText.Text;

                        //if (DictText == "")
                        //{
                        //    txtDictText.Text = TextWord;
                        //}
                        //else
                        //{
                        //    TextWord = TextWord.Replace("\"", "%");

                        //    txtDictText.Text = txtDictText.Text + "-" + TextWord;
                        //}

                        string AudioText = txtSampa.Text;

                        if (AudioText == "")
                        {
                            txtSampa.Text = Sampa;
                        }
                        else
                        {
                            //Sampa = Sampa.Replace("\"", "%");
                            txtSampa.Text = txtSampa.Text + " | " + Sampa;
                        }

                    }
                    else
                    {
                
                        txtSampa.Text = Sampa;

                    }


                    return;

                }

            }

            //Der blev ikke fundet nogen
            if (MultiSearch)
            {
                //string DictText = txtDictText.Text;

                //if (DictText == "")
                //{
                //    txtDictText.Text = "**********";
                //}
                //else
                //{
                //    txtDictText.Text = txtDictText.Text + " - **********";
                //}

                string AudioText = txtSampa.Text;

                if (AudioText == "")
                {
                    txtSampa.Text = "**********";
                }
                else
                {
                    txtSampa.Text = txtSampa.Text + " | **********";
                }

            }
            else
            {

                txtSampa.Text = "Ingen match";
             
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnDictionary_Click(object sender, EventArgs e)
        {
            frmDictionary Dict = new frmDictionary();

            Point P = btnDictionary.Location;

            LexiconEntry Lex = Dict.LoadAndReturn("", _Lexicon, P);
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            PlaySampa();
        }

        private void PlaySampa()
        {
 
            string SampaWord = txtSampa.Text.Trim();
            string TextWord = "x";// txtInput.Text;
            string Pos = "NN";
            string Lang = "dan";
            string Spell = "0";
            string Stress = "1";

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
                SampaWord = SampaWord.Replace(" | ", " - ");
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveMultiWord();
        }

        private void SaveMultiWord()
        {
            string SampaWord = txtSampa.Text.Trim();
            string TextWord =  txtInput.Text;
            string Pos = "NN";
            string Lang = "dan";
            string Spell = "0";
            string Stress = "1";

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

            //Kun for at validere
            string tmpSampa=SampaWord.Replace(" | ", " - ");
            
            SSMLServices SML = new SSMLServices("x", tmpSampa, Pos, Lang, Spell, Stress, false);

            if (SML.ErrMsg != "")
            {
                MessageBox.Show(SML.ErrMsg, "Valideringsfejl");
                return;
            }

            //Komponér string til MultiWord
            string MWord = TextWord + "\t" + SampaWord + "\t" + Pos + "\t" + "0" + "\t" + "dan\tdan";

            string[] FileLine = new string[] { MWord };

            try
            {
                File.AppendAllLines(mGeneral.MULTIWORD_LEX, FileLine, Encoding.Default);
                txtInput.Text = "";
                txtSampa.Text = "";
            }
            catch(Exception e)
            {
                MessageBox.Show("der kunne ikke gemmes i " + mGeneral.MULTIWORD_LEX + ". Grund: " + e.Message, "Multiword");
            }
            
        }
    }
}
