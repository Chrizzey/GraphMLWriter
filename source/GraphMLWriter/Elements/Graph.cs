using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using GraphMLWriter.Contracts;
using GraphMLWriter.Elements.Edges;

namespace GraphMLWriter.Elements
{
    public class Graph
    {
        private readonly List<INode> _nodes;
        private readonly List<Edge> _edges;

        public Graph()
        {
            _nodes = new List<INode>();
            _edges = new List<Edge>();
        }

        public IReadOnlyCollection<INode> AllNodes => new ReadOnlyCollection<INode>(_nodes);

        public IReadOnlyCollection<Edge> AllEdges => new ReadOnlyCollection<Edge>(_edges);

        public void AddNodes(params INode[] nodes)
        {
            AddNodes((IEnumerable<INode>)nodes);
        }

        public void AddNodes(IEnumerable<INode> nodes)
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

        public void AddNode(INode node)
        {
            if (NodeExists(node))
                throw new DuplicateNodeException();

            _nodes.Add(node);
        }

        public bool NodeExists(INode node)
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
