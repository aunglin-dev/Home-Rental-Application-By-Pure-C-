using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Data.SqlClient;


namespace Customer_N_ProductRegisteration.AdminControlPanle
{
    public partial class ControlMainForm : Form
    {

        
        RentalTableAdapters.Appliances2TableAdapter AT2 = new RentalTableAdapters.Appliances2TableAdapter();
        DataTable dt = new DataTable();
     //   DataRow dr; 


        private string adminId { get; set; }
        private decimal AnnualCost,MonthlyFee;
        public ControlMainForm(string id, string name)
        {
            InitializeComponent();
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            adminId = id;
            btnAdminName.Text = name;
          dt = AT2.GetData();
          SetType();
          AutoID();
            dgvAppliances.DataSource = dt;
            dgvAppliances.Refresh();
        }



        private void AutoID()
        {
            DataTable dt = new DataTable();
            dt = AT2.GetData();
            int NoofRow = dt.Rows.Count;
            if (NoofRow < 1)
            {
                txtappId.Text = "AP-00001";
            }

            else
            {
                int oldid = dt.Rows.Count - 1;
                string OldID = dt.Rows[oldid][8].ToString();
                int OldNum = Convert.ToInt32(OldID.Substring(3));

                OldNum++;
                String NewID = "AP-" + OldNum.ToString("00000");
                txtappId.Text = NewID;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            try {
                string[] txtArray = { txtApplianceName.Text, txtdescription.Text, txtPowerUsage.Text, txtBrand.Text, txtColor.Text, txtType.Text, txtModel.Text, txtDimension.Text, txtEnergyConsumption.Text };
                bool empty = true;

                foreach (var txtBoxes in txtArray)
                {

                    if (Regex.IsMatch(txtBoxes, @"^\s*$"))
                    {
                        empty = false;

                        MessageBox.Show("All textboxes have to be added data");
                        break;
                    }

                }

                int Quantity = (int)NUDQuantity.Value;



                if (empty)
                {
                    if (Quantity == 0)
                    {
                        MessageBox.Show("Total Quantity have to be added");
                    }
                    else if (pictureLink.Image == null)
                    {
                        MessageBox.Show("Add picture");
                    }
                    else if (!Regex.IsMatch(txtAnnCost.Text, @"^\d+(\.\d+)?$"))
                    {
                        MessageBox.Show("Annual Cost should be number");
                    }

                    else if (!Regex.IsMatch(txtMonthlyFee.Text, @"^\d+(\.\d+)?$"))
                    {
                        MessageBox.Show("Monthly Fee should be number");
                    }

                    else
                    {

                        string Picturelocation = "C:\\Users\\Asus\\Documents\\150(DDOOCP-Exe)\\DDOOCP_Assignment\\AdminView\\Customer_N_ProductRegisteration\\bin\\Debug";
                        string path = Path.Combine(Picturelocation, txtappId.Text + ".jpg");
                        Image img = pictureLink.Image;
                        img.Save(path);
                        AnnualCost = decimal.Parse(txtAnnCost.Text);
                        MonthlyFee = decimal.Parse(txtMonthlyFee.Text);


                        AT2.Insert(txtApplianceName.Text, txtPowerUsage.Text, txtBrand.Text, txtModel.Text, txtDimension.Text, txtColor.Text, Quantity, path, txtappId.Text, txtEnergyConsumption.Text, txtType.Text, txtdescription.Text, AnnualCost, MonthlyFee, adminId);
                        MessageBox.Show("Saved Successfully");
                        dt = AT2.GetData();
                        dgvAppliances.DataSource = dt;
                        dgvAppliances.Refresh();
             
                        Clear();
                    }

                }

            }
            catch (SqlException ex)
            {
                if (ex.Number == 8152) // over-range varchar column
                {
                    MessageBox.Show("The data is too long for some columns", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                   // MessageBox.Show();
                }
                else
                {
                    MessageBox.Show(ex.Message);
                }
            }

           
         
           
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            WelcomeFom WF = new WelcomeFom();
            WF.Show();
            this.Hide();
        }

        private void pictureLink_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            PictureBox p = sender as PictureBox;
            if (p != null) {

                open.Filter = "(*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";

                if (open.ShowDialog() == DialogResult.OK) {
                    p.Image = Image.FromFile(open.FileName);
                }
            }
        }

        private void ControlMainForm_Load(object sender, EventArgs e)
        {

        }

        private void dgvAppliances_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            DataGridViewRow row = this.dgvAppliances.Rows[e.RowIndex];
            txtappId.Text = row.Cells["AppliancesID"].Value.ToString();
            txtApplianceName.Text = row.Cells["AppliancesName"].Value.ToString();
            txtDimension.Text = row.Cells["Dimension"].Value.ToString();
            txtdescription.Text = row.Cells["Description"].Value.ToString();
            txtAnnCost.Text = row.Cells["EstimateAnnCost"].Value.ToString();
            txtPowerUsage.Text = row.Cells["PowerUsage"].Value.ToString();
            txtBrand.Text = row.Cells["Brand"].Value.ToString();
            string imageData = (string)row.Cells["picture"].Value;
           // Bitmap image = new Bitmap(new MemoryStream(imageData));
            pictureLink.Image = Image.FromFile(imageData);
            txtColor.Text = row.Cells["Color"].Value.ToString();
                    txtType.Text=row.Cells["Type"].Value.ToString();
                    txtModel.Text = row.Cells["Model"].Value.ToString();
                    txtEnergyConsumption.Text = row.Cells["EnergyConsumption"].Value.ToString();
                    txtMonthlyFee.Text = row.Cells["MonthlyFee"].Value.ToString();
                        NUDQuantity.Value = (int)row.Cells["Quantity"].Value;

                        btnSave.Enabled = false;
                        btnUpdate.Enabled = true;
                        btnDelete.Enabled = true;

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int Quantity = (int)NUDQuantity.Value;
            string Picturelocation = "C:\\Users\\Asus\\Documents\\150(DDOOCP-Exe)\\DDOOCP_Assignment\\AdminView\\Customer_N_ProductRegisteration\\bin\\Debug";
            string path = Path.Combine(Picturelocation, txtappId.Text + ".jpg");
            Image img = pictureLink.Image;
        
            AnnualCost = decimal.Parse(txtAnnCost.Text);
            MonthlyFee = decimal.Parse(txtMonthlyFee.Text);
            AT2.UpdateAppliance(txtApplianceName.Text, txtPowerUsage.Text, txtBrand.Text, txtModel.Text, txtDimension.Text, txtColor.Text, Quantity, path, txtappId.Text, txtEnergyConsumption.Text, txtType.Text, txtdescription.Text, AnnualCost, MonthlyFee, adminId);
            MessageBox.Show("Updated Successfully");
            dt = AT2.GetData();
            dgvAppliances.DataSource = dt;
            dgvAppliances.Refresh();
            AutoID();
            Clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                AT2.DeleteAppliance(txtappId.Text);
                MessageBox.Show("Deleted Successfully");
                dt = AT2.GetData();
                dgvAppliances.DataSource = dt;
                dgvAppliances.Refresh();

                Clear();
            }
            catch (Exception ex) {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Set the type combobox 
        public void SetType()
        {
            DataTable dt = new DataTable();
            dt = AT2.GetData();

            var types = dt.AsEnumerable().Select(row => row.Field<string>("Type")).Distinct();

            CboType.Items.Add("All");
            //Add all of types that are in database 
            foreach (var value in types)
            {
                CboType.Items.Add(value);
            }
            CboType.SelectedIndex = 0;
        }




        //Render appliances according to cboType's SelectedItem
        public void selectedItem()
        {

            DataTable dt = new DataTable();

            dt = AT2.GetItemType(CboType.SelectedItem.ToString());
          //  IEnumerable<DataRow> query = dt.AsEnumerable().OrderBy(row => row.Field<string>("AppliancesID"));
            dgvAppliances.DataSource = dt;
            dgvAppliances.Refresh();
         
        }

        public void Clear() {
            AutoID();
            txtApplianceName.Text = "";
            txtDimension.Text = "";
            txtdescription.Text = "";
            txtAnnCost.Text = "";
            txtPowerUsage.Text = "";
            txtBrand.Text = "";

            pictureLink.Image = null;
            txtColor.Text = "";
            txtType.Text = "";
            txtModel.Text = "";
            txtEnergyConsumption.Text = "";
            txtMonthlyFee.Text= "";
            NUDQuantity.Value = 0;
            btnSave.Enabled = true;
        
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }




        private void CboType_SelectedIndexChanged(object sender, EventArgs e)
        {
       

            if (CboType.SelectedIndex == 0)
            {

                dt = AT2.GetData();
                dgvAppliances.DataSource = dt;
                dgvAppliances.Refresh();

            }
            else
            {
                selectedItem();
            }
        }

      

        private void btnAdminName_Click(object sender, EventArgs e)
        {
           
        }

    }
}
