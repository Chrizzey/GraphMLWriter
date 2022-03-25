using System;
using System.Collections.Generic;
using System.Drawing;

namespace GraphMLWriter.Contracts
{
    public interface IEdge : ISourcePoint, ITargetPoint
    {
        string Id { get; }

        string Source { get; set; }

        string Target { get; set; }

        List<Point> Points { get; }
    }
}
