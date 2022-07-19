using COMPUTERIZED_STATISTICAL_ROOM.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COMPUTERIZED_STATISTICAL_ROOM.Screens
{
    public partial class HonorsAndAwardsScreen : Form
    {
        COMPUTERIZED_STATISTICAL_ROOM2Entities db = new COMPUTERIZED_STATISTICAL_ROOM2Entities();
        HonorsAndAward honors;
        Award award;

        int id;
        public HonorsAndAwardsScreen()
        {
            InitializeComponent();
            Upload_Data();

            if (User.Id != 1111)
            {
                txtnum.Text = User.Id.ToString();
                Max_Value();
            }
            txtAward2.Text = "";
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
            comboAward.DataSource = db.Awards.ToList();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();

            Thread th = new Thread(OpenAcademicQualificationsform);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        void OpenAcademicQualificationsform()
        {
            Application.Run(new AcademicQualificationsScreen());
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();

            Thread th = new Thread(OpenPublicationsform);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        void OpenPublicationsform()
        {
            Application.Run(new PublicationsScreen());
        }
        void Max_Value()
        {
            try
            {
                txtAwardid.Text = (db.HonorsAndAwards.Max(x => x.Award_id) + 1).ToString();
                txtAwardId2.Text = (db.Awards.Max(x => x.AwardId) + 1).ToString();
            }
            catch
            {
                txtAwardid.Text = "1";
                txtAwardId2.Text ="1";
            }

        }

        void Add_Data()
        {
            if (panel1.Visible == true)
            {
                honors = new HonorsAndAward()
                {
                    StaffMemNum = User.Id,
                    Award = int.Parse(comboAward.SelectedValue.ToString()),
                    Organization = txtOrganization.Text,
                    Year = int.Parse(comboYear.SelectedValue.ToString()),
                    Amount = txtAmount.Text,
                    description = txtdescription.Text
                };
                db.HonorsAndAwards.Add(honors);
            }
            else
            {
                if (txtAward2.Text != "")
                {
                    award = new Award()
                    {
                        AwardName = txtAward2.Text
                    };
                    db.Awards.Add(award);

                }
            }
            db.SaveChanges();
        }

        void Upload_Data()
        {
            comboYear.DataSource = db.Years.ToList();
            comboYear.DisplayMember = "Year1";
            comboYear.ValueMember = "yearId";
            comboYear.SelectedValue = 0;
            
            comboAward.DataSource = db.Awards.ToList();
            comboAward.DisplayMember = "AwardName";
            comboAward.ValueMember = "AwardId";
            comboAward.SelectedValue = 0;

            comboAward2.DataSource = db.Awards.ToList();
            comboAward2.DisplayMember = "AwardName";
            comboAward2.ValueMember = "AwardId";
            comboAward2.SelectedValue = 0;
        }

        void Clear_Data()
        {
            if (panel1.Visible == true)
            {
                comboAward.SelectedValue = 0;
                txtOrganization.Text = "";
                comboYear.SelectedValue = 0;
                txtAmount.Text = "";
                txtdescription.Text = "";
            }
            else
            {
                comboAward2.DataSource = db.Awards.ToList();
                comboAward2.SelectedValue = 0;
                txtAward2.Text = "";
            }
        }
        void save()
        {
            var m = MessageBox.Show("هل تريد الحفظ", "", MessageBoxButtons.OKCancel);
            if (m == DialogResult.OK)
            {
                Add_Data();
                Max_Value();
                Clear_Data();
                MessageBox.Show("تم الحفظ");
            }
        }
        private void button10_Click(object sender, EventArgs e)
        {
            save();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            save();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (comboAward2.SelectedValue != null)
            {
                award.AwardName= txtAward2.Text;
                db.SaveChanges();
                MessageBox.Show("تم التعديل");
                comboAward2.DataSource = db.Awards.ToList();
                comboAward2.SelectedValue = 0;
            }
            else
            {
                MessageBox.Show("برجاء اختيار البيانات للتعديل");
            }
        }

        void Remove_Data()
        {
            if (comboAward2.SelectedValue != null)
            {
                var r = db.Awards.Find(id);
                try
                {
                    db.Awards.Remove(r);
                    db.SaveChanges();
                    MessageBox.Show("تم الحذف");
                }
                catch 
                {
                    MessageBox.Show("هذة البيانات مستخدمة مسبقا لا يمكن حذفها");
                }
                comboAward2.DataSource = db.Awards.ToList();
                comboAward2.SelectedValue = 0;
                txtAward2.Text = "";
            }
            else
            {
                MessageBox.Show("برجاء اختيار البيانات للحذف");
            }
        }
        private void button17_Click(object sender, EventArgs e)
        {
            Remove_Data();
        }

        private void comboAward2_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                id = (int)comboAward2.SelectedValue;
                award = db.Awards.SingleOrDefault(x => x.AwardId == id);
                txtAwardId2.Text = award.AwardId.ToString();
                txtAward2.Text = award.AwardName;
            }
            catch { }
        }
    }
}
