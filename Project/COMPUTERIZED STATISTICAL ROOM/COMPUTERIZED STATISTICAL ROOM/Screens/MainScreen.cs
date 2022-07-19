using COMPUTERIZED_STATISTICAL_ROOM.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COMPUTERIZED_STATISTICAL_ROOM.Screens
{
    public partial class MainScreen : Form
    {
        COMPUTERIZED_STATISTICAL_ROOM2Entities db = new COMPUTERIZED_STATISTICAL_ROOM2Entities();
        Main Staff;
        ProfessionalAffiliationMembership PAM;
        Service ser;
        LevelDegree level;
        ProfessionalExperince pro;

        int PAM_id , ser_id , level_id , pro_id;
        string imagepath = "";
        int c = 0;
        string file = "";
        public MainScreen()
        {
            InitializeComponent();
            upload_data();

            if (User.Id != 1111)
            {
                lblusername.Text = User.Name;
                txtnumber1.Text = User.Id.ToString();
                show_Data();
            }
            else
            {
                
                //btndelete.Visible = true;
                //deleteicone.Visible = true;
                
                btnAdd.Visible = true;
                addicone.Visible = true;
                txtnumber1.ReadOnly = false;
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //البيانات الاساسية
            basic_data.Visible = true;
            panel4.Visible = false;
            tabok.Visible = false;
            control.Visible = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //تسجيل الدخول
            Login login = new Login();
            login.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //الرئيسية جامعة تبوك
            tabok.Visible = true;
            basic_data.Visible = false;
            control.Visible = false;
            panel4.Visible = false;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //البيانات المهنية
            tabok.Visible = false;
            basic_data.Visible = false;
            panel4.Visible = true;
            control.Visible = true;
        }
        private void المؤهلاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AcademicQualificationsScreen Q = new AcademicQualificationsScreen();
            Q.Show();
        }

        private void الاوسمةوالجوائزToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HonorsAndAwardsScreen h = new HonorsAndAwardsScreen();
            h.Show();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            if (c>0)
            {
                AcademicQualificationsScreen Q = new AcademicQualificationsScreen();
                Q.Show();
            }
            else
            {
                MessageBox.Show("برجاء حفظ البيانات");
            }
            
        }

        private void المنشوراتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PublicationsScreen p = new PublicationsScreen();
            p.Show();
        }

        private void الاشرافعلىالرسائلالجامعيةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DissertationsSupervisedScreen d = new DissertationsSupervisedScreen();
            d.Show();
        }

        private void المنشوراتفىالمقالاتالمرجعيةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PublicationsInReferredJournals pi = new PublicationsInReferredJournals();
            pi.Show();
        }

        private void المؤتمراتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            conferencePaperProceedingsScreen c = new conferencePaperProceedingsScreen();
            c.Show();
        }

        private void التمويلToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FundingScreen f = new FundingScreen();
            f.Show();
        }

        private void التقاريرالفنيةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TechnicalreportsScreen t = new TechnicalreportsScreen();
            t.Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            BooksScreen b = new BooksScreen();
            b.Show();
        }

        private void المحاضراتالمدعوهToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InvitedLectureScreen i = new InvitedLectureScreen();
            i.Show();
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            openaddsociety();
        }

        private void العضويةالمهنيهToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openaddsociety();
        }
        void openaddsociety()
        {
            AddSociety s = new AddSociety();
            s.Show();
        }
        void openservices()
        {
            Services s = new Services();
            s.Show();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            openservices();
        }

        private void الخدماتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openservices();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            openLevelDegree();
        }

        private void مستويالدرجةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openLevelDegree();
        }
        void openLevelDegree()
        {
            LevelDegreeScreen l = new LevelDegreeScreen();
            l.Show();
        }
        void openProfessionalExperince()
        {
            ProfessionalExperinceScreen p = new ProfessionalExperinceScreen();
            p.Show();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            openProfessionalExperince();
        }

        private void الخبرةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openProfessionalExperince();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            EventsScreen E = new EventsScreen();
            E.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            RefereesScreen r = new RefereesScreen();
            r.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            AssignmentsScreen a = new AssignmentsScreen();
            a.Show();
        }

        private void المنحالدراسيةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ScholarshipsScreen s = new ScholarshipsScreen();
            s.Show();
        }

        void show_Data()
        {
           Staff = db.Mains.SingleOrDefault(x => x.StaffMemNum == User.Id);

            txtaddress1.Text = Staff.Address;
            txtname1.Text = Staff.Name;
            comboCitizenship1.SelectedValue = Staff.Citizenship;
            combogender1.SelectedValue = Staff.Gender;
            comboOccupation1.SelectedValue = Staff.Occupation;
            comboMaritalStatus1.SelectedValue = Staff.MaritalStatus;
            dateTimePicker1.Value = (DateTime)Staff.DateofBirth;
            txtPlaceofBirth1.Text = Staff.PlaceofBirth;
            pictureBox2.ImageLocation = Staff.Photo;
            txtaddress1.Text = Staff.Address;
            txtphone1.Text = Staff.ContactNum;
            txtmail1.Text = Staff.Email;
            txtWebPage1.Text = Staff.Web_Page;
            txtResidenceNationalNo1.Text = Staff.ResidenceNationalNo;
            txtWorkCity1.Text = Staff.WorkCity;

            if (Staff.FirstDateHirig != null)
            {
                dateTimePicker7.Value = (DateTime)Staff.FirstDateHirig;
                dateTimePicker8.Value = (DateTime)Staff.FirstDateTabuk;
                txtPassportNo1.Text = Staff.PassportNo;
                comboOffBuidling1.SelectedValue = Staff.OffBuidling;
                txtOfficeNo1.Text = Staff.OfficeNo.ToString();
                txtOfficeTrNo1.Text = Staff.OfficeTrNo.ToString();
                comboPassportCountry1.SelectedValue = Staff.PassportCountry;
            }
        }

        void Add_BasicData()
        {
            if (basic_data.Visible==true)
            {
                Staff.Name = txtname1.Text;
                 Staff.DateofBirth = dateTimePicker1.Value;
                Staff.PlaceofBirth = txtPlaceofBirth1.Text;
                Staff.Address = txtaddress1.Text;
                Staff.Email = txtmail1.Text;
                Staff.Web_Page = txtWebPage1.Text;
                Staff.Photo = imagepath;
                Staff.WorkCity = txtWorkCity1.Text;
                Staff.FirstDateHirig = dateTimePicker7.Value;
                Staff.FirstDateTabuk = dateTimePicker8.Value;
                Staff.PassportNo = txtPassportNo1.Text;
                int OffNo, OffTrNo;
                int.TryParse(txtOfficeNo1.Text, out OffNo);
                int.TryParse(txtOfficeTrNo1.Text, out OffTrNo);
                Staff.OfficeNo = OffNo;
                Staff.OfficeTrNo = OffTrNo;
                Staff.ResidenceNationalNo = txtResidenceNationalNo1.Text;
                Staff.Docs_certificates_ = file;
                try
                {
                    Staff.OffBuidling = int.Parse(comboOffBuidling1.SelectedValue.ToString());
                    Staff.PassportCountry = int.Parse(comboPassportCountry1.SelectedValue.ToString());
                    Staff.Citizenship = int.Parse(comboCitizenship1.SelectedValue.ToString());
                    Staff.Occupation = int.Parse(comboOccupation1.SelectedValue.ToString());
                    Staff.Gender = int.Parse(combogender1.SelectedValue.ToString());
                    Staff.MaritalStatus = int.Parse(comboMaritalStatus1.SelectedValue.ToString());

                }
                catch{ }

                if (User.Id == 1111)
                {
                    Staff.StaffMemNum = int.Parse(txtnumber1.Text);
                    db.Mains.Add(Staff);
                }

                db.SaveChanges();
                if (imagepath != "")
                {
                    string new_path = Environment.CurrentDirectory + "\\images\\users\\" + Staff.StaffMemNum + ".png";
                    File.Copy(imagepath, new_path, true);

                    Staff.Photo = new_path;
                    db.SaveChanges();
                }
                if (file != "")
                {
                    string[] f = file.Split('\\');
                    string file_name = f[(f.Length) - 1];
                    string new_file = Environment.CurrentDirectory + "\\Files\\Docs\\" + Staff.StaffMemNum + file_name;
                    File.Copy(file, new_file, true);
                    Staff.Docs_certificates_ = new_file;
                    db.SaveChanges();
                }
            }
            MessageBox.Show("تم الحفظ ");

        }

        void Add_ProData()
        {
            if (comboSociety2.SelectedValue != null )
            {
                try
                {
                    if (PAM.StaffMemNum == User.Id && PAM.society == int.Parse(comboSociety2.SelectedValue.ToString()))
                    {
                        MessageBox.Show("بيانات الانتساب المهني  موجودة بالفعل برجاء ادخال بيانات جديدة");
                    }
                }
                catch
                {
                    PAM = new ProfessionalAffiliationMembership()
                    {
                        StaffMemNum = User.Id,
                        society = int.Parse(comboSociety2.SelectedValue.ToString()),
                        from = DTASociety2.Value
                    };
                    db.ProfessionalAffiliationMemberships.Add(PAM);
                }
            }

            else if (comboServicesScope2.SelectedValue != null)
            {
                try
                {
                    if (ser.StaffMemNum == User.Id && ser.ServicesScope == int.Parse(comboServicesScope2.SelectedValue.ToString()))
                    {
                        MessageBox.Show("بيانات الخدمة موجودة بالفعل برجاء ادخال بيانات جديدة");
                    }
                }
                catch
                {
                    ser = new Service()
                    {
                        StaffMemNum = User.Id,
                        ServicesName = txtservice2.Text,
                        Task = txtTask.Text,
                        ServicesScope = int.Parse(comboServicesScope2.SelectedValue.ToString()),
                        orgnization = txtSerOrg2.Text,
                        From = DTPServiceBegin2.Value,
                        To = DTPServiceEnd2.Value,
                        description = txtServiceDes2.Text
                    };
                    db.Services.Add(ser);
                }
                
            }
            else if (comboLevelDegree2.SelectedValue != null)
            {
                try
                {
                    if (level.StaffMemNum == User.Id && level.levedegreeType == int.Parse(comboLevelDegree2.SelectedValue.ToString()))
                    {
                        MessageBox.Show(" بيانات الدرجة موجودة بالفعل برجاء ادخال بيانات جديدة");
                    }
                }
                catch 
                {
                    level = new LevelDegree()
                    {
                        StaffMemNum = User.Id,
                        title = txtLevelAddress2.Text,
                        BriefOutlines = txtBriefOutlines2.Text,
                        levedegreeType = int.Parse(comboLevelDegree2.SelectedValue.ToString()),
                        EquivalentCourseCode = int.Parse(txtCode2.Text)
                    };
                    db.LevelDegrees.Add(level);
                }
            }
            else if (comboProExpType2.SelectedValue != null)
            {
                try
                {
                    if (pro.StaffMemNum == User.Id && pro.ProfessionalExperinceType == int.Parse(comboProExpType2.SelectedValue.ToString()))
                    {
                        MessageBox.Show(" بيانات الخبرة العلمية موجودة بالفعل برجاء ادخال بيانات جديدة");
                    }
                }
                catch 
                {
                    pro = new ProfessionalExperince()
                    {
                        StaffMemNum = User.Id,
                        From = DTPExpBegin2.Value,
                        To = DTPExpEnd2.Value,
                        orgnization = txtExpOrg2.Text,
                        address = txtExpAddress.Text,
                        Country = int.Parse(comboExpCountry2.SelectedValue.ToString()),
                        occupation = int.Parse(comboExpoccupation2.SelectedValue.ToString()),
                        Description = txtExpDes.Text,
                        ProfessionalExperinceType = int.Parse(comboProExpType2.SelectedValue.ToString())
                    };
                    db.ProfessionalExperinces.Add(pro);
                }
            }
            db.SaveChanges();
            //MessageBox.Show("تم الحفظ ");
        }

        void Update_ProData()
        {
            if (comboSociety2.SelectedValue != null)
            {
                try
                {
                    if (PAM.StaffMemNum == User.Id && PAM.society == int.Parse(comboSociety2.SelectedValue.ToString()))
                    {
                        PAM.from = DTASociety2.Value;
                    }
                }
                catch
                {
                    MessageBox.Show("برجاء اختيار بيانات موجودة للتعديل");
                }
            }
            if (comboServicesScope2.SelectedValue != null)
            {
                try
                {
                    if (ser.StaffMemNum == User.Id && ser.ServicesScope == int.Parse(comboServicesScope2.SelectedValue.ToString()))
                    {
                        ser.ServicesName = txtservice2.Text;
                        ser.Task = txtTask.Text;
                        ser.orgnization = txtSerOrg2.Text;
                        ser.From = DTPServiceBegin2.Value;
                        ser.To = DTPServiceEnd2.Value;
                        ser.description = txtServiceDes2.Text;
                    }
                }
                catch
                {
                    MessageBox.Show("برجاء اختيار بيانات موجودة للتعديل");
                }
                    
            }
            if (comboLevelDegree2.SelectedValue != null)
            {
                try
                {
                    if (level.StaffMemNum == User.Id && level.levedegreeType == int.Parse(comboLevelDegree2.SelectedValue.ToString()))
                    {
                        level.title = txtLevelAddress2.Text;
                        level.BriefOutlines = txtBriefOutlines2.Text;
                        level.EquivalentCourseCode = int.Parse(txtCode2.Text);
                    }
                }
                catch
                {
                    MessageBox.Show("برجاء اختيار بيانات موجودة للتعديل");
                }

            }
            if (comboProExpType2.SelectedValue != null)
            {
                try
                {
                    if (pro.StaffMemNum == User.Id && pro.ProfessionalExperinceType == int.Parse(comboProExpType2.SelectedValue.ToString()))
                    {
                        pro.From = DTPExpBegin2.Value;
                        pro.To = DTPExpEnd2.Value;
                        pro.orgnization = txtExpOrg2.Text;
                        pro.address = txtExpAddress.Text;
                        pro.Country = int.Parse(comboExpCountry2.SelectedValue.ToString());
                        pro.occupation = int.Parse(comboExpoccupation2.SelectedValue.ToString());
                        pro.Description = txtExpDes.Text;
                    }
                }
                catch
                {
                    MessageBox.Show("برجاء اختيار بيانات موجودة للتعديل");
                }

            }
            db.SaveChanges();
            //MessageBox.Show("تم التعديل ");
        }
        private void MainScreen_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cOMPUTERIZED_STATISTICAL_ROOMDataSet6.Gender' table. You can move, or remove it, as needed.
            this.genderTableAdapter1.Fill(this.cOMPUTERIZED_STATISTICAL_ROOMDataSet6.Gender);
            // TODO: This line of code loads data into the 'cOMPUTERIZED_STATISTICAL_ROOMDataSet3.MaritalState' table. You can move, or remove it, as needed.
            this.maritalStateTableAdapter.Fill(this.cOMPUTERIZED_STATISTICAL_ROOMDataSet3.MaritalState);
            // TODO: This line of code loads data into the 'cOMPUTERIZED_STATISTICAL_ROOMDataSet1.Occupation' table. You can move, or remove it, as needed.
            this.occupationTableAdapter.Fill(this.cOMPUTERIZED_STATISTICAL_ROOMDataSet1.Occupation);
            // TODO: This line of code loads data into the 'cOMPUTERIZED_STATISTICAL_ROOMDataSet.Citizenship' table. You can move, or remove it, as needed.
            this.citizenshipTableAdapter.Fill(this.cOMPUTERIZED_STATISTICAL_ROOMDataSet.Citizenship);

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

            comboOffBuidling1.DataSource = db.OffBuidlings.ToList();
            comboOffBuidling1.DisplayMember = "MaritalType";
            comboOffBuidling1.ValueMember = "OffBuidlingID";
            comboOffBuidling1.SelectedValue = 0;

            comboPassportCountry1.DataSource = db.Citizenships.ToList();
            comboPassportCountry1.DisplayMember = "CitizenshipName";
            comboPassportCountry1.ValueMember = "CitizenshipNumber";
            comboPassportCountry1.SelectedValue = 0;

            comboSociety2.DataSource = db.societies.ToList();
            comboSociety2.DisplayMember = "societyType";
            comboSociety2.ValueMember = "societyID";
            comboSociety2.SelectedValue = 0;

            comboServicesScope2.DataSource = db.ServicesScopes.ToList();
            comboServicesScope2.DisplayMember = "ServicesScopeType";
            comboServicesScope2.ValueMember = "ServicesScopeID";
            comboServicesScope2.SelectedValue = 0;

            comboLevelDegree2.DataSource = db.levedegreeTypes.ToList();
            comboLevelDegree2.DisplayMember = "type";
            comboLevelDegree2.ValueMember = "type_id";
            comboLevelDegree2.SelectedValue = 0;

            comboProExpType2.DataSource = db.ProfessionalExperinceTypes.ToList();
            comboProExpType2.DisplayMember = "ProfessionalExperinceType1";
            comboProExpType2.ValueMember = "ProfessionalExperinceTypeID";
            comboProExpType2.SelectedValue = 0;

            comboExpCountry2.DataSource = db.Citizenships.ToList();
            comboExpCountry2.DisplayMember = "CitizenshipName";
            comboExpCountry2.ValueMember = "CitizenshipNumber";
            comboExpCountry2.SelectedValue = 0;

            comboExpoccupation2.DataSource = db.Occupations.ToList();
            comboExpoccupation2.DisplayMember = "OccupationName";
            comboExpoccupation2.ValueMember = "OccupationNumber";
            comboExpoccupation2.SelectedValue = 0;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imagepath = dialog.FileName;
                pictureBox2.ImageLocation = dialog.FileName;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            //update
            c=1;
            var r = MessageBox.Show("هل تريد حفظ التعديل ", "", MessageBoxButtons.OKCancel);
            if (r == DialogResult.OK)
            {
                if (basic_data.Visible==true)
                {
                    Add_BasicData();
                }
                if (panel4.Visible==true)
                {
                    Update_ProData();
                    MessageBox.Show("تم التعديل ");
                }
                
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            c = 0;
            this.Close();

            Thread th = new Thread(logout);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();

        }
        void logout()
        {
            var l = MessageBox.Show("هل تريد الخروج", "", MessageBoxButtons.OKCancel);
            if (l == DialogResult.OK)
            {
                Application.Run(new Login());
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (User.Id == 1111 && c==0) 
            {
                if (basic_data.Visible==true)
                {
                    Staff = new Main();
                    Add_BasicData();
                }
                else if (panel4.Visible==true)
                {
                    Add_ProData();
                }
            }
            else if (panel4.Visible == true)
            {
                Add_ProData();
                MessageBox.Show("تم الحفظ");
            }
            else
            {
                if (c != 1)
                {
                    MessageBox.Show("برجاء الضغط على زر تعديل لحفظ البيانات");
                }
                else
                {
                    MessageBox.Show("تم الحفظ");
                }
                
            }    
        }

        private void button16_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                file = dialog.FileName;
                //pictureBox2.ImageLocation = dialog.FileName;
            }
        }
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            c = 0;
            Clear_data();
        }
        
        void Clear_data()
        {
            txtnumber1.Text = "";
            txtaddress1.Text = "";
            txtname1.Text = "";
            comboCitizenship1.SelectedValue = 0;
            combogender1.SelectedValue = 0;
            comboOccupation1.SelectedValue = 0;
            comboMaritalStatus1.SelectedValue =0;
            dateTimePicker1.Value = DateTime.Today;
            txtPlaceofBirth1.Text = "";
            pictureBox2.ImageLocation = "";
            txtphone1.Text = "";
            txtmail1.Text = "";
            txtWebPage1.Text = "";
            txtResidenceNationalNo1.Text = "";
            txtWorkCity1.Text = "";
            dateTimePicker7.Value = DateTime.Today;
            dateTimePicker8.Value = DateTime.Today;
            txtPassportNo1.Text = "";
            comboOffBuidling1.SelectedValue = 0;
            txtOfficeNo1.Text = "";
            txtOfficeTrNo1.Text = "";
            comboPassportCountry1.SelectedValue = 0;
        }
        
        //private void comboSociety2_SelectedValueChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        PAM_id = (int)comboSociety2.SelectedValue;
        //        PAM = db.ProfessionalAffiliationMemberships.SingleOrDefault(x => x.society == PAM_id && x.StaffMemNum == User.Id);
        //        DTASociety2.Value = (DateTime)PAM.from;
        //    }
        //    catch { }
        //}

        private void btndelete_Click(object sender, EventArgs e)
        {

        }

        private void comboServicesScope2_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                ser_id = (int)comboServicesScope2.SelectedValue;
                ser = db.Services.SingleOrDefault(x => x.ServicesScope == ser_id && x.StaffMemNum == User.Id);

                txtservice2.Text = ser.ServicesName;
                txtTask.Text = ser.Task;
                txtSerOrg2.Text = ser.orgnization;
                DTPServiceBegin2.Value = (DateTime)ser.From;
                DTPServiceEnd2.Value = (DateTime)ser.To;
                txtServiceDes2.Text = ser.description;
            }
            catch{ }
        }
        private void comboLevelDegree2_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                level_id = (int)comboLevelDegree2.SelectedValue;
                level = db.LevelDegrees.SingleOrDefault(x => x.levedegreeType == level_id && x.StaffMemNum == User.Id);

                txtLevelAddress2.Text = level.title;
                txtBriefOutlines2.Text = level.BriefOutlines;
                txtCode2.Text = level.EquivalentCourseCode.ToString();
            }
            catch { }
        }
        private void comboProExpType2_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                pro_id = (int)comboProExpType2.SelectedValue;
                pro = db.ProfessionalExperinces.SingleOrDefault(x => x.ProfessionalExperinceType == pro_id && x.StaffMemNum == User.Id);

                DTPExpBegin2.Value = (DateTime)pro.From;
                DTPExpEnd2.Value = (DateTime)pro.To;
                txtExpOrg2.Text = pro.orgnization;
                txtExpAddress.Text = pro.address;
                comboExpCountry2.SelectedValue = pro.Country;
                comboExpoccupation2.SelectedValue = pro.occupation;
                txtExpDes.Text = pro.Description;
            }
            catch { }
        }
    }
}
