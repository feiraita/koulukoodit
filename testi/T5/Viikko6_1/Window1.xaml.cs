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
using System.Windows.Shapes;

namespace Viikko6_1
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    { 
      
        public Window1()
        {
            InitializeComponent();
        }

        public void button1_Click(object sender, RoutedEventArgs e)
        {
            textBlock.FontSize = int.Parse(sizeBox.Text);

            MainWindow mainWindow = (MainWindow)this.DataContext;

            mainWindow.textBox.FontSize = int.Parse(sizeBox.Text);
            mainWindow.textBox.FontStyle = textBlock.FontStyle;
            mainWindow.textBox.FontWeight = textBlock.FontWeight;
        }

        private void italicButton_Click(object sender, RoutedEventArgs e)
        {
           if (textBlock.FontStyle == FontStyles.Italic) textBlock.FontStyle = FontStyles.Normal; 
           else textBlock.FontStyle = FontStyles.Italic;
        }

        private void boldButton_Click(object sender, RoutedEventArgs e)
        {
            if (textBlock.FontWeight == FontWeights.Bold) textBlock.FontWeight = FontWeights.Normal;
            else textBlock.FontWeight = FontWeights.Bold; 
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var result = MessageBox.Show("Haluatko poistua?", "Suljetaanko", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.No) e.Cancel = true;
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
