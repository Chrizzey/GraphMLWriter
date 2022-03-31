using System.Drawing;
using GraphMLWriter.Contracts;
using GraphMLWriter.Elements.NodeFactories;

namespace GraphMLWriter.Elements.Nodes
{
    public class Node : GraphMlElement, INode
    {
        public string Text { get; set; }

        public double Height { get; set; }

        public double Width { get; set; }

        public double X { get; set; }

        public double Y { get; set; }

        public string Color { get; set; }

        public Border Border { get; set; }
        
        public Node(int nodeNumber) 
            : base("n"+nodeNumber)
        {
            Height = 30d;
            Width = 250d;
            X = 0d;
            Y = 0d;

            Color = "#CCCCCC";
            Border = new Border();
            NodeLabel = new NodeLabel();
        }

        public Node(string text, int nodeNumber) 
            : this(nodeNumber)
        {
            Text = text;
        }

        public void SetColor(Color color)
        {
            Color = color.ToHexCode();
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

        public INodeLabel NodeLabel { get; set; }
    }
}