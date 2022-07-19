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
    public partial class BooksScreen : Form
    {
        COMPUTERIZED_STATISTICAL_ROOM2Entities db = new COMPUTERIZED_STATISTICAL_ROOM2Entities();
        Book book;

        int result;
        public BooksScreen()
        {
            InitializeComponent();

            comboYear.DataSource = db.Years.ToList();
            comboYear.DisplayMember = "Year";
            comboYear.ValueMember = "yearId";
            comboYear.SelectedValue = 0;

            if (User.Id != 1111)
            {
                txtnum.Text = User.Id.ToString();
                Max_Value();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
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

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();

            Thread th = new Thread(OpenInvitedLectureform);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        void OpenInvitedLectureform()
        {
            Application.Run(new InvitedLectureScreen());
        }

        void Add_Data()
        {
            book = new Book()
            {
                StaffMemNum = User.Id,
                title = txttitle.Text,
                author = txtauthor.Text,
                Organization = txtOrganization.Text,
                Year = int.Parse(comboYear.SelectedValue.ToString()),
                Publisher = txtPublisher.Text,
                ISBN = txtISBN.Text,
                chapters = int.Parse(txtchapters.Text)
            };
            db.Books.Add(book);
            db.SaveChanges();
        }
        void Max_Value()
        {
            try
            {
                result = db.Books.Max(x => x.BookID) + 1;
                txtBookID.Text = result.ToString();
            }
            catch
            {
                result = 0;
                txtBookID.Text = result.ToString();
            }

        }

        void Clear_Data()
        {
            txttitle.Text = "";
            txtauthor.Text = "";
            txtOrganization.Text = "";
            txtPublisher.Text = "";
            txtISBN.Text = "";
            txtchapters.Text = "";
            comboYear.SelectedValue = 0;
        }
        private void button10_Click(object sender, EventArgs e)
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
    }
}
