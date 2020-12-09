using HospitalMap;
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

namespace GraphicEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Main.Content = new Map();
        }


        private void ShowB1Floor0_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Building1Floor0();
        }

        private void ShowB1Floor1_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Building1Floor1();
        }

        private void ShowB1Floor2_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Building1Floor2();
        }

        private void ShowMBFloor0_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new MainBuildingFloor0();
        }

        private void ShowMBFloor1_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new MainBuildingFloor1();
        }

        private void ShowMBFloor2_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new MainBuildingFloor2();
        }

        private void ShowB2Floor0_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Building2Floor0();
        }

        private void ShowB2Floor1_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Building2Floor1();
        }

        private void ShowB2Floor2_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Building2Floor2();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Map();
        }

    }





}
