using COMPUTERIZED_STATISTICAL_ROOM.DB;
using COMPUTERIZED_STATISTICAL_ROOM.Screens;
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

namespace COMPUTERIZED_STATISTICAL_ROOM
{
    public partial class Login : Form
    {
        COMPUTERIZED_STATISTICAL_ROOM2Entities db = new COMPUTERIZED_STATISTICAL_ROOM2Entities();
        
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SignUp signup = new SignUp();
            signup.Show();
        }

        private void user_signin_Click(object sender, EventArgs e)
        {

            int password;
            int.TryParse(txtpassword.Text, out password);
            var result = db.Mains.FirstOrDefault(x => x.Name == txtname.Text && x.StaffMemNum == password);

            if (result != null)
            {
                this.Close();

                Thread th = new Thread(Openform);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();

                User.Name = result.Name;
                User.Id = result.StaffMemNum;
            }
            else
            {
                MessageBox.Show("اسم المستخدم او كلمة المرور غير صحيحه");
                txtname.Text = "";
                txtpassword.Text = "";
            }
        }
        void Openform()
        {
            Application.Run(new MainScreen());
        }

        private void admin_signin_Click(object sender, EventArgs e)
        {
            if (txtname.Text=="مسئول" && txtpassword.Text=="1111")
            {
                this.Close();

                Thread th = new Thread(Openform);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();

                //User.Name = "مسئول";
                User.Id = 1111;
            }
            else
            {
                MessageBox.Show("انت لست مسئول");
                txtname.Text = "";
                txtpassword.Text = "";
            }
        }

        
    }
    static class User
    {
        static public string Name { get; set; }
        static public int Id { get; set; }
    }
}
