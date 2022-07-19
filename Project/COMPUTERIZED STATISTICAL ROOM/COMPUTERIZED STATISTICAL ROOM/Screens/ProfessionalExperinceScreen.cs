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
    public partial class ProfessionalExperinceScreen : Form
    {
        COMPUTERIZED_STATISTICAL_ROOM2Entities db = new COMPUTERIZED_STATISTICAL_ROOM2Entities();
        ProfessionalExperinceType Exp;
        int id;
        int result;
        public ProfessionalExperinceScreen()
        {
            InitializeComponent();

            comboExp.DataSource = db.ProfessionalExperinceTypes.ToList();
            comboExp.DisplayMember = "ProfessionalExperinceType1";
            comboExp.ValueMember = "ProfessionalExperinceTypeID";
            comboExp.SelectedValue = 0;

            max_value();
            txtExpName.Text = "";

        }

        void max_value()
        {
            result = db.levedegreeTypes.Max(x => x.type_id) + 1;
            txtExpNum.Text = result.ToString();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            Exp = new ProfessionalExperinceType()
            {
                ProfessionalExperinceType1 = txtExpName.Text,
            };

            db.ProfessionalExperinceTypes.Add(Exp);

            db.SaveChanges();
            MessageBox.Show("تم الحفظ");
            
            comboExp.DataSource = db.ProfessionalExperinceTypes.ToList();
            comboExp.SelectedValue = 0;
            max_value();
            txtExpName.Text = "";
        }

        private void comboExp_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {

                id = (int)comboExp.SelectedValue;
                Exp = db.ProfessionalExperinceTypes.SingleOrDefault(x => x.ProfessionalExperinceTypeID == id);
                txtExpNum.Text = Exp.ProfessionalExperinceTypeID.ToString();
                txtExpName.Text = Exp.ProfessionalExperinceType1;
            }
            catch
            { }
        }

        void RemoveData()
        {
            if (comboExp.SelectedValue != null)
            {
                var r = db.ProfessionalExperinceTypes.Find(id);
                db.ProfessionalExperinceTypes.Remove(r);

                db.SaveChanges();
                MessageBox.Show("تم الحذف");
                comboExp.DataSource = db.ProfessionalExperinceTypes.ToList();
                comboExp.SelectedValue = 0;
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
            if (comboExp.SelectedValue != null)
            {
                Exp.ProfessionalExperinceType1 = txtExpName.Text;
                db.SaveChanges();
                MessageBox.Show("تم التعديل");
                comboExp.DataSource = db.ProfessionalExperinceTypes.ToList();
                comboExp.SelectedValue = 0;
            }
            else
            {
                MessageBox.Show("برجاء اختيار البيانات للتعديل");
            }
            
        }
    }
}
