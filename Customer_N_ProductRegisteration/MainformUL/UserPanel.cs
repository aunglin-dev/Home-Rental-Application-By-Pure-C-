using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Customer_N_ProductRegisteration.MainformUL
{
    public partial class UserPanel : Form
    {

        RentalTableAdapters.CustomersTableAdapter CT = new RentalTableAdapters.CustomersTableAdapter();
        RentalTableAdapters.ShopCartTableAdapter SCT = new RentalTableAdapters.ShopCartTableAdapter();
        DataTable dt = new DataTable();
        private string userid, username, picture;
        public UserPanel(string userId)
        {
            InitializeComponent();
            dt = CT.GetSpecificUser(userId);

            userid = userId;
            foreach (DataRow row in dt.Rows) {
                username = row.Field<string>("UserName").ToString();
                pictureBox2.Image = Image.FromFile(row.Field<string>("ProfilePic").ToString());
                picture = row.Field<string>("ProfilePic").ToString();
                lblFullName.Text = row.Field<string>("FullName").ToString();
                lblUserName.Text = row.Field<string>("UserName").ToString();
                lblDeliAddress.Text = row.Field<string>("Address").ToString();
                lblEmail.Text = row.Field<string>("Email").ToString();
            
            }
           

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("All of your shop cart lists will be deleted when you are logged out", "Are you sure you to log out?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {


   

                UserView UV = new UserView();
                UV.Show();
                UV.Enabled = true;
                SCT.DeleteQuery();// delete all items from shop cart when logging out
                this.Hide();

           

            }
            else {

                this.Show();
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            MainForm MF = new MainForm(username,userid,picture);
            MF.Show();
            this.Hide();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

     
    }
}
