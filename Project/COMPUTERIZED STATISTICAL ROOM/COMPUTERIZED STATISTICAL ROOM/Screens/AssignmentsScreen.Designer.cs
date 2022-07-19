namespace COMPUTERIZED_STATISTICAL_ROOM.Screens
{
    partial class AssignmentsScreen
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.button10 = new System.Windows.Forms.Button();
            this.label34 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.DTPEndDate = new System.Windows.Forms.DateTimePicker();
            this.DTPStartDate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.comboAssignmentstype = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAssignmentsID = new System.Windows.Forms.TextBox();
            this.txtnum = new System.Windows.Forms.TextBox();
            this.comboAssignmentsName = new System.Windows.Forms.ComboBox();
            this.comboEntity = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.button10);
            this.panel1.Controls.Add(this.label34);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(15, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(610, 335);
            this.panel1.TabIndex = 122;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.BackgroundImage = global::COMPUTERIZED_STATISTICAL_ROOM.Properties.Resources.iconfinder_Button_White_Check_58494;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Location = new System.Drawing.Point(451, 284);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(39, 32);
            this.pictureBox3.TabIndex = 117;
            this.pictureBox3.TabStop = false;
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.button10.FlatAppearance.BorderSize = 0;
            this.button10.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green;
            this.button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button10.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button10.ForeColor = System.Drawing.Color.White;
            this.button10.Location = new System.Drawing.Point(486, 284);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(119, 32);
            this.button10.TabIndex = 116;
            this.button10.Text = "حفظ";
            this.button10.UseVisualStyleBackColor = false;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.BackColor = System.Drawing.Color.Transparent;
            this.label34.Font = new System.Drawing.Font("Times New Roman", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.label34.ForeColor = System.Drawing.Color.White;
            this.label34.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label34.Location = new System.Drawing.Point(234, 4);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(89, 31);
            this.label34.TabIndex = 70;
            this.label34.Text = "التكليفات";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboEntity);
            this.groupBox1.Controls.Add(this.comboAssignmentsName);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.DTPEndDate);
            this.groupBox1.Controls.Add(this.DTPStartDate);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.comboAssignmentstype);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtAssignmentsID);
            this.groupBox1.Controls.Add(this.txtnum);
            this.groupBox1.Location = new System.Drawing.Point(1, 17);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(604, 242);
            this.groupBox1.TabIndex = 115;
            this.groupBox1.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(234, 125);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 19);
            this.label9.TabIndex = 122;
            this.label9.Text = "تاريخ النهاية";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(238, 84);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 19);
            this.label8.TabIndex = 121;
            this.label8.Text = "تاريخ البدء";
            // 
            // DTPEndDate
            // 
            this.DTPEndDate.Location = new System.Drawing.Point(73, 123);
            this.DTPEndDate.Name = "DTPEndDate";
            this.DTPEndDate.Size = new System.Drawing.Size(154, 20);
            this.DTPEndDate.TabIndex = 120;
            // 
            // DTPStartDate
            // 
            this.DTPStartDate.Location = new System.Drawing.Point(73, 84);
            this.DTPStartDate.Name = "DTPStartDate";
            this.DTPStartDate.Size = new System.Drawing.Size(154, 20);
            this.DTPStartDate.TabIndex = 119;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(231, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 19);
            this.label6.TabIndex = 118;
            this.label6.Text = "الجهه المكلفة";
            // 
            // comboAssignmentstype
            // 
            this.comboAssignmentstype.FormattingEnabled = true;
            this.comboAssignmentstype.Items.AddRange(new object[] {
            "رئيس قسم",
            "رئيس وحدة",
            "مشرف",
            "عضو لجنة",
            "عضو وحدة",
            "سكرتير"});
            this.comboAssignmentstype.Location = new System.Drawing.Point(324, 161);
            this.comboAssignmentstype.Name = "comboAssignmentstype";
            this.comboAssignmentstype.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.comboAssignmentstype.Size = new System.Drawing.Size(154, 21);
            this.comboAssignmentstype.TabIndex = 115;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(490, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 19);
            this.label1.TabIndex = 50;
            this.label1.Text = "رقم العضو";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(488, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 19);
            this.label2.TabIndex = 52;
            this.label2.Text = "رقم التكليف";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(487, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 19);
            this.label4.TabIndex = 54;
            this.label4.Text = "نوع التكليف";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(487, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 19);
            this.label5.TabIndex = 56;
            this.label5.Text = "اسم التكليف";
            // 
            // txtAssignmentsID
            // 
            this.txtAssignmentsID.BackColor = System.Drawing.SystemColors.Window;
            this.txtAssignmentsID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAssignmentsID.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.txtAssignmentsID.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtAssignmentsID.Location = new System.Drawing.Point(324, 84);
            this.txtAssignmentsID.Multiline = true;
            this.txtAssignmentsID.Name = "txtAssignmentsID";
            this.txtAssignmentsID.ReadOnly = true;
            this.txtAssignmentsID.Size = new System.Drawing.Size(154, 19);
            this.txtAssignmentsID.TabIndex = 51;
            this.txtAssignmentsID.Tag = "";
            this.txtAssignmentsID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtnum
            // 
            this.txtnum.BackColor = System.Drawing.SystemColors.Window;
            this.txtnum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtnum.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.txtnum.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtnum.Location = new System.Drawing.Point(324, 46);
            this.txtnum.Multiline = true;
            this.txtnum.Name = "txtnum";
            this.txtnum.ReadOnly = true;
            this.txtnum.Size = new System.Drawing.Size(154, 19);
            this.txtnum.TabIndex = 49;
            this.txtnum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // comboAssignmentsName
            // 
            this.comboAssignmentsName.FormattingEnabled = true;
            this.comboAssignmentsName.Items.AddRange(new object[] {
            "علوم الحاسب",
            "القياس و التقويم",
            "الجودة",
            "ملتقي علمي"});
            this.comboAssignmentsName.Location = new System.Drawing.Point(324, 121);
            this.comboAssignmentsName.Name = "comboAssignmentsName";
            this.comboAssignmentsName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.comboAssignmentsName.Size = new System.Drawing.Size(154, 21);
            this.comboAssignmentsName.TabIndex = 123;
            // 
            // comboEntity
            // 
            this.comboEntity.FormattingEnabled = true;
            this.comboEntity.Items.AddRange(new object[] {
            "عمادة الكلية",
            "القسم العلمي"});
            this.comboEntity.Location = new System.Drawing.Point(73, 43);
            this.comboEntity.Name = "comboEntity";
            this.comboEntity.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.comboEntity.Size = new System.Drawing.Size(154, 21);
            this.comboEntity.TabIndex = 124;
            // 
            // AssignmentsScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(640, 366);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "AssignmentsScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "التكليفات";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker DTPEndDate;
        private System.Windows.Forms.DateTimePicker DTPStartDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboAssignmentstype;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAssignmentsID;
        private System.Windows.Forms.TextBox txtnum;
        private System.Windows.Forms.ComboBox comboAssignmentsName;
        private System.Windows.Forms.ComboBox comboEntity;
    }
}