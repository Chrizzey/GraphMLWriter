using GraphMLWriter.Elements.Nodes;

namespace GraphMLWriter.Contracts
{
    public interface IShape
    {
        double Height { get; set; }
        double Width { get; set; }
        double X { get; set; }
        double Y { get; set; }
        string Color { get; set; }

        Border Border { get; set; }
    }
}