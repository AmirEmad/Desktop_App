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
    public partial class RefereesScreen : Form
    {
        COMPUTERIZED_STATISTICAL_ROOM2Entities db = new COMPUTERIZED_STATISTICAL_ROOM2Entities();
        Referee Ref;

        int result;
        public RefereesScreen()
        {
            InitializeComponent();

            if (User.Id != 1111)
            {
                txtnum.Text = User.Id.ToString();
                Max_Value();
            }
        }

        void Max_Value()
        {
            try
            {
                result = db.Referees.Max(x => x.RefereeID) + 1;
                txtRefereeID.Text = result.ToString();
            }
            catch 
            {
                result = 0;
                txtRefereeID.Text = result.ToString();
            }
            
        }
        void Add_Data()
        {
            Ref = new Referee()
            {
                StaffMemNum = User.Id,
                name = txtName.Text,
                Position=txtPosition.Text,
                Affiliation=txtAffiliation.Text,
                Address=txtAddress.Text,
                Email=txtEmail.Text,
                ContactNumber=int.Parse(txtContactNumber.Text)
            };
            db.Referees.Add(Ref);
            db.SaveChanges();
            
        }

        void Clear_Data()
        {
            txtName.Text = "";
            txtPosition.Text = "";
            txtAffiliation.Text = "";
            txtAddress.Text = "";
            txtEmail.Text = "";
            txtContactNumber.Text = "";
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
