using System;
using System.Collections.Generic;
using System.Windows.Shapes;
using System.IO;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;

namespace GraphicEditor
{
    //

    class LoadObject
    {
        public List<Rect> LoadFromFile(string textFile1)
        {
            List<Rect> rectangles = new List<Rect>();
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;
            string textFile = path + textFile1;
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
        public List<Rectangle> Window_Loaded(string textFile, Canvas canvas, List<Rect> rects)
        {
            // ... Create list of our Rect objects.
            // List<Rect1> rects = new List<Rect1>();
            //rects = LoadFromFile(textFile);

            List<Rectangle> rectangles = new List<Rectangle>();
            foreach (Rect rect in rects)
            {
                // ... Create Rectangle object.
                Rectangle r = new Rectangle();
                r.Name = rect.Id;
                r.Width = rect.Width;
                r.Height = rect.Height;
                r.Fill = rect.Color;

                setOnCanvas( r, rect, canvas);
                rectangles.Add(r);
            }
            return rectangles;
        }
        public void setOnCanvas( Rectangle r, Rect r1, Canvas canvas)
        {
            Canvas.SetLeft(r, r1.Left);
            Canvas.SetTop(r, r1.Top);

            // ... Add to canvas.
            canvas.Children.Add(r);
        }
    }
}
