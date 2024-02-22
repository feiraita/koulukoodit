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
using ConsoleApp1;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Ajoneuvo a = new();
            a.asetaNimi("Volkswagen");
            a.Ika(85);
            textBlock.Text = a.Tiedot();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new();
            window1.textBox.Text = "Alkuarvo";
            window1.ShowDialog();
            textBlock.Text = window1.textBox.Text;
        }
    }
}