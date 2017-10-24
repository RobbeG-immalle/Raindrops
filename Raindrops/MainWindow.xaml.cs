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
using System.Windows.Threading;


namespace Raindrops
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Random randomNumber = new Random();
        private double x, y, size;
        private SolidColorBrush brush;

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();
        }

        private void stopButton_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            mijnCanvas.Children.Clear();
        }

        private DispatcherTimer timer = new DispatcherTimer();

        private void gapSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int timeGap = Convert.ToInt32(gapSlider.Value);
            gapLabel.Content = Convert.ToString(timeGap);
        }

        public MainWindow()
        {
            InitializeComponent();

            gapLabel.Content = Convert.ToString(gapSlider.Value);
            brush = new SolidColorBrush(Colors.DarkRed);
            timer.Interval = TimeSpan.FromMilliseconds(gapSlider.Value);
            timer.Tick += timer_Tick;

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            x = randomNumber.Next(0, Convert.ToInt32(mijnCanvas.Width));
            y = randomNumber.Next(0, Convert.ToInt32(mijnCanvas.Height));
            size = randomNumber.Next(1, 40);

            Ellipse ellipse = new Ellipse();
            ellipse.Width = size;
            ellipse.Height = size;
            ellipse.Stroke = brush;
            ellipse.Fill = brush;
            ellipse.Margin = new Thickness(x, y, 0, 0);
            mijnCanvas.Children.Add(ellipse);

            timer.Stop();
            int ms = randomNumber.Next(1, Convert.ToInt32(gapSlider.Value));
            timer.Interval = TimeSpan.FromMilliseconds(ms);
            timer.Start();
        }
    }
}
