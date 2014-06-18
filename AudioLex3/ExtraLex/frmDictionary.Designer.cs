namespace ExtraLex
{
    partial class frmDictionary
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
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.optRegEx = new System.Windows.Forms.RadioButton();
            this.optExact = new System.Windows.Forms.RadioButton();
            this.optEnds = new System.Windows.Forms.RadioButton();
            this.optBegins = new System.Windows.Forms.RadioButton();
            this.txtPatternText = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtDictionaryName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDictText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAudio = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtGrammar = new System.Windows.Forms.TextBox();
            this.btnTransfer = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnFindFirst = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.groupBox7.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.optRegEx);
            this.groupBox7.Controls.Add(this.optExact);
            this.groupBox7.Controls.Add(this.optEnds);
            this.groupBox7.Controls.Add(this.optBegins);
            this.groupBox7.Controls.Add(this.txtPatternText);
            this.groupBox7.Location = new System.Drawing.Point(12, 12);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(481, 78);
            this.groupBox7.TabIndex = 13;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Mønster tekst";
            // 
            // optRegEx
            // 
            this.optRegEx.AutoSize = true;
            this.optRegEx.Checked = true;
            this.optRegEx.Location = new System.Drawing.Point(225, 47);
            this.optRegEx.Name = "optRegEx";
            this.optRegEx.Size = new System.Drawing.Size(57, 17);
            this.optRegEx.TabIndex = 3;
            this.optRegEx.TabStop = true;
            this.optRegEx.Text = "RegEx";
            this.optRegEx.UseVisualStyleBackColor = true;
            this.optRegEx.CheckedChanged += new System.EventHandler(this.optRegEx_CheckedChanged);
            // 
            // optExact
            // 
            this.optExact.AutoSize = true;
            this.optExact.Location = new System.Drawing.Point(309, 47);
            this.optExact.Name = "optExact";
            this.optExact.Size = new System.Drawing.Size(58, 17);
            this.optExact.TabIndex = 4;
            this.optExact.Text = "Eksakt";
            this.optExact.UseVisualStyleBackColor = true;
            this.optExact.CheckedChanged += new System.EventHandler(this.optExact_CheckedChanged);
            // 
            // optEnds
            // 
            this.optEnds.AutoSize = true;
            this.optEnds.Location = new System.Drawing.Point(126, 46);
            this.optEnds.Name = "optEnds";
            this.optEnds.Size = new System.Drawing.Size(78, 17);
            this.optEnds.TabIndex = 2;
            this.optEnds.Text = "Slutter med";
            this.optEnds.UseVisualStyleBackColor = true;
            this.optEnds.CheckedChanged += new System.EventHandler(this.optEnds_CheckedChanged);
            // 
            // optBegins
            // 
            this.optBegins.AutoSize = true;
            this.optBegins.Location = new System.Drawing.Point(7, 47);
            this.optBegins.Name = "optBegins";
            this.optBegins.Size = new System.Drawing.Size(93, 17);
            this.optBegins.TabIndex = 1;
            this.optBegins.Text = "Begynder med";
            this.optBegins.UseVisualStyleBackColor = true;
            this.optBegins.CheckedChanged += new System.EventHandler(this.optBegins_CheckedChanged);
            // 
            // txtPatternText
            // 
            this.txtPatternText.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPatternText.Location = new System.Drawing.Point(6, 19);
            this.txtPatternText.Name = "txtPatternText";
            this.txtPatternText.Size = new System.Drawing.Size(371, 21);
            this.txtPatternText.TabIndex = 0;
            this.txtPatternText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPatternText_KeyDown);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtDictionaryName);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtDictText);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtAudio);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtGrammar);
            this.groupBox2.Location = new System.Drawing.Point(12, 144);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(481, 180);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ordbog";
            // 
            // txtDictionaryName
            // 
            this.txtDictionaryName.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDictionaryName.Location = new System.Drawing.Point(383, 41);
            this.txtDictionaryName.Name = "txtDictionaryName";
            this.txtDictionaryName.Size = new System.Drawing.Size(87, 21);
            this.txtDictionaryName.TabIndex = 21;
            this.txtDictionaryName.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(380, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Ordbog";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Fundet tekst";
            // 
            // txtDictText
            // 
            this.txtDictText.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDictText.Location = new System.Drawing.Point(9, 41);
            this.txtDictText.Name = "txtDictText";
            this.txtDictText.Size = new System.Drawing.Size(358, 21);
            this.txtDictText.TabIndex = 20;
            this.txtDictText.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Fundet lydskrift";
            // 
            // txtAudio
            // 
            this.txtAudio.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAudio.Location = new System.Drawing.Point(9, 99);
            this.txtAudio.Name = "txtAudio";
            this.txtAudio.Size = new System.Drawing.Size(358, 21);
            this.txtAudio.TabIndex = 22;
            this.txtAudio.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Grammatik";
            // 
            // txtGrammar
            // 
            this.txtGrammar.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGrammar.Location = new System.Drawing.Point(9, 148);
            this.txtGrammar.Name = "txtGrammar";
            this.txtGrammar.Size = new System.Drawing.Size(181, 21);
            this.txtGrammar.TabIndex = 23;
            this.txtGrammar.TabStop = false;
            // 
            // btnTransfer
            // 
            this.btnTransfer.Location = new System.Drawing.Point(322, 337);
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.Size = new System.Drawing.Size(75, 23);
            this.btnTransfer.TabIndex = 6;
            this.btnTransfer.Text = "&Overfør";
            this.btnTransfer.UseVisualStyleBackColor = true;
            this.btnTransfer.Click += new System.EventHandler(this.btnTransfer_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(418, 338);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Luk";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnFindFirst
            // 
            this.btnFindFirst.Location = new System.Drawing.Point(11, 96);
            this.btnFindFirst.Name = "btnFindFirst";
            this.btnFindFirst.Size = new System.Drawing.Size(85, 23);
            this.btnFindFirst.TabIndex = 19;
            this.btnFindFirst.Text = "Find første";
            this.btnFindFirst.UseVisualStyleBackColor = true;
            this.btnFindFirst.Click += new System.EventHandler(this.btnFindFirst_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(114, 96);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(88, 23);
            this.btnNext.TabIndex = 5;
            this.btnNext.Text = "&Næste";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // frmDictionary
            // 
            this.AcceptButton = this.btnFindFirst;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(510, 370);
            this.ControlBox = false;
            this.Controls.Add(this.btnFindFirst);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnTransfer);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox7);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDictionary";
            this.Text = "Søg i ordbøger";
            this.Shown += new System.EventHandler(this.frmDictionary_Shown);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.RadioButton optRegEx;
        private System.Windows.Forms.RadioButton optExact;
        private System.Windows.Forms.RadioButton optEnds;
        private System.Windows.Forms.RadioButton optBegins;
        private System.Windows.Forms.TextBox txtPatternText;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtDictionaryName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDictText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAudio;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtGrammar;
        private System.Windows.Forms.Button btnTransfer;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnFindFirst;
        private System.Windows.Forms.Button btnNext;
    }
}