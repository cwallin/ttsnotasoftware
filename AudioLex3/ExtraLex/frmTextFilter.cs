using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace ExtraLex
{
    public partial class frmTextFilter : Form
    {
        private XmlDocument _TxF;

        private string _ErrMsg;

        private string[] RegExChars;

        public string ErrMsg
        {
            get { return _ErrMsg; }
            set { _ErrMsg = value; }
        }

        public frmTextFilter()
        {
            InitializeComponent();
        }

        public void LoadMe(string OrgWord)
        {
            txtOrgText.Text = OrgWord;
            txtNewText.Text = OrgWord;

            RegExChars=new string[]{"\\", "*", "+", "?", "|", "{", "[", "(",")", "^", "$",".", "#"};

            this.Show();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string Act = "replace";

            string Scope = "this";

            if(optReject.Checked)
            {
                Act = "reject";
            }

            if(optGeneral.Checked)
            {
                Scope = "general";
            }

            if(txtNewText.Text !="")
            {
                string OrgText = txtOrgText.Text;

                OrgText = EscapeRegEx(OrgText);

                if (CreateXmlEntry(OrgText, txtNewText.Text, Act, Scope) == false)
               {
                   MessageBox.Show("Der kunne ikke oprettes en ny post. Grund: " + _ErrMsg , "Fejl ved oprettelse");
                   
               }

               this.Dispose();
            }
        }

        private string EscapeRegEx(string S)
        {
           foreach (string R in RegExChars)
           {
               S = S.Replace(R, "\\" + R);
           }

            return S;
        }

        private bool CreateXmlEntry(string OldWord, string NewWord, string Action, string Scope)
        {
            if(File.Exists(mGeneral.TEXT_FILTER))
            {
                _TxF=new XmlDocument();

                try
                {
                    _TxF.Load(mGeneral.TEXT_FILTER);
                }
                catch(XmlException ex)
                {
                    _ErrMsg = mGeneral.TEXT_FILTER + " kunne ikke åbnes: " + ex.Message;
                    return false;
                }

                try
                {
                    XmlNode Root = _TxF.DocumentElement;
                    XmlNode TextFilters = Root.SelectSingleNode("textfilters");


                    //Dan expression
                    XmlNode Exp = CreateNode("expression");

                    //Sæt attributter
                    string AttName = "generator";
                    string ValName = "AudioLex";
                    string AttAction = "action";
                    string AttScope = "scope";
                    string AttStamp = "datestamp";

                    string DateStamp = CreateLogDate();

                    AddAttribute(ref Exp, ref AttName, ref ValName);
                    AddAttribute(ref Exp, ref AttAction, ref Action);
                    AddAttribute(ref Exp, ref AttScope, ref Scope);
                    AddAttribute(ref Exp, ref AttStamp, ref DateStamp);

                    //Dan search
                    XmlNode Search = CreateNode("search");

                    XmlCDataSection CD = _TxF.CreateCDataSection(OldWord);

                    Search.AppendChild(CD);

                    //Dan replace
                    XmlNode Replace = CreateNode("replace");

                    CD = _TxF.CreateCDataSection(NewWord);

                    Replace.AppendChild(CD);

                    //Dan description
                    XmlNode Desc = CreateNode("description");

                    Exp.AppendChild(Search);
                    Exp.AppendChild(Replace);
                    Exp.AppendChild(Desc);

                    TextFilters.AppendChild(Exp);

                    _TxF.Save(mGeneral.TEXT_FILTER);
                }
                catch(XmlException ex2)
                {
                    _ErrMsg = "Xml-problemer: " + ex2.Message;
                    return false;
                }

            }
            else
            {
                _ErrMsg = mGeneral.TEXT_FILTER + " kunne ikke findes";
                return false;
            }

            return true;
        }

        private XmlNode CreateNode(string NodeName)
        {
            XmlNode n = _TxF.CreateNode(XmlNodeType.Element, NodeName, "");

            //string FCode = "feltkode";
            //pAddAttribute(ref n, ref FCode, ref FieldCode);

            return n;

        }

        private void AddAttribute(ref XmlNode n, ref string att, ref string AttText)
        {
            if (string.IsNullOrEmpty(AttText))
            {
                System.Xml.XmlNamedNodeMap objAttributes = n.Attributes;
                objAttributes.RemoveNamedItem(att);
                return;
            }

            System.Xml.XmlAttribute NewAttr = _TxF.CreateAttribute(att);
            NewAttr.Value = AttText;
            n.Attributes.SetNamedItem(NewAttr);

        }

        private string CreateLogDate()
        {
            DateTime D = DateTime.Now;
            return D.ToString("yyyyMMdd");
        }

        private void frmTextFilter_Shown(object sender, EventArgs e)
        {
            txtOrgText.Focus();
        }

    }


}
