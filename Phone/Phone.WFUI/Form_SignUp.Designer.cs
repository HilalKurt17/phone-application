namespace Phone.WFUI
{
    partial class Form_SignUp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_SignUp));
            this.label1 = new System.Windows.Forms.Label();
            this.txtBx_userName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBx_email = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBx_password = new System.Windows.Forms.TextBox();
            this.bttn_signUp = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(276, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "User Name:";
            // 
            // txtBx_userName
            // 
            this.txtBx_userName.Location = new System.Drawing.Point(394, 46);
            this.txtBx_userName.Name = "txtBx_userName";
            this.txtBx_userName.Size = new System.Drawing.Size(235, 27);
            this.txtBx_userName.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(276, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Email:";
            // 
            // txtBx_email
            // 
            this.txtBx_email.Location = new System.Drawing.Point(394, 83);
            this.txtBx_email.Name = "txtBx_email";
            this.txtBx_email.Size = new System.Drawing.Size(235, 27);
            this.txtBx_email.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(276, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Password:";
            // 
            // txtBx_password
            // 
            this.txtBx_password.Location = new System.Drawing.Point(394, 120);
            this.txtBx_password.Name = "txtBx_password";
            this.txtBx_password.PasswordChar = '*';
            this.txtBx_password.Size = new System.Drawing.Size(235, 27);
            this.txtBx_password.TabIndex = 2;
            // 
            // bttn_signUp
            // 
            this.bttn_signUp.Location = new System.Drawing.Point(394, 169);
            this.bttn_signUp.Name = "bttn_signUp";
            this.bttn_signUp.Size = new System.Drawing.Size(235, 42);
            this.bttn_signUp.TabIndex = 3;
            this.bttn_signUp.Text = "SIGN UP";
            this.bttn_signUp.UseVisualStyleBackColor = true;
            this.bttn_signUp.Click += new System.EventHandler(this.bttn_signUp_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Location = new System.Drawing.Point(22, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(221, 208);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(7, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(210, 178);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Form_SignUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 252);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.bttn_signUp);
            this.Controls.Add(this.txtBx_password);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBx_email);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBx_userName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form_SignUp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SIGN UP";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label label1;
        private TextBox txtBx_userName;
        private Label label2;
        private TextBox txtBx_email;
        private Label label3;
        private TextBox txtBx_password;
        private Button bttn_signUp;
        private GroupBox groupBox1;
        private PictureBox pictureBox1;
    }
}