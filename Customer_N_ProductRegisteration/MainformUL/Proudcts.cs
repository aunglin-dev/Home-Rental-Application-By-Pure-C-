using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Customer_N_ProductRegisteration.LoginRegisteUI;
using System.Text.RegularExpressions;


namespace Customer_N_ProductRegisteration.MainformUL
{
    public partial class Proudcts : UserControl
    {

        private GroupBox groupBox;
      

        public Proudcts()
        {
            InitializeComponent();
            SetType();
            SetEachData();
         
        }

        RentalTableAdapters.AppliancesTableAdapter AT = new RentalTableAdapters.AppliancesTableAdapter();
        RentalTableAdapters.Appliances2TableAdapter AT2 = new RentalTableAdapters.Appliances2TableAdapter();
        DataTable dt = new DataTable();

        //Set the type combobox 
        public void SetType() {
            DataTable dt = new DataTable();
            dt = AT2.GetData();

            var types = dt.AsEnumerable().Select(row=>row.Field<string>("Type")).Distinct();

          CboType.Items.Add("All");
            //Add all of types that are in database 
          foreach (var value in types) {
              CboType.Items.Add(value);
          }
          CboType.SelectedIndex = 0;
        }

        //Set searchby combobox 
        public void SetEachData() {

            DataTable dt = new DataTable();
            dt = AT2.GetData();
            CboSearchBy.Items.Add("AppliancesName");
            //add data to combox namely searchby 
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                if (dt.Columns[i].ColumnName != "Type" & dt.Columns[i].ColumnName != "AppliancesID" & dt.Columns[i].ColumnName != "AppliancesName" & dt.Columns[i].ColumnName != "MonthlyFee" & dt.Columns[i].ColumnName != "AdminID" & dt.Columns[i].ColumnName != "EstimateAnnCost" & dt.Columns[i].ColumnName != "Quantity")
                {

                    CboSearchBy.Items.Add(dt.Columns[i].ColumnName);
                }
                CboSearchBy.SelectedIndex = 0;

            
            }
        
        }

        private void CboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //If cboType's selectedIndex Changed refresh flowlayout panel and clear text box
            flowLayoutPanel1.Controls.Clear();
            txtSearch.Text = "";

            if (CboType.SelectedIndex == 0)
            {

                dynamicwithdatabase();

            }
            else {
                selectedItem();
            }
            
        }

        private void CboSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            //If cbosearchby combo box's selectedIndex changed  clear text box
            txtSearch.Text = "";
        }

    
        //Render appliances according to cboType's SelectedItem
        public void selectedItem() {

            DataTable dt = new DataTable();

            dt = AT2.GetItemType(CboType.SelectedItem.ToString());
            IEnumerable<DataRow> query = dt.AsEnumerable().OrderBy(row => row.Field<string>("AppliancesID"));

            foreach (DataRow row in query)
            {
                string GpText = row.Field<string>("Brand");
                string LabelText = row.Field<string>("AppliancesName");
                string description = row.Field<string>("Description");
                string Picture = row.Field<string>("picture");
                string MonthlyFee = row.Field<decimal>("MonthlyFee").ToString();
                string Appid = row.Field<string>("AppliancesID");
                Items(LabelText, GpText, Picture, description, MonthlyFee, Appid);
            }
        }

        //Render all appliances that are in database
        public void dynamicwithdatabase()
        {
            DataTable dt = new DataTable();
            dt = AT2.GetData();
          
            IEnumerable<DataRow> query = dt.AsEnumerable().OrderBy(row => row.Field<string>("AppliancesID"));
          
            
            foreach (DataRow row in query)
            {
            
                    string GpText = row.Field<string>("Brand");
                    string LabelText = row.Field<string>("AppliancesName");
                    string description = row.Field<string>("Description");
                   string MonthlyFee = row.Field<decimal>("MonthlyFee").ToString();
                    string Picture = row.Field<String>("picture");
                    string Appid = row.Field<string>("AppliancesID");
                    Items(LabelText, GpText, Picture, description, MonthlyFee,Appid);

            }


        }

        //Render appliances according to the search changes
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            string searchValue = txtSearch.Text.ToLower().Trim();
            string pattern = string.Format("\\b{0}\\w*\\b", Regex.Escape(searchValue));
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            DataTable dt = new DataTable();
         
           dt = CboType.SelectedIndex==0? AT2.GetData(): AT2.GetItemType(CboType.SelectedItem.ToString());

           IEnumerable<DataRow> query = dt.AsEnumerable().OrderBy(row => row.Field<string>("AppliancesID"));

            foreach (DataRow row in query)
            {
                if (regex.IsMatch(row.Field<string>(CboSearchBy.SelectedItem.ToString()).ToString())) //Using regular expression to chech match or not 
                {

                    string GpText = row.Field<string>("Brand");
                    string LabelText = row.Field<string>("AppliancesName");
                    string description = row.Field<string>("Description");
                    string MonthlyFee = row.Field<decimal>("MonthlyFee").ToString();
                    string Picture = row.Field<String>("picture");
                    string Appid = row.Field<string>("AppliancesID");
                    Items(LabelText, GpText, Picture, description, MonthlyFee,Appid);


                }
      

            }


        }

        //Create function for dynamic items
        public void Items(string LabelText, string gp, string picture,string des,string monthlyfee,string AppId)
        {

            groupBox = new GroupBox();

            groupBox.Size = new Size(200, 300);
            groupBox.BackColor = Color.FromArgb(102, 98, 98);
            groupBox.ForeColor = Color.White;
            groupBox.Font = new Font("Century Gothic", 9, FontStyle.Regular);
            groupBox.Text = gp;
            flowLayoutPanel1.Controls.Add(groupBox);


            Label nameLabel = new Label();
            nameLabel.Text = LabelText;
            groupBox.Controls.Add(nameLabel);
            nameLabel.Location = new Point(5, 40);
            nameLabel.Size = new Size(150, 20);

            Label descrption = new Label();
            descrption.Size = new Size(180, 50);
            descrption.Text = des;
          
            descrption.Location = new Point(5, 70);
            descrption.BorderStyle= BorderStyle.Fixed3D;
            groupBox.Controls.Add(descrption);

            PictureBox PB = new PictureBox();
            groupBox.Controls.Add(PB);
            PB.Location = new Point(5, 130);
            PB.SizeMode = PictureBoxSizeMode.StretchImage;
            PB.Size = new Size(190, 90);
           // PB.Image = Image.FromFile(picture);
            PB.BorderStyle = BorderStyle.Fixed3D;

            Label NUD = new Label();
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
          UnitItem UI = new UnitItem(unitItemId);
          
            UI.Show();
            
       
           
       
        }
        private void Proudcts_Load(object sender, EventArgs e)
        {

        }






    }
}
