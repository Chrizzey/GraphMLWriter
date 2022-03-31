using System.Drawing;

namespace GraphMLWriter.Elements.Nodes
{
    public class Border
    {
        public string Color { get; set; } = "#000000";

        public string Style { get; set; } = "line";

        public double Width { get; set; } = 1d;

        public void SetColor(Color color)
        {
            Color = color.ToHexCode();
        }
    }
}