using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using GraphMLWriter.Elements.Edges;

namespace GraphMLWriter.Elements
{
    public class Graph
    {
        private readonly List<Node> _nodes;
        private readonly List<Edge> _edges;

        public Graph()
        {
            _nodes = new List<Node>();
            _edges = new List<Edge>();
        }

        public IReadOnlyCollection<Node> AllNodes => new ReadOnlyCollection<Node>(_nodes);

        public IReadOnlyCollection<Edge> AllEdges => new ReadOnlyCollection<Edge>(_edges);

        public void AddNodes(params Node[] nodes)
        {
            AddNodes((IEnumerable<Node>)nodes);
        }

        public void AddNodes(IEnumerable<Node> nodes)
        {
            foreach (var node in nodes)
            {
                AddNode(node);
            }
        }

        public void AddEdges(params Edge[] edges)
        {
            AddEdges((IEnumerable<Edge>)edges);
        }

        public void AddEdges(IEnumerable<Edge> edges)
        {
            foreach (var edge in edges)
            {
                AddEdge(edge);
            }
        }

        public void AddNode(Node node)
        {
            if (NodeExists(node))
                throw new DuplicateNodeException();

            _nodes.Add(node);
        }

        public bool NodeExists(Node node)
        {
            return _nodes.Any(x => x.Id == node.Id);
        }
        
        public void AddEdge(Edge edge)
        {
            if (EdgeExists(edge))
                throw new DuplicateEdgeException();

            _edges.Add(edge);
        }

        public bool EdgeExists(Edge edge)
        {
            return _edges.Any(x => x.Id == edge.Id || (x.Source == edge.Source && x.Target == edge.Target));
        }
        
        public void FitAllNodes()
        {
            foreach (var node in _nodes)
            {
                node.FitText();
            }
        }
    }

    public class DuplicateEdgeException : Exception
    {
    }

    public class DuplicateNodeException : Exception
    {
    }
}
