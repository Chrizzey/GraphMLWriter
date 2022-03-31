namespace GraphMLWriter.Elements.NodeFactories
{
    public interface INodeLabel
    {
        NodeLabel.LabelAlignment Alignment { get; set; }
        string FontFamily { get; set; }
        int FontSize { get; set; }
        string FontStyle { get; set; }
        bool HasBackgroundColor { get; set; }
        bool HasLineColor { get; set; }
        string TextColor { get; set; }
        bool UnderlineText { get; set; }
        bool IsVisible { get; set; }
    }
}