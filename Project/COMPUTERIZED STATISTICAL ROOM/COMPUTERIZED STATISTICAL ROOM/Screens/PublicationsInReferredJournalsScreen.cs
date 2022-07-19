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
    public partial class PublicationsInReferredJournals : Form
    {
        COMPUTERIZED_STATISTICAL_ROOM2Entities db = new COMPUTERIZED_STATISTICAL_ROOM2Entities();
        PublicationsInReferredJournal Pub;

        int  c = 0;
        public PublicationsInReferredJournals()
        {
            InitializeComponent();
            Upload_Data();
            if (User.Id != 1111)
            {
                txtnum.Text = User.Id.ToString();
                Max_Value();
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (c==1)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("برجاء حفظ البيانات اولاً");
            }
            

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
                txtPuplishID.Text = (db.PublicationsInReferredJournals.Max(x => x.PuplishID) + 1).ToString();
                
            }
            catch
            {
                
                txtPuplishID.Text = "1";
            }
        }

        void Add_Data()
        {
            int v, p;
            int.TryParse(txtVolume.Text,out v);
            int.TryParse(txtpages.Text, out p);
            Pub = new PublicationsInReferredJournal()
            {
                StaffMemNum = User.Id,
                Journal = txtJournal.Text,
                ArticleTitle = txtArticleTitle.Text,
                authors = txtauthors.Text,
                Volume = v,
                pages = p,
                Indexer = txtIndexer.Text,
                Year = int.Parse(comboYear.SelectedValue.ToString())
            };
            db.PublicationsInReferredJournals.Add(Pub);
            db.SaveChanges();
        }
        void Clear_Data()
        {
            txtJournal.Text = "";
            txtArticleTitle.Text = "";
            txtauthors.Text = "";
            txtVolume.Text = "";
            txtpages.Text = "";
            txtIndexer.Text = "";
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
    }
}
