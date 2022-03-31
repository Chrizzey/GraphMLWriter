using System.Collections.Generic;
using System.Drawing;
using GraphMLWriter.Contracts;
using GraphMLWriter.Elements.Nodes;
using GraphMLWriter.Elements.Shapes;

namespace GraphMLWriter.Elements.Edges
{
    public class Edge : GraphMlElement, IEdge
    {
        public string Source { get; set; }
        public string Target { get; set; }
        public double Sx { get; set; }
        public double Sy { get; set; }
        public double Tx { get; set; }
        public double Ty { get; set; }

        public EdgeArrow SourceArrow { get; set; } = EdgeArrow.None;

        public EdgeArrow TargetArrow { get; set; } = EdgeArrow.Standard;

        public LineProperties LineProperties { get; set; } = new LineProperties();

            public List<Point> Points
        { get; protected set; }

        public Edge(int edgeNumber, INode source, INode target)
            : this(edgeNumber, source.Id, target.Id)
        {
        }

        public Edge(int edgeNumber, string sourceId, string targetId)
            : base("e" + edgeNumber)
        {
            Sx = 0d;
            Sy = 0d;
            Tx = 0d;
            Ty = 0d;
            Source = sourceId;
            Target = targetId;
            Points = new List<Point>();
        }

    }
}