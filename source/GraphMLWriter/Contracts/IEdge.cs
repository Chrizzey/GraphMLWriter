using System.Collections.Generic;
using System.Drawing;
using GraphMLWriter.Elements.Shapes;

namespace GraphMLWriter.Contracts
{
    public interface IEdge : IGraphMlElement, ISourcePoint, ITargetPoint
    {
        string Source { get; set; }

        string Target { get; set; }

        public List<Point> Points { get; }

        EdgeArrow SourceArrow { get; set; }

        EdgeArrow TargetArrow { get; set; }

        LineProperties LineProperties { get; set; }
    }
}
