using Microsoft.Win32;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Viikko6_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var result = MessageBox.Show("Haluatko poistua?", "Suljetaanko", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.No) e.Cancel = true;
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            string teksti = textBox.Text;

            SaveFileDialog dialog = new SaveFileDialog()
            {
                Filter = "Text Files(*.txt)|*.txt|All(*.*)|*"
            };

            if (dialog.ShowDialog() == true) File.WriteAllText(dialog.FileName, teksti);
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            string teksti = textBox.Text;

            OpenFileDialog dialog = new OpenFileDialog()
            {
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"
            };

            if (dialog.ShowDialog() == true)
            {
                teksti = File.ReadAllText(dialog.FileName);
                textBox.Text = teksti;
            }

        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            Window1 myWindow = new Window1();
            myWindow.sizeBox.Text = textBox.FontSize.ToString();
            myWindow.DataContext = this;
            myWindow.Show();
        }
    }
}