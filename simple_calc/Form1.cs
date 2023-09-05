using simple_calc.Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace simple_calc
{
    public partial class Form1 : Form
    {
        CalcController controller;
        public Form1()
        {
            InitializeComponent();
            controller = new CalcController();
        }

        private void equalsButton_Click(object sender, EventArgs e)
        {
            double result = controller.Solve(textBox1.Text);
            textBox1.Text += $"= {result}";

        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder(textBox1.Text);
            sb.Remove(sb.Length - 1, 1);
            textBox1.Text = sb.ToString();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
        }

        private void generalButton_click(object sender, EventArgs e)
        {
           string buttonText = ((Button)sender).Text;
           textBox1.Text += buttonText;
        }

        private void PIButton_Click(object sender, EventArgs e)
        {
            textBox1.Text += "3,14";
        }

        private void denominatorButton_Click(object sender, EventArgs e)
        {
            textBox1.Text += "1/";
        }

        private void percentButton_Click(object sender, EventArgs e)
        {
            textBox1.Text += "%";
            int position = textBox1.Text.Length-1;
            
            while((position > 0 &&textBox1.Text[position]>= 48 && textBox1.Text[position] <= 57) || textBox1.Text[position] == ',' || textBox1.Text[position] == '%')
            {
                position--;
            }
            if (textBox1.Text[position] >=57 || textBox1.Text[position] <=48) position++;
            
            StringBuilder sbNumber = new StringBuilder();
           
            while (textBox1.Text[position] != '%')
            {
                sbNumber.Append(textBox1.Text[position]);
                position++;
            }
            textBox1.Text = textBox1.Text.Remove(position - sbNumber.Length, sbNumber.Length+1);

            textBox1.Text += $"{Convert.ToDouble(sbNumber.ToString()) / 100}";
        }
    }
}
