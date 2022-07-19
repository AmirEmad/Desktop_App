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
    public partial class TechnicalreportsScreen : Form
    {
        COMPUTERIZED_STATISTICAL_ROOM2Entities db = new COMPUTERIZED_STATISTICAL_ROOM2Entities();

        Technicalreport Tech;
        int result, c = 0;
        public TechnicalreportsScreen()
        {
            InitializeComponent();

            Upload_Data();
            if (User.Id != 1111)
            {
                txtnum.Text = User.Id.ToString();
                Max_Value();
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
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

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            
                this.Close();

                Thread th = new Thread(OpenBooksform);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
           
            
        }
        void OpenBooksform()
        {
            Application.Run(new BooksScreen());
        }

        void Upload_Data()
        {
            comboYear.DataSource = db.Years.ToList();
            comboYear.DisplayMember = "Year1";
            comboYear.ValueMember = "yearId";
            comboYear.SelectedValue = 0;
        }

        void Max_Value()
        {
            try
            {
                result = db.Technicalreports.Max(x => x.TechnicalReportsID) + 1;
                txtTechnicalReportsID.Text = result.ToString();
            }
            catch
            {
                result = 1;
                txtTechnicalReportsID.Text = result.ToString();
            }
        }

        void Clear_Data()
        {
            txtauthor.Text = "";
            txtOrganization.Text = "";
            txttitle.Text = "";
            comboYear.SelectedValue = 0;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            var m = MessageBox.Show("هل تريد الحفظ", "", MessageBoxButtons.OKCancel);
            if (m == DialogResult.OK)
            {
                c = 1;
                Add_Data();
                Max_Value();
                Clear_Data();
                MessageBox.Show("تم الحفظ");
            }
        }

        void Add_Data()
        {
            Tech = new Technicalreport()
            {
                StaffMemNum = User.Id,
                title = txttitle.Text,
                author = txtauthor.Text,
                Organization = txtOrganization.Text,
                Year = int.Parse(comboYear.SelectedValue.ToString())
            };
            db.Technicalreports.Add(Tech);
            db.SaveChanges();
        }
    }
}
