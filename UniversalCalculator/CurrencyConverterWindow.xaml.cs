using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace UniversalCalculator
{
    /// <summary>
    /// Currency Conversion Calculator window.
    /// </summary>
    public sealed partial class CurrencyConverterWindow : Window
    {
        public CurrencyConverterWindow()
        {
            InitializeComponent();
        }

        // Conversion rates from the ASI Appendix table
        private double GetConversionRate(string fromCode, string toCode)
        {
            string pair = fromCode + "-" + toCode;

            if (pair == "USD-EUR") return 0.85189982;
            if (pair == "USD-GBP") return 0.72872436;
            if (pair == "USD-INR") return 74.257327;

            if (pair == "EUR-USD") return 1.1739732;
            if (pair == "EUR-GBP") return 0.8556672;
            if (pair == "EUR-INR") return 87.00755;

            if (pair == "GBP-USD") return 1.371907;
            if (pair == "GBP-EUR") return 1.1686692;
            if (pair == "GBP-INR") return 101.68635;

            if (pair == "INR-USD") return 0.011492628;
            if (pair == "INR-EUR") return 0.013492774;
            if (pair == "INR-GBP") return 0.0098339397;

            return 1.0;   // same currency selected
        }

        // Calculation method: accepts the input parameters and returns the result
        public double ConvertCurrency(double amount, string fromCode, string toCode)
        {
            double exchangeRate = GetConversionRate(fromCode, toCode);
            return amount * exchangeRate;
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            double amount = double.Parse(txtAmount.Text);
            string fromCode = ((ComboBoxItem)cboFrom.SelectedItem).Content.ToString();
            string toCode = ((ComboBoxItem)cboTo.SelectedItem).Content.ToString();

            double result = ConvertCurrency(amount, fromCode, toCode);

            lblResult.Text = amount + " " + fromCode + " = " + result.ToString("N2") + " " + toCode;
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            universalcalculator universalcalculator = new universalcalculator();
            universalcalculator.Activate();
            this.Close();
        }
    }
}