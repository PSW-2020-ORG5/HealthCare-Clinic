using System;
using System.Collections.Generic;
using System.IO;
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
using GraphicEditor;
//using HospitalMap.dodatneInfo;
using Rect = GraphicEditor.Rect;

namespace HospitalMap
{
    /// <summary>
    /// Interaction logic for MainBuildingFloor0.xaml
    /// </summary>

    public partial class Building2Floor1 : Page
    {
        public Building2Floor1()
        {
            InitializeComponent();
        }

        public void Building2Objects(object sender, RoutedEventArgs e)
        {
            List<Rectangle> rectangles = new List<Rectangle>();
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.Parent.Parent.FullName;
            string textFile = "\\MapData\\Building2Floor1.txt";
            LoadObject o = new LoadObject();
            List<Rect> rectangles1 = new List<Rect>();
            rectangles1 = o.LoadFromFile(textFile);
            rectangles = o.Window_Loaded(textFile, CanB2F1, rectangles1);
            foreach (Rectangle rectangle in rectangles)
            {
                rectangle.MouseDown += KlikNaZgradu;
            }

        }

        void KlikNaZgradu(object sender, MouseButtonEventArgs e)
        {

            var mouseWasDownOn = e.Source as FrameworkElement;
            if (mouseWasDownOn != null)
            {
                string elementName = mouseWasDownOn.Name;
                Console.WriteLine(elementName);
             /*   if (MainWindow.user.Equals("di") || MainWindow.user.Equals("pa"))
                {
                    var s = new RoomData(elementName);
                    s.ShowDialog();
                } */
            }

        }
    }
}
