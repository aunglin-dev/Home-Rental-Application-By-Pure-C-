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
    public partial class SpecificHistory : Form
    {
        public SpecificHistory(string rentId,string userId)
        {
            InitializeComponent();
            DetailHistory(rentId,userId);
     


        }

        RentalTableAdapters.DetailHistoryTableAdapter DHT = new RentalTableAdapters.DetailHistoryTableAdapter();
        RentalTableAdapters.RentDetail2TableAdapter RD = new RentalTableAdapters.RentDetail2TableAdapter();
        private TableLayoutPanel tableShopCart;


        public void DetailHistory(string rent,string user)
        {
           
            DataTable dt = new DataTable();
           

            dt = DHT.GetDetailHistory(user,rent);


            // Create the TableLayoutPanel dynamically
            tableShopCart = new TableLayoutPanel();
            tableShopCart.AutoScroll = true;
            tableShopCart.Dock = DockStyle.Fill;
            tableShopCart.ColumnCount = dt.Columns.Count + 1;
            tableShopCart.RowCount = dt.Rows.Count + 1;
            tableShopCart.ColumnStyles.Clear();
            tableShopCart.RowStyles.Clear();
       

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
                label.Font = new Font("Century Gothic", 8F, FontStyle.Bold);
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
             

            }
            panelSpecificHistory.Controls.Add(tableShopCart);
             

        }
      
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();

        }
    }
}
