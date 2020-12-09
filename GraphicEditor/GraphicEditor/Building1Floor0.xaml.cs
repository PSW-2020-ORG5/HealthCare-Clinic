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
//using HospitalMap.dodatneInfo;

using GraphicEditor;

namespace HospitalMap
{
    /// <summary>
    /// Interaction logic for Building1Floor0.xaml
    /// </summary>
    public partial class Building1Floor0 : Page
    {
        public Building1Floor0()
        {
            InitializeComponent();
        }

        public void Building1Objects(object sender, RoutedEventArgs e)
        {
            List<Rectangle> rectangles = new List<Rectangle>();

            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.Parent.Parent.FullName;
            string textFile = "\\MapData\\Building1Floor0.txt";

            LoadObject o = new LoadObject();
            List<GraphicEditor.Rect> rectangles1 = new List<GraphicEditor.Rect>();
            rectangles1 = o.LoadFromFile(textFile);
            rectangles = o.Window_Loaded(textFile, Can2, rectangles1);
            foreach (Rectangle rectangle in rectangles)
            {
                rectangle.MouseLeftButtonDown += KlikNaZgradu;
                // rectangle.MouseRightButtonDown += ChangeBasicInfo;
            }
        }

        void KlikNaZgradu(object sender, MouseButtonEventArgs e)
        {
            var mouseWasDownOn = e.Source as FrameworkElement;
            if (mouseWasDownOn != null)
            {
                string elementName = mouseWasDownOn.Name;
                Console.WriteLine(elementName);

                /*  if (MainWindow.user.Equals("di"))
                  {
                      var s = new RoomData(elementName);
                      s.ShowDialog();
                  }
              }
          }
          void ChangeBasicInfo(object sender, MouseButtonEventArgs e)
          {
              var mouseWasDownOn = e.Source as FrameworkElement;
              if (MainWindow.user.Equals("di"))
              {
                  ChangeBasicInformation cb = new ChangeBasicInformation(mouseWasDownOn.Name);
                  cb.Show();
              } */
            }

        }
    }
}
