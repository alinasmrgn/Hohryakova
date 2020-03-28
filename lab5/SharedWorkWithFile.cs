using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2
{
    public static class SharedWorkWithFile<T>
    {
        public static void ReadFromFile(Button button, OpenFileDialog openFileDialogRead, List<T> list, RichTextBox richTextBox)
        {
            if (openFileDialogRead.ShowDialog() == DialogResult.Cancel)
                return;
            list.AddRange(XmlSerializeWrapper.Deserialize<List<T>>(openFileDialogRead.FileName).ToArray());
            list = list.Distinct().ToList();
            FillRichTextBox(richTextBox, list);
        }

        public static void WriteToFile(Button button, SaveFileDialog saveFileDialogWrite, List<T> list)
        {
            if (saveFileDialogWrite.ShowDialog() == DialogResult.Cancel)
                return;
            XmlSerializeWrapper.Serialize(list, saveFileDialogWrite.FileName);
        }

        public static void FillRichTextBox(RichTextBox richTextBoxShow, List<T> list)
        {
            richTextBoxShow.Text = "";
            if (list as List<Student> != null)
            {
                TextStudent(list, richTextBoxShow);
            }
            else if (list as List<WorkPlace> !=null)
            {
                TextWorkPlace(list, richTextBoxShow);
            }
            else if(list as List<Address> != null)
            {
                TextAddress(list, richTextBoxShow);
            }
        }

        private static void TextStudent(List<T> list, RichTextBox richTextBox)
        {
            richTextBox.Clear();
            int i = 1;
            List<Student> students = list as List<Student>;
            foreach (var item in students)
            {
                richTextBox.Text += string.Format("Student №{0}\nFull Name: {1}\nAge: {2}\nSpeciality: {3}\nDate of Birth: {4}\n" +
                    "Course: {5}\nAverage Mark: {6}\nGroup: {7}\n", i, item.FullName, item.Age, item.Speciality,
                    item.DateOfBirth.ToShortDateString(), item.Course, item.AverageMark, item.Group) + string.Format("Address №{0}\nCountry: {1}\nCity: {2}\nStreet: {3}\nHouse: {4}\n\n", i++,
                    item.Address.Country, item.Address.City, item.Address.Street, item.Address.House);
            }
        }

        private static void TextWorkPlace(List<T> list, RichTextBox richTextBox)
        {
            richTextBox.Clear();
            int i = 1;
            List<WorkPlace> workPlaces = list as List<WorkPlace>;
            foreach (var item in workPlaces)
            {
                richTextBox.Text += string.Format("WorkPlace №{0}\nCompany: {1}\nPost: {2}\nExperience: {3}\nAddress: {4}\n\n", i++,
                    item.Company, item.Post, item.Experience, item.Address);
            }
        }

        private static void TextAddress(List<T> list, RichTextBox richTextBox)
        {
            richTextBox.Clear();
            int i = 1;
            List<Address> addresses = list as List<Address>;
            foreach (var item in addresses)
            {
                richTextBox.Text += string.Format("Address №{0}\nCountry: {1}\nCity: {2}\nStreet: {3}\nHouse: {4}\n\n", i++,
                    item.Country, item.City, item.Street, item.House);
            }
        }
    }
}
