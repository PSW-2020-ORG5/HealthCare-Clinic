﻿using GraphicEditor;
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
using Rect = GraphicEditor.Rect;

namespace HospitalMap
{
    /// <summary>
    /// Interaction logic for MainBuildingFloor0.xaml
    /// </summary>

    public partial class MainBuildingFloor0 : Page
    {
        public MainBuildingFloor0()
        {
            InitializeComponent();
        }

        public void MainBuildingObjects(object sender, RoutedEventArgs e)
        {
            List<Rectangle> rectangles = new List<Rectangle>();
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.Parent.Parent.FullName;
            string textFile = "\\MapData\\MainBuildingFloor0.txt";
            LoadObject o = new LoadObject();
            List<Rect> rectangles1 = new List<Rect>();
            rectangles1 = o.LoadFromFile(textFile);
            rectangles = o.Window_Loaded(textFile, Can3, rectangles1);
            /* foreach (Rectangle rectangle in rectangles)
             {
                 rectangle.MouseDown += KlikNaZgradu;
             }
             */
        }
    }
}
