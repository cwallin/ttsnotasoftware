namespace ExtraLex
{
    partial class frmTextFilter
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
            this.btnOK = new System.Windows.Forms.Button();
            this.txtOrgText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNewText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.optReject = new System.Windows.Forms.RadioButton();
            this.optReplace = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.optGeneral = new System.Windows.Forms.RadioButton();
            this.optThisEdition = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(231, 104);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtOrgText
            // 
            this.txtOrgText.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrgText.Location = new System.Drawing.Point(12, 25);
            this.txtOrgText.Name = "txtOrgText";
            this.txtOrgText.Size = new System.Drawing.Size(294, 21);
            this.txtOrgText.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Oprindelig tekst";
            // 
            // txtNewText
            // 
            this.txtNewText.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewText.Location = new System.Drawing.Point(12, 69);
            this.txtNewText.Name = "txtNewText";
            this.txtNewText.Size = new System.Drawing.Size(294, 21);
            this.txtNewText.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ny tekst";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(231, 129);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Fortryd";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.optReject);
            this.groupBox1.Controls.Add(this.optReplace);
            this.groupBox1.Location = new System.Drawing.Point(12, 92);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(89, 61);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Action";
            // 
            // optReject
            // 
            this.optReject.AutoSize = true;
            this.optReject.Location = new System.Drawing.Point(7, 38);
            this.optReject.Name = "optReject";
            this.optReject.Size = new System.Drawing.Size(56, 17);
            this.optReject.TabIndex = 0;
            this.optReject.Text = "Reject";
            this.optReject.UseVisualStyleBackColor = true;
            // 
            // optReplace
            // 
            this.optReplace.AutoSize = true;
            this.optReplace.Checked = true;
            this.optReplace.Location = new System.Drawing.Point(7, 18);
            this.optReplace.Name = "optReplace";
            this.optReplace.Size = new System.Drawing.Size(65, 17);
            this.optReplace.TabIndex = 0;
            this.optReplace.TabStop = true;
            this.optReplace.Text = "Replace";
            this.optReplace.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.optGeneral);
            this.groupBox2.Controls.Add(this.optThisEdition);
            this.groupBox2.Location = new System.Drawing.Point(107, 95);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(118, 58);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Scope";
            // 
            // optGeneral
            // 
            this.optGeneral.AutoSize = true;
            this.optGeneral.Location = new System.Drawing.Point(7, 34);
            this.optGeneral.Name = "optGeneral";
            this.optGeneral.Size = new System.Drawing.Size(65, 17);
            this.optGeneral.TabIndex = 0;
            this.optGeneral.Text = "Generelt";
            this.optGeneral.UseVisualStyleBackColor = true;
            // 
            // optThisEdition
            // 
            this.optThisEdition.AutoSize = true;
            this.optThisEdition.Checked = true;
            this.optThisEdition.Location = new System.Drawing.Point(7, 15);
            this.optThisEdition.Name = "optThisEdition";
            this.optThisEdition.Size = new System.Drawing.Size(96, 17);
            this.optThisEdition.TabIndex = 0;
            this.optThisEdition.TabStop = true;
            this.optThisEdition.Text = "Denne udgave";
            this.optThisEdition.UseVisualStyleBackColor = true;
            // 
            // frmTextFilter
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(318, 160);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNewText);
            this.Controls.Add(this.txtOrgText);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmTextFilter";
            this.Text = "Tekstfilter";
            this.Shown += new System.EventHandler(this.frmTextFilter_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox txtOrgText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNewText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton optReject;
        private System.Windows.Forms.RadioButton optReplace;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton optGeneral;
        private System.Windows.Forms.RadioButton optThisEdition;
    }
}