using System;
using System.Collections.Generic;
using System.Text;
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
}
