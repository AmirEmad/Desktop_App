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
    public partial class LevelDegreeScreen : Form
    {
        COMPUTERIZED_STATISTICAL_ROOM2Entities db = new COMPUTERIZED_STATISTICAL_ROOM2Entities();
        levedegreeType level;
        int id;
        int result;
        public LevelDegreeScreen()
        {
            InitializeComponent();

            comboLvele.DataSource = db.levedegreeTypes.ToList();
            comboLvele.DisplayMember = "type";
            comboLvele.ValueMember = "type_id";
            comboLvele.SelectedValue = 0;

            max_value();
            txtLevelName.Text = "";
        }

        void max_value()
        {
            result = db.levedegreeTypes.Max(x => x.type_id) + 1;
            txtLevelNum.Text = result.ToString();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            level = new levedegreeType()
            {
                //societyID = result,
                type = txtLevelName.Text,
            };

            db.levedegreeTypes.Add(level);

            db.SaveChanges();
            MessageBox.Show("تم الحفظ");
            
            comboLvele.DataSource = db.levedegreeTypes.ToList();
            comboLvele.SelectedValue = 0;
            max_value();
            txtLevelName.Text = "";
        }

        private void comboLvele_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {

                id = (int)comboLvele.SelectedValue;
                level = db.levedegreeTypes.SingleOrDefault(x => x.type_id == id);
                txtLevelNum.Text = level.type_id.ToString();
                txtLevelName.Text = level.type;
            }
            catch
            { }
        }

        void RemoveData()
        {
            if (comboLvele.SelectedValue != null)
            {
                var r = db.levedegreeTypes.Find(id);
                db.levedegreeTypes.Remove(r);

                db.SaveChanges();
                MessageBox.Show("تم الحذف");
                comboLvele.DataSource = db.levedegreeTypes.ToList();
                comboLvele.SelectedValue = 0;
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
            if (comboLvele.SelectedValue != null)
            {
                level.type = txtLevelName.Text;
                db.SaveChanges();
                MessageBox.Show("تم التعديل");
                comboLvele.DataSource = db.levedegreeTypes.ToList();
                comboLvele.SelectedValue = 0;
            }
            else
            {
                MessageBox.Show("برجاء اختيار البيانات للتعديل");
            }
            
        }
    }
}
