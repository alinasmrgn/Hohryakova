using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Collection
{
    public partial class Collection : Form
    {
        private List<string> _marks;
        private static Random random;
        public delegate int OrderSort(object object1, object object2);

        public Collection()
        {
            _marks = new List<string>();
            random = new Random();
            InitializeComponent();
        }

        private void ButtonGenerateCollection_Click(object sender, EventArgs e)
        {
            int size;
            ClearCollections();
            try
            {
                size = int.Parse(TextBoxSize.Text);
            }
            catch
            {
                size = 5;
            }
            FillCollection(size);
            ListBoxDefault.Items.AddRange(_marks.ToArray());
        }

        private void ClearCollections()
        {
            _marks.Clear();
            ListBoxDefault.Items.Clear();
            ListBoxResult.Items.Clear();
        }

        private void FillCollection(int size)
        {
            for (int i = 0; i < size; i++)
            {
                _marks.Add("Оценка " + random.Next(0, 10).ToString());
            }
        }

        private string[] Sort(string type)
        {
            OrderSort orderSort = Comparator;
            string[] array = _marks.ToArray();
            string temp = "";
            return type.Equals("ButtonSort") ? BubbleSort(array, orderSort, temp) : BubbleSortByDescending(array, orderSort, temp);
        }

        private string[] BubbleSort(string[] array, OrderSort orderSort, string temp)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    if ((orderSort(array[j], array[j + 1]) < 0))
                    {
                        temp = array[j + 1];
                        array[j + 1] = array[j];
                        array[j] = temp;
                    }
                }
            }
            return array;
        }
        private string[] BubbleSortByDescending(string[] array, OrderSort orderSort, string temp)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    if ((orderSort(array[j], array[j + 1]) > 0))
                    {
                        temp = array[j + 1];
                        array[j + 1] = array[j];
                        array[j] = temp;
                    }
                }
            }
            return array;
        }
        private int Comparator(object object1, object object2)
        {
            string str1 = (string)object1;
            string str2 = (string)object2;
            return string.Compare(str1, str2);
        }

        private void Sort_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            FillListBoxResult(Sort(button.Name));
        }

        private void FillListBoxResult(string[] array)
        {
            ListBoxResult.Items.Clear();
            ListBoxResult.Items.AddRange(array);
        }

        private void Querry_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            FillListBoxResult(GetQuerry(button.Name));
        }

        private string[] GetQuerry(string buttonName)
        {
            switch(buttonName)
            {
                case "ButtonDistinct":
                    return _marks.Distinct().ToArray();
                case "ButtonOnlyZero":
                    return _marks.Where(mark => mark.Contains(" 0")).ToArray();
                case "ButtonFirstFive":
                    return _marks.Take(5).ToArray();
                default:
                    return _marks.ToArray();
            }
        }
    }
}