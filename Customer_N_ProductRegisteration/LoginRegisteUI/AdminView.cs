using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Customer_N_ProductRegisteration
{
    public partial class AdminView : Form
    {

        private int LoginCount = 0;
        public static string AdminID, AdminName;
        
        public AdminView()
        {
            InitializeComponent();
            Btn_Register.BackColor = Color.Black;
           panel_Login.BringToFront();
           AutoID();
         
        }

        RentalTableAdapters.AdminTableAdapter RTA = new RentalTableAdapters.AdminTableAdapter();


        //Automatic ID 
        public void AutoID()
        {
            DataTable dt = new DataTable();
            dt = RTA.GetData();
            if (dt.Rows.Count == 0)
            {
                txtId.Text = "A_001";
            }
            else
            {
                int size = dt.Rows.Count - 1;
                string oldID = dt.Rows[size][0].ToString();
                int newid = Convert.ToInt32(oldID.Substring(2, 3));
                if (newid >= 1 && newid < 10)
                {
                    txtId.Text = "A_00" + (newid + 1);
                }
                else if (newid > 9 && newid < 100)
                {
                    txtId.Text = "A_0" + (newid + 1);
                }
                else if (newid > 99 && newid < 1000)
                {
                    txtId.Text = "A_" + (newid + 1);
                }
            }
        }   


        Color choose_Color = Color.FromArgb(46, 49, 49);


        //Bringing Front to panel_Login for login
        private void Btn_Login_Click(object sender, EventArgs e)
        {
            panel_Login.BringToFront();
            Btn_Login.BackColor = choose_Color;
            panel_Login.BackColor = choose_Color;
            Btn_Register.BackColor = Color.Black;
        }



        //Bringing Front to panel_Register for register
        private void Btn_Register_Click(object sender, EventArgs e)
        {
            panel_register.BringToFront();
            Btn_Register.BackColor = choose_Color;
            panel_register.BackColor = choose_Color;
            Btn_Login.BackColor = Color.Black;


        }

        //EXit application
        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRegister_Click_1(object sender, EventArgs e)
        {

            if (txtId.Text == "")
            {
                MessageBox.Show("Please Enter ID");
            }

            else if (txtName.Text == "")
            {
                MessageBox.Show("Please Enter Name");
            }

            else if (txtPhNo.Text == "")
            {
                MessageBox.Show("Please Enter Phone");
            }
            else if (txtAddress.Text == "")
            {
                MessageBox.Show("Please Enter Address");
            }
            else if (txtNRC.Text == "")
            {
                MessageBox.Show("Please Enter NRC number");
            }
            else if (txtEmail.Text == "")
            {
                MessageBox.Show("Please Add Your Picture");
            }
            else if (txtEmail.Text == "")
            {
                MessageBox.Show("Please Enter Email Address");
            }
            else if (txtEmail.Text == "")
            {
                MessageBox.Show("Please Add Your Picture");
            }


            else
            {

                try
                {
                    string MemberID = txtId.Text;
                    string MemberName = txtName.Text;
                    string NRCNumber = txtNRC.Text;
                    string Phone = txtPhNo.Text;
                    string Address = txtAddress.Text;
                    string Email = txtEmail.Text;
                    string genders = rdoMale.Checked == true ? "Male" : "Female";

                    DataTable dt = new DataTable();
                    dt = RTA.GetData();
                    IEnumerable<DataRow> query = dt.AsEnumerable().OrderBy(row => row.Field<string>("Email"));
                    string checkEmail = Email.Trim();
                    foreach (DataRow row in query)
                    {

                        //Make sure is not duplicated
                        if (checkEmail == row.Field<string>("Email"))
                        {

                            throw new Exception("This email is already in use");

                        }
                    }



                    string Picturelocation = "C:\\Users\\Asus\\Documents\\150(DDOOCP-Exe)\\DDOOCP_Assignment\\AdminView\\Customer_N_ProductRegisteration\\bin\\Debug";

                    string path = Path.Combine(Picturelocation, MemberID + ".jpg");

                    Image img = pictureBox1.Image;
                    img.Save(path);

                    //Call passwordPanel form
                    PasswordPanel Ps = new PasswordPanel();

                    //passing data by passwordPanel's SetData function
                    Ps.SetData(MemberID, MemberName, NRCNumber, Address, Phone, Email, genders, path, null);


                    this.Hide();
                    Ps.Show();
                }
                catch (Exception ex) {

                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            PictureBox p = sender as PictureBox;
            if (p != null)
            {

                open.Filter = "(*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";

                if (open.ShowDialog() == DialogResult.OK)
                {
                    p.Image = Image.FromFile(open.FileName);
                }
            }
        }
       

        private void button1_Click(object sender, EventArgs e)
        {
            if (LoginCount == 5)
            {

                MessageBox.Show("Login Fail 5 time! You have reach your limit");
                this.Close();

            }

            else
            {

                DataTable admindt = new DataTable();
                admindt = RTA.GetAdminLogin(txtLoginEmail.Text,txtLoginPassword.Text);

                if (admindt.Rows.Count == 1)
                {

                    MessageBox.Show("Login Successfully");
                    
                    this.Hide();
                    foreach (DataRow row in admindt.Rows)
                    {


                        AdminID = row.Field<string>("AdminID").ToString();
                        AdminName = row.Field<string>("AdminName").ToString();


                    }
                    AdminControlPanle.ControlMainForm CMF = new AdminControlPanle.ControlMainForm(AdminID, AdminName);
                    CMF.Show();
                }
                else
                {
                    LoginCount += 1;
                    MessageBox.Show("Invalid Login attempt :" + LoginCount);
                }
            }
        }


        //Clear data in textboxes
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            txtNRC.Clear();
            txtPhNo.Clear();
            txtAddress.Clear();
            txtEmail.Clear();
            rdoMale.Checked = false;
            rdoFemale.Checked = false;
          
            pictureBox1.Image = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

       

        

     

      

        
    }
}
