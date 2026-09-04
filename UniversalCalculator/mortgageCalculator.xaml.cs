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
using System.Data;
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
    public sealed partial class mortgageCalculator : Window
    {
        public mortgageCalculator()
        {
            InitializeComponent();
        }

        private static bool isANumber(char character)
        {
            return int.TryParse(character.ToString(), out _);
        }

        private static double performCalculation(string text)
        {
            string result = new DataTable().Compute(text, "").ToString();
            double doubleResult = Convert.ToDouble(result);

            return doubleResult;
        }

        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            double yearlyInterestRate, principalBorrow, monthlyInterestRate, numerator, denominator, monthlyRepayment;
            yearlyInterestRate = principalBorrow = 0.0;
            int years, months, numberOfPayments;
            years = months = 0;
            bool completeCalculation = true;
            if (principalTextBox.Text == "" || annualInterestTextBox.Text == "" || yearsTextBox.Text == "" || monthsTextBox.Text == "")
            {
                completeCalculation = false;
            }
            else
            {
                if (principalTextBox.Text != "")
                {
                    try
                    {
                        principalBorrow = double.Parse(principalTextBox.Text);
                    }
                    catch
                    {
                        principalTextBox.Text = "Please enter only numbers.";
                        completeCalculation = false;
                    }
                }
                if (annualInterestTextBox.Text != "")
                {
                    try
                    {
                        yearlyInterestRate = double.Parse(annualInterestTextBox.Text);
                    }
                    catch
                    {
                        annualInterestTextBox.Text = "Please enter only numbers.";
                        completeCalculation = false;
                    }
                }
                if (yearsTextBox.Text != "")
                {
                    try
                    {
                        years = int.Parse(yearsTextBox.Text);
                    }
                    catch
                    {
                        yearsTextBox.Text = "Please enter only numbers.";
                        completeCalculation = false;
                    }
                }

                if (monthsTextBox.Text != "")
                {
                    try
                    {
                        months = int.Parse(monthsTextBox.Text);
                    }
                    catch
                    {
                        monthsTextBox.Text = "Please enter only numbers.";
                        completeCalculation = false;
                    }
                }
                if (completeCalculation == true)
                {
                    monthlyInterestRate = yearlyInterestRate / 12.0;
                    monthlyInterestRate = monthlyInterestRate * 0.01;
                    numberOfPayments = years * 12 + months;
                    numerator = principalBorrow * Math.Pow(1 + monthlyInterestRate, numberOfPayments) * monthlyInterestRate;
                    denominator = Math.Pow(1 + monthlyInterestRate, numberOfPayments) - 1;
                    monthlyRepayment = numerator / denominator;
                    monthlyInterestTextBox.Text = monthlyInterestRate.ToString();
                    monthlyRepaymentTextBox.Text = monthlyRepayment.ToString();
                }
            }

        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
