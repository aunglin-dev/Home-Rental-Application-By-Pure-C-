using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Customer_N_ProductRegisteration.LoginRegisteUI
{
    public partial class UnitItem : Form
    {

        UnitItemDataStore UID = new UnitItemDataStore();
      

        RentalTableAdapters.Appliances2TableAdapter AT2 = new RentalTableAdapters.Appliances2TableAdapter();
        RentalTableAdapters.ShopCartTableAdapter ST = new RentalTableAdapters.ShopCartTableAdapter();
       private int totalQuantity;
       private decimal EstimateAnnCost, MonthlyFee;
        private string ShopID,UnitId;
        private string AppliancesName, PowerUsage, Brand, Model, Dimension, Color, picture, AppliancesID, EnergyConsumption, Type, Description, AdminID;
        public UnitItem(string data)
        {
            InitializeComponent();


            displayBtn();

            FillDatainlable(data);
            displayLabel();
            UnitId = data;
          AutoID();
           
            
        }

        public void displayLabel() {
            lblDes.Text = Description;
            lblName.Text = AppliancesName;
            lblPowerUsage.Text = PowerUsage;
            lblModel.Text = Model;
            lblType.Text = Type;
            lblColor.Text = Color;
            lblId.Text = AppliancesID;
            lblEstimateCost.Text = EstimateAnnCost.ToString();
            lblMonthlyFee.Text = MonthlyFee.ToString();
            lblDimension.Text = Dimension;
             //pictureLink.Image = Image.FromFile(picture);
            lblEnergy.Text = EnergyConsumption;
            lblBrand.Text = Brand;
       
        
        }

        //Display how many items are added in ShopCart
        public void displayBtn() {
           
            DataTable dtpro = new DataTable();
            dtpro = ST.GetData();
            
           
            lblDisplay.Text = dtpro.Rows.Count.ToString(); ;
        }


        public void FillDatainlable(string unitId) 
        {
            DataTable dtpro = new DataTable();
          
        dtpro = AT2.GetSpecificItem(unitId);
       

        foreach (DataRow row in dtpro.Rows)
        {

            AppliancesName = row.Field<string>("AppliancesName");
            PowerUsage = row.Field<string>("PowerUsage");
            Brand = row.Field<string>("Brand");
            Model = row.Field<string>("Model");
            Dimension = row.Field<string>("Dimension");
            Color = row.Field<string>("Color");
            picture = row.Field<string>("picture");
            AppliancesID = row.Field<string>("AppliancesID");
            EnergyConsumption = row.Field<string>("EnergyConsumption");
            Type = row.Field<string>("Type");
            Description = row.Field<string>("Description");
            EstimateAnnCost = row.Field<decimal>("EstimateAnnCost");
            MonthlyFee = row.Field<decimal>("MonthlyFee");
            AdminID = row.Field<string>("AdminID");
            
            totalQuantity = row.Field<int>("Quantity");
           
            
        }
           
        }

        private void btnSave_Click(object sender, EventArgs e)  
        {

            try
            {
               

                if (totalQuantity < 1) {
                    throw new Exception("Sorry, this product is out of stock");//if product quantity is 0, throw an exception
                }
                else if (NUDtotalMonths.Value == 0) {
                    throw new Exception("You need to choose total months to rent"); //if numerical updown is not chose ,throw an exception
                }

                DataTable dtpro = new DataTable();
                decimal MothlyFee = decimal.Parse(lblMonthlyFee.Text);
                int TotalMonths = (int)NUDtotalMonths.Value;

                decimal discount = TotalMonths > 1 ? MothlyFee : 0; //using conditional operator 
                DateTime currentdate = DateTime.Now;
                DateTime duedate = currentdate.AddMonths(TotalMonths);
                decimal totalPrice = (TotalMonths * MothlyFee) - discount;
                string apID = lblId.Text == null ? "Ap_001" : lblId.Text;
                string apName = lblDes.Text == null ? "testing1" : lblDes.Text;


               
                dtpro = AT2.GetSpecificItem(UnitId);
                foreach (DataRow row in dtpro.Rows)
                {
                    totalQuantity = row.Field<int>("Quantity") - 1;  //minus total quantity everytime when user clicked add to shopcart button
                }
              

                AT2.UpdateAppliance(AppliancesName, PowerUsage, Brand, Model, Dimension, Color, totalQuantity, picture, AppliancesID, EnergyConsumption, Type, Description, EstimateAnnCost, MonthlyFee, AdminID);
                ST.Insert(ShopID, apID, currentdate, duedate, totalPrice, discount, true, TotalMonths);
                AutoID();
                displayBtn();
            }
            catch (Exception ex) {

                MessageBox.Show(ex.Message, "Dear Customer", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }


        }


        //Automatically generate ID
        private void AutoID()
        {
            DataTable dt = new DataTable();
            dt = ST.GetData();
            int NoofRow = dt.Rows.Count;
            if (NoofRow < 1)
            {
                ShopID= "SP-00001";
            }

            else
            {
                int oldid = dt.Rows.Count-1;
                string OldID = dt.Rows[oldid][0].ToString();
                int OldNum = Convert.ToInt32(OldID.Substring(3));
                
                OldNum++;
                String NewID = "SP-" + OldNum.ToString("00000");
                ShopID= NewID;
            }
        }

      
    

        private void button1_Click(object sender, EventArgs e)
        {
           
            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

       

       

      
    }
}
