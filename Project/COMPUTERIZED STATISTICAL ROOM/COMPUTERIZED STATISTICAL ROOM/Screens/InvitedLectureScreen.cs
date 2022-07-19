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
    public partial class InvitedLectureScreen : Form
    {
        COMPUTERIZED_STATISTICAL_ROOM2Entities db = new COMPUTERIZED_STATISTICAL_ROOM2Entities();

        InvitedLecture Invite;

        int result, c = 0;

        public InvitedLectureScreen()
        {
            InitializeComponent();

            if (User.Id != 1111)
            {
                txtnum.Text = User.Id.ToString();
                Max_Value();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
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

        void Max_Value()
        {
            try
            {
                result = db.InvitedLectures.Max(x => x.LectureID) + 1;
                txtLectureID.Text = result.ToString();
            }
            catch
            {
                result = 1;
                txtLectureID.Text = result.ToString();
            }
        }

        void Clear_Data()
        {
            txtinvier.Text = "";
            txtOrganization.Text = "";
            txttitle.Text = "";
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

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();

            Thread th = new Thread(OpenScholarshipsScreen);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        void OpenScholarshipsScreen()
        {
            Application.Run(new ScholarshipsScreen());
        }
        void Add_Data()
        {
            Invite = new InvitedLecture()
            {
                StaffMemNum = User.Id,
                title = txttitle.Text,
                invier = txtinvier.Text,
                Organization = txtOrganization.Text,
                date = DTPDate.Value
            };
            db.InvitedLectures.Add(Invite);
            db.SaveChanges();
        }
    }
}
