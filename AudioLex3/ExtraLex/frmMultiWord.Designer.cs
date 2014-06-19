namespace ExtraLex
{
    partial class frmMultiWord
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
            this.txtInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSampa = new System.Windows.Forms.TextBox();
            this.btnSearchAll = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDictionary = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtSSML = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtInput
            // 
            this.txtInput.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInput.Location = new System.Drawing.Point(16, 31);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(698, 21);
            this.txtInput.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Inputtekst";
            // 
            // txtSampa
            // 
            this.txtSampa.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSampa.Location = new System.Drawing.Point(16, 108);
            this.txtSampa.Multiline = true;
            this.txtSampa.Name = "txtSampa";
            this.txtSampa.Size = new System.Drawing.Size(695, 76);
            this.txtSampa.TabIndex = 2;
            // 
            // btnSearchAll
            // 
            this.btnSearchAll.Location = new System.Drawing.Point(16, 58);
            this.btnSearchAll.Name = "btnSearchAll";
            this.btnSearchAll.Size = new System.Drawing.Size(89, 23);
            this.btnSearchAll.TabIndex = 3;
            this.btnSearchAll.Text = "Søg alle ord...";
            this.btnSearchAll.UseVisualStyleBackColor = true;
            this.btnSearchAll.Click += new System.EventHandler(this.btnSearchAll_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Resultat";
            // 
            // btnDictionary
            // 
            this.btnDictionary.Location = new System.Drawing.Point(121, 58);
            this.btnDictionary.Name = "btnDictionary";
            this.btnDictionary.Size = new System.Drawing.Size(93, 23);
            this.btnDictionary.TabIndex = 5;
            this.btnDictionary.Text = "Ordbøger...";
            this.btnDictionary.UseVisualStyleBackColor = true;
            this.btnDictionary.Click += new System.EventHandler(this.btnDictionary_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(19, 270);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(75, 23);
            this.btnPlay.TabIndex = 6;
            this.btnPlay.Text = "Lyt";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(112, 270);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(122, 23);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Gem i multiword";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(635, 268);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Luk";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtSSML
            // 
            this.txtSSML.Location = new System.Drawing.Point(19, 210);
            this.txtSSML.Multiline = true;
            this.txtSSML.Name = "txtSSML";
            this.txtSSML.Size = new System.Drawing.Size(695, 54);
            this.txtSSML.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 191);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "SSML";
            // 
            // frmMultiWord
            // 
            this.AcceptButton = this.btnSearchAll;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(723, 304);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSSML);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.btnDictionary);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSearchAll);
            this.Controls.Add(this.txtSampa);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtInput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmMultiWord";
            this.Text = "Multiword";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSampa;
        private System.Windows.Forms.Button btnSearchAll;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDictionary;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtSSML;
        private System.Windows.Forms.Label label3;
    }
}