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

namespace Question2FinalWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            EventHandler ev = (o, e) => {
                if (Counter > 0)
                    SetValue(CounterProperty, Counter - 1);
                

            };

            DispatcherTimer timer = new DispatcherTimer(TimeSpan.FromSeconds(1), DispatcherPriority.Normal,
                ev, Dispatcher);
           
           
          
        }

        public int Counter
        {
            get { return (int)GetValue(CounterProperty);}
            set { SetValue(CounterProperty, value); }
        }

        public static readonly DependencyProperty CounterProperty =
            DependencyProperty.Register("Counter", typeof(int), typeof(MainWindow), new PropertyMetadata(30));
        public void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You clicker Right");
       }

        public void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (Counter == 0)
            {
                btn421.IsEnabled = false;
            }
            else
                SetCurrentValue(CounterProperty, Counter);
            MessageBox.Show("Clicked wrong try again!");
            myWindow.Background = Brushes.Red;

        }

        public void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (Counter == 0)
            {
                btn318.IsEnabled = false;
            }
            else
                SetCurrentValue(CounterProperty, Counter);
            myWindow.Background = Brushes.Red;
            MessageBox.Show("Clicked wrong try again!");

        }
        public void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (Counter == 0)
            {
                btn214.IsEnabled = false;
            }
            else
                SetCurrentValue(CounterProperty, Counter);
            myWindow.Background = Brushes.Red;
            MessageBox.Show("Clicked wrong try again!");
        }
    }
}
