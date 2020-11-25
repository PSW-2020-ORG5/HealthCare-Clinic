using System;
using System.Collections.Generic;
using System.Windows.Shapes;
using System.IO;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;

namespace GraphicEditor
{
    class Rect
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int Left { get; set; }
        public int Top { get; set; }
        public string Id { get; set; }
        public SolidColorBrush Color { get; set; }
    }
    class LoadObject
    {
        public List<Rect> LoadFromFile(string textFile)
        {
            List<Rect> rectangles = new List<Rect>();

            if (File.Exists(textFile))
            {
                // Read a text file line by line.  
                string[] lines = File.ReadAllLines(textFile);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    byte b1 = Byte.Parse(parts[5]);
                    byte b2 = Byte.Parse(parts[6]);
                    byte b3 = Byte.Parse(parts[7]);

                    Color col = Color.FromRgb(b1, b2, b3);

                    rectangles.Add(new Rect()
                    {
                        Id = parts[0],
                        Width = Int32.Parse(parts[1]),
                        Height = Int32.Parse(parts[2]),
                        Left = Int32.Parse(parts[3]),
                        Top = Int32.Parse(parts[4]),
                        Color = new SolidColorBrush(col)
                    });
                }
            }
            return rectangles;
        }
        public List<Rectangle> Window_Loaded(string textFile, Canvas canvas)
        {
            // ... Create list of our Rect objects.
            List<Rect> rects = new List<Rect>();
            rects = LoadFromFile(textFile);

            List<Rectangle> rectangles = new List<Rectangle>();
            foreach (Rect rect in rects)
            {
                // ... Create Rectangle object.
                Rectangle r = new Rectangle();
                r.Name = rect.Id;
                r.Width = rect.Width;
                r.Height = rect.Height;
                r.Fill = rect.Color;


                // ... Set canvas position based on Rect object.
                Canvas.SetLeft(r, rect.Left);
                Canvas.SetTop(r, rect.Top);

                // ... Add to canvas.
                canvas.Children.Add(r);


                rectangles.Add(r);
            }
            return rectangles;
        }
    }
}
