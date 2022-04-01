using System.Xml.Linq;
using GraphMLWriter.Contracts;
using GraphMLWriter.Elements.NodeFactories;
using GraphMLWriter.Elements.Nodes;

namespace GraphMLWriter.Serializer.ElementSerializer
{
    public abstract class NodeSerializer : INodeSerializer
    {
        protected readonly XNamespace YNamespace;

        protected NodeSerializer()
        {
            YNamespace = "http://www.yworks.com/xml/graphml";
        }

        public abstract XElement SerializeNode(INode node);

        protected virtual XElement Geometry(INode node)
        {
            return new XElement(YNamespace + "Geometry",
                new XAttribute("height", node.Height),
                new XAttribute("width", node.Width),
                new XAttribute("x", node.X),
                new XAttribute("y", node.Y));
        }

        protected virtual XElement NodeLabel(INode node)
        {
            return NodeLabel(node.NodeLabel, node.Text);
        }

        protected virtual XElement NodeLabel(INodeLabel label, string text)
        {
            var nodeLabel = new XElement(YNamespace + "NodeLabel",
                new XAttribute("alignment", "center"),
                new XAttribute("autoSizePolicy", "content"),
                new XAttribute("fontFamily", label.FontFamily),
                new XAttribute("fontSize", label.FontSize),
                new XAttribute("fontStyle", label.FontStyle),
                new XAttribute("hasBackgroundColor", label.HasBackgroundColor),
                new XAttribute("hasLineColor", label.HasLineColor),
                new XAttribute("height", "19.92626953125"),
                new XAttribute("modelName", "custom"),
                new XAttribute("textColor", label.TextColor),
                new XAttribute("visible", label.IsVisible),
                new XAttribute("underlinedText", label.UnderlineText),
                new XAttribute("width", "38.68994140625"),
                new XAttribute("x", "30.655029296875"),
                new XAttribute("y", "3.0"));
            nodeLabel.Add(text);
            var labelModel = new XElement(YNamespace + "LabelModel",
                new XElement(YNamespace + "SmartNodeLabelModel",
                    new XAttribute("distance", "4.0")
                )
            );

            nodeLabel.Add(labelModel);
            var modelParameter = new XElement(YNamespace + "ModelParameter",
                new XElement(YNamespace + "SmartNodeLabelModelParameter",
                    new XAttribute("labelRatioX", "0.0"),
                    new XAttribute("labelRatioY", "0.0"),
                    new XAttribute("nodeRatioX", "0.0"),
                    new XAttribute("nodeRatioY", "-0.03703090122767855"),
                    new XAttribute("offsetX", "0.0"),
                    new XAttribute("offsetY", "0.0"),
                    new XAttribute("upX", "0.0"),
                    new XAttribute("upY", "-1.0"))
            );
            nodeLabel.Add(modelParameter);
            return nodeLabel;
        }

        protected virtual XElement BorderStyle(INode node)
        {
            return BorderStyle(node.Border);
        }

        protected virtual XElement BorderStyle(Border border)
        {
            var borderStyle = new XElement(YNamespace + "BorderStyle",
                new XAttribute("color", border.Color),
                new XAttribute("type", border.Style),
                new XAttribute("width", border.Width));
            return borderStyle;
        }

        protected virtual XElement Fill(INode node)
        {
            var fill = new XElement(YNamespace + "Fill",
                new XAttribute("color", node.Color),
                new XAttribute("transparent", "false"));
            return fill;
        }
    }
}