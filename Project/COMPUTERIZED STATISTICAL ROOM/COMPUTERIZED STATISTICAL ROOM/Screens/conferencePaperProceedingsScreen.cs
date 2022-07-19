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
    public partial class conferencePaperProceedingsScreen : Form
    {
        COMPUTERIZED_STATISTICAL_ROOM2Entities db = new COMPUTERIZED_STATISTICAL_ROOM2Entities();

        conferencePaperProceeding Conf;
        ConferenceType ConfType;

        int id;
        public conferencePaperProceedingsScreen()
        {
            InitializeComponent();
            Upload_Data();

            if (User.Id != 1111)
            {
                txtnum.Text = User.Id.ToString();
                Max_Value();
            }
            txtconfType2.Text = "";
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
            comboConfPaperType.DataSource = db.ConferenceTypes.ToList();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
                this.Close();

                Thread th = new Thread(OpenDissertationsSupervisedform);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
            
            
        }
        void OpenDissertationsSupervisedform()
        {
            Application.Run(new DissertationsSupervisedScreen());
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            
                this.Close();

                Thread th = new Thread(OpenFundingform);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
            
            
        }
        void OpenFundingform()
        {
            Application.Run(new FundingScreen());
        }

        void Upload_Data()
        {
            comboYear.DataSource = db.Years.ToList();
            comboYear.DisplayMember = "Year1";
            comboYear.ValueMember = "yearId";
            comboYear.SelectedValue = 0;

            comboConfPaperType.DataSource = db.ConferenceTypes.ToList();
            comboConfPaperType.DisplayMember = "conferenceType1";
            comboConfPaperType.ValueMember = "conferenceTypeid";
            comboConfPaperType.SelectedValue = 0;

            comboconfType2.DataSource = db.ConferenceTypes.ToList();
            comboconfType2.DisplayMember = "conferenceType1";
            comboconfType2.ValueMember = "conferenceTypeid";
            comboconfType2.SelectedValue = 0;
        }
        void Max_Value()
        {
            try
            {
                txtConfPaperID.Text = (db.conferencePaperProceedings.Max(x => x.ConferencePaperID) + 1).ToString();
                txtconfTypeid2.Text = (db.ConferenceTypes.Max(x => x.conferenceTypeid) + 1).ToString();
            }
            catch
            {
                txtConfPaperID.Text = "1";
                txtconfTypeid2.Text = "1";
            }

        }

        void Add_Data()
        {
            if (panel1.Visible == true)
            {
                Conf = new conferencePaperProceeding()
                {
                    StaffMemNum = User.Id,
                    ConferenceType = int.Parse(comboConfPaperType.SelectedValue.ToString()),
                    papeTitle = txtpapeTitle.Text,
                    authors = txtauthors.Text,
                    place = txtplace.Text,
                    Proceeding = txtProceeding.Text,
                    Year = int.Parse(comboYear.SelectedValue.ToString()),
                    from = DTPfrom.Value,
                    to = DTPto.Value
                };
                db.conferencePaperProceedings.Add(Conf);
            }
            else
            {
                if (txtconfTypeid2.Text != "")
                {
                    ConfType = new ConferenceType()
                    {
                        conferenceType1 = txtconfType2.Text
                    };
                    db.ConferenceTypes.Add(ConfType);
                }   
            }
            db.SaveChanges();
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
            if (comboconfType2.SelectedValue != null)
            {
                ConfType.conferenceType1 = txtconfType2.Text;
                db.SaveChanges();
                MessageBox.Show("تم التعديل");
                Reload_Data();
            }
            else
            {
                MessageBox.Show("برجاء اختيار البيانات للتعديل");
            }
            txtconfType2.Text = "";
        }

        private void comboconfType2_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                id = (int)comboconfType2.SelectedValue;
                ConfType = db.ConferenceTypes.SingleOrDefault(x => x.conferenceTypeid == id);
                txtconfType2.Text = ConfType.conferenceType1;
                txtconfTypeid2.Text = ConfType.conferenceTypeid.ToString();
            }
            catch { }
        }

        void Remove_Data()
        {
            if (comboconfType2.SelectedValue != null)
            {
                var r = db.ConferenceTypes.Find(id);
                try
                {
                    db.ConferenceTypes.Remove(r);
                    db.SaveChanges();
                    MessageBox.Show("تم الحذف");
                }
                catch 
                {
                    MessageBox.Show("هذة البيانات مستخدمة مسبقا لا يمكن حذفها");
                }

                Reload_Data();
            }
            else
            {
                MessageBox.Show("برجاء اختيار البيانات للحذف");
            }
            txtconfType2.Text = "";
        }
        private void button17_Click(object sender, EventArgs e)
        {
            Remove_Data();
        }

        void Clear_Data()
        {
            if (panel1.Visible == true)
            {
                comboConfPaperType.SelectedValue = 0;
                txtpapeTitle.Text = "";
                txtauthors.Text = "";
                txtplace.Text = "";
                txtProceeding.Text = "";
                comboYear.SelectedValue = 0;

            }
            else
            {
                Reload_Data();
                txtconfType2.Text = "";
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

        void Reload_Data()
        {
            comboconfType2.DataSource = db.ConferenceTypes.ToList();
            comboconfType2.SelectedValue = 0;
        }
    }
}
