﻿using System;
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
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.Parent.Parent.FullName;
            string textFile = "\\MapData\\MainObjects.txt";
            List<Rect> rectangles1 = new List<Rect>();
            rectangles1 = o.LoadFromFile(textFile);
            rectangles = o.Window_Loaded(textFile, Can1, rectangles1);

            foreach (Rectangle rectangle in rectangles)
            {
                rectangle.MouseLeftButtonDown += KlikNaZgradu;
                //rectangle.MouseRightButtonDown += ChangeBasicInfo;
            }





        }

        void KlikNaZgradu(object sender, MouseButtonEventArgs e)
        {

            var mouseWasDownOn = e.Source as FrameworkElement;
            if (mouseWasDownOn != null)
            {
                string elementName = mouseWasDownOn.Name;
                Console.WriteLine(elementName);
                if (elementName.Equals("Building1"))
                {
                    NavigationService.Navigate(new HospitalMap.Building1Floor0());

                }
               /* else if (elementName.Equals("MainBuilding"))
                {
                    NavigationService.Navigate(new MainBuildingFloor0());
                }
                else if (elementName.Equals("Building2"))
                {
                    NavigationService.Navigate(new Building2Floor0());
                } */
            }

        }
    }
}