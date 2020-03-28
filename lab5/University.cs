using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2
{
    public partial class University : Form
    {
        private List<Student> _students;

        public University()
        {
            InitializeComponent();
            _students = new List<Student>();
            listBoxAverage.DataSource = GetAverages();
            dateTimePickerDateOfBirth.MaxDate = DateTime.Now;
        }

        private void WorkWithFiles(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button.Name.Equals(buttonReadFromXML.Name))
                SharedWorkWithFile<Student>.ReadFromFile(button, openFileDialogRead, _students, richTextBoxShowStudent);
            else
                SharedWorkWithFile<Student>.WriteToFile(button, saveFileDialogWrite, _students);
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            if (textBoxFullName.Text.Equals("") || numericUpDownAge.Value == 0 || ((string)comboBoxSpeciality.SelectedItem).Equals("") ||
                dateTimePickerDateOfBirth.Value == null || CheckRadioButtons() || ((string)listBoxAverage.SelectedItem).Equals(""))
            {
                MessageBox.Show("All fields are required!");
            }
            else
            {
                var names = _students.Select(student => student.FullName);
                if (names.Contains(textBoxFullName.Text))
                    MessageBox.Show("This student already exists.");
                else
                {
                    _students.Add(CreateStudent());
                    SharedWorkWithFile<Student>.FillRichTextBox(richTextBoxShowStudent, _students);
                }
            }
        }

        private bool CheckRadioButtons()
        {
            return !radioButtonCourseOne.Checked && !radioButtonCourseTwo.Checked && !radioButtonCourseThree.Checked && !radioButtonCourseFour.Checked;
        }

        private int GetCourse()
        {
            if (radioButtonCourseOne.Checked)
                return int.Parse(radioButtonCourseOne.Text);
            else if (radioButtonCourseTwo.Checked)
                return int.Parse(radioButtonCourseTwo.Text);
            else if (radioButtonCourseThree.Checked)
                return int.Parse(radioButtonCourseThree.Text);
            else if (radioButtonCourseFour.Checked)
                return int.Parse(radioButtonCourseFour.Text);
            else
                return 1;
        }

        private Student CreateStudent()
        {
            var item = treeViewAddress.SelectedNode;
            Address address = new Address(item.Parent.Parent.Parent.Text, item.Parent.Parent.Text, item.Parent.Text, int.Parse(item.Text));
            return new Student(textBoxFullName.Text, (int)numericUpDownAge.Value, (string)comboBoxSpeciality.SelectedItem,
                dateTimePickerDateOfBirth.Value.Date, GetCourse(), (string)listBoxAverage.SelectedItem, trackBarGroup.Value, address);
        }

        private void trackBarGroup_Scroll(object sender, EventArgs e)
        {
            TrackBar trackBar = (TrackBar)sender;
            labelGroup.Text = "Group: " + trackBar.Value;
        }

        private string[] GetAverages()
        {
            string[] averages = { "1-1,9", "2-2,9", "3-3,9", "4-4,9", "5-5,9", "6-6,9", "7-7,9", "8-8,9", "9-10" };
            return averages;
        }

        private void workPlaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            WorkPlaceForm workPlace = new WorkPlaceForm();
            workPlace.Show();
        }

        private void addressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            AddressForm address = new AddressForm();
            address.Show();
        }
    }
}
