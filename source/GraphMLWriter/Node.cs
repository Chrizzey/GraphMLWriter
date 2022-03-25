using System.Drawing;
using GraphMLWriter.Contracts;

namespace GraphMLWriter
{
    public class Node : GraphMlElement, INode
    {
        public string Text { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public double X { get; set; }
        public double Y { get; set; }

        public string Color { get; set; }
        public string BorderColor { get; set; }
        public string BorderStyle { get; set; }
        public double BorderWidth { get; set; }

        public Node(int nodeNumber) 
            : base("n"+nodeNumber)
        {
            Height = 30d;
            Width = 250d;
            X = 0d;
            Y = 0d;

            Color = "#CCCCCC";
            BorderColor = "#000000";
            BorderStyle = "line";
            BorderWidth = 1d;
        }

        public Node(string text, int nodeNumber) 
            : this(nodeNumber)
        {
            Text = text;
        }
        
        public void FitText()
        {
            using var bitmap = new Bitmap(1, 1);
            using var g = Graphics.FromImage(bitmap);
            var font = new Font("Arial", 15f, FontStyle.Bold);
            var size = g.MeasureString(Text, font);

            Width = size.Width + 4f;
            Height = size.Height + 4f;
        }
    }
}