using System;

namespace GraphMLWriter
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