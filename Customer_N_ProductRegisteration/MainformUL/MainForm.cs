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
    public partial class MainForm : Form
    {
        private string userId{get;set;}
        private decimal totalDiscount { get; set; }
        private decimal totalCost { get; set; }
        private int totalAppliances { get; set; }
        private int totalmonths { get; set; }
        private string RentID { get; set; }
        private string RentDetailID { get; set; }
       
        public MainForm(string name ,string id, string picture)
        {

            InitializeComponent();
         
    
            btnStaffLogin.Text = name;
            pictureProfile.Image = Image.FromFile(picture);
            userId = id;

            //Set sidepanel to same height as button
            sidepanel.Height = btnHome.Height;
            sidepanel.Top = btnHome.Top;

            btnRent.Enabled = false;
            home1.BringToFront();

      
           
        }

        RentalTableAdapters.ShopCartTableAdapter ST = new RentalTableAdapters.ShopCartTableAdapter();
        RentalTableAdapters.RentTableAdapter RT = new RentalTableAdapters.RentTableAdapter();
        RentalTableAdapters.ShopCartAndAppTableAdapter SPCA = new RentalTableAdapters.ShopCartAndAppTableAdapter();
        RentalTableAdapters.RentDetail2TableAdapter RDT2 = new RentalTableAdapters.RentDetail2TableAdapter();
        RentalTableAdapters.RentHistoryTableAdapter RH = new RentalTableAdapters.RentHistoryTableAdapter();
        RentalTableAdapters.Appliances2TableAdapter AT2 = new RentalTableAdapters.Appliances2TableAdapter();


       //btnHome is clicked , home1 usercontrol appears
        private void btnHome_Click(object sender, EventArgs e)
        {
            sidepanel.Height = btnHome.Height;
            sidepanel.Top = btnHome.Top;
            home1.BringToFront();
              
        }
        //btnProduct is clicked, products2 usercontrol appears
        private void btnProducts_Click(object sender, EventArgs e)
        {
            sidepanel.Height = btnProducts.Height;
            sidepanel.Top = btnProducts.Top;
            proudcts2.BringToFront();
        }

        //btnShopCart is clicked, PanelSC appears
        private void btnShopCart_Click(object sender, EventArgs e)
        {
            sidepanel.Height = btnShopCart.Height;
            sidepanel.Top = btnShopCart.Top;
            PanelShopCart.Controls.Clear();
            //PanelShopCart.BringToFront();
            PanelSC.BringToFront();
            totalPrice();
            ExampleShopCart();
            PaymentType();     
         
        }

        //btnHistory is clicked, panelTableLayoutHis appears
        private void btnHistory_Click(object sender, EventArgs e)
        {
            sidepanel.Height = btnHistory.Height;
            sidepanel.Top = btnHistory.Top;
            panelHistory.BringToFront();
            panelTableLayoutFHis.Controls.Clear();
            HistoryTotal();
        }

        //Create dynamic tablelayoutpanel
       private TableLayoutPanel tableShopCart;
       private TableLayoutPanel tableHistoryOverall;

       public void HistoryTotal() {

           DataTable dt = new DataTable();
           dt = RH.GetHistory(userId);

           if (dt.Rows.Count == 0)
           {
           
               Label lB = new Label();
               lB.Text = "No history is still here, go and get some products";
               lB.Size = new Size(360, 40);
               lB.Font = new Font("Century Gothic", 10, FontStyle.Regular);
               lB.Location = new Point(25, 20);

               panelTableLayoutFHis.Controls.Add(lB);
           }

           else
           {
               
               // Create the TableLayoutPanel dynamically
               tableHistoryOverall = new TableLayoutPanel();
               tableHistoryOverall.AutoScroll = true;
               tableHistoryOverall.Dock = DockStyle.Fill;
               tableHistoryOverall.ColumnCount = dt.Columns.Count + 1;
               tableHistoryOverall.RowCount = dt.Rows.Count + 1;
               tableHistoryOverall.ColumnStyles.Clear();
               tableHistoryOverall.RowStyles.Clear();
              

               for (int i = 0; i < tableHistoryOverall.ColumnCount; i++)
               {
                   tableHistoryOverall.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 110F));
               }

               tableHistoryOverall.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));

               // Adding column headers to the TableLayoutPanel
               for (int i = 0; i < dt.Columns.Count; i++)
               {
                   Label label = new Label();
                   label.Text = dt.Columns[i].ColumnName;
                   label.Dock = DockStyle.Fill;
                   label.TextAlign = ContentAlignment.MiddleCenter;
                   label.Font = new Font("Century Gothic", 9, FontStyle.Bold);
                   tableHistoryOverall.Controls.Add(label, i, 0);
               }



               // Adding data rows to the TableLayoutPanel
               for (int i = 0; i < dt.Rows.Count; i++)
               {
                   for (int j = 0; j < dt.Columns.Count; j++)
                   {

                       Label label = new Label();
                       label.Text = dt.Rows[i][j].ToString();
                       //  label.Dock = DockStyle.Fill;
                       label.TextAlign = ContentAlignment.MiddleCenter;
                       tableHistoryOverall.Controls.Add(label, j, i + 1);

                   }
                   Button btnCancel = new Button();
                   tableHistoryOverall.Controls.Add(btnCancel, dt.Columns.Count, i + 1);
                   btnCancel.Text = "View Detail";
                   btnCancel.Tag = dt.Rows[i][0];
                   btnCancel.Click += new EventHandler(ViewMore_Click);

               }
               panelTableLayoutFHis.Controls.Add(tableHistoryOverall);
           }

       }

       private void ViewMore_Click(object sender, EventArgs e)
       {
          
           Button clickedButton = (Button)sender;
           string RentingId = clickedButton.Tag.ToString();
           SpecificHistory SH = new SpecificHistory(RentingId, userId);
           SH.Show();
          
       }


        public void ExampleShopCart()
        {
           
            DataTable dt = new DataTable();
           

            dt = SPCA.GetData();

            if (dt.Rows.Count == 0)
            {
                Label lB = new Label();
                lB.Text = "There is no appliance in shop card, add now ....";
                lB.Size = new Size(360, 40);
                lB.Font = new Font("Century Gothic", 10, FontStyle.Regular);
                lB.Location = new Point(25, 20);
              
                PanelShopCart.Controls.Add(lB);
            }

            else
            {btnRent.Enabled = true;
                // Create the TableLayoutPanel dynamically
                tableShopCart = new TableLayoutPanel();
                tableShopCart.AutoScroll = true;
                tableShopCart.Dock = DockStyle.Fill;
                tableShopCart.ColumnCount = dt.Columns.Count + 1;
                tableShopCart.RowCount = dt.Rows.Count + 1;
                tableShopCart.ColumnStyles.Clear();
                tableShopCart.RowStyles.Clear();
                //  tableLayoutPanel.CellMouseClick += tableLayoutPanel_CellMouseClick;

                for (int i = 0; i < tableShopCart.ColumnCount; i++)
                {
                    tableShopCart.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 110F));
                }

                tableShopCart.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));

                // Adding column headers to the TableLayoutPanel
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    Label label = new Label();
                    label.Text = dt.Columns[i].ColumnName;
                    label.Dock = DockStyle.Fill;
                    label.TextAlign = ContentAlignment.MiddleCenter;
                    label.Font = new Font("Century Gothic", 7, FontStyle.Bold);
                    tableShopCart.Controls.Add(label, i, 0);
                }



                // Adding data rows to the TableLayoutPanel
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {

                        Label label = new Label();
                        label.Text = dt.Rows[i][j].ToString();
                        //  label.Dock = DockStyle.Fill;
                        label.TextAlign = ContentAlignment.MiddleCenter;
                        tableShopCart.Controls.Add(label, j, i + 1);

                    }
                    Button btnCancel = new Button();
                    tableShopCart.Controls.Add(btnCancel, dt.Columns.Count, i + 1);
                    btnCancel.Text = "Remove";
                    btnCancel.Tag = new Tuple<string, string>(dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString());
                    btnCancel.Click += new EventHandler(Cancel_Click);

                }
                PanelShopCart.Controls.Add(tableShopCart);

            }
        }
        //Create event handler for btnCancel
        private void Cancel_Click(object sender, EventArgs e)
        {
            Tuple<string, string> tagValues = (Tuple<string, string>)((Button)sender).Tag;
          
            string unitShopTemId = tagValues.Item1;
            string unitApplianceId = tagValues.Item2;
            ST.DeleteShopCartCell(unitShopTemId);
            DataTable dtpro = new DataTable();
            dtpro = AT2.GetSpecificItem(unitApplianceId);
            foreach (DataRow row in dtpro.Rows)
            {

               string AppliancesName = row.Field<string>("AppliancesName");
               string PowerUsage = row.Field<string>("PowerUsage");
                string Brand = row.Field<string>("Brand");
                string Model = row.Field<string>("Model");
                string Dimension = row.Field<string>("Dimension");
                string Color = row.Field<string>("Color");
                string picture = row.Field<string>("picture");
                string AppliancesID = row.Field<string>("AppliancesID");
               string EnergyConsumption = row.Field<string>("EnergyConsumption");
                string Type = row.Field<string>("Type");
                string Description = row.Field<string>("Description");
                decimal EstimateAnnCost = row.Field<decimal>("EstimateAnnCost");
                decimal MonthlyFee = row.Field<decimal>("MonthlyFee");
                string AdminID = row.Field<string>("AdminID");
        int totalQuantity = row.Field<int>("Quantity")+1;
        AT2.UpdateAppliance(AppliancesName, PowerUsage, Brand, Model, Dimension, Color, totalQuantity, picture, AppliancesID, EnergyConsumption, Type, Description, EstimateAnnCost, MonthlyFee, AdminID);


            }

           PanelShopCart.Controls.Clear();
            ExampleShopCart();
            totalPrice();
           

        }




        private void btnRent_Click(object sender, EventArgs e)
        {

         
            AutoID();
           
            DataTable dt2 = new DataTable();
                 DataTable dt = new DataTable();
           dt= SPCA.GetData();
           DateTime RentDate = DateTime.Now;

           RT.Insert(userId, RentID, totalDiscount, dt.Rows.Count, CboPaymentType.SelectedItem.ToString(), totalCost, RentDate);
          
          totalPrice();
       
           foreach(DataRow row in dt.Rows )
           {
               AutoIDForRentDetail();
              

               RDT2.Insert(RentDetailID,RentID, row.Field<string>("AppliancesID"), row.Field<decimal>("UnitTotalPrice"), row.Field<DateTime>("FromDate"), row.Field<DateTime>("DueDate"), row.Field<decimal>("discount"), row.Field<int>("TotalMonths"));
           }
            ST.DeleteQuery();
            PanelShopCart.Controls.Clear();
            ExampleShopCart();
           MessageBox.Show("Saved sucessfully");
           
        }

        private void AutoID()
        {
            DataTable dt = new DataTable();
            dt = RT.GetData();
            int NoofRow = dt.Rows.Count;
            if (NoofRow < 1)
            {
                RentID = "RD-00001";
            }

            else
            {

                int oldid = dt.Rows.Count + 1;
               // string OldID = dt.Rows[oldid][0].ToString();
                //int OldNum = Convert.ToInt32(OldID.Substring(3));

              //  OldNum++;
                String NewID = "RD-" + oldid.ToString("00000");
                RentID = NewID;
            }
        }

        //AutoId for RentDetail
        private void AutoIDForRentDetail()
        {
            DataTable dt = new DataTable();
            dt = RDT2.GetData();
            int NoofRow = dt.Rows.Count;
            if (NoofRow < 1)
            {
                RentDetailID = "RE-00001";
            }

            else
            {

                int oldid = dt.Rows.Count + 1;
                // string OldID = dt.Rows[oldid][0].ToString();
                //int OldNum = Convert.ToInt32(OldID.Substring(3));

                //  OldNum++;
                String NewID = "RE-" + oldid.ToString("00000");
                RentDetailID = NewID;
            }
        }
 
        //Calculate total price
        public void totalPrice()
        {
            decimal totalprice = 0;
            decimal discount = 0;
            DataTable dt = new DataTable();
          
           dt= SPCA.GetData();
          
    
            foreach (DataRow row in dt.Rows) {
                totalmonths += row.Field<int>("TotalMonths");
                 discount+= row.Field<decimal>("discount");
                totalprice += row.Field<decimal>("UnitTotalPrice");
            }

            txtTotalPrice.Text = totalprice.ToString();
            txtDiscount.Text = discount.ToString();
            totalDiscount = discount;
            totalCost = totalprice;
        
        }
        //set paymentType
        public void PaymentType() {

            if (!CboPaymentType.Items.Contains("Bank") & !CboPaymentType.Items.Contains("Cash On Delivery") & !CboPaymentType.Items.Contains("Credit Card"))
            {
                CboPaymentType.Items.Add("Bank");
                CboPaymentType.Items.Add("Cash On Delivery");
                CboPaymentType.Items.Add("Credit Card");
            }
          

            CboPaymentType.SelectedIndex = 0;

        
        }
      

       

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void btnStaffLogin_Click(object sender, EventArgs e)
        {
            UserPanel UP = new UserPanel(userId);
            UP.Show();
            this.Hide();
        }

      

       
        

       
    }
}
