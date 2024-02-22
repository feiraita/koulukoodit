// MainWindow.xaml.cs
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

namespace Viikko5_2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Canvas.SetLeft(ellipse1, 400);
        }

        private void myCanvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

            Canvas.SetTop(ellipse1, e.GetPosition(myCanvas).Y - 50);
            Canvas.SetLeft(ellipse1, e.GetPosition(myCanvas).X - 50);
        }

        private void myCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            // Canvas.SetTop(ellipse1, e.GetPosition(myCanvas).Y - 50);
            // Canvas.SetLeft(ellipse1, e.GetPosition(myCanvas).X - 50);

            if(e.LeftButton == MouseButtonState.Pressed)
            {
                Ellipse ellipse = new Ellipse();
                ellipse.Width = ellipse.Height = 20;
                ellipse.Fill = Brushes.SpringGreen;
                // !!!
                myCanvas.Children.Add(ellipse);

                Canvas.SetLeft(ellipse, e.GetPosition(myCanvas).X);
                Canvas.SetTop(ellipse, e.GetPosition(myCanvas).Y);
            }
        }
    }
}