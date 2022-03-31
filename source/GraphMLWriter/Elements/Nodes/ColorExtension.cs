using System.Drawing;

namespace GraphMLWriter.Elements.Nodes
{
    public static class ColorExtension
    {
        public static string ToHexCode(this Color color)
        {
            return $"#{color.R:X2}{color.G:X2}{color.B:X2}";
        }
    }
}