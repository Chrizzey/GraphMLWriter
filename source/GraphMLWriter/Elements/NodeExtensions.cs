using System.Drawing;
using GraphMLWriter.Contracts;
using GraphMLWriter.Elements.Nodes;

namespace GraphMLWriter.Elements
{
    public static class NodeExtensions
    {
        public static T SetLocation<T>(this T node, int x, int y) where T : INode
        {
            node.X = x;
            node.Y = y;

            return node;
        }

        public static T SetSize<T>(this T node, double width, double height) where T : INode
        {
            node.Width = width;
            node.Height = height;

            return node;
        }

        public static T SetColor<T>(this T node, Color color) where T : INode
        {
            node.Color = color.ToHexCode();

            return node;
        }

        public static T SetBorder<T>(this T node, Color color, string style, double width) where T : INode
        {
            return node.SetBorder(color.ToHexCode(), style, width);
        } 

        public static T SetBorder<T>(this T node, string color, string style, double width) where T : INode
        {
            return node.SetBorder(new Border {Color = color, Style = style, Width = width});
        }

        public static T SetBorder<T>(this T node, Border border) where T:INode
        {
            node.Border = border;

            return node;
        }
    }
}
