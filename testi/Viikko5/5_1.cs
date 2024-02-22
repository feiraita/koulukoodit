// MainWindow.xaml.cs
using System.IO;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Viikko5_1
{
    public partial class MainWindow : Window
    {
        double x = 260;
        double y = 200;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            omaCanvas.SetXY(x, y);
            x += 50;
            y += 10;
        }

        private void omaCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            var x = e.GetPosition(omaCanvas).X;
            var y = e.GetPosition(omaCanvas).Y;

            if(e.LeftButton == MouseButtonState.Pressed)
            {
                omaCanvas.SetXY(x, y);
            }
        }

        string filename = "piirros.json";
        //save -nappi
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Configure sace file dialog box
            var dialog = new Microsoft.Win32.SaveFileDialog();
            dialog.FileName = "Document";
            dialog.DefaultExt = ".json";
            dialog.Filter = "Json documents (.json)|*.json";

            // Show save file dialog box
            bool? result = dialog.ShowDialog();

            //Process save file dialog box result
            if (result == true)
            {
                //Save document
                filename = dialog.FileName;
            }

            //Serialize lista
            File.WriteAllText(filename, JsonSerializer.Serialize(omaCanvas.pisteet));
        }

        //palauta -nappi
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var pisteet = JsonSerializer.Deserialize<List<System.Windows.Point>>(File.ReadAllText(filename));
            foreach(var item in pisteet)
            {
                omaCanvas.SetXY(item.X, item.Y);
            }
        }
    }
}