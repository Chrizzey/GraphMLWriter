using System.Collections.Generic;
using System.Drawing;
using GraphMLWriter.Contracts;

namespace GraphMLWriter
{
    public class Edge : GraphMlElement, IEdge
    {
        public string Source { get; set; }
        public string Target { get; set; }
        public double Sx { get; set; }
        public double Sy { get; set; }
        public double Tx { get; set; }
        public double Ty { get; set; }

        public List<Point> Points { get; protected set; }
        
        public Edge(int edgeNumber, Node source, Node target)
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