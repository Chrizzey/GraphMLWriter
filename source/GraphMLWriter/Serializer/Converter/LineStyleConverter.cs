using System;
using GraphMLWriter.Elements.Shapes;

namespace GraphMLWriter.Serializer.Converter
{
    public class LineStyleConverter
    {
        public string ConvertLineStyle(LineStyle lineStyle)
        {
            return lineStyle switch
            {
                LineStyle.Line => "line",
                LineStyle.Dashed => "dashed",
                LineStyle.Dotted => "dotted",
                LineStyle.DashedDotted => "dashed_dotted",
                _ => throw new NotSupportedException()
            };
        }
    }
}