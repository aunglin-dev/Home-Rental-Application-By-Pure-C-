using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Customer_N_ProductRegisteration
{
    public partial class PasswordPanel : Form
    {


        public PasswordPanel()
        {
            InitializeComponent();
            
        }

        //Call RegisterVariableStore Class
       RegisterVariableStore RVS = new RegisterVariableStore();



        //Accepting data and pass again to RegisterVariableStore Class for temporary store 
        public void SetData(string id, string name, string nrc, string address, string phone, string email, string gender, string profilepic ,string fullname)
        {
            RVS.MemberID = id;
            RVS.MemberName = name;
            RVS.NRCNumber = nrc;
            RVS.Address = address;
            RVS.Phone = phone;
            RVS.Email = email;
            RVS.Gender = gender;
            RVS.ProfilePic = profilepic;
            RVS.FullName = fullname;
        }


     
        RentalTableAdapters.CustomersTableAdapter objuser = new RentalTableAdapters.CustomersTableAdapter();
        RentalTableAdapters.AdminTableAdapter RTA = new RentalTableAdapters.AdminTableAdapter();
  

     

        private void BtnSave_Click_1(object sender, EventArgs e)
        {

            string password1 = txtpassword1.Text;
            string password2 = txtpassword2.Text;

            //psssowrd is not null and include appropriate lenth, upper letter, lower letter and two password are same
            if (password1 == null)
            {
                MessageBox.Show("Please Enter Your Password.");
                txtpassword1.Focus();
            }

            else if (password2 == null)
            {
                MessageBox.Show("Please Enter Your Retype Password.");
                txtpassword2.Focus();
            }
            else if (password1 != password2)
            {
                MessageBox.Show("Passwords doesn't match");
            }
            else if (password1.Length < 8 || password1.Length > 20)
            {
                MessageBox.Show("Password lengh should between 8 and 20 character");
                txtpassword1.Focus();

            }
            else if (!password1.Any(char.IsUpper))
            {
                MessageBox.Show("Password should contain at least one upper letter.");
                txtpassword1.Focus();
            }
            else if (!password1.Any(char.IsLower))
            {
                MessageBox.Show("Password should contain at least one lower letter.");
                txtpassword1.Focus();
            }
            else if (!password1.Any(char.IsDigit))
            {
                MessageBox.Show("Password should contain at least one digit.");
                txtpassword1.Focus();
            }
     
          
            else
            {
                //Split RVS.MemberID with (_) 
                string [] arrId = RVS.MemberID.Split('_');
               
                if (arrId[0] == "A")
                {
                    //if RVS.MemberID starts with "A", data will be saved in Admin Table
                      
                    try {

                     

                        RTA.Insert(RVS.MemberID, RVS.MemberName,  RVS.Email, RVS.Phone, RVS.Address, RVS.Gender, RVS.NRCNumber, password2,RVS.ProfilePic);
                        MessageBox.Show("Successfully Saved");
                        AdminView AV = new AdminView();

                       AV.Show();
                       this.Hide();
                    }
                    catch (SqlException ex)
                    {
                        if (ex.Number == 8152) // over-range varchar column
                        {
                            MessageBox.Show("The data is too long for some columns");
                        }
                        else
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                else {
                  
                    //others, data will be saved in Customers Table
                    try
                    {
                        objuser.Insert(RVS.MemberID, RVS.MemberName, RVS.Email, RVS.Phone, RVS.Address, RVS.NRCNumber, RVS.Gender, password2, RVS.ProfilePic, RVS.FullName);
                        MessageBox.Show("Successfully Saved");
                        UserView UV = new UserView();
                        this.Hide();
                        UV.Show();
                    }
                    catch (SqlException ex)
                    {
                        if (ex.Number == 8152) // over-range varchar column
                        {
                            MessageBox.Show("The data is too long for some columns");
                        }
                        else
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                  
                   

                }
                   
                }

               
            }
        

      
        //Exit the application
        private void pictureBoxClose_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            //Split RVS.MemberID with (_) 
            string[] arrId = RVS.MemberID.Split('_');
            if (arrId[0] == "A")
            {
                AdminView AV = new AdminView();
              
                AV.Show();
                this.Hide();
            }
            else {

                UserView UV = new UserView();
                this.Hide();
                UV.Show();
            }
        }

     

        
    }
}
