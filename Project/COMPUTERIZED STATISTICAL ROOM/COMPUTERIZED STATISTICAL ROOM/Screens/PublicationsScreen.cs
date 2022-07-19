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
    public partial class PublicationsScreen : Form
    {
        COMPUTERIZED_STATISTICAL_ROOM2Entities db = new COMPUTERIZED_STATISTICAL_ROOM2Entities();

        Publication Pub;
        PublicationsType Pubtype;
        EditionalRole Edirole;

        int Pubtype_id , Edirole_id;
        public PublicationsScreen()
        {
            InitializeComponent();

            Upload_Data();
            if (User.Id != 1111)
            {
                txtnum.Text = User.Id.ToString();
                Max_Value();
            }
            txtPublicationsType2.Text = "";
            txtEditionalRoleType2.Text = "";
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel1.Visible = true;

            comboPublicationsType.DataSource = db.PublicationsTypes.ToList();
            comboEditionalRole.DataSource = db.EditionalRoles.ToList();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel1.Visible = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();

            Thread th = new Thread(OpenHonorsAndAwardsform);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        void OpenHonorsAndAwardsform()
        {
            Application.Run(new HonorsAndAwardsScreen());
        }

        private void pictureBox4_Click(object sender, EventArgs e)
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

        private void button16_Click(object sender, EventArgs e)
        {
            PublicationsInReferredJournals pi = new PublicationsInReferredJournals();
            pi.Show();
        }

        void Upload_Data()
        {
            comboPublicationsType.DataSource = db.PublicationsTypes.ToList();
            comboPublicationsType.DisplayMember = "PublicationsType1";
            comboPublicationsType.ValueMember = "PublicationsTypeID";
            comboPublicationsType.SelectedValue = 0;

            comboEditionalRole.DataSource = db.EditionalRoles.ToList();
            comboEditionalRole.DisplayMember = "EditionalRoleType";
            comboEditionalRole.ValueMember = "EditionalRoleID";
            comboEditionalRole.SelectedValue = 0;

            comboPublications2.DataSource = db.PublicationsTypes.ToList();
            comboPublications2.DisplayMember = "PublicationsType1";
            comboPublications2.ValueMember = "PublicationsTypeID";
            comboPublications2.SelectedValue = 0;

            comboEditionalRole2.DataSource = db.EditionalRoles.ToList();
            comboEditionalRole2.DisplayMember = "EditionalRoleType";
            comboEditionalRole2.ValueMember = "EditionalRoleID";
            comboEditionalRole2.SelectedValue = 0;


        }

        void Max_Value()
        {
            try
            {
                txtPublicationsID.Text = (db.Publications.Max(x => x.PublicationsID) + 1).ToString();
            }
            catch
            {
                txtPublicationsID.Text = "1";                
            }
            try
            {
                txtPublicationsTypeID2.Text = (db.PublicationsTypes.Max(x => x.PublicationsTypeID) + 1).ToString();

            }
            catch 
            {
                txtPublicationsTypeID2.Text = "1";
            }
            try
            {
                txtEditionalRoleID2.Text = (db.EditionalRoles.Max(x => x.EditionalRoleID) + 1).ToString();
            }
            catch
            {
                txtEditionalRoleID2.Text = "1";
            }
        }

        void Add_Data()
        {
            if (panel1.Visible==true)
            {
                Pub = new Publication()
                {
                    StaffMemNum = User.Id,
                    PublicationsType = int.Parse(comboPublicationsType.SelectedValue.ToString()),
                    EditionalRole = int.Parse(comboEditionalRole.SelectedValue.ToString()),
                    Description = txtDescription.Text,
                    From = DTPFrom.Value,
                    To = DTPto.Value
                };
                db.Publications.Add(Pub);
            }
            else
            {
                if (txtPublicationsType2.Text != "")
                {
                    Pubtype = new PublicationsType()
                    {
                        PublicationsType1 = txtPublicationsType2.Text
                    };
                    db.PublicationsTypes.Add(Pubtype);
                }
                else if (txtEditionalRoleType2.Text != "")
                {
                    Edirole = new EditionalRole()
                    {
                        EditionalRoleType = txtEditionalRoleType2.Text
                    };
                    db.EditionalRoles.Add(Edirole);
                }
                
            }
            db.SaveChanges();
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

        void Clear_Data()
        {
            if (panel1.Visible == true)
            {
                comboPublicationsType.SelectedValue = 0;
                comboEditionalRole.SelectedValue = 0;
                txtDescription.Text = "";
            }
            else
            {
                comboEditionalRole2.DataSource = db.EditionalRoles.ToList();
                comboEditionalRole2.SelectedValue = 0;
                txtEditionalRoleType2.Text = "";

                comboPublications2.DataSource = db.PublicationsTypes.ToList();
                comboPublications2.SelectedValue = 0;
                txtPublicationsType2.Text = "";

                
            }
        }
        private void button10_Click(object sender, EventArgs e)
        {
            save();
        }

        private void comboEditionalRole2_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                Edirole_id = (int)comboEditionalRole2.SelectedValue;
                Edirole = db.EditionalRoles.SingleOrDefault(x => x.EditionalRoleID == Edirole_id);
                txtEditionalRoleID2.Text = Edirole.EditionalRoleID.ToString();
                txtEditionalRoleType2.Text = Edirole.EditionalRoleType;
            }
            catch { }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            var m = MessageBox.Show("هل تريد التعديل", "", MessageBoxButtons.OKCancel);
            if (m == DialogResult.OK)
            {
                if (comboEditionalRole2.SelectedValue != null)
                {
                    Edirole.EditionalRoleType = txtEditionalRoleType2.Text;
                    db.SaveChanges();
                    comboEditionalRole2.DataSource = db.EditionalRoles.ToList();
                    comboEditionalRole2.SelectedValue = 0;
                }
                else if (comboPublications2.SelectedValue != null)
                {
                    Pubtype.PublicationsType1 = txtPublicationsType2.Text;
                    db.SaveChanges();
                    comboPublications2.DataSource = db.PublicationsTypes.ToList();
                    comboPublications2.SelectedValue = 0;
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
                if (comboPublications2.SelectedValue != null)
                {
                    var r = db.PublicationsTypes.Find(Pubtype_id);
                    try
                    {
                        db.PublicationsTypes.Remove(r);
                        db.SaveChanges();
                        MessageBox.Show("تم الحذف");
                    }
                    catch
                    {
                        MessageBox.Show("هذة البيانات مستخدمة مسبقا لا يمكن حذفها");
                    }
                    comboPublications2.DataSource = db.PublicationsTypes.ToList();
                    comboPublications2.SelectedValue = 0;
                }
                if (comboEditionalRole2.SelectedValue != null)
                {
                    var r = db.EditionalRoles.Find(Edirole_id);
                    try
                    {
                        db.EditionalRoles.Remove(r);
                        db.SaveChanges();
                        MessageBox.Show("تم الحذف");
                    }
                    catch 
                    {
                        MessageBox.Show("هذة البيانات مستخدمة مسبقا لا يمكن حذفها");  
                    }
                    
                    comboEditionalRole2.DataSource = db.EditionalRoles.ToList();
                    comboEditionalRole2.SelectedValue = 0;
                }
                
            }

            MessageBox.Show("برجاء اختيار البيانات للحذف");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            save();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
        }

        private void comboPublications2_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                Pubtype_id= (int)comboPublications2.SelectedValue;
                Pubtype = db.PublicationsTypes.SingleOrDefault(x => x.PublicationsTypeID == Pubtype_id);
                txtPublicationsTypeID2.Text = Pubtype.PublicationsTypeID.ToString();
                txtPublicationsType2.Text = Pubtype.PublicationsType1;
            }
            catch { }
        }
    }
}
