using System;
using GraphMLWriter.Elements.Shapes;

namespace GraphMLWriter.Serializer.Converter
{
    public class EdgeArrowConverter
    {
        public string ConvertArrow(EdgeArrow arrow)
        {
            return arrow switch
            {
                EdgeArrow.None => "none",
                EdgeArrow.Standard => "standard",
                EdgeArrow.Delta => "delta",
                EdgeArrow.WhiteDelta => "white_delta",
                EdgeArrow.Diamond => "diamond",
                EdgeArrow.WhiteDiamond => "white_diamond",
                EdgeArrow.Short => "short",
                EdgeArrow.Plain => "plain",
                EdgeArrow.Concave => "concave",
                EdgeArrow.Convex => "convex",
                EdgeArrow.Circle => "circle",
                EdgeArrow.TransparentCircle => "transparent_circle",
                EdgeArrow.WhiteCircle => "white_circle",
                EdgeArrow.Dash => "dash",
                EdgeArrow.SkewedDash => "skewed_dash",
                EdgeArrow.TShape => "t_shape",
                EdgeArrow.CrowsFootOneMandatory => "crows_foot_one_mandatory",
                EdgeArrow.CrowsFootManyMandatory => "crows_foot_many_mandatory",
                EdgeArrow.CrowsFootOneOptional => "crows_foot_one_optional",
                EdgeArrow.CrowsFootManyOptional => "crows_foot_many_optional",
                EdgeArrow.CrowsFootOne => "crows_foot_one",
                EdgeArrow.CrowsFootMany => "crows_foot_many",
                EdgeArrow.CrowsFootOptional => "crows_foot_optional",
                EdgeArrow.Cross => "cross",
                _ => throw new NotSupportedException()
            };
        }
    }
}