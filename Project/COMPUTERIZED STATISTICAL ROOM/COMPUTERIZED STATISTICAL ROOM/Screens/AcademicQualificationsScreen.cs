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
    public partial class AcademicQualificationsScreen : Form
    {
        COMPUTERIZED_STATISTICAL_ROOM2Entities db = new COMPUTERIZED_STATISTICAL_ROOM2Entities();

        AcademicQualification AcaQuali;
        GeneralSpecialization GenSpe;
        SpecificSpecialization Specific;
        COMPUTERIZED_STATISTICAL_ROOM.DB.Class cl;
        Degree degree;


        int GenSpe_id , Specific_id , cl_id , degree_id;
        public AcademicQualificationsScreen()
        {
            InitializeComponent();
            Upload_Data();

            if (User.Id != 1111)
            {
                txtnum.Text = User.Id.ToString();
                Max_Value();
            }

            txtSpecificSpecialization2.Text = "";
            txtGeneralSpecialization2.Text = "";
            txtdegree2.Text = "";
            txtclass2.Text = "";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
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
            comboclass.DataSource = db.Classes.ToList();
            combodegree.DataSource = db.Degrees.ToList();
            comboGeneralSpecialization.DataSource = db.GeneralSpecializations.ToList();
            comboSpecificSpecialization.DataSource = db.SpecificSpecializations.ToList();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();

            Thread th = new Thread(Openform);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        void Openform()
        {
            Application.Run(new HonorsAndAwardsScreen());
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }

        void Add_Data()
        {
            if (panel1.Visible==true)
            {
                AcaQuali = new AcademicQualification()
                {
                    StaffMemNum = User.Id,
                    degree = int.Parse(combodegree.SelectedValue.ToString()),
                    Class = int.Parse(comboclass.SelectedValue.ToString()),
                    DateofAward = DTPDateofAward.Value,
                    Institute = txtInstitute.Text,
                    Country = int.Parse(comboCountry.SelectedValue.ToString()),
                    Address = txtAddress.Text,
                    GeneralSpecialization = int.Parse(comboGeneralSpecialization.SelectedValue.ToString()),
                    SpecificSpecialization = int.Parse(comboSpecificSpecialization.SelectedValue.ToString())
                };
                db.AcademicQualifications.Add(AcaQuali);
            }
            else
            {
                //panel2
                if (txtGeneralSpecialization2.Text != "")
                {
                        GenSpe = new GeneralSpecialization()
                        {
                            GeneralSpecialization1 = txtGeneralSpecialization2.Text
                        };
                        db.GeneralSpecializations.Add(GenSpe);
                }
                if (txtSpecificSpecialization2.Text != "")
                {
                    
                        Specific = new SpecificSpecialization()
                        {
                            SpecificSpecialization1 = txtSpecificSpecialization2.Text
                        };
                        db.SpecificSpecializations.Add(Specific);
                    
                    
                    
                }
                if (txtdegree2.Text != "")
                {
                    
                        degree = new Degree()
                        {
                            degree1 = txtdegree2.Text
                        };
                        db.Degrees.Add(degree);
                    
                    
                }
                if (txtclass2.Text != "")
                {
                        cl = new COMPUTERIZED_STATISTICAL_ROOM.DB.Class()
                        {
                            class1 = txtclass2.Text
                        };
                        db.Classes.Add(cl);
                    
                    
                }
            }
            db.SaveChanges();
        }

        private void comboGeneralSpecialization2_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                GenSpe_id= (int)comboGeneralSpecialization2.SelectedValue;
                GenSpe = db.GeneralSpecializations.SingleOrDefault(x => x.GeneralSpecializationNumber == GenSpe_id);
                txtGeneralSpecialization2.Text = GenSpe.GeneralSpecialization1;
            }
            catch { }
        }

        private void comboSpecificSpecialization2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Specific_id= (int)comboSpecificSpecialization2.SelectedValue;
                Specific = db.SpecificSpecializations.SingleOrDefault(x => x.SpecificSpecializationNumber == Specific_id);
                txtSpecificSpecialization2.Text = Specific.SpecificSpecialization1;
            }
            catch { }
        }

        private void combodegree2_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                degree_id = (int)combodegree2.SelectedValue;
                degree = db.Degrees.SingleOrDefault(x => x.degreeNumber == degree_id);
                txtdegree2.Text = degree.degree1;
            }
            catch { }
        }

        private void comboclass2_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                cl_id = (int)comboclass2.SelectedValue;
                cl = db.Classes.SingleOrDefault(x => x.classNumber == cl_id);
                txtclass2.Text = cl.class1;
            }
            catch { }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            //update
            var m = MessageBox.Show("هل تريد التعديل", "", MessageBoxButtons.OKCancel);
            if (m==DialogResult.OK)
            {
                if (comboGeneralSpecialization2.SelectedValue != null)
                {
                    GenSpe.GeneralSpecialization1 = txtGeneralSpecialization2.Text;
                    db.SaveChanges();
                    comboGeneralSpecialization2.DataSource = db.GeneralSpecializations.ToList();
                    comboGeneralSpecialization2.SelectedValue = 0;
                }
                else if (comboSpecificSpecialization2.SelectedValue != null)
                {
                    Specific.SpecificSpecialization1 = txtSpecificSpecialization2.Text;
                    db.SaveChanges();
                    comboSpecificSpecialization2.DataSource = db.SpecificSpecializations.ToList();
                    comboSpecificSpecialization2.SelectedValue = 0;
                }
                else if (combodegree2.SelectedValue != null)
                {
                    degree.degree1 = txtdegree2.Text;
                    db.SaveChanges();
                    combodegree2.DataSource = db.Degrees.ToList();
                    combodegree2.SelectedValue = 0;
                }
                else if (comboclass2.SelectedValue != null)
                {
                    cl.class1 = txtclass2.Text;
                    db.SaveChanges();
                    comboclass2.DataSource = db.Classes.ToList();
                    comboclass2.SelectedValue = 0;
                }
                MessageBox.Show("تم التعديل");
            }
            MessageBox.Show("برجاء اختيار البيانات للتعديل");


        }

        private void button17_Click(object sender, EventArgs e)
        {
            //delete
            var m = MessageBox.Show("هل تريد الحذف", "", MessageBoxButtons.OKCancel);
            if (m == DialogResult.OK)
            {
                if (comboGeneralSpecialization2.SelectedValue != null)
                {
                    var r = db.GeneralSpecializations.Find(GenSpe_id);
                    try
                    {
                        db.GeneralSpecializations.Remove(r);
                        db.SaveChanges();
                        MessageBox.Show("تم الحذف");
                    }
                    catch
                    {
                        MessageBox.Show("هذة البيانات مستخدمة مسبقا لا يمكن حذفها");
                    }
                    comboGeneralSpecialization2.DataSource = db.GeneralSpecializations.ToList();
                    comboGeneralSpecialization2.SelectedValue = 0;
                    txtGeneralSpecialization2.Text = "";
                }
                if (comboSpecificSpecialization2.SelectedValue != null)
                {
                    var r = db.SpecificSpecializations.Find(Specific_id);
                    try
                    {
                        db.SpecificSpecializations.Remove(r);
                        db.SaveChanges();
                        MessageBox.Show("تم الحذف");
                    }
                    catch
                    {
                        MessageBox.Show("هذة البيانات مستخدمة مسبقا لا يمكن حذفها");
                    }
                    
                    comboSpecificSpecialization2.DataSource = db.SpecificSpecializations.ToList();
                    comboSpecificSpecialization2.SelectedValue = 0;
                    txtSpecificSpecialization2.Text = "";
                }
                if (comboclass2.SelectedValue != null)
                {
                    var r = db.Classes.Find(cl_id);
                    try
                    {
                        db.Classes.Remove(r);
                        db.SaveChanges();
                        MessageBox.Show("تم الحذف");
                    }
                    catch
                    {
                        MessageBox.Show("هذة البيانات مستخدمة مسبقا لا يمكن حذفها");
                    }
                    
                    comboclass2.DataSource = db.Classes.ToList();
                    comboclass2.SelectedValue = 0;
                    txtclass2.Text = "";
                }
                if (combodegree2.SelectedValue != null)
                {
                    var r = db.Degrees.Find(degree_id);
                    try
                    {
                        db.Degrees.Remove(r);
                        db.SaveChanges();
                        MessageBox.Show("تم الحذف");
                    }
                    catch
                    {
                        MessageBox.Show("هذة البيانات مستخدمة مسبقا لا يمكن حذفها");
                    }
                    
                    combodegree2.DataSource = db.Degrees.ToList();
                    combodegree2.SelectedValue = 0;
                    txtdegree2.Text = "";
                }
                
                
            }
            
            MessageBox.Show("برجاء اختيار البيانات للحذف");
            
            

        }

        void Upload_Data()
        {
            combodegree.DataSource = db.Degrees.ToList();
            combodegree.DisplayMember = "degree1";
            combodegree.ValueMember = "degreeNumber";
            combodegree.SelectedValue = 0;

            combodegree2.DataSource = db.Degrees.ToList();
            combodegree2.DisplayMember = "degree1";
            combodegree2.ValueMember = "degreeNumber";
            combodegree2.SelectedValue = 0;

            comboclass.DataSource = db.Classes.ToList();
            comboclass.DisplayMember = "class1";
            comboclass.ValueMember = "classNumber";
            comboclass.SelectedValue = 0;

            comboclass2.DataSource = db.Classes.ToList();
            comboclass2.DisplayMember = "class1";
            comboclass2.ValueMember = "classNumber";
            comboclass2.SelectedValue = 0;

            comboCountry.DataSource = db.Citizenships.ToList();
            comboCountry.DisplayMember = "CitizenshipName";
            comboCountry.ValueMember = "CitizenshipNumber";
            comboCountry.SelectedValue = 0;

            comboGeneralSpecialization.DataSource = db.GeneralSpecializations.ToList();
            comboGeneralSpecialization.DisplayMember = "GeneralSpecialization1";
            comboGeneralSpecialization.ValueMember = "GeneralSpecializationNumber";
            comboGeneralSpecialization.SelectedValue = 0;

            comboSpecificSpecialization.DataSource = db.SpecificSpecializations.ToList();
            comboSpecificSpecialization.DisplayMember = "SpecificSpecialization1";
            comboSpecificSpecialization.ValueMember = "SpecificSpecializationNumber";
            comboSpecificSpecialization.SelectedValue = 0;

            comboGeneralSpecialization2.DataSource = db.GeneralSpecializations.ToList();
            comboGeneralSpecialization2.DisplayMember = "GeneralSpecialization1";
            comboGeneralSpecialization2.ValueMember = "GeneralSpecializationNumber";
            comboGeneralSpecialization2.SelectedValue = 0;

            comboSpecificSpecialization2.DataSource = db.SpecificSpecializations.ToList();
            comboSpecificSpecialization2.DisplayMember = "SpecificSpecialization1";
            comboSpecificSpecialization2.ValueMember = "SpecificSpecializationNumber";
            comboSpecificSpecialization2.SelectedValue = 0;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            save();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
        }

        void Max_Value()
        {
            try
            {
                txtAqNumber.Text = (db.AcademicQualifications.Max(x => x.AqNumber) + 1).ToString();
            }
            catch
            {
                txtAqNumber.Text ="1";
                
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

        void Clear_Data()
        {
            if (panel1.Visible==true)
            {
                combodegree.SelectedValue = 0;
                comboclass.SelectedValue = 0;
                txtInstitute.Text = "";
                comboCountry.SelectedValue = 0;
                txtAddress.Text = "";
                comboGeneralSpecialization.SelectedValue = 0;
                comboSpecificSpecialization.SelectedValue = 0;
            }
            else
            {
                comboGeneralSpecialization2.DataSource = db.GeneralSpecializations.ToList();
                comboGeneralSpecialization2.SelectedValue = 0;
                txtGeneralSpecialization2.Text = "";

                comboSpecificSpecialization2.DataSource = db.SpecificSpecializations.ToList();
                comboSpecificSpecialization2.SelectedValue = 0;
                txtSpecificSpecialization2.Text = "";

                combodegree2.DataSource = db.Degrees.ToList();
                combodegree2.SelectedValue = 0;
                txtdegree2.Text = "";

                comboclass2.DataSource = db.Classes.ToList();
                comboclass2.SelectedValue = 0;
                txtclass2.Text = "";
            }
        }
        private void button10_Click(object sender, EventArgs e)
        {
            save();
        }
    }
}
