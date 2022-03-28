using System.Collections.Generic;
using System.Linq;
using GraphMLWriter.Elements;
using GraphMLWriter.Elements.Edges;
using GraphMLWriter.Serializer;

namespace GraphMLWriter
{
    public class GraphMlBuilder
    {

        /// <summary>
        /// If true, ensures that only one link is drawn between 2 packages
        /// </summary>
        public bool CollapseRedundantDependencies { get; set; }

        private Dictionary<Dependency, Node> _dependencies;
        private List<Edge> _edges;

        public Dictionary<Dependency, Node> Dependencies => _dependencies;

        public GraphMlBuilder()
        {
            CollapseRedundantDependencies = true;
        }

        public GraphSerializer BuildDependencyGraph(IEnumerable<Dependency> rootSolutions)
        {
            GraphSerializer g = new GraphSerializer();
            _dependencies = new Dictionary<Dependency, Node>();
            _edges = new List<Edge>();

            foreach (Dependency root in rootSolutions)
            {
                if (!_dependencies.ContainsKey(root))
                {
                    Node rootNode = new Node(root.Name, Dependencies.Count) { Color = "#FFCC00" };
                    _dependencies.Add(root, rootNode);
                    g.AddNode(rootNode);
                }
                else
                {
                    Node rootNode = _dependencies[root];
                    rootNode.Color = "#FFCC00";
                }
                TraceDependencies(root, g);
            }

            foreach (Edge e in _edges)
            {
                g.AddEdge(e);
            }

            return g;
        }

        private void TraceDependencies(Dependency root, GraphSerializer g)
        {
            Node rootNode = _dependencies[root];

            foreach (Dependency d in root.Dependencies)
            {
                Node dNode;
                if (_dependencies.ContainsKey(d))
                {
                    dNode = _dependencies[d];
                }
                else
                {
                    dNode = new Node(d.Name, Dependencies.Count);
                    if (d.IsThirdPartyDependency)
                        dNode.Color = "#FF4444";
                    _dependencies.Add(d, dNode);
                    g.AddNode(dNode);
                }

                if (CollapseRedundantDependencies)
                {
                    if (!_edges.Any(e => e.Source == rootNode.Id && e.Target == dNode.Id))
                    {
                        _edges.Add(new Edge(_edges.Count, rootNode.Id, dNode.Id));
                    }
                }
                else
                {
                    _edges.Add(new Edge(_edges.Count, rootNode.Id, dNode.Id));
                }

                TraceDependencies(d, g);
            }
        }
    }
}
