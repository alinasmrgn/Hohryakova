using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1
{
    public partial class Calculator : Form
    {
        double result = 0;
        string operation = "";
        bool isOperationDone = false;
        bool isEqualed = false;
        double memory;

        public Calculator()
        {
            InitializeComponent();
        }

        private void Number_Click(object sender, EventArgs e)
        {
            if (isEqualed)
                isEqualed = false;
            Button button = (Button)sender;
            if (Display.Text.Equals("0") || (isOperationDone))
                Display.Clear();
            isOperationDone = false;
            if ((button.Text.Equals(",") && !Display.Text.Contains(",")) || !button.Text.Equals(","))
            {
                Display.Text += button.Text;
            }
        }

        private void Operator_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (result != 0)
            {
                ButtonEqual.PerformClick();
            }
            operation = button.Text;
            result = double.Parse(Display.Text);
            if (!isEqualed)
                LabelResult.Text += result + " " + operation + " ";
            else
                LabelResult.Text += " " + operation;
            isOperationDone = true;
        }

        private void ButtonC_Click(object sender, EventArgs e)
        {
            operation = "";
            LabelResult.Text = "";
            Display.Text = "0";
            result = 0;
        }

        private void ButtonEqual_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            LabelResult.Text += Display.Text + button.Text;
            try
            {
                switch (operation)
                {
                    case "+":
                        Display.Text = (result + double.Parse(Display.Text)).ToString();
                        break;
                    case "-":
                        Display.Text = (result - double.Parse(Display.Text)).ToString();
                        break;
                    case "*":
                        Display.Text = (result * double.Parse(Display.Text)).ToString();
                        break;
                    case "/":
                        if (Display.Text.Equals("0"))
                            throw new ArithmeticException();
                        Display.Text = (result / double.Parse(Display.Text)).ToString();
                        break;
                    case "mod":
                        Display.Text = (result % double.Parse(Display.Text)).ToString();
                        break;
                    default:
                        LabelResult.Text = "";
                        break;
                }
            }
            catch (ArithmeticException ex)
            {
                Display.Text = "0";
                LabelResult.Text = "Division by ";
            }
            operation = "";
            isEqualed = true;
            LabelResult.Text += Display.Text;
        }

        private void ButtonMemory_Click(object sender, EventArgs e)
        {
            memory = double.Parse(Display.Text);
            LabelMemory.Text = "Mem: " + memory;
        }

        private void ButtonMemoryResult_Click(object sender, EventArgs e)
        {
            Display.Text += memory.ToString();
        }

        private void Calculator_Load(object sender, EventArgs e)
        {

        }

        private void LabelMemory_Click(object sender, EventArgs e)
        {

        }

        private void Display_TextChanged(object sender, EventArgs e)
        {

        }

        private void LabelResult_Click(object sender, EventArgs e)
        {

        }
    }
}

