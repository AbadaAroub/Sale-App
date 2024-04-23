using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;


namespace lab4_sale_app
{
    public partial class AddProductForm : Form
    {
        library MyLibrary;
        private const int MIN = 0, MAX = 999999;
        BindingSource ProductSource;
        internal Product Result { get; private set; }
        public AddProductForm()
        {
            InitializeComponent();
            MyLibrary = new library();
            ProductSource = new BindingSource();
            ProductSource.DataSource = MyLibrary.ProductList;
        }



        private void AddButton_Click(object sender, EventArgs e)
        {

            Random rnd = new Random();
            int ID = 0, price, Qty;
            bool temp;
            if (IDText.Text == "")
            {
                ID = rnd.Next(MIN, MAX);
                for (int i = 0; i < MyLibrary.ProductList.Count; i++)
                {
                    if (int.Parse(MyLibrary.ProductList.ElementAt(i).ProductID) == ID)
                    {
                        ID = rnd.Next(MIN, MAX);
                        i = 0;
                    }
                }
                IDText.Text = ID.ToString();
            }
        
            else
            {
                try
                {
                    ID = int.Parse(IDText.Text);
                    temp = MyLibrary.IDValid(ID);
                    if (!temp)
                    {
                        MessageBox.Show("Product ID is already used!\nTry another product ID!");
                        return;
                    }
                    if (ID < 0)
                    {
                        MessageBox.Show("Product ID can't be negative!");
                        return;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Product id should be a number!");
                    return;
                }
            }

            if (ProductText.Text == "")
            {
                MessageBox.Show("Please select the type of the product!");
                return;
            }
            if (NameText.Text == "")
            {
                MessageBox.Show("Name can't be empty!");
                return;
            }
            if (PriceText.Text == "")
            {
                MessageBox.Show("Price can't be empty!");
                return;
            }
            if (QuantityText.Text == "")
            {
                MessageBox.Show("Quantity can't be empty!");
                return;
            }

            try
            {
                price = int.Parse(PriceText.Text);
                if (price < 0)
                {
                    MessageBox.Show("Price can't be negative!");
                    return;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Price should be a number!");
                return;
            }

            try
            {
                Qty = int.Parse(QuantityText.Text);
                if (Qty < 0)
                {
                    MessageBox.Show("Quantity can't be negative!");
                    return;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Quantity should be a number!");
                return;
            }
            try
            {
                if (TimeText.Text != "")
                {
                    if (int.Parse(TimeText.Text) < 0)
                    {
                        MessageBox.Show("PlayTime can not be negative!");
                        return;
                    }
                }

            }
            catch (Exception)
            {
                MessageBox.Show("PlayTime should be a number!");
                return;
            }
            Result = new Product(); 
            Result.Name = NameText.Text;
            Result.Price = PriceText.Text;
            Result.ProductID = IDText.Text;
            Result.Quantity = int.Parse(QuantityText.Text);
            Result.Platform = PlatformText.Text;
            Result.Author = AuthorText.Text;
            Result.Language = LanguageText.Text;
            Result.Format = FormatText.Text;
            Result.Genre = GenreText.Text;
            Result.PlayTime = TimeText.Text;
            Result.Description = Dtext.Text;
            

            DialogResult= DialogResult.OK;
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult= DialogResult.Cancel;
            this.Close();
        }

        private void ProductType_selectedindexChanged(object sender, EventArgs e)
        {
            if(ProductText.Text == "Book")
            {
                PriceText.Enabled = true;
                NameText.Enabled = true;
                IDText.Enabled = true;
                QuantityText.Enabled = true;
                PlatformText.Enabled = false;
                AuthorText.Enabled = true;
                LanguageText.Enabled = true;
                FormatText.Enabled = true;
                GenreText.Enabled = true;
                TimeText.Enabled = false;
                Dtext.Enabled = true;
            }
            else if (ProductText.Text == "Film")
            {
                PriceText.Enabled = true;
                NameText.Enabled = true;
                IDText.Enabled = true;
                QuantityText.Enabled = true;
                PlatformText.Enabled = false;
                AuthorText.Enabled = false;
                LanguageText.Enabled = true;
                FormatText.Enabled = true;
                GenreText.Enabled = false;
                TimeText.Enabled = true;
                Dtext.Enabled = true;
            }
            else if (ProductText.Text == "PC Games")
            {
                PriceText.Enabled = true;
                NameText.Enabled = true;
                IDText.Enabled = true;
                QuantityText.Enabled = true;
                PlatformText.Enabled = true;
                AuthorText.Enabled = false;
                LanguageText.Enabled = false;
                FormatText.Enabled = false;
                GenreText.Enabled = false;
                TimeText.Enabled = false;
                Dtext.Enabled = true;
            }
        }
    }
}
