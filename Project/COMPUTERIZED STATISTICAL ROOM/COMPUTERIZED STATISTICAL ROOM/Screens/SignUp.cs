using COMPUTERIZED_STATISTICAL_ROOM.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COMPUTERIZED_STATISTICAL_ROOM.Screens
{
    public partial class SignUp : Form
    {
        COMPUTERIZED_STATISTICAL_ROOM2Entities db = new COMPUTERIZED_STATISTICAL_ROOM2Entities();
        string imagepath = "";


        public SignUp()
        {
            InitializeComponent();
            upload_data();

        }

        void Add_Data()
        {
            Main user = new Main()
            {
                StaffMemNum = int.Parse(txtnumber.Text),
                Name = txtname.Text,
                ContactNum = txtphone.Text,
                DateofBirth = dateTimePicker1.Value,
                PlaceofBirth = txtPlaceofBirth.Text,
                Address = txtaddress.Text,
                Photo = imagepath,
                Citizenship = int.Parse(comboCitizenship1.SelectedValue.ToString()),
                Occupation = int.Parse(comboOccupation1.SelectedValue.ToString()),
                Gender = int.Parse(combogender1.SelectedValue.ToString()),
                MaritalStatus = int.Parse(comboMaritalStatus1.SelectedValue.ToString())
            };

            db.Mains.Add(user);
            db.SaveChanges();
            if (imagepath != "")
            {
                string new_path = Environment.CurrentDirectory + "\\images\\users\\" + user.StaffMemNum + ".png";
                File.Copy(imagepath, new_path,true);

                user.Photo = new_path;
                db.SaveChanges();
            }
            MessageBox.Show("تم الحفظ ");
        }


        //private void SignUp_Load(object sender, EventArgs e)
        //{
        //    // TODO: This line of code loads data into the 'cOMPUTERIZED_STATISTICAL_ROOMDataSet7.Gender' table. You can move, or remove it, as needed.
        //    this.genderTableAdapter1.Fill(this.cOMPUTERIZED_STATISTICAL_ROOMDataSet7.Gender);
        //    dateTimePicker1.Value = DateTime.Today;
        //    // TODO: This line of code loads data into the 'cOMPUTERIZED_STATISTICAL_ROOMDataSet3.MaritalState' table. You can move, or remove it, as needed.
        //    this.maritalStateTableAdapter.Fill(this.cOMPUTERIZED_STATISTICAL_ROOMDataSet3.MaritalState);
        //    // TODO: This line of code loads data into the 'cOMPUTERIZED_STATISTICAL_ROOMDataSet1.Occupation' table. You can move, or remove it, as needed.
        //    this.occupationTableAdapter.Fill(this.cOMPUTERIZED_STATISTICAL_ROOMDataSet1.Occupation);
        //    // TODO: This line of code loads data into the 'cOMPUTERIZED_STATISTICAL_ROOMDataSet.Citizenship' table. You can move, or remove it, as needed.
        //    this.citizenshipTableAdapter.Fill(this.cOMPUTERIZED_STATISTICAL_ROOMDataSet.Citizenship);
            
        //}

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imagepath = dialog.FileName;
                pictureBox2.ImageLocation = dialog.FileName;
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (txtnumber.Text=="" || txtname.Text== "" || txtphone.Text=="")
            {
                MessageBox.Show("برجاء اكمال البيانات");
            }
            else
            {
                var r = MessageBox.Show("هل تريد الحفظ ", "", MessageBoxButtons.OKCancel);
                if (r == DialogResult.OK)
                {
                    Add_Data();
                   // Clear_Data();
                    this.Close();
                }
                
            }
        }

        void Clear_Data()
        {
            txtnumber.Text = "";
            txtphone.Text = "";
            txtname.Text = "";
            txtaddress.Text = "";
            txtPlaceofBirth.Text = "";

        }

        private void txtnumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtphone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        void upload_data()
        {
            comboCitizenship1.DataSource = db.Citizenships.ToList();
            comboCitizenship1.DisplayMember = "CitizenshipName";
            comboCitizenship1.ValueMember = "CitizenshipNumber";
            comboCitizenship1.SelectedValue = 0;

            comboOccupation1.DataSource = db.Occupations.ToList();
            comboOccupation1.DisplayMember = "OccupationName";
            comboOccupation1.ValueMember = "OccupationNumber";
            comboOccupation1.SelectedValue = 0;

            combogender1.DataSource = db.Genders.ToList();
            combogender1.DisplayMember = "Gender_Type";
            combogender1.ValueMember = "GenderNumber";
            combogender1.SelectedValue = 0;

            comboMaritalStatus1.DataSource = db.MaritalStates.ToList();
            comboMaritalStatus1.DisplayMember = "MaritalType";
            comboMaritalStatus1.ValueMember = "MaritalNumber";
            comboMaritalStatus1.SelectedValue = 0;
            
        }
    }
}
