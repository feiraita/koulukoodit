//MainWindow.xaml.cs

using System.Security.Cryptography.X509Certificates;
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

namespace Viikko5_3
{
    public partial class MainWindow : Window
    {
        List<Kivi> kivilista = new List<Kivi>();
        public MainWindow()
        {
            InitializeComponent();
            textBlock.Text = Tallentaja.testi();
            kivilista = Tallentaja.LataaKivet();
            PaivitaLista();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text = "SSS";
            textBox.Width -= 10;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string name = string.Empty; // string name = "";
            int weight;
            string ruffness = string.Empty;
            int grade;

            if (!string.IsNullOrEmpty(nimi.Text)) name = nimi.Text;
            if (!string.IsNullOrEmpty(karheusaste.Text)) ruffness = karheusaste.Text;

            int.TryParse(paino.Text, out weight);
            int.TryParse(yleisarvosana.Text, out grade);

            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(ruffness) && weight + grade > 0)
            {
                var newRock = new Kivi(name, weight, ruffness, grade);
                kivilista.Add(newRock);
            }
            PaivitaLista();
            Tallentaja.TallennaKivet(kivilista);
        }
        public void PaivitaLista()
        {
            var stringgi = "";
            foreach (var kivi in kivilista) 
                stringgi += $"[{kivi.tunnisteTieto}] {kivi.nimi} ({kivi.paino}g) - {kivi.yleisArvosana}/10 \n";

            kivilista_block.Text = stringgi;
        }
    }
}