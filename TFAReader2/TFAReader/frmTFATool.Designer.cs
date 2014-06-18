namespace TFAReader
{
    partial class frmTFATool
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnGo = new System.Windows.Forms.Button();
            this.RTF = new System.Windows.Forms.RichTextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtWord = new System.Windows.Forms.TextBox();
            this.txtSpeech = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtReplacement = new System.Windows.Forms.TextBox();
            this.btnReplace = new System.Windows.Forms.Button();
            this.chkShortForm = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.chkExact = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnReplacePron = new System.Windows.Forms.Button();
            this.btnWordAndPronCompare = new System.Windows.Forms.Button();
            this.btnWordOnlyListCompare = new System.Windows.Forms.Button();
            this.txtTFA = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(22, 30);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 0;
            this.btnGo.Text = "Load";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // RTF
            // 
            this.RTF.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RTF.Location = new System.Drawing.Point(479, 12);
            this.RTF.Name = "RTF";
            this.RTF.Size = new System.Drawing.Size(547, 483);
            this.RTF.TabIndex = 2;
            this.RTF.Text = "";
            this.RTF.WordWrap = false;
            // 
            // btnSearch
            // 
            this.btnSearch.Enabled = false;
            this.btnSearch.Location = new System.Drawing.Point(25, 73);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Søg...";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 160);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Ord";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 208);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Lydskrift";
            // 
            // txtWord
            // 
            this.txtWord.Location = new System.Drawing.Point(25, 177);
            this.txtWord.Name = "txtWord";
            this.txtWord.Size = new System.Drawing.Size(231, 20);
            this.txtWord.TabIndex = 5;
            // 
            // txtSpeech
            // 
            this.txtSpeech.Location = new System.Drawing.Point(25, 224);
            this.txtSpeech.Name = "txtSpeech";
            this.txtSpeech.Size = new System.Drawing.Size(231, 20);
            this.txtSpeech.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 260);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Erstat med";
            // 
            // txtReplacement
            // 
            this.txtReplacement.Location = new System.Drawing.Point(25, 277);
            this.txtReplacement.Name = "txtReplacement";
            this.txtReplacement.Size = new System.Drawing.Size(231, 20);
            this.txtReplacement.TabIndex = 7;
            // 
            // btnReplace
            // 
            this.btnReplace.Enabled = false;
            this.btnReplace.Location = new System.Drawing.Point(25, 120);
            this.btnReplace.Name = "btnReplace";
            this.btnReplace.Size = new System.Drawing.Size(75, 23);
            this.btnReplace.TabIndex = 9;
            this.btnReplace.Text = "Erstat";
            this.btnReplace.UseVisualStyleBackColor = true;
            this.btnReplace.Click += new System.EventHandler(this.btnReplace_Click);
            // 
            // chkShortForm
            // 
            this.chkShortForm.AutoSize = true;
            this.chkShortForm.Location = new System.Drawing.Point(125, 79);
            this.chkShortForm.Name = "chkShortForm";
            this.chkShortForm.Size = new System.Drawing.Size(149, 17);
            this.chkShortForm.TabIndex = 10;
            this.chkShortForm.Text = "Vis søgeresultat i kort form";
            this.chkShortForm.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(25, 322);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Gem";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // chkExact
            // 
            this.chkExact.AutoSize = true;
            this.chkExact.Location = new System.Drawing.Point(300, 77);
            this.chkExact.Name = "chkExact";
            this.chkExact.Size = new System.Drawing.Size(142, 17);
            this.chkExact.TabIndex = 12;
            this.chkExact.Text = "Søg i ord (Ingen lydskrift)";
            this.chkExact.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnReplacePron);
            this.groupBox2.Controls.Add(this.btnWordAndPronCompare);
            this.groupBox2.Controls.Add(this.btnWordOnlyListCompare);
            this.groupBox2.Location = new System.Drawing.Point(22, 371);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(435, 124);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Listesammenligning";
            // 
            // btnReplacePron
            // 
            this.btnReplacePron.Location = new System.Drawing.Point(282, 29);
            this.btnReplacePron.Name = "btnReplacePron";
            this.btnReplacePron.Size = new System.Drawing.Size(121, 23);
            this.btnReplacePron.TabIndex = 2;
            this.btnReplacePron.Text = "Erstat pron";
            this.btnReplacePron.UseVisualStyleBackColor = true;
            this.btnReplacePron.Click += new System.EventHandler(this.btnReplacePron_Click);
            // 
            // btnWordAndPronCompare
            // 
            this.btnWordAndPronCompare.Enabled = false;
            this.btnWordAndPronCompare.Location = new System.Drawing.Point(149, 29);
            this.btnWordAndPronCompare.Name = "btnWordAndPronCompare";
            this.btnWordAndPronCompare.Size = new System.Drawing.Size(107, 23);
            this.btnWordAndPronCompare.TabIndex = 1;
            this.btnWordAndPronCompare.Text = "Ord og pron";
            this.btnWordAndPronCompare.UseVisualStyleBackColor = true;
            this.btnWordAndPronCompare.Click += new System.EventHandler(this.btnWordAndPronCompare_Click);
            // 
            // btnWordOnlyListCompare
            // 
            this.btnWordOnlyListCompare.Enabled = false;
            this.btnWordOnlyListCompare.Location = new System.Drawing.Point(7, 30);
            this.btnWordOnlyListCompare.Name = "btnWordOnlyListCompare";
            this.btnWordOnlyListCompare.Size = new System.Drawing.Size(117, 23);
            this.btnWordOnlyListCompare.TabIndex = 0;
            this.btnWordOnlyListCompare.Text = "Kun ord";
            this.btnWordOnlyListCompare.UseVisualStyleBackColor = true;
            this.btnWordOnlyListCompare.Click += new System.EventHandler(this.btnListCompare_Click);
            // 
            // txtTFA
            // 
            this.txtTFA.Location = new System.Drawing.Point(115, 32);
            this.txtTFA.Name = "txtTFA";
            this.txtTFA.Size = new System.Drawing.Size(327, 20);
            this.txtTFA.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(117, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Aktuel TFA";
            // 
            // frmTFATool
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1039, 513);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtTFA);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.chkExact);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.chkShortForm);
            this.Controls.Add(this.btnReplace);
            this.Controls.Add(this.txtReplacement);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSpeech);
            this.Controls.Add(this.txtWord);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.RTF);
            this.Controls.Add(this.btnGo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "frmTFATool";
            this.Text = "TFA-reader 0.4";
            this.Load += new System.EventHandler(this.frmTFATool_Load);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.RichTextBox RTF;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtWord;
        private System.Windows.Forms.TextBox txtSpeech;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtReplacement;
        private System.Windows.Forms.Button btnReplace;
        private System.Windows.Forms.CheckBox chkShortForm;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox chkExact;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnWordOnlyListCompare;
        private System.Windows.Forms.Button btnWordAndPronCompare;
        private System.Windows.Forms.Button btnReplacePron;
        private System.Windows.Forms.TextBox txtTFA;
        private System.Windows.Forms.Label label6;
    }
}

