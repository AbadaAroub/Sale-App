using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab4_sale_app
{
    public class library
    {
        private List<string> csvFile;
        
        internal BindingList<Product> ProductList { get; private set; }
        public library()
        {
            ProductList = new BindingList<Product>();
        }

        internal bool IDValid(int ID)
        {
            LoadFile();

            foreach (var product in ProductList)
            {
                if (ID == int.Parse(product.ProductID))
                {
                    return false;
                }
            }
            return true;
        }

        public void SaveFileDialog()
        {
            string result = "";

            foreach (var product in ProductList)
            {
                result +=

                    product.Price +
                    ';' + product.Name +
                    ';' + product.ProductID +
                    ';' + product.Quantity +
                    ';' + product.Platform +
                    ';' + product.Author +
                    ';' + product.Language +
                    ';' + product.Format +
                    ';' + product.Genre +
                    ';' + product.PlayTime +
                    ';' + product.Description +

                    '\r';
            }
            if (!File.Exists("data.csv"))
            {
                File.Create("data.csv").Close();
            }
            System.IO.File.WriteAllText("data.csv", result);
        }
        public void LoadFile() 
        {
            if (File.Exists("data.csv"))
            {
                csvFile = new List<string>();
                try
                {
                    csvFile = System.IO.File.ReadAllText("data.csv").Split('\r').ToList();
                }
                catch (Exception)
                {
                    return;
                }

                // Remove the last line which is an empty line!
                csvFile.RemoveAt(csvFile.Count() - 1);

                foreach (string line in csvFile)
                {
                    try
                    {
                        ProductList.Add(new Product
                        {
                            Price = line.Split(';').ElementAt(0),
                            Name = line.Split(';').ElementAt(1),
                            ProductID = line.Split(';').ElementAt(2),
                            Quantity = int.Parse(line.Split(';').ElementAt(3)),
                            Platform = line.Split(';').ElementAt(4),
                            Author = line.Split(';').ElementAt(5),
                            Language = line.Split(';').ElementAt(6),
                            Format = line.Split(';').ElementAt(7),
                            Genre = line.Split(';').ElementAt(8),
                            PlayTime = line.Split(';').ElementAt(9),
                            Description = line.Split(';').Last()
                        });
                    }
                    catch (Exception)
                    {

                        return;
                    }


                    if (line.Split(';').ElementAt(0) == "")
                    {
                        Random rnd = new Random();
                        int ID = 0;
                        ID = rnd.Next(0, 999999);
                        for (int i = 0; i < ProductList.Count; i++)
                        {
                            if (int.Parse(ProductList.ElementAt(i).ProductID) == ID)
                            {
                                ID = rnd.Next(0, 999999);
                                i = 0;
                            }
                        }
                        
                        ProductList.ElementAt(ProductList.Count).ProductID = ID.ToString();
                    }

                }

            }
            else
            {
                File.Create("data.csv").Close();
            }
        }

      }
  }
 

