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
    public partial class TechnicalreportsScreen : Form
    {
        public TechnicalreportsScreen()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();

            Thread th = new Thread(OpenFundingform);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        void OpenFundingform()
        {
            Application.Run(new FundingScreen());
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

            this.Close();

            Thread th = new Thread(OpenBooksform);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        void OpenBooksform()
        {
            Application.Run(new BooksScreen());
        }
    }
}
