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
    public sealed partial class universalcalculator : Window
    {
        public universalcalculator()
        {
            InitializeComponent();
        }

        private void mathCalculatorButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void mortgageCalculatorButton_Click(object sender, RoutedEventArgs e)
        {
            mortgageCalculator mortgageCalculator = new mortgageCalculator();
            mortgageCalculator.Activate();
            this.Close();
        }

        private void currencyCalculatorButton_Click(object sender, RoutedEventArgs e)
        {
            CurrencyConverterWindow currencyWindow = new CurrencyConverterWindow();
            currencyWindow.Activate();
            this.Close();
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
