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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        int lahtohinta = 0;
        public MainWindow()
        {
            InitializeComponent();
            textBox.Focus();
            textBox.SelectAll();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var teksti = textBox.Text;
            var numero = int.Parse(teksti);

            textBox.Text = numero.ToString();  

            if (numero > lahtohinta)
            {
                lahtohinta = numero;
                textBlock.Text = numero.ToString();
            }

            textBox.Focus();
            textBox.SelectAll();
        }
    }
}