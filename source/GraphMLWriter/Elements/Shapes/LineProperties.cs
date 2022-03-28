namespace GraphMLWriter.Elements.Shapes
{
    public class LineProperties
    {
        public string Color { get; set; } = "#000000";

        public double Width { get; set; } = 1d;

        public LineStyle LineStyle { get; set; } = LineStyle.Line;

        public bool SmoothEdges { get; set; } = false;
    }
}