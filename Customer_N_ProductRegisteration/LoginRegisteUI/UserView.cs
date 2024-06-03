using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Customer_N_ProductRegisteration
{
    public partial class UserView : Form
    {

        private int LoginCount = 0;
        public static string UserID, UserName, pictureProfile;
    

        public UserView()
        {
            InitializeComponent();
            AutoID();
            Btn_Register.BackColor = Color.Black;
            panel_Login.BringToFront();
        }
        Color choose_Color = Color.FromArgb(46, 49, 49);

        RentalTableAdapters.CustomersTableAdapter objuser = new RentalTableAdapters.CustomersTableAdapter();
       

        //AutoID for User
        private void AutoID()
        {
            DataTable dt = new DataTable();
            dt = objuser.GetData();
            int NoofRow = dt.Rows.Count;
            if (NoofRow < 1)
            {
                txtId.Text = "Us-00001";
            }

            else
            {
                int oldid = dt.Rows.Count - 1;
                string OldID = dt.Rows[oldid][0].ToString();
                int OldNum = Convert.ToInt32(OldID.Substring(3));

                OldNum++;
                String NewID = "Us-" + OldNum.ToString("00000");
                txtId.Text = NewID;
            }
        }

        //Bringing Front to panel_Register for register
        private void Btn_Register_Click(object sender, EventArgs e)
        {
            panel_register.BringToFront();
            Btn_Register.BackColor = choose_Color;
            panel_register.BackColor = choose_Color;
            Btn_Login.BackColor = Color.Black;
        }

        //Bringing Front to panel_Login for login
        private void Btn_Login_Click(object sender, EventArgs e)
        {
            panel_Login.BringToFront();
            Btn_Login.BackColor = choose_Color;
            panel_Login.BackColor = choose_Color;
            Btn_Register.BackColor = Color.Black;
        }

        //Exit Application 
        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            //Check textboxes are empty or not   
                if (txtName.Text == "")
                {

                    MessageBox.Show("Error: " + "Please Enter Name", "User Register:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (rdoMale.Checked == false & rdoFemale.Checked == false)
                {

                    MessageBox.Show("Please Choose Your Gender");
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
                    MessageBox.Show("Please Enter Email Address");
                }
                else if (txtEmail.Text == "")
                {
                    MessageBox.Show("Please Add Your Picture");
                }
                else if (txtFullName.Text == "")
                {
                    MessageBox.Show("Please Enter FullName");
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
                        string fullName = txtFullName.Text;


                        DataTable dt = new DataTable();
                        dt = objuser.GetData();
                        IEnumerable<DataRow> query = dt.AsEnumerable().OrderBy(row => row.Field<string>("Email"));
                        string checkEmail = Email.Trim();
                        foreach (DataRow row in query)
                        {

                            //Make sure email is not duplicated
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
                       Ps.SetData(MemberID, MemberName, NRCNumber, Address, Phone, Email, genders, path, fullName);
                       
                      
                        this.Hide();
                        Ps.Show();
                    }
                    catch (Exception ex) {

                        MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                    }
                }
            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (LoginCount == 5)
            {
                // if LoginCOunt is more than 5 time, shows reach limit
                MessageBox.Show("Login Fail 5 time! You have reach your limit");
                this.Close();

            }

            else {

                DataTable userdt = new DataTable();
                userdt = objuser.GetUserLogin(txtLoginEmail.Text, txtLoginPassowrd.Text);

                if (userdt.Rows.Count == 1)
                {

                    MessageBox.Show("Login Successfully");
                  
                    this.Hide();
  
                  
         
                    foreach (DataRow row in userdt.Rows) {


                        UserID = row.Field<string>("UserId").ToString();
                        UserName = row.Field<string>("UserName").ToString();
                        pictureProfile=row.Field<string>("ProfilePic").ToString();                        
                     
                    
                    }
                    MainformUL.MainForm mf = new MainformUL.MainForm(UserName,UserID,pictureProfile);
                    mf.Show();
                }
                else {
                    LoginCount += 1;
                    MessageBox.Show("Invalid Login attempt :" + LoginCount);
                }
            }
           

        }
        
        private void pictureBox1_Click(object sender, EventArgs e)
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

        //Clear all textboxes
        private void button1_Click(object sender, EventArgs e)
        {
        
         txtName.Clear();
         txtNRC.Clear();
             txtPhNo.Clear();
           txtAddress.Clear();
          txtEmail.Clear();
           rdoMale.Checked = false ;
           rdoFemale.Checked = false;
         txtFullName.Clear();
         pictureBox1.Image = null;
           
        }
         

        



       
    }
}
