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

    public partial class Services : Form
    {
        COMPUTERIZED_STATISTICAL_ROOM2Entities db = new COMPUTERIZED_STATISTICAL_ROOM2Entities();
        ServicesScope ser;
        int id;
        int result;
        public Services()
        {
            InitializeComponent();

            comboServices.DataSource = db.ServicesScopes.ToList();
            comboServices.DisplayMember = "ServicesScopeType";
            comboServices.ValueMember = "ServicesScopeID";
            comboServices.SelectedValue = 0;

            max_value();
            txtSerName.Text = "";
        }
        void max_value()
        {
            result = db.ServicesScopes.Max(x => x.ServicesScopeID) + 1;
            txtSerNum.Text = result.ToString();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            ser = new ServicesScope()
            {
                ServicesScopeType = txtSerName.Text
            };
            db.ServicesScopes.Add(ser);
            db.SaveChanges();

            MessageBox.Show("تم الحفظ");
            
            comboServices.DataSource = db.ServicesScopes.ToList();
            comboServices.SelectedValue = 0;
            max_value();
            txtSerName.Text = "";
        }

        private void comboServices_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {

                id = (int)comboServices.SelectedValue;
                ser = db.ServicesScopes.SingleOrDefault(x => x.ServicesScopeID == id);
                txtSerNum.Text = ser.ServicesScopeID.ToString();
                txtSerName.Text = ser.ServicesScopeType;
            }
            catch
            { }
        }

        void RemoveData()
        {
            if (comboServices.SelectedValue != null)
            {
                var r = db.ServicesScopes.Find(id);
                db.ServicesScopes.Remove(r);

                db.SaveChanges();
                MessageBox.Show("تم الحذف");
                comboServices.DataSource = db.ServicesScopes.ToList();
                comboServices.SelectedValue = 0;
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
            if (comboServices.SelectedValue != null)
            {
                ser.ServicesScopeType = txtSerName.Text;
                db.SaveChanges();
                MessageBox.Show("تم التعديل");
                comboServices.DataSource = db.ServicesScopes.ToList();
                comboServices.SelectedValue = 0;
            }
            else
            {
                MessageBox.Show("برجاء اختيار البيانات للتعديل");
            }
            
        }
    }
}
