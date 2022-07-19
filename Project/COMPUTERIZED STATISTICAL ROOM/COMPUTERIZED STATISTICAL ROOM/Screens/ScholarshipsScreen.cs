using COMPUTERIZED_STATISTICAL_ROOM.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COMPUTERIZED_STATISTICAL_ROOM.Screens
{
    public partial class ScholarshipsScreen : Form
    {
        COMPUTERIZED_STATISTICAL_ROOM2Entities db = new COMPUTERIZED_STATISTICAL_ROOM2Entities();

        ScholarshipsDetail Scholar;
        schoolardegree degree;
        ScholarshipCase SchCase;
        
        int degree_id , SchCase_id;
        public ScholarshipsScreen()
        {
            InitializeComponent();

            Upload_Data();
            if (User.Id != 1111)
            {
                txtnum.Text = User.Id.ToString();
                Max_Value();
            }
            txtschoolardegree2.Text = "";
            txtScholarshipCaseName.Text = "";
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
            comboScholarshipDegree.DataSource = db.schoolardegrees.ToList();
            comboCase.DataSource = db.ScholarshipCases.ToList();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
        }

        void Upload_Data()
        {
            comboScholarshipDegree.DataSource = db.schoolardegrees.ToList();
            comboScholarshipDegree.DisplayMember = "schoolardegree1";
            comboScholarshipDegree.ValueMember = "schoolardegreeID";
            comboScholarshipDegree.SelectedValue = 0;

            comboScholarshipCountry.DataSource = db.Citizenships.ToList();
            comboScholarshipCountry.DisplayMember = "CitizenshipName";
            comboScholarshipCountry.ValueMember = "CitizenshipNumber";
            comboScholarshipCountry.SelectedValue = 0;

            comboGeneralSpecialization.DataSource = db.GeneralSpecializations.ToList();
            comboGeneralSpecialization.DisplayMember = "GeneralSpecialization1";
            comboGeneralSpecialization.ValueMember = "GeneralSpecializationNumber";
            comboGeneralSpecialization.SelectedValue = 0;

            comboSpecificSpecialization.DataSource = db.SpecificSpecializations.ToList();
            comboSpecificSpecialization.DisplayMember = "SpecificSpecialization1";
            comboSpecificSpecialization.ValueMember = "SpecificSpecializationNumber";
            comboSpecificSpecialization.SelectedValue = 0;

            comboCase.DataSource = db.ScholarshipCases.ToList();
            comboCase.DisplayMember = "ScholarshipCaseName";
            comboCase.ValueMember = "ScholarshipCaseId";
            comboCase.SelectedValue = 0;

            comboScholarshipCase2.DataSource = db.ScholarshipCases.ToList();
            comboScholarshipCase2.DisplayMember = "ScholarshipCaseName";
            comboScholarshipCase2.ValueMember = "ScholarshipCaseId";
            comboScholarshipCase2.SelectedValue = 0;

            comboschoolardegree2.DataSource = db.schoolardegrees.ToList();
            comboschoolardegree2.DisplayMember = "schoolardegree1";
            comboschoolardegree2.ValueMember = "schoolardegreeID";
            comboschoolardegree2.SelectedValue = 0;

        }

        void Max_Value()
        {
            try
            {
                txtScholarshipID.Text = (db.ScholarshipsDetails.Max(x => x.ScholarshipID) + 1).ToString();
            }
            catch
            {
                txtScholarshipID.Text = "1";
            }
            try
            {
                txtScholarshipCaseId2.Text = (db.ScholarshipCases.Max(x => x.ScholarshipCaseId) + 1).ToString();
            }
            catch 
            {
                txtScholarshipCaseId2.Text = "1";
            }
            try
            {
                txtschoolardegreeID2.Text = (db.schoolardegrees.Max(x => x.schoolardegreeID) + 1).ToString();

            }
            catch
            {
                txtschoolardegreeID2.Text = "1";
            }
        }

        void Add_Data()
        {
            if (panel1.Visible == true)
            {
                int letterNum;
                int.TryParse(txtScholarshipLetterNumber.Text, out letterNum);
                Scholar = new ScholarshipsDetail()
                {
                    StaffMemNum = User.Id,
                    ScholarshipDegree = int.Parse(comboScholarshipDegree.SelectedValue.ToString()),
                    ScholarshipCountry = int.Parse(comboScholarshipCountry.SelectedValue.ToString()),
                    GeneralSpecialization = int.Parse(comboGeneralSpecialization.SelectedValue.ToString()),
                    SpecificSpecialization = int.Parse(comboSpecificSpecialization.SelectedValue.ToString()),
                    StartDate = DTPStartDate.Value,
                    EndDate = DTPEndDate.Value,
                    ScholarshipLetterNumber = letterNum,
                    Case = int.Parse(comboCase.SelectedValue.ToString()),
                };
                db.ScholarshipsDetails.Add(Scholar);
            }
            else
            {
                if(txtScholarshipCaseName.Text != "")
                {
                    SchCase = new ScholarshipCase()
                    {
                        ScholarshipCaseName = txtScholarshipCaseName.Text
                    };
                    db.ScholarshipCases.Add(SchCase);
                }
                if (txtschoolardegree2.Text != "")
                {
                    degree = new schoolardegree()
                    {
                        schoolardegree1 = txtschoolardegree2.Text,
                    };
                    db.schoolardegrees.Add(degree);
                }
            }

            db.SaveChanges();
        }

        void Clear_Data()
        {
            if (panel1.Visible == true)
            {
                txtScholarshipLetterNumber.Text = "";
                comboGeneralSpecialization.SelectedValue = 0;
                comboSpecificSpecialization.SelectedValue = 0;
                comboScholarshipCountry.SelectedValue = 0;
                comboScholarshipDegree.SelectedValue = 0;
                comboCase.SelectedValue = 0;

            }
            else
            {
                comboschoolardegree2.DataSource = db.schoolardegrees.ToList();
                comboschoolardegree2.SelectedValue = 0;
                txtschoolardegree2.Text = "";

                comboScholarshipCase2.DataSource = db.ScholarshipCases.ToList();
                comboScholarshipCase2.SelectedValue = 0;
                txtScholarshipCaseName.Text = "";

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
            var m = MessageBox.Show("هل تريد التعديل", "", MessageBoxButtons.OKCancel);
            if (m == DialogResult.OK)
            {
                if (comboScholarshipCase2.SelectedValue != null)
                {
                    SchCase.ScholarshipCaseName = txtScholarshipCaseName.Text;
                    db.SaveChanges();
                    comboScholarshipCase2.DataSource = db.ScholarshipCases.ToList();
                    comboScholarshipCase2.SelectedValue = 0;
                }
                else if (comboschoolardegree2.SelectedValue != null)
                {
                    degree.schoolardegree1 = txtschoolardegree2.Text;
                    db.SaveChanges();
                    comboschoolardegree2.DataSource = db.schoolardegrees.ToList();
                    comboschoolardegree2.SelectedValue = 0;
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
                if (comboschoolardegree2.SelectedValue != null)
                {
                    var r = db.schoolardegrees.Find(degree_id);
                    try
                    {
                        db.schoolardegrees.Remove(r);
                        db.SaveChanges();
                        MessageBox.Show("تم الحذف");
                    }
                    catch
                    {
                        MessageBox.Show("هذة البيانات مستخدمة مسبقا لا يمكن حذفها");
                    }
                    comboschoolardegree2.DataSource = db.schoolardegrees.ToList();
                    comboschoolardegree2.SelectedValue = 0;
                }
                else if (comboScholarshipCase2.SelectedValue != null)
                {
                    var r = db.ScholarshipCases.Find(SchCase_id);
                    try
                    {
                        db.ScholarshipCases.Remove(r);
                        db.SaveChanges();
                        MessageBox.Show("تم الحذف");
                    }
                    catch 
                    {
                        MessageBox.Show("هذة البيانات مستخدمة مسبقا لا يمكن حذفها");
                    }
                    comboScholarshipCase2.DataSource = db.EditionalRoles.ToList();
                    comboScholarshipCase2.SelectedValue = 0;
                }
            }
        }
        private void comboschoolardegree2_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                degree_id = (int)comboschoolardegree2.SelectedValue;
                degree = db.schoolardegrees.SingleOrDefault(x => x.schoolardegreeID == degree_id);
                txtschoolardegreeID2.Text = degree.schoolardegreeID.ToString();
                txtschoolardegree2.Text = degree.schoolardegree1;
            }
            catch { }
        }
        private void comboScholarshipCase2_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                SchCase_id= (int)comboScholarshipCase2.SelectedValue;
                SchCase = db.ScholarshipCases.SingleOrDefault(x => x.ScholarshipCaseId == SchCase_id);
                txtScholarshipCaseId2.Text = SchCase.ScholarshipCaseId.ToString();
                txtScholarshipCaseName.Text = SchCase.ScholarshipCaseName;
            }
            catch { }
        }
    }
}
