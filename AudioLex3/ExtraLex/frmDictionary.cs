using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ExtraLex
{
    public partial class frmDictionary : Form
    {
        private List<LexiconEntry> _Lexicon;
        private LexiconEntry _CurrentEntry;//Den til enhver tid aktive entry
        private int _ListCounter;

        public frmDictionary()
        {
            InitializeComponent();
        }

        public LexiconEntry LoadAndReturn(string SearchWord, List<LexiconEntry> Lexicon, Point P)
        {

            txtPatternText.Text = SearchWord;

            _Lexicon = Lexicon;

            //this.Location = P;

            this.ShowDialog();

            return _CurrentEntry;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (txtPatternText.Text == "")
            {
                return;
            }

            string SearchForWord = txtPatternText.Text;

            FindEntries(SearchForWord, _ListCounter, false,0);
        }

        private void btnFindFirst_Click(object sender, EventArgs e)
        {
            //_ListCounter = 0;//Bliv her
            if (txtPatternText.Text == "")
            {
                return;
            }

            string SearchForWord = txtPatternText.Text;

            //SearchForWord = "energiagentur|direktørjob|livsbane";

            _CurrentEntry = null;//For at sikre mod utilsigtet overskrivning

            if (SearchForWord.Contains("|"))
            {
                txtDictText.Text = "";
                txtAudio.Text = "";
                txtGrammar.Text = "";
                txtDictionaryName.Text = "";

                //Søg efter alle ord i rækkefølge
                SearchForWord = SearchForWord.Replace("^", "");
                SearchForWord = SearchForWord.Replace("$", "");

                string[] Sep = new string[] { "|" };
                string[] SWords = SearchForWord.Split(Sep, StringSplitOptions.None);

                int WCount=0;

                foreach (string W in SWords)
                {
                    FindEntries("^" + W + "$", 0, true, WCount);
                    WCount += 1;
                }

            }
            else
            {
                FindEntries(SearchForWord, 0, false,0);
            }

        }

        private void FindEntries(string SearchForWord, int LexiCounter, bool MultiSearch, int WordNumber)
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

                    if (MultiSearch)
                    {

                        //Hvis WordNumber=0 (første ord) skal det beholde hovedtryk (") og evt. bitryk (%) falder bort
                        //Hvis WordNumber > 0 bliver hovedtryk til bitryk og evt. bitryk falder bort

                        if(WordNumber==0)
                        {
                            //Fjern bi-tryk
                            Sampa = Sampa.Replace("%", "");
                        }
                        else
                        {
                            //Fjern bi-tryk og gør hovedtryk til bi-tryk
                            Sampa = Sampa.Replace("%", "");
                            Sampa = Sampa.Replace("\"", "%");
                        }

                        string DictText = txtDictText.Text;

                        if (DictText == "")
                        {
                            txtDictText.Text = TextWord;
                        }
                        else
                        {
                            //TextWord = TextWord.Replace("\"", "%");

                            txtDictText.Text = txtDictText.Text + "-" + TextWord;
                        }

                        string AudioText = txtAudio.Text;

                        if (AudioText == "")
                        {
                            txtAudio.Text = Sampa;
                        }
                        else
                        {
                            //Sampa = Sampa.Replace("\"", "%");
                            txtAudio.Text = txtAudio.Text + " - " + Sampa;
                        }

                        txtGrammar.Text = "Multisearch";
                        txtDictionaryName.Text = "Multisearch";
                    }
                    else
                    {
                        txtDictText.Text = TextWord;
                        txtAudio.Text = Sampa;
                        txtGrammar.Text = LE.Grammar;
                        txtDictionaryName.Text = LE.LexiconType;
                    }


                    return;

                }

            }

            //Der blev ikke fundet nogen
            if (MultiSearch)
            {
                string DictText = txtDictText.Text;

                if (DictText == "")
                {
                    txtDictText.Text = "**********";
                }
                else
                {
                    txtDictText.Text = txtDictText.Text + " - **********";
                }

                string AudioText = txtAudio.Text;

                if (AudioText == "")
                {
                    txtAudio.Text = "**********";
                }
                else
                {
                    txtAudio.Text = txtAudio.Text + " - **********";
                }
                txtGrammar.Text = "Multisearch";
                txtDictionaryName.Text = "Multisearch";
            }
            else
            {
                txtDictText.Text = "Ingen match";
                txtAudio.Text = "Ingen match";
                txtGrammar.Text = "Ingen match";
                txtDictionaryName.Text = "";
            }

        }

        private string CleanText(string Pat)
        {
            Pat = Pat.Replace("^", "");
            Pat = Pat.Replace("$", "");

            return Pat;
        }

        private void optRegEx_CheckedChanged(object sender, EventArgs e)
        {
            if (txtPatternText.Text == "")
            {
                return;
            }

            if (optRegEx.Checked)
            {
                string Pat = CleanText(txtPatternText.Text);

                txtPatternText.Text = Pat;
            }
        }

        private void optExact_CheckedChanged(object sender, EventArgs e)
        {
            if (txtPatternText.Text == "")
            {
                return;
            }

            if (optExact.Checked)
            {
                string Pat = CleanText(txtPatternText.Text);
                Pat = "^" + Pat + "$";
                txtPatternText.Text = Pat;
            }
        }

        private void optEnds_CheckedChanged(object sender, EventArgs e)
        {
            if (txtPatternText.Text == "")
            {
                return;
            }

            if (optEnds.Checked)
            {
                string Pat = CleanText(txtPatternText.Text);
                Pat = Pat + "$";
                txtPatternText.Text = Pat;
            }
        }

        private void optBegins_CheckedChanged(object sender, EventArgs e)
        {
            if (txtPatternText.Text == "")
            {
                return;
            }

            if (optBegins.Checked)
            {
                string Pat = CleanText(txtPatternText.Text);
                Pat = "^" + Pat;
                txtPatternText.Text = Pat;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            if (txtAudio.Text != "Ingen match")
            {
                _CurrentEntry = new LexiconEntry();
                _CurrentEntry.TextWord = txtPatternText.Text;
                _CurrentEntry.AudioWord = txtAudio.Text;
            }

            this.Dispose();
        }

        private void frmDictionary_Shown(object sender, EventArgs e)
        {
            txtPatternText.Focus();
        }

        private void txtPatternText_KeyDown(object sender, KeyEventArgs e)
        {
            int Pos = txtPatternText.SelectionStart;
            string W = txtPatternText.Text;

            if (e.KeyCode == (Keys)220)
            {

                if (W.Contains("|") == false)
                {
                    W = W + "|";
                    txtPatternText.Text = W;
                    txtPatternText.SelectionStart = W.Length - 1;
                    Pos = W.Length - 1;
                }
                else
                {
                    W = W.Replace("|", "");
                    txtPatternText.Text = W;
                }

                e.SuppressKeyPress = true;
                return;
            }

            if (W.Contains("|"))
            {

                if (e.KeyCode == Keys.Left)
                {
                    if (Pos > 0)
                    {
                        int DPos = Pos - 1;
                        ChangeDividerPos(DPos,Pos);
                    }
                }
                else if (e.KeyCode == Keys.Right)
                {

                    if (Pos <= txtPatternText.SelectionStart)
                    {
                        int DPos = Pos + 1;
                        ChangeDividerPos(DPos,Pos);
                    }

                }

            }
        }

        private void ChangeDividerPos(int DivPos, int ActualPos)
        {
           
            string W = txtPatternText.Text;

            if(DivPos > W.Length)
            {
                return;
            }

            string W1 = W.Substring(0, DivPos);
            W1 = W1.Replace("|", "");

            string W2 = W.Substring(DivPos);
            W2 = W2.Replace("|", "");

            string NewWord = W1 + "|" + W2;
            txtPatternText.Text = NewWord;
            txtPatternText.SelectionStart = ActualPos;

        }

    }
}
