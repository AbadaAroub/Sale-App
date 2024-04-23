using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab4_sale_app
{
    public partial class MainForm : Form
    {
        library MyLibrary;
        BindingSource ProductSource;

        public MainForm()
        {
            InitializeComponent();
            ProductSource= new BindingSource();
            MyLibrary = new library();
            MyLibrary.LoadFile();
            ProductSource.DataSource= MyLibrary.ProductList;


        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Inventorycontrol inventorycontrol = new Inventorycontrol(MyLibrary, ProductSource);
            Sellcontrol sellcontrol = new Sellcontrol(MyLibrary, ProductSource);
            inventorycontrol.Dock= DockStyle.Fill;
            sellcontrol.Dock = DockStyle.Fill;
            invtab.Controls.Add(inventorycontrol);
            kassatab.Controls.Add(sellcontrol);

            AcceptButton = sellcontrol.DefaultButton;

        }
    }
}
