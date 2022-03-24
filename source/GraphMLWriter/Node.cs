using System.Drawing;

namespace GraphMLWriter
{
    public class Node : GraphMlElement
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
            using (var bitmap = new Bitmap(1, 1))
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                Font f = new Font("Arial", 13f);
                var size = g.MeasureString(Text, f);

                Width = size.Width + 4f;
                Height = size.Height + 4f;
            }
        }
    }
}