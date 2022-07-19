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
    public partial class AddSociety : Form
    {
        COMPUTERIZED_STATISTICAL_ROOM2Entities db = new COMPUTERIZED_STATISTICAL_ROOM2Entities();
        society soc;

        int id;
        int result;
        public AddSociety()
        {
            InitializeComponent();

            combosociety.DataSource = db.societies.ToList();
            combosociety.DisplayMember = "societyType";
            combosociety.ValueMember = "societyID";
            combosociety.SelectedValue = 0;

            max_value();
            txtSocName.Text = "";
        }

        void max_value()
        {
            result = db.societies.Max(x => x.societyID) + 1;
            txtSocNum.Text = result.ToString();
        }
        private void Add_Click(object sender, EventArgs e)
        {
            soc = new society()
            {
                //societyID = result,
                societyType = txtSocName.Text,
            };

            db.societies.Add(soc);

            db.SaveChanges();
            MessageBox.Show("تم الحفظ");

            combosociety.DataSource = db.societies.ToList();
            combosociety.SelectedValue = 0;
            max_value();
            txtSocName.Text = "";
        }

        private void combosociety_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {            

            id =(int) combosociety.SelectedValue;
            soc = db.societies.SingleOrDefault(x => x.societyID == id);
            txtSocNum.Text = soc.societyID.ToString();
            txtSocName.Text = soc.societyType;
            }
            catch
            { }
        }

        void RemoveData()
        {
            if (combosociety.SelectedValue != null)
            {
                var r = db.societies.Find(id);
                try
                {
                    db.societies.Remove(r);
                    db.SaveChanges();
                    MessageBox.Show("تم الحذف");
                }
                catch
                {
                    MessageBox.Show("هذة البيانات مستخدمة مسبقا لا يمكن حذفها");
                }

                combosociety.DataSource = db.societies.ToList();
                combosociety.SelectedValue = 0;
            }
            else
            {
                MessageBox.Show("برجاء اختيار البيانات للحذف");
            }
            
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            RemoveData();
        }

        private void Update_Click(object sender, EventArgs e)
        {
            if (combosociety.SelectedValue != null)
            {
                soc.societyType = txtSocName.Text;
                db.SaveChanges();
                MessageBox.Show("تم التعديل");
                combosociety.DataSource = db.societies.ToList();
                combosociety.SelectedValue = 0;
            }
            else
            {
                MessageBox.Show("برجاء اختيار البيانات للتعديل");
            }
        }
    }
}
