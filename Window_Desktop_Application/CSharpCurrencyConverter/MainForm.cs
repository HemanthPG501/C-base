using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CSharpCurrencyConverter
{
    public partial class MainForm : Form
    {
        private readonly Dictionary<string, double> rates = new Dictionary<string, double>
        {
            {"INR", 1.0},
            {"USD", 0.012},
            {"EUR", 0.011},
            {"GBP", 0.0097}
        };

        public MainForm()
        {
            InitializeComponent();
            cmbFrom.Items.AddRange(new object[] {"INR", "USD", "EUR", "GBP"});
            cmbTo.Items.AddRange(new object[] {"INR", "USD", "EUR", "GBP"});
            cmbFrom.SelectedIndex = 0;
            cmbTo.SelectedIndex = 1;
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            if (double.TryParse(txtAmount.Text, out double amount))
            {
                string from = cmbFrom.SelectedItem.ToString();
                string to = cmbTo.SelectedItem.ToString();

                double result = amount * (rates[to] / rates[from]);
                lblResult.Text = $"Result: {result:F2} {to}";
            }
            else
            {
                MessageBox.Show("Please enter a valid amount.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
