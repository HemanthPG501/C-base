using System;
using System.Drawing;
using System.Windows.Forms;

namespace CSharpBMICalculator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (double.TryParse(txtWeight.Text, out double weight) &&
                double.TryParse(txtHeight.Text, out double heightCm))
            {
                double heightM = heightCm / 100;
                double bmi = weight / (heightM * heightM);
                string category = GetBMICategory(bmi);

                lblResult.Text = $"Result: BMI = {bmi:F1} ({category})";
                lblResult.ForeColor = GetColor(category);
            }
            else
            {
                MessageBox.Show("Please enter valid numeric values for weight and height.", 
                                "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private string GetBMICategory(double bmi)
        {
            if (bmi < 18.5) return "Underweight";
            if (bmi < 25) return "Normal";
            if (bmi < 30) return "Overweight";
            return "Obese";
        }

        private Color GetColor(string category)
        {
            switch (category)
            {
                case "Underweight": return Color.Blue;
                case "Normal": return Color.Green;
                case "Overweight": return Color.Orange;
                case "Obese": return Color.Red;
                default: return Color.Black;
            }
        }
    }
}
