namespace GraphMLWriter.Contracts
{
    public interface IShape
    {
        double Height { get; set; }
        double Width { get; set; }
        double X { get; set; }
        double Y { get; set; }
        string Color { get; set; }
        string BorderColor { get; set; }
        string BorderStyle { get; set; }
        double BorderWidth { get; set; }
    }
}