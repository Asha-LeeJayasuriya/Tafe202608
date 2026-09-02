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
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CurrencyConverterWindow : Window
    {
        public CurrencyConverterWindow()
        {
            InitializeComponent();
        }

        // Exchange rates against USD
        private double GetRate(string code)
        {
            if (code == "EUR") return 0.85;
            if (code == "AUD") return 1.52;
            return 1.0;   // USD
        }

        // Calculation method: accepts the input parameters and returns the result
        public double ConvertCurrency(double amount, string fromCode, string toCode)
        {
            double exchangeRate = GetRate(toCode) / GetRate(fromCode);
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
    }
}
