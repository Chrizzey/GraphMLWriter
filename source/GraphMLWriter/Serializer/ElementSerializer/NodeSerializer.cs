﻿using System.Xml.Linq;
using GraphMLWriter.Contracts;

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
            var nodeLabel = new XElement(YNamespace + "NodeLabel",
                new XAttribute("alignment", "center"),
                new XAttribute("autoSizePolicy", "content"),
                new XAttribute("fontFamily", node.NodeLabel.FontFamily),
                new XAttribute("fontSize", node.NodeLabel.FontSize),
                new XAttribute("fontStyle", node.NodeLabel.FontStyle),
                new XAttribute("hasBackgroundColor", node.NodeLabel.HasBackgroundColor),
                new XAttribute("hasLineColor", node.NodeLabel.HasLineColor),
                new XAttribute("height", "19.92626953125"),
                new XAttribute("modelName", "custom"),
                new XAttribute("textColor", node.NodeLabel.TextColor),
                new XAttribute("visible", node.NodeLabel.IsVisible),
                new XAttribute("width", "38.68994140625"),
                new XAttribute("x", "30.655029296875"),
                new XAttribute("y", "3.0"));
            nodeLabel.Add(node.Text);
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
            var borderStyle = new XElement(YNamespace + "BorderStyle",
                new XAttribute("color", node.BorderColor),
                new XAttribute("type", node.BorderStyle),
                new XAttribute("width", node.BorderWidth));
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