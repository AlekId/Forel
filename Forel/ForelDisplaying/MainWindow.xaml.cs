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
using Forel;

namespace ForelDisplaying
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
        ForelManager m = new ForelManager();
        private void DisplayDefault_Click(object sender, RoutedEventArgs e)
        {           
            m.GetData();
            foreach (var p in m.points)
            {
                Ellipse elipse = new Ellipse();
                elipse.Fill = new SolidColorBrush(Colors.LightGray);
                elipse.StrokeThickness = 1;
                elipse.Stroke = Brushes.Black;
                elipse.Width = 15;
                elipse.Height = 15;
                Canvas.SetTop(elipse,p.Y*25);
                Canvas.SetLeft(elipse,p.X*25);
                defaultCanvas.Children.Add(elipse);
            }
        }

        private void Cluster_Click(object sender, RoutedEventArgs e)
        {
            m.Cluster();
            foreach (var cluster in m.result)
            {
                
                Color[] clrs = new Color[] { Colors.Red, Colors.SkyBlue, Colors.Orange, Colors.ForestGreen, Colors.Blue, Colors.DeepPink, Colors.Lime, Colors.BlueViolet, Colors.Aqua };              
                var color = new SolidColorBrush(clrs[m.result.IndexOf(cluster)]);
                foreach (var p in cluster)
                {
                    Ellipse elipse = new Ellipse();
                    elipse.Fill = color;
                    elipse.StrokeThickness = 1;
                    elipse.Stroke = Brushes.Black;
                    elipse.Width = 15;
                    elipse.Height = 15;
                    Canvas.SetTop(elipse, p.Y * 25);
                    Canvas.SetLeft(elipse, p.X * 25);
                    resultCanvas.Children.Add(elipse);
                }                
            }

            Color[] backClrs = new Color[] { Colors.LightGoldenrodYellow, Colors.LightCyan, Colors.LightBlue, Colors.LightSteelBlue, Colors.LightYellow };              
            foreach (var c in m.centers)
            {
                var color = new SolidColorBrush(backClrs[m.centers.IndexOf(c)]);
                Ellipse elps = new Ellipse();
                elps.Fill = color;
                elps.Opacity = 0.4;
                elps.StrokeThickness = 2;
                elps.Stroke = Brushes.Black;               
                Canvas.SetTop(elps, c.Y * 25);
                Canvas.SetLeft(elps, c.X * 25);
                elps.Width = 5;
                elps.Height = 5;
                resultCanvas.Children.Add(elps);
            }

        }
    }
}
