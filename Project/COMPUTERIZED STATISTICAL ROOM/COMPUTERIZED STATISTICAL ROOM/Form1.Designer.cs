namespace COMPUTERIZED_STATISTICAL_ROOM
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.txtname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtpassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.user_signin = new System.Windows.Forms.Button();
            this.admin_signin = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtname
            // 
            this.txtname.BackColor = System.Drawing.SystemColors.Window;
            this.txtname.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.txtname, "txtname");
            this.txtname.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtname.Name = "txtname";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Name = "label2";
            // 
            // txtpassword
            // 
            this.txtpassword.BackColor = System.Drawing.SystemColors.Window;
            this.txtpassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.txtpassword, "txtpassword");
            this.txtpassword.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtpassword.Name = "txtpassword";
            this.txtpassword.Tag = "";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Name = "label3";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.AppWorkspace;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.button1, "button1");
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // user_signin
            // 
            this.user_signin.BackColor = System.Drawing.SystemColors.MenuHighlight;
            resources.ApplyResources(this.user_signin, "user_signin");
            this.user_signin.FlatAppearance.BorderSize = 0;
            this.user_signin.ForeColor = System.Drawing.Color.White;
            this.user_signin.Name = "user_signin";
            this.user_signin.UseVisualStyleBackColor = false;
            this.user_signin.Click += new System.EventHandler(this.user_signin_Click);
            // 
            // admin_signin
            // 
            this.admin_signin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            resources.ApplyResources(this.admin_signin, "admin_signin");
            this.admin_signin.FlatAppearance.BorderSize = 0;
            this.admin_signin.ForeColor = System.Drawing.Color.White;
            this.admin_signin.Name = "admin_signin";
            this.admin_signin.UseVisualStyleBackColor = false;
            this.admin_signin.Click += new System.EventHandler(this.admin_signin_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::COMPUTERIZED_STATISTICAL_ROOM.Properties.Resources.تبوك;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // Login
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::COMPUTERIZED_STATISTICAL_ROOM.Properties.Resources.pexels_johannes_plenio_1103970;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.admin_signin);
            this.Controls.Add(this.user_signin);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtpassword);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtname);
            this.MaximizeBox = false;
            this.Name = "Login";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtpassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button user_signin;
        private System.Windows.Forms.Button admin_signin;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

