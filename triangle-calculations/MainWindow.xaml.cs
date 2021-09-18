using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace triangle_calculations
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Create database connection
            DatabaseConnection dbConn = new DatabaseConnection();

            // Create table (if required)
            dbConn.CreateTable();

            // Load GUI calculation history
            CalculationHistory.Text = dbConn.SelectCalculations();
        }

        // Button Click: Pythagoras Hypotenuse
        private void PHButton(object sender, RoutedEventArgs e)
        {
            try
            {
                // Create new calculation
                double sideA = double.Parse(PHSideA.Text);
                double sideB = double.Parse(PHSideB.Text);
                Calculation calculation = new CalcPythagHypot(sideA, sideB);

                // Update database with calculation info
                DatabaseConnection dbConn = new DatabaseConnection();
                dbConn.InsertCalculation(calculation.Timestamp, calculation.Summary);

                // Update GUI result
                PHResult.Text = calculation.Result;
                PHResultPanel.Visibility = Visibility.Visible;

                // Update GUI calculation history
                CalculationHistory.Text = dbConn.SelectCalculations();

                // Hide GUI validation warning
                BadInputNotice.Visibility = Visibility.Hidden;
            }
            catch
            {
                // Show GUI validation warning
                BadInputNotice.Visibility = Visibility.Visible;
            }
        }

        // Button Click: Pythagoras Other
        private void POButton(object sender, RoutedEventArgs e)
        {
            try
            {
                // Create new calculation
                double hypotenuse = double.Parse(POHypot.Text);
                double sideA = double.Parse(POSideA.Text);
                Calculation calculation = new CalcPythagOther(hypotenuse, sideA);

                // Update database with calculation info
                DatabaseConnection dbConn = new DatabaseConnection();
                dbConn.InsertCalculation(calculation.Timestamp, calculation.Summary);

                // Update GUI result
                POResult.Text = calculation.Result;
                POResultPanel.Visibility = Visibility.Visible;

                // Update GUI calculation history
                CalculationHistory.Text = dbConn.SelectCalculations();

                // Hide GUI validation warning
                BadInputNotice.Visibility = Visibility.Hidden;
            }
            catch
            {
                // Show GUI validation warning
                BadInputNotice.Visibility = Visibility.Visible;
            }
        }

        // Button Click: Area of Triangle
        private void ATButton(object sender, RoutedEventArgs e)
        {
            try
            {
                // Create new calculation
                double baseT = double.Parse(ATBase.Text);
                double heightT = double.Parse(ATHeight.Text);
                Calculation calculation = new CalcArea(baseT, heightT);

                // Update database with calculation info
                DatabaseConnection dbConn = new DatabaseConnection();
                dbConn.InsertCalculation(calculation.Timestamp, calculation.Summary);

                // Update GUI result
                ATResult.Text = calculation.Result;
                ATResultPanel.Visibility = Visibility.Visible;

                // Update GUI calculation history
                CalculationHistory.Text = dbConn.SelectCalculations();

                // Hide GUI validation warning
                BadInputNotice.Visibility = Visibility.Hidden;
            }
            catch
            {
                // Show GUI validation warning
                BadInputNotice.Visibility = Visibility.Visible;
            }
        }

        // Button Click: Perimeter of Triangle
        private void PTButton(object sender, RoutedEventArgs e)
        {
            try
            {
                // Create new calculation
                double sideA = double.Parse(PTSideA.Text);
                double sideB = double.Parse(PTSideB.Text);
                double sideC = double.Parse(PTSideC.Text);
                Calculation calculation = new CalcPerimeter(sideA, sideB, sideC);

                // Update database with calculation info
                DatabaseConnection dbConn = new DatabaseConnection();
                dbConn.InsertCalculation(calculation.Timestamp, calculation.Summary);

                // Update GUI result
                PTResult.Text = calculation.Result;
                PTResultPanel.Visibility = Visibility.Visible;

                // Update GUI calculation history
                CalculationHistory.Text = dbConn.SelectCalculations();

                // Hide GUI validation warning
                BadInputNotice.Visibility = Visibility.Hidden;
            }
            catch
            {
                // Show GUI validation warning
                BadInputNotice.Visibility = Visibility.Visible;
            }
        }

        // Drop database table and create it to clear calculation history. Update GUI calculation history.
        private void ClearButton(object sender, RoutedEventArgs e)
        {
            DatabaseConnection dbConn = new DatabaseConnection();
            dbConn.DropTable();
            dbConn.CreateTable();
            CalculationHistory.Text = dbConn.SelectCalculations();
        }
    }
}
