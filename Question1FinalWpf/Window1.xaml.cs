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
using System.Windows.Shapes;

namespace Question1FinalWpf
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public string GetText { get; set; }
        public  double GetWidth { get; set; }
        public double GetHeight { get; set; }

        public Window1(string text ,double width,double height)
        {
            InitializeComponent();
            GetText = text;
            GetWidth = width;
            GetHeight = height;
            DataContext = this;
        }
    }
}
