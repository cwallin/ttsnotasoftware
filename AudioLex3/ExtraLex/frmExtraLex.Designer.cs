namespace ExtraLex
{
    partial class frmExtraLex
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
            this.btnInsert = new System.Windows.Forms.Button();
            this.txtSampa = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPlay = new System.Windows.Forms.Button();
            this.cmbPos = new System.Windows.Forms.ComboBox();
            this.txtSSML = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbLanguage = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbSpell = new System.Windows.Forms.ComboBox();
            this.cmbStress = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.chkKeepText = new System.Windows.Forms.CheckBox();
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnAprove = new System.Windows.Forms.Button();
            this.btnFirst = new System.Windows.Forms.Button();
            this.btnToAdvancedList = new System.Windows.Forms.Button();
            this.chkAudio = new System.Windows.Forms.CheckBox();
            this.btnIgnore = new System.Windows.Forms.Button();
            this.btnTextFilter = new System.Windows.Forms.Button();
            this.cmbWords = new System.Windows.Forms.ComboBox();
            this.mnuStrip = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGetWordsWithID = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGetList = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFunctions = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAcronym = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMultiword = new System.Windows.Forms.ToolStripMenuItem();
            this.chkCashed = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtContext = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnSuggestion = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.txtSuggestion = new System.Windows.Forms.TextBox();
            this.btnListenSugg = new System.Windows.Forms.Button();
            this.mnuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(477, 507);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(75, 23);
            this.btnInsert.TabIndex = 5;
            this.btnInsert.Text = "&Indsæt";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // txtSampa
            // 
            this.txtSampa.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSampa.Location = new System.Drawing.Point(11, 249);
            this.txtSampa.Name = "txtSampa";
            this.txtSampa.Size = new System.Drawing.Size(460, 22);
            this.txtSampa.TabIndex = 2;
            this.txtSampa.TextChanged += new System.EventHandler(this.txtSampa_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "&Ord";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 233);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "&SAMPA";
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(477, 249);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(75, 23);
            this.btnPlay.TabIndex = 8;
            this.btnPlay.Text = "&Lyt";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // cmbPos
            // 
            this.cmbPos.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbPos.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbPos.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPos.FormattingEnabled = true;
            this.cmbPos.Items.AddRange(new object[] {
            "PM_NOM - navne",
            "NN - substantiver (navneord)",
            "ACR_NOM - Akronymer",
            "VB - verber (udsagnsord)",
            "JJ - adjektiver (tillægsord)",
            "PN - pronomener (stedord)",
            "RG  - talord",
            "AB - adverbier (biord)",
            "PP - præpositioner (forholdsord)",
            "IN - udråbsord/lydord"});
            this.cmbPos.Location = new System.Drawing.Point(14, 350);
            this.cmbPos.Name = "cmbPos";
            this.cmbPos.Size = new System.Drawing.Size(281, 24);
            this.cmbPos.TabIndex = 3;
            this.cmbPos.SelectedIndexChanged += new System.EventHandler(this.cmbPos_SelectedIndexChanged);
            // 
            // txtSSML
            // 
            this.txtSSML.Location = new System.Drawing.Point(14, 409);
            this.txtSSML.Multiline = true;
            this.txtSSML.Name = "txtSSML";
            this.txtSSML.Size = new System.Drawing.Size(538, 92);
            this.txtSSML.TabIndex = 8;
            this.txtSSML.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 393);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "SSML";
            // 
            // cmbLanguage
            // 
            this.cmbLanguage.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLanguage.FormattingEnabled = true;
            this.cmbLanguage.Items.AddRange(new object[] {
            "da",
            "en"});
            this.cmbLanguage.Location = new System.Drawing.Point(310, 350);
            this.cmbLanguage.Name = "cmbLanguage";
            this.cmbLanguage.Size = new System.Drawing.Size(45, 24);
            this.cmbLanguage.TabIndex = 10;
            this.cmbLanguage.TabStop = false;
            this.cmbLanguage.Text = "da";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 336);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "POS";
            // 
            // cmbSpell
            // 
            this.cmbSpell.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSpell.FormattingEnabled = true;
            this.cmbSpell.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cmbSpell.Location = new System.Drawing.Point(374, 350);
            this.cmbSpell.Name = "cmbSpell";
            this.cmbSpell.Size = new System.Drawing.Size(36, 24);
            this.cmbSpell.TabIndex = 11;
            this.cmbSpell.TabStop = false;
            this.cmbSpell.Text = "0";
            // 
            // cmbStress
            // 
            this.cmbStress.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStress.FormattingEnabled = true;
            this.cmbStress.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cmbStress.Location = new System.Drawing.Point(432, 350);
            this.cmbStress.Name = "cmbStress";
            this.cmbStress.Size = new System.Drawing.Size(36, 24);
            this.cmbStress.TabIndex = 6;
            this.cmbStress.TabStop = false;
            this.cmbStress.Text = "1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(307, 336);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Language";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(372, 336);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Spelling";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(433, 334);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Stress";
            // 
            // chkKeepText
            // 
            this.chkKeepText.AutoSize = true;
            this.chkKeepText.Location = new System.Drawing.Point(386, 513);
            this.chkKeepText.Name = "chkKeepText";
            this.chkKeepText.Size = new System.Drawing.Size(85, 17);
            this.chkKeepText.TabIndex = 4;
            this.chkKeepText.Text = "Behold tekst";
            this.chkKeepText.UseVisualStyleBackColor = true;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(11, 534);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(0, 13);
            this.lblInfo.TabIndex = 10;
            // 
            // btnFind
            // 
            this.btnFind.Enabled = false;
            this.btnFind.Location = new System.Drawing.Point(479, 51);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 23);
            this.btnFind.TabIndex = 1;
            this.btnFind.Text = "&Find...";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnAprove
            // 
            this.btnAprove.Location = new System.Drawing.Point(12, 79);
            this.btnAprove.Name = "btnAprove";
            this.btnAprove.Size = new System.Drawing.Size(83, 23);
            this.btnAprove.TabIndex = 12;
            this.btnAprove.Text = "&Godkend";
            this.btnAprove.UseVisualStyleBackColor = true;
            this.btnAprove.Click += new System.EventHandler(this.btnAprove_Click);
            // 
            // btnFirst
            // 
            this.btnFirst.Location = new System.Drawing.Point(101, 80);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(83, 23);
            this.btnFirst.TabIndex = 14;
            this.btnFirst.Text = "Afspil";
            this.btnFirst.UseVisualStyleBackColor = true;
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // btnToAdvancedList
            // 
            this.btnToAdvancedList.Location = new System.Drawing.Point(288, 80);
            this.btnToAdvancedList.Name = "btnToAdvancedList";
            this.btnToAdvancedList.Size = new System.Drawing.Size(80, 23);
            this.btnToAdvancedList.TabIndex = 16;
            this.btnToAdvancedList.Text = "Til avanceret";
            this.btnToAdvancedList.UseVisualStyleBackColor = true;
            this.btnToAdvancedList.Click += new System.EventHandler(this.btnToAdvancedList_Click);
            // 
            // chkAudio
            // 
            this.chkAudio.AutoSize = true;
            this.chkAudio.Checked = true;
            this.chkAudio.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAudio.Location = new System.Drawing.Point(479, 80);
            this.chkAudio.Name = "chkAudio";
            this.chkAudio.Size = new System.Drawing.Size(63, 17);
            this.chkAudio.TabIndex = 17;
            this.chkAudio.Text = "Med lyd";
            this.chkAudio.UseVisualStyleBackColor = true;
            // 
            // btnIgnore
            // 
            this.btnIgnore.Location = new System.Drawing.Point(190, 80);
            this.btnIgnore.Name = "btnIgnore";
            this.btnIgnore.Size = new System.Drawing.Size(92, 23);
            this.btnIgnore.TabIndex = 18;
            this.btnIgnore.Text = "Ig&norér";
            this.btnIgnore.UseVisualStyleBackColor = true;
            this.btnIgnore.Click += new System.EventHandler(this.btnIgnore_Click);
            // 
            // btnTextFilter
            // 
            this.btnTextFilter.Location = new System.Drawing.Point(376, 80);
            this.btnTextFilter.Name = "btnTextFilter";
            this.btnTextFilter.Size = new System.Drawing.Size(75, 23);
            this.btnTextFilter.TabIndex = 21;
            this.btnTextFilter.Text = "&Textfilter...";
            this.btnTextFilter.UseVisualStyleBackColor = true;
            this.btnTextFilter.Click += new System.EventHandler(this.btnTextFilter_Click);
            // 
            // cmbWords
            // 
            this.cmbWords.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbWords.FormattingEnabled = true;
            this.cmbWords.Location = new System.Drawing.Point(12, 50);
            this.cmbWords.Name = "cmbWords";
            this.cmbWords.Size = new System.Drawing.Size(439, 23);
            this.cmbWords.TabIndex = 22;
            this.cmbWords.DropDown += new System.EventHandler(this.cmbWords_DropDown);
            // 
            // mnuStrip
            // 
            this.mnuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuFunctions});
            this.mnuStrip.Location = new System.Drawing.Point(0, 0);
            this.mnuStrip.Name = "mnuStrip";
            this.mnuStrip.Size = new System.Drawing.Size(568, 24);
            this.mnuStrip.TabIndex = 24;
            this.mnuStrip.Text = "&Fil";
            // 
            // mnuFile
            // 
            this.mnuFile.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuGetWordsWithID,
            this.mnuGetList});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.ShowShortcutKeys = false;
            this.mnuFile.Size = new System.Drawing.Size(55, 20);
            this.mnuFile.Text = "Import";
            // 
            // mnuGetWordsWithID
            // 
            this.mnuGetWordsWithID.Name = "mnuGetWordsWithID";
            this.mnuGetWordsWithID.ShowShortcutKeys = false;
            this.mnuGetWordsWithID.Size = new System.Drawing.Size(216, 22);
            this.mnuGetWordsWithID.Text = "Hent ord fra dokument(er)...";
            this.mnuGetWordsWithID.Click += new System.EventHandler(this.mnuGetWordsWithID_Click);
            // 
            // mnuGetList
            // 
            this.mnuGetList.Name = "mnuGetList";
            this.mnuGetList.ShowShortcutKeys = false;
            this.mnuGetList.Size = new System.Drawing.Size(216, 22);
            this.mnuGetList.Text = "Hent ordliste";
            this.mnuGetList.Click += new System.EventHandler(this.mnuGetList_Click);
            // 
            // mnuFunctions
            // 
            this.mnuFunctions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAcronym,
            this.mnuMultiword});
            this.mnuFunctions.Name = "mnuFunctions";
            this.mnuFunctions.ShowShortcutKeys = false;
            this.mnuFunctions.Size = new System.Drawing.Size(76, 20);
            this.mnuFunctions.Text = "Funktioner";
            // 
            // mnuAcronym
            // 
            this.mnuAcronym.Name = "mnuAcronym";
            this.mnuAcronym.Size = new System.Drawing.Size(145, 22);
            this.mnuAcronym.Text = "Dan akronym";
            this.mnuAcronym.Click += new System.EventHandler(this.mnuAcronym_Click);
            // 
            // mnuMultiword
            // 
            this.mnuMultiword.Name = "mnuMultiword";
            this.mnuMultiword.Size = new System.Drawing.Size(145, 22);
            this.mnuMultiword.Text = "Multiword...";
            this.mnuMultiword.Click += new System.EventHandler(this.mnuMultiword_Click);
            // 
            // chkCashed
            // 
            this.chkCashed.AutoSize = true;
            this.chkCashed.Location = new System.Drawing.Point(479, 104);
            this.chkCashed.Name = "chkCashed";
            this.chkCashed.Size = new System.Drawing.Size(63, 17);
            this.chkCashed.TabIndex = 25;
            this.chkCashed.Text = "Cached";
            this.chkCashed.UseVisualStyleBackColor = true;
            this.chkCashed.CheckedChanged += new System.EventHandler(this.chkCashed_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(71, 233);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(282, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "ø = @, æ = $, c=\", å = POS, z = PM NOM, x = NN, < = JJ ";
            // 
            // txtContext
            // 
            this.txtContext.Location = new System.Drawing.Point(12, 126);
            this.txtContext.Multiline = true;
            this.txtContext.Name = "txtContext";
            this.txtContext.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtContext.Size = new System.Drawing.Size(542, 98);
            this.txtContext.TabIndex = 27;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 110);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 13);
            this.label9.TabIndex = 28;
            this.label9.Text = "Kontext";
            // 
            // btnSuggestion
            // 
            this.btnSuggestion.Location = new System.Drawing.Point(477, 276);
            this.btnSuggestion.Name = "btnSuggestion";
            this.btnSuggestion.Size = new System.Drawing.Size(75, 23);
            this.btnSuggestion.TabIndex = 29;
            this.btnSuggestion.Text = "F&orslag";
            this.btnSuggestion.UseVisualStyleBackColor = true;
            this.btnSuggestion.Click += new System.EventHandler(this.btnSuggestion_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(11, 286);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 13);
            this.label10.TabIndex = 30;
            this.label10.Text = "Forslag";
            // 
            // txtSuggestion
            // 
            this.txtSuggestion.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.txtSuggestion.Location = new System.Drawing.Point(15, 303);
            this.txtSuggestion.Name = "txtSuggestion";
            this.txtSuggestion.Size = new System.Drawing.Size(453, 22);
            this.txtSuggestion.TabIndex = 31;
            this.txtSuggestion.TextChanged += new System.EventHandler(this.txtSuggestion_TextChanged);
            // 
            // btnListenSugg
            // 
            this.btnListenSugg.Location = new System.Drawing.Point(479, 303);
            this.btnListenSugg.Name = "btnListenSugg";
            this.btnListenSugg.Size = new System.Drawing.Size(75, 23);
            this.btnListenSugg.TabIndex = 32;
            this.btnListenSugg.Text = "L&yt";
            this.btnListenSugg.UseVisualStyleBackColor = true;
            this.btnListenSugg.Click += new System.EventHandler(this.btnListenSugg_Click);
            // 
            // frmExtraLex
            // 
            this.AcceptButton = this.btnPlay;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 558);
            this.Controls.Add(this.btnListenSugg);
            this.Controls.Add(this.txtSuggestion);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnSuggestion);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtContext);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.chkCashed);
            this.Controls.Add(this.cmbWords);
            this.Controls.Add(this.btnTextFilter);
            this.Controls.Add(this.btnIgnore);
            this.Controls.Add(this.chkAudio);
            this.Controls.Add(this.btnToAdvancedList);
            this.Controls.Add(this.btnFirst);
            this.Controls.Add(this.btnAprove);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.chkKeepText);
            this.Controls.Add(this.txtSSML);
            this.Controls.Add(this.cmbStress);
            this.Controls.Add(this.cmbSpell);
            this.Controls.Add(this.cmbLanguage);
            this.Controls.Add(this.cmbPos);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSampa);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.mnuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MainMenuStrip = this.mnuStrip;
            this.MaximizeBox = false;
            this.Name = "frmExtraLex";
            this.Text = "AudioLex 0.13";
            this.Load += new System.EventHandler(this.frmExtraLex_Load);
            this.Shown += new System.EventHandler(this.frmExtraLex_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmExtraLex_KeyDown);
            this.mnuStrip.ResumeLayout(false);
            this.mnuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.TextBox txtSampa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.ComboBox cmbPos;
        private System.Windows.Forms.TextBox txtSSML;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbLanguage;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbSpell;
        private System.Windows.Forms.ComboBox cmbStress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chkKeepText;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Button btnAprove;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Button btnToAdvancedList;
        private System.Windows.Forms.CheckBox chkAudio;
        private System.Windows.Forms.Button btnIgnore;
        private System.Windows.Forms.Button btnTextFilter;
        private System.Windows.Forms.ComboBox cmbWords;
        private System.Windows.Forms.MenuStrip mnuStrip;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuGetWordsWithID;
        private System.Windows.Forms.ToolStripMenuItem mnuGetList;
        private System.Windows.Forms.ToolStripMenuItem mnuFunctions;
        private System.Windows.Forms.ToolStripMenuItem mnuAcronym;
        private System.Windows.Forms.CheckBox chkCashed;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtContext;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ToolStripMenuItem mnuMultiword;
        private System.Windows.Forms.Button btnSuggestion;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtSuggestion;
        private System.Windows.Forms.Button btnListenSugg;
    }
}

