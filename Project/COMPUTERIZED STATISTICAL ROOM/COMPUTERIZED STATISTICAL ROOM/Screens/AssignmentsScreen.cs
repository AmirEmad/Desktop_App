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
    public partial class AssignmentsScreen : Form
    {
        COMPUTERIZED_STATISTICAL_ROOM2Entities db = new COMPUTERIZED_STATISTICAL_ROOM2Entities();
        Assignment Assign;

        int result;
        public AssignmentsScreen()
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
                result = db.Assignments.Max(x => x.AssignmentsID) + 1;
                txtAssignmentsID.Text = result.ToString();
            }
            catch
            {
                result = 0;
                txtAssignmentsID.Text = result.ToString();
            }

        }
        void Add_Data()
        {
            Assign = new Assignment()
            {
                StaffMemNum = User.Id,
                Assignmentstype = comboAssignmentstype.SelectedItem.ToString(),
                AssignmentsName = comboAssignmentsName.SelectedItem.ToString(),
                //StartDate = DTPStartDate.Value,
                //EndDate = DTPEndDate.Value,
                Entity = comboEntity.SelectedItem.ToString()
            };
            db.Assignments.Add(Assign);
            db.SaveChanges();
        }

        void Clear_Data()
        {
            comboEntity.SelectedItem = null;
            comboAssignmentstype.SelectedItem= null;
            comboAssignmentsName.SelectedItem= null;
            
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
