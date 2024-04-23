using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab4_sale_app
{
    public partial class Sellcontrol : UserControl
    {
        private BindingSource ProductSource;
        private int x;
        Bitmap bitmap;
        library MyLibrary;
        public Button DefaultButton { get { return AddToCartbutton; } }
        public Sellcontrol(library myLibrary, BindingSource productSource)

        {

            InitializeComponent();
            ProductSource= productSource;
            this.ProductSource = productSource;
            MyLibrary= myLibrary;
            dataGridView1.DataSource= productSource;

        }

        private void Sellcontrol_Load(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            IDText.Text = "";
        }

        private void ProductListDataGrid_SelectionChanged(object sender, EventArgs e)
        {
            
            if (dataGridView1.SelectedRows.Count < 1)
                return;

            var product = (Product)dataGridView1.SelectedRows[0].DataBoundItem;
            IDText.Text = product.ProductID;
            dataGridView1.ClearSelection();
            IDText.Focus();
            IDText.SelectAll();
        }

        private void AddToCartbutton_Click(object sender, EventArgs e)
        {
            
            foreach(var product in (BindingList<Product>)ProductSource.DataSource)
            {
                if(product.ProductID == IDText.Text.Trim())
                {
                    if (product.Quantity == 0)
                    {
                        MessageBox.Show("Product is out of stock!");
                        return;
                    }
                    if (listBox1.Items.Count == 0) {
                        listBox1.Items.Add("Welcome to AA-Supermarket!");
                        listBox1.Items.Add(DateTime.Now.ToString("HH:mm:ss"));
                        listBox1.Items.Add(DateTime.Now.ToString("MM/dd/yyyy"));
                    }
                    
                    listBox1.Items.Add(product);
                    product.Quantity = product.Quantity - 1;
                    dataGridView1.Refresh();
                    x += int.Parse(product.Price);
                    listBox1.Refresh();
                    //MyLibrary.SaveFileDialog();
                }
            }
        }

        private void ReturnButton_Click(object sender, EventArgs e)
        {
            foreach (var product in (BindingList<Product>)ProductSource.DataSource)
            {
                if (product.ProductID == IDText.Text.Trim())
                {
                    if (listBox1.Items.Count > 0)
                    {
                        listBox1.Items.Remove(product);
                        product.Quantity = product.Quantity + 1;
                        dataGridView1.Refresh();
                        //MyLibrary.SaveFileDialog();
                    }
                    else
                    {
                        string message = "Are you sure you want to return this product?";
                        string title = "Return Window";
                        MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                        DialogResult result = MessageBox.Show(message, title, buttons);
                        if (result == DialogResult.Yes)
                        {
                            listBox1.Items.Remove(product);
                            product.Quantity = product.Quantity + 1;
                            dataGridView1.Refresh();

                        }
                        else if (result == DialogResult.No)
                        {
                            return;
                        }
                    }

                }
            }

        }

        private void SellButton_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add("Thank you for your shopping!");
            PrintButton_Click(sender, e);
            MyLibrary.SaveFileDialog();
            MessageBox.Show("Sold! Total " + x);
            listBox1.Items.Clear();
            return;
        }

        private void PrintButton_Click(object sender, EventArgs e)
        {
            string message = "Do you want to print the receipt?!";
            string title = "receipt Window";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                try
                {
                    int height = listBox1.Height;
                    listBox1.Height = listBox1.Height * 2;
                    bitmap = new Bitmap(listBox1.Width, listBox1.Height);
                    listBox1.DrawToBitmap(bitmap, new Rectangle(0, 0, listBox1.Width, listBox1.Height));
                    printPreviewDialog1.PrintPreviewControl.Zoom = 1;
                    printPreviewDialog1.ShowDialog();
                    listBox1.Height = height;
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }

            }
            else if (result == DialogResult.No)
            {
                return;
            }
           
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                e.Graphics.DrawImage(bitmap,0,0);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
