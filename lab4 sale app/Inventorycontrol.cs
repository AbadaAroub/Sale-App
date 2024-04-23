using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace lab4_sale_app
{
    public partial class Inventorycontrol : UserControl
    {
        BindingSource ProductSource;
        Product selectedItem;
        library MyLibrary;
        public Inventorycontrol(library myLibrary, BindingSource productSource)
        {
            InitializeComponent();
            this.ProductSource = productSource;
            MyLibrary= myLibrary;
            ProductDataGrid.DataSource = productSource;
          
        }

        private void SetTextEnabled(bool state)
        {
            NameText.Enabled = state;
            PriceText.Enabled = state;
            IDText.Enabled = state;
            QuantityText.Enabled = state;
            PlatformText.Enabled = state;
            AuthorText.Enabled = state;
            LanguageText.Enabled = state;
            FormatText.Enabled = state;
            GenreText.Enabled = state;
            TimeText.Enabled = state;
            Dtext.Enabled = state;
            ProductText.Enabled = state;
        }

        private void ProductDataGrid_selectionChanged(object sender, EventArgs e)
        {
            if(ProductDataGrid.SelectedRows.Count < 1)
            {
                SetTextEnabled(false);
                return;
            }
  
            var product = (Product)ProductDataGrid.SelectedRows[0].DataBoundItem;
            NameText.Text = product.Name;
            PriceText.Text = product.Price;
            IDText.Text = product.ProductID;
            QuantityText.Text = product.Quantity.ToString();
            PlatformText.Text = product.Platform;
            AuthorText.Text = product.Author;
            LanguageText.Text = product.Language;
            FormatText.Text = product.Format;
            GenreText.Text = product.Genre;
            TimeText.Text = product.PlayTime;
            Dtext.Text = product.Description;
            selectedItem = product;
            SaveButton.Enabled = false;
            CancelButton.Enabled = false;
            SetTextEnabled(true);
        }

        private void PriceText_TextChanged(object sender, EventArgs e)
        {
            SaveButton.Enabled = true;
            CancelButton.Enabled = true;
        }

        private void NameText_TextChanged(object sender, EventArgs e)
        {
            SaveButton.Enabled = true;
            CancelButton.Enabled = true;
        }

        private void IDText_TextChanged(object sender, EventArgs e)
        {
            SaveButton.Enabled = true;
            CancelButton.Enabled = true;
        }

        private void QuantityText_TextChanged(object sender, EventArgs e)
        {
            SaveButton.Enabled = true;
            CancelButton.Enabled = true;
        }

        private void PlatformText_TextChanged(object sender, EventArgs e)
        {
            SaveButton.Enabled = true;
            CancelButton.Enabled = true;
        }

        private void AuthorText_TextChanged(object sender, EventArgs e)
        {
            SaveButton.Enabled = true;
            CancelButton.Enabled = true;
        }

        private void LanguageText_TextChanged(object sender, EventArgs e)
        {
            SaveButton.Enabled = true;
            CancelButton.Enabled = true;
        }

        private void FormatText_TextChanged(object sender, EventArgs e)
        {
            SaveButton.Enabled = true;
            CancelButton.Enabled = true;
        }

        private void GenreText_TextChanged(object sender, EventArgs e)
        {
            SaveButton.Enabled = true;
            CancelButton.Enabled = true;
        }

        private void TimeText_TextChanged(object sender, EventArgs e)
        {
            SaveButton.Enabled = true;
            CancelButton.Enabled = true;
        }

        private void Dtext_TextChanged(object sender, EventArgs e)
        {
            SaveButton.Enabled = true;
            CancelButton.Enabled = true;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            ProductDataGrid_selectionChanged(sender, null);

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
                selectedItem.Name = NameText.Text;
                selectedItem.Price = PriceText.Text;
                selectedItem.ProductID = IDText.Text;
                selectedItem.Quantity = int.Parse(QuantityText.Text);
                selectedItem.Platform = PlatformText.Text;
                selectedItem.Author = AuthorText.Text;
                selectedItem.Language = LanguageText.Text;
                selectedItem.Format = FormatText.Text;
                selectedItem.Genre = GenreText.Text;
                selectedItem.PlayTime = TimeText.Text;
                selectedItem.Description = Dtext.Text;
                ProductSource.ResetCurrentItem();
                ProductDataGrid_selectionChanged(sender, null);
                MyLibrary.SaveFileDialog();
            }
        

        private void Deletebutton_Click(object sender, EventArgs e)
        {
            if (ProductDataGrid.SelectedRows.Count < 1)
                return;
            if (int.Parse(QuantityText.Text) == 0)
            {
                var product = (Product)ProductDataGrid.SelectedRows[0].DataBoundItem;
                ProductSource.Remove(product);
                NameText.Text = PriceText.Text = IDText.Text = QuantityText.Text = PlatformText.Text = AuthorText.Text = LanguageText.Text = FormatText.Text = GenreText.Text = TimeText.Text = Dtext.Text = string.Empty;
                SaveButton.Enabled = false;
                CancelButton.Enabled = false;
                ProductDataGrid_selectionChanged(sender, null);
                MyLibrary.SaveFileDialog();
            }
            else
            {
                string message = "Are you sure you want to delete this product?";
                string title = "Delete Window";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    var product = (Product)ProductDataGrid.SelectedRows[0].DataBoundItem;
                    ProductSource.Remove(product);
                    NameText.Text = PriceText.Text = IDText.Text = QuantityText.Text = PlatformText.Text = AuthorText.Text = LanguageText.Text = FormatText.Text = GenreText.Text = TimeText.Text = Dtext.Text = string.Empty;
                    SaveButton.Enabled = false;
                    CancelButton.Enabled = false;
                    ProductDataGrid_selectionChanged(sender, null);
                    MyLibrary.SaveFileDialog();

                }
                else if(result == DialogResult.No)
                {
                    MyLibrary.SaveFileDialog();
                    return;

                }
            }
        }

        private void Addbutton_Click(object sender, EventArgs e)
        {
            AddProductForm addProductForm = new AddProductForm();
            addProductForm.StartPosition = FormStartPosition.CenterParent;
            if (addProductForm.ShowDialog() == DialogResult.OK)
            {
                ProductSource.Add(addProductForm.Result);
                MyLibrary.SaveFileDialog();
            }
            else
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WebClient client = new WebClient();
            var text = client.DownloadString("https://hex.cse.kau.se/~jonavest/csharp-api");
            XmlDocument document = new XmlDocument();
            document.LoadXml(text);
            XmlWriterSettings textwriter = new XmlWriterSettings();
            textwriter.Indent = true;
            XmlWriter save = XmlWriter.Create("KAUAPI.xml", textwriter);
            document.Save(save);
            save.Close();
            if (!document.FirstChild.InnerXml.Contains("error"))
            {
                document.Load("KAUAPI.xml");
                XmlNodeList pelem = document.SelectNodes("/response/products/*");
                foreach (XmlElement elem in pelem)
                {
                    foreach (DataGridViewRow product in ProductDataGrid.Rows)
                    {
                        int ID = int.Parse(elem.ChildNodes[0].InnerXml);
                        int Pid = int.Parse((string)product.Cells[2].Value);
                        if (ID == Pid)
                        {
                            int Pr = int.Parse(elem.ChildNodes[2].InnerXml);
                            product.Cells[1].Value = Pr;
                            int Qnt = int.Parse(elem.ChildNodes[3].InnerXml);
                            product.Cells[3].Value = Qnt;
                        }
                    }
                }
                ProductDataGrid.Refresh();
            }
            else
            {
                MessageBox.Show("error! ", "error message", MessageBoxButtons.OK);
            }

        }
    }
}
    

