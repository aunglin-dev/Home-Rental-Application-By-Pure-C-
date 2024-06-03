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
    public partial class ShopCart : UserControl
    {



      
        public ShopCart()
        {
            InitializeComponent();

           

        }



   private TableLayoutPanel tableShopCart;

       
      public void ExampleShopCart()
        {
            RentalTableAdapters.ShopCartAndAppTableAdapter SPCA = new RentalTableAdapters.ShopCartAndAppTableAdapter();
            DataTable dt = new DataTable();
           
           
            PanelShopCart.Controls.Clear();
            
            dt = SPCA.GetData();
            

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
                tableShopCart.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80F));
            }

            tableShopCart.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));

            // Adding column headers to the TableLayoutPanel
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                Label label = new Label();
                label.Text = dt.Columns[i].ColumnName;
                label.Dock = DockStyle.Fill;
                label.TextAlign = ContentAlignment.MiddleCenter;
                label.Font = new Font("Century Gothic", 7F, FontStyle.Bold);
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
                btnCancel.Text = "Cancel";
                btnCancel.Tag = dt.Rows[i][0];
                btnCancel.Click += new EventHandler(Cancel_Click);

            }
            PanelShopCart.Controls.Add(tableShopCart);

        }
        private void Cancel_Click(object sender, EventArgs e)
        {
            RentalTableAdapters.ShopCartTableAdapter ST = new RentalTableAdapters.ShopCartTableAdapter();
            DataTable dtS = new DataTable();

            Button clickedButton = (Button)sender;
            string unitItemId = clickedButton.Tag.ToString();
            ST.DeleteShopCartCell(unitItemId);
            PanelShopCart.Controls.Clear();
            ExampleShopCart();
            // MessageBox.Show(unitItemId);

        }  
       

    }
}
