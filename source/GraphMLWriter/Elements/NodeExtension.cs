using GraphMLWriter.Contracts;

namespace GraphMLWriter.Elements
{
    public static class NodeExtension
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
    }
}
