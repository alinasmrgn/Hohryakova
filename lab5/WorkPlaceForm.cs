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
    public partial class WorkPlaceForm : Form
    {
        private List<WorkPlace> _workPlaces;

        public WorkPlaceForm()
        {
            InitializeComponent();
            _workPlaces = new List<WorkPlace>();
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            for (int i=0; i<dataGridViewWorkPlace.Rows.Count-1; i++)
            {
                var cells = dataGridViewWorkPlace.Rows[i].Cells;
                CheckEmptyCells(cells);
                WorkPlace workPlace = new WorkPlace(cells[0].Value.ToString(), cells[1].Value.ToString(), cells[2].Value.ToString(),
                    cells[3].Value.ToString());
                _workPlaces.Add(workPlace);
            }
            SharedWorkWithFile<WorkPlace>.FillRichTextBox(richTextBoxShow, _workPlaces);
        }

        private void WorkWithFiles(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button.Name.Equals(buttonReadFromXML.Name))
                SharedWorkWithFile<WorkPlace>.ReadFromFile(button, openFileDialogRead, _workPlaces, richTextBoxShow);
            else
                SharedWorkWithFile<WorkPlace>.WriteToFile(button, saveFileDialogWrite, _workPlaces);
        }

        private void CheckEmptyCells(DataGridViewCellCollection cellCollection)
        {
            for (int i=0; i<cellCollection.Count; i++)
            {
                if (cellCollection[i].Value==null)
                {
                    object temp = "unknown";
                    cellCollection[i].Value = temp;
                }
            }
        }

        private void universityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            University university = new University();
            university.ShowDialog();
        }

        private void addressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            AddressForm address = new AddressForm();
            address.Show();
        }
    }
}
