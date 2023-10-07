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
using static System.Net.Mime.MediaTypeNames;

namespace InteresRate
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool state1 = false;
        public MainWindow()
        {
            InitializeComponent();
            //tb1.Text = "something";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var x1 = double.Parse(value1.Text);
                var x2 = double.Parse(rate1.Text);
                double resx = x1 * x2;
                res1.Text = resx.ToString();
            }
            catch
            {
                res1.Text = "Invalid input";
            }
        }

        //private void btn1_Click(object sender, RoutedEventArgs e)
        //{

        //    var number1 = 1;

        //    if (state1)
        //    {
        //        tb1.Text = "run";
        //        btn1.Content = "change";
        //        state1 = !state1;
        //    }
        //    else
        //    {
        //        tb1.Text = "stop";
        //        btn1.Content = "back";
        //        state1 = !state1;
        //    }
        //}
    }
}
