using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Customer_N_ProductRegisteration
{
    public partial class WelcomeFom : Form
    {
        public WelcomeFom()
        {
            InitializeComponent();
        }


        //Go to the UserView Form
        private void btnUser_Click(object sender, EventArgs e)
        {
            UserView UV = new UserView();
            this.Hide();
            UV.Show();
        }

        //Go to the AdminView Form
        private void btnAdmin_Click(object sender, EventArgs e)
        {
            AdminView AV = new AdminView();
            this.Hide();
            AV.Show();
        }
    }
}
