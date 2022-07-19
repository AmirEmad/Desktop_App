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
    public partial class DissertationsSupervisedScreen : Form
    {
        COMPUTERIZED_STATISTICAL_ROOM2Entities db = new COMPUTERIZED_STATISTICAL_ROOM2Entities();

        DissertationsSupervised DissSuper;
        DissertationsSupervisedType DissSuperType;
        int  DissSuper_id;
        public DissertationsSupervisedScreen()
        {
            InitializeComponent();
            Upload_Data();
            if (User.Id != 1111)
            {
                txtnum.Text = User.Id.ToString();
                Max_Value();
            }
            txtDissertationsSupervisedType2.Text = "";
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
            comboDissertationsSupervisedType.DataSource = db.DissertationsSupervisedTypes.ToList();

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
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

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();

            Thread th = new Thread(OpenconferencePaperProceedingsform);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        void OpenconferencePaperProceedingsform()
        {
            Application.Run(new conferencePaperProceedingsScreen());
        }

        void Add_Data()
        {
            if (panel1.Visible==true)
            {
                DissSuper = new DissertationsSupervised()
                {
                    StaffMemNum = User.Id,
                    DissertationsSupervisedType = int.Parse(comboDissertationsSupervisedType.SelectedValue.ToString()),
                    Project_title = txtProjecttitle.Text,
                    year = int.Parse(comboYear.SelectedValue.ToString()),
                    institute = txtinstitute.Text
                };
                db.DissertationsSuperviseds.Add(DissSuper);
            }
            else
            {
                if (txtDissertationsSupervisedType2.Text != "")
                {
                    DissSuperType = new DissertationsSupervisedType()
                    {
                        DissertationsSupervisedType1 = txtDissertationsSupervisedType2.Text,
                    };
                    db.DissertationsSupervisedTypes.Add(DissSuperType);
                }
                
            }
            db.SaveChanges();
        }
        void Max_Value()
        {
            try
            {
                txtDissertationsSupervisedID.Text = (db.DissertationsSuperviseds.Max(x => x.DissertationsSupervisedID) + 1).ToString();
            }
            catch
            {
                txtDissertationsSupervisedID.Text = "1";
            }
            try
            {
                txtDissertationsSupervisedTypeid1.Text = (db.DissertationsSupervisedTypes.Max(x => x.DissertationsSupervisedTypeid) + 1).ToString();
            }
            catch 
            {
                txtDissertationsSupervisedTypeid1.Text = "1";
            }

        }

        void Upload_Data()
        {
            comboYear.DataSource = db.Years.ToList();
            comboYear.DisplayMember = "Year1";
            comboYear.ValueMember = "yearId";
            comboYear.SelectedValue = 0;

            comboDissertationsSupervisedType.DataSource = db.DissertationsSupervisedTypes.ToList();
            comboDissertationsSupervisedType.DisplayMember = "DissertationsSupervisedType1";
            comboDissertationsSupervisedType.ValueMember = "DissertationsSupervisedTypeid";
            comboDissertationsSupervisedType.SelectedValue = 0;

            comboDissertationsSupervised2.DataSource = db.DissertationsSupervisedTypes.ToList();
            comboDissertationsSupervised2.DisplayMember = "DissertationsSupervisedType1";
            comboDissertationsSupervised2.ValueMember = "DissertationsSupervisedTypeid";
            comboDissertationsSupervised2.SelectedValue = 0;
        }

        void Clear_Data()
        {
            if (panel1.Visible == true)
            {
                comboDissertationsSupervisedType.SelectedValue = 0;
                txtProjecttitle.Text = "";
                comboYear.SelectedValue = 0;
                txtinstitute.Text = "";
            }
            else
            {
                comboDissertationsSupervised2.DataSource = db.DissertationsSupervisedTypes.ToList();
                comboDissertationsSupervised2.SelectedValue = 0;
                txtDissertationsSupervisedType2.Text = "";
            }
        }
        void save()
        {
            var m = MessageBox.Show("هل تريد الحفظ", "", MessageBoxButtons.OKCancel);
            if (m == DialogResult.OK)
            {
                Add_Data();
                Max_Value();
                Clear_Data()
                ;
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
            var m = MessageBox.Show("هل تريد التعديل", "", MessageBoxButtons.OKCancel);
            if (m == DialogResult.OK)
            {
                if (comboDissertationsSupervised2.SelectedValue != null)
                {
                    DissSuperType.DissertationsSupervisedType1= txtDissertationsSupervisedType2.Text;
                    db.SaveChanges();
                    comboDissertationsSupervised2.DataSource = db.DissertationsSupervisedTypes.ToList();
                    comboDissertationsSupervised2.SelectedValue = 0;
                }

                MessageBox.Show("تم التعديل");
            }
            MessageBox.Show("برجاء اختيار البيانات للتعديل");
        }

        private void button17_Click(object sender, EventArgs e)
        {
            var m = MessageBox.Show("هل تريد الحذف", "", MessageBoxButtons.OKCancel);
            if (m == DialogResult.OK)
            {
                if (comboDissertationsSupervised2.SelectedValue != null)
                {
                    var r = db.DissertationsSupervisedTypes.Find(DissSuper_id);
                    try
                    {
                        db.DissertationsSupervisedTypes.Remove(r);
                        db.SaveChanges();
                    }
                    catch
                    {
                        MessageBox.Show("هذة البيانات مستخدمة مسبقا لا يمكن حذفها");
                    }
                    comboDissertationsSupervised2.DataSource = db.DissertationsSupervisedTypes.ToList();
                    comboDissertationsSupervised2.SelectedValue = 0;
                }
                MessageBox.Show("تم الحذف");
            }

            MessageBox.Show("برجاء اختيار البيانات للحذف");
        }

        private void comboDissertationsSupervised2_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                DissSuper_id = (int)comboDissertationsSupervised2.SelectedValue;
                DissSuperType = db.DissertationsSupervisedTypes.SingleOrDefault(x => x.DissertationsSupervisedTypeid == DissSuper_id);
                txtDissertationsSupervisedTypeid1.Text = DissSuperType.DissertationsSupervisedTypeid.ToString();
                txtDissertationsSupervisedType2.Text = DissSuperType.DissertationsSupervisedType1;
            }
            catch { }
        }
    }
}
