using System.Collections.Generic;
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

namespace WpfT1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// 
    /// </summary>
    public partial class MainWindow : Window
    {
        List<int> numerot = new List<int>();

        public MainWindow()
        {
            InitializeComponent();
        }

        public void Luvut(int numero, string luku)
        {
            textBox.Text = "";
            textBox2.Text = "";
            numerot.Add(numero);
            textBox.Text = luku;
        }

        public void Errori(string viesti)
        {
            textBox.Text = "";
            textBox2.Text = viesti;
            numerot.Clear();
        }

        //1
        private void one_Click(object sender, RoutedEventArgs e)
        {
            if (numerot.Count < 2)
            {
                Luvut(1, "1");
            }
            else
            {
                Errori("Voit valita max 2 lukua!\nValitse uudestaan.");
            }
        }

        //2
        private void two_Click(object sender, RoutedEventArgs e)
        {
            if (numerot.Count < 2)
            {
                Luvut(2, "2");
            }
            else
            {
                Errori("Voit valita max 2 lukua!\nValitse uudestaan.");
            }
        }

        //3
        private void three_Click(object sender, RoutedEventArgs e)
        {
            if (numerot.Count < 2)
            {
                Luvut(3, "3");
            }
            else
            {
                Errori("Voit valita max 2 lukua!\nValitse uudestaan.");
            }
        }
        //4
        private void four_Click(object sender, RoutedEventArgs e)
        {
            if (numerot.Count < 2)
            {
                Luvut(4, "4");
            }
            else
            {
                Errori("Voit valita max 2 lukua!\nValitse uudestaan.");
            }
        }

        //5
        private void five_Click(object sender, RoutedEventArgs e)
        {
            if (numerot.Count < 2)
            {
                Luvut(5, "5");
            }
            else
            {
                Errori("Voit valita max 2 lukua!\nValitse uudestaan.");
            }
        }

        //6
        private void six_Click(object sender, RoutedEventArgs e)
        {
            if (numerot.Count < 2)
            {
                Luvut(6, "6");
            }
            else
            {
                Errori("Voit valita max 2 lukua!\nValitse uudestaan.");
            }
        }

        //7
        private void seven_Click(object sender, RoutedEventArgs e)
        {
            if (numerot.Count < 2)
            {
                Luvut(7, "7");
            }
            else
            {
                Errori("Voit valita max 2 lukua!\nValitse uudestaan.");
            }
        }

        //8
        private void eight_Click(object sender, RoutedEventArgs e)
        {
            if (numerot.Count < 2)
            {
                Luvut(8, "8");
            }
            else
            {
                Errori("Voit valita max 2 lukua!\nValitse uudestaan.");
            }
        }

        //9
        private void nine_Click(object sender, RoutedEventArgs e)
        {
            if (numerot.Count < 2)
            {
                Luvut(9, "9");
            }
            else
            {
                Errori("Voit valita max 2 lukua!\nValitse uudestaan.");
            }
        }

        //tulos
        private void tulos_Click(object sender, RoutedEventArgs e)
        {
            if (numerot.Count == 2)
            {
                if (jakolasku.IsChecked == true)
                {
                    double tulos = Math.Round((double)numerot[0] / (double)numerot[1], 2);
                    textBox.Text = $"{tulos.ToString()}";
                    textBox2.Text = $"{numerot[0]} / {numerot[1]}";
                    numerot.Clear();
                }
                else
                {
                    double tulos = numerot[0] + numerot[1];
                    textBox.Text = $"{tulos.ToString()}";
                    textBox2.Text = $"{numerot[0]} + {numerot[1]}";
                    numerot.Clear();
                }
            }

            else
            {
                Errori("Valitse 2 lukua!");
            }
        }

        private void jakolasku_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}