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
    public partial class EventsScreen : Form
    {
        COMPUTERIZED_STATISTICAL_ROOM2Entities db = new COMPUTERIZED_STATISTICAL_ROOM2Entities();

        EventAttended EveAttended;
        EventsAttendedType EveAttendedType;

        int result,id;
        public EventsScreen()
        {
            InitializeComponent();

            Upload_Data();

            if (User.Id != 1111)
            {
                txtnum.Text = User.Id.ToString();
                Max_Value();
            }
        }

        void Upload_Data()
        {
            comboyear.DataSource = db.Years.ToList();
            comboyear.DisplayMember = "Year";
            comboyear.ValueMember = "yearId";
            comboyear.SelectedValue = 0;

            comboEvents.DataSource = db.EventsAttendedTypes.ToList();
            comboEvents.DisplayMember = "EventsAttendedType";
            comboEvents.ValueMember = "EventsAttendedTypeID";
            comboEvents.SelectedValue = 0;

            comboEventsAttendedType.DataSource = db.EventsAttendedTypes.ToList();
            comboEventsAttendedType.DisplayMember = "EventsAttendedType";
            comboEventsAttendedType.ValueMember = "EventsAttendedTypeID";
            comboEventsAttendedType.SelectedValue = 0;
        }
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
        }

        void Add_Data()
        {
            if (panel1.Visible==true)
            {
                EveAttended = new EventAttended()
                {
                    StaffMemNum = User.Id,
                    EventsAttendedType = int.Parse(comboEventsAttendedType.SelectedValue.ToString()),
                    Title = txtTitle.Text,
                    Organization = txtOrganization.Text,
                    Place = txtPlace.Text,
                    //from = DTPfrom.Value,
                    //to = DTPto.Value,
                    year = int.Parse(comboyear.SelectedValue.ToString())
                };
                db.EventAttendeds.Add(EveAttended);
            }
            else
            {
                EveAttendedType = new EventsAttendedType()
                {
                    EventsAttendedType1 = txtEventsAttendedType.Text
                };
                db.EventsAttendedTypes.Add(EveAttendedType);
            }
            
            db.SaveChanges();
        }
        void Max_Value()
        {
            try
            {
                if (panel1.Visible==true)
                {
                    result = db.EventAttendeds.Max(x => x.EventsAttendedID) + 1;
                    txtEventsAttendedID.Text = result.ToString();
                }
                else
                {
                    result = db.EventsAttendedTypes.Max(x => x.EventsAttendedTypeID) + 1;
                    txtEventsAttendedTypeID.Text = result.ToString();
                }
                
            }
            catch
            {
                result = 1;
                if (panel1.Visible==true)
                {
                    txtEventsAttendedID.Text = result.ToString();
                }
                else
                {
                    txtEventsAttendedTypeID.Text = result.ToString();
                }


            }

        }

        void Clear_Data()
        {
            if (panel1.Visible==true)
            {
                txtTitle.Text = "";
                txtPlace.Text = "";
                txtOrganization.Text = "";
                comboEventsAttendedType.SelectedValue = 0;
                comboyear.SelectedValue = 0;
            }
            else
            {
                comboEvents.DataSource = db.EventsAttendedTypes.ToList();
                comboEvents.SelectedValue = 0;
                txtEventsAttendedType.Text = "";
            }
        }

        void save()
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
        private void button10_Click(object sender, EventArgs e)
        {
            save();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            save();
        }

        void Remove_Data()
        {
            if (comboEvents.SelectedValue != null)
            {
                var r = db.EventsAttendedTypes.Find(id);
                db.EventsAttendedTypes.Remove(r);

                db.SaveChanges();
                MessageBox.Show("تم الحذف");
                comboEvents.DataSource = db.EventsAttendedTypes.ToList();
                comboEvents.SelectedValue = 0;
            }
            else
            {
                MessageBox.Show("برجاء اختيار البيانات للحذف");
            }
        }
        private void button17_Click(object sender, EventArgs e)
        {

            Remove_Data();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (comboEvents.SelectedValue != null)
            {
                EveAttendedType.EventsAttendedType1 = txtEventsAttendedType.Text;
                db.SaveChanges();
                MessageBox.Show("تم التعديل");
                comboEvents.DataSource = db.EventsAttendedTypes.ToList();
                comboEvents.SelectedValue = 0;
            }
            else
            {
                MessageBox.Show("برجاء اختيار البيانات للتعديل");
            }
        }

        private void comboEvents_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                id = (int)comboEvents.SelectedValue;
                EveAttendedType = db.EventsAttendedTypes.SingleOrDefault(x => x.EventsAttendedTypeID == id);
                txtEventsAttendedTypeID.Text = EveAttendedType.EventsAttendedTypeID.ToString();
                txtEventsAttendedType.Text = EveAttendedType.EventsAttendedType1;
            }
            catch { }
        }

    }
}
