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
    public partial class FundingScreen : Form
    {
        COMPUTERIZED_STATISTICAL_ROOM2Entities db = new COMPUTERIZED_STATISTICAL_ROOM2Entities();

        Funding funding;
        public FundingScreen()
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

                Thread th = new Thread(OpenconferencePaperProceedingsform);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
            
            
        }
        void OpenconferencePaperProceedingsform()
        {
            Application.Run(new conferencePaperProceedingsScreen());
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
                this.Close();

                Thread th = new Thread(OpenTechnicalreportsform);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
           

        }
        void OpenTechnicalreportsform()
        {
            Application.Run(new TechnicalreportsScreen());
        }

        void Upload_Data()
        {
            comboyear.DataSource = db.Years.ToList();
            comboyear.DisplayMember = "Year1";
            comboyear.ValueMember = "yearId";
            comboyear.SelectedValue = 0;
        }
            void Add_Data()
        {
            funding = new Funding()
            {
                StaffMemNum = User.Id,
                ResearchTitle = txtResearchTitle.Text,
                Sponser = txtSponser.Text,
                year = int.Parse(comboyear.SelectedValue.ToString()),
                amount = txtamount.Text,
                description = txtdescription.Text
            };
            db.Fundings.Add(funding);
            db.SaveChanges();
        }

        void Max_Value()
        {
            try
            {
                txtfundingID.Text = (db.Fundings.Max(x => x.fundingID) + 1).ToString();
            }
            catch
            {
                txtfundingID.Text = "1";
            }
        }

        void Clear_Data()
        {
            txtResearchTitle.Text = "";
            txtSponser.Text = "";
            txtamount.Text = "";
            txtamount.Text = "";
            txtdescription.Text = "";
            comboyear.SelectedValue = 0;
        }
        private void button10_Click(object sender, EventArgs e)
        {
            var m = MessageBox.Show("هل تريد الحفظ", "", MessageBoxButtons.OKCancel);
            if (m == DialogResult.OK )
            {
                Add_Data();
                Max_Value();
                Clear_Data();
                MessageBox.Show("تم الحفظ");
            }
        }
    }
}
