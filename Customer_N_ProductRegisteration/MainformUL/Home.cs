using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Customer_N_ProductRegisteration.MainformUL
{
    public partial class Home : UserControl
    {

        private GroupBox groupBox; // declare groupbox
        private int xpos=10; // set vertical postion 
        public Home()
        {
            InitializeComponent();
            dynamicwithdatabase();
        }

        RentalTableAdapters.AppliancesTableAdapter AT = new RentalTableAdapters.AppliancesTableAdapter();
        RentalTableAdapters.Appliances2TableAdapter AT2 = new RentalTableAdapters.Appliances2TableAdapter();


        public void dynamicwithdatabase()
        {
            DataTable dt = new DataTable();
            dt = AT2.GetData();

            int skipRow = dt.Rows.Count - 3;
            IEnumerable<DataRow> query = dt.AsEnumerable().OrderBy(row => row.Field<string>("AppliancesID"));

            foreach (DataRow row in query.Skip(skipRow).Take(3))   //Skip skipRow(rows.count-3) index in database and take another 3 
            {


                string GpText = row.Field<string>("Brand");
                string LabelText = row.Field<string>("AppliancesName");
                string description = row.Field<string>("Description");
                string MonthlyFee = row.Field<decimal>("MonthlyFee").ToString();
                string Picture = row.Field<string>("picture");
                string Appid = row.Field<string>("AppliancesID");

                Items(LabelText, GpText, Picture, description, MonthlyFee, Appid); //pass variables to Items function
                    groupBox.Location = new Point(xpos, 10);

                    xpos += 220; // plus 220 x postion 

            }


        }

        public void Items(string LabelText, string gp, string picture, string des, string monthlyfee, string AppId) // accept data
        {

            groupBox = new GroupBox(); // Call group box  

            groupBox.Size = new Size(200, 300);   //set the size 
            groupBox.BackColor = Color.FromArgb(102, 98, 98);
            groupBox.ForeColor = Color.White;
            groupBox.Font = new Font("Century Gothic", 9, FontStyle.Regular);
            groupBox.Text = gp;
            panelHome.Controls.Add(groupBox);  //Add group box to panel namely panel home


            Label nameLabel = new Label(); //create label 
            nameLabel.Text = LabelText;
            groupBox.Controls.Add(nameLabel);
            nameLabel.Location = new Point(5, 40);
            nameLabel.Size = new Size(150, 20);

            Label descrption = new Label();     //create label 
            descrption.Size = new Size(180, 50);
            descrption.Text = des;
            descrption.Location = new Point(5, 70);
            descrption.BorderStyle = BorderStyle.Fixed3D;
            groupBox.Controls.Add(descrption); //add that label to previous groupbox

            PictureBox PB = new PictureBox();  // create picture box
            groupBox.Controls.Add(PB);
            PB.Location = new Point(5, 130);
            PB.SizeMode = PictureBoxSizeMode.StretchImage;
            PB.Size = new Size(190, 90);
            //PB.Image = Image.FromFile(picture);
            PB.BorderStyle = BorderStyle.Fixed3D;

            Label NUD = new Label();        //create lable
            groupBox.Controls.Add(NUD);
            NUD.Text = "Monthly Fee : " + " " + monthlyfee + "$";
            NUD.Location = new Point(5, 235);
            NUD.Size = new Size(150, 20);


            Button ViewMore = new Button();

            ViewMore.Tag = AppId;
            ViewMore.Text = "View More";
            ViewMore.Click += new EventHandler(viewMore_Click);
            ViewMore.BackColor = Color.FromArgb(241, 90, 34);
            ViewMore.Size = new Size(80, 30);
            ViewMore.FlatStyle = FlatStyle.Flat;
            ViewMore.FlatAppearance.BorderSize = 0;
            ViewMore.Location = new Point(115, 263);
            groupBox.Controls.Add(ViewMore);
            ViewMore.Cursor = Cursors.Hand;

        }

        private void viewMore_Click(object sender, EventArgs e)
        {

            Button clickedButton = (Button)sender;
            string unitItemId = clickedButton.Tag.ToString();


         // UnitItem UI = new UnitItem(unitItemId);

           // UI.Show();




        }

        
    

        
    }
}
