using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2
{
    public partial class AddressForm : Form
    {
        public AddressForm()
        {
            InitializeComponent();
        }

        private void buttonSubmit_Click_1(object sender, EventArgs e)
        {
            richTextBoxShow.Clear();
            var item = treeViewAddress.SelectedNode;
            Address address = new Address (item.Parent.Parent.Parent.Text, item.Parent.Parent.Text, item.Parent.Text, int.Parse(item.Text));
            richTextBoxShow.Text += string.Format("Country: {0}\nCity: {1}\nStreet: {2}\nHouse: {3}\n", address.Country, address.City, address.Street,
                address.House);
        }

        private void universityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            University university = new University();
            university.ShowDialog();
        }
    }
}
