using System;
using System.Collections.Generic;
using System.IO;
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

namespace GraphicEditor
{
    /// <summary>
    /// Interaction logic for Map.xaml
    /// </summary>
    public partial class Map : Page
    {
        public Map()
        {
            InitializeComponent();
        }
        public void MainObjects(object sender, RoutedEventArgs e)
        {
            List<Rectangle> rectangles = new List<Rectangle>();
            LoadObject o = new LoadObject();
            // string textFile = "../../../MapData/MainObjects.txt";
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.Parent.Parent.FullName;
            Console.WriteLine(path);
            string textFile = "\\MapData\\MainObjects.txt";
            List<Rect> rectangles1 = new List<Rect>();
            rectangles1 = o.LoadFromFile(textFile);
            rectangles = o.Window_Loaded(textFile, Can1, rectangles1);

        }
    }
}
