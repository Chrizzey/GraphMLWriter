using System.Globalization;
using System.Xml.Linq;
using GraphMLWriter.Contracts;
using GraphMLWriter.Serializer.Converter;

namespace GraphMLWriter.Serializer.ElementSerializer
{
    public class EdgeSerializer
    {
        private readonly XNamespace _yNamespace;

        private readonly EdgeArrowConverter _edgeArrowConverter;
        private readonly LineStyleConverter _lineStyleConverter;

        public EdgeSerializer()
        {
            _edgeArrowConverter = new EdgeArrowConverter();
            _lineStyleConverter = new LineStyleConverter();

            _yNamespace = "http://www.yworks.com/xml/graphml";
        }

        public XElement SerializeEdge(IEdge edge)
        {
            var edgeElement = new XElement("edge",
              new XAttribute("id", edge.Id),
              new XAttribute("source", edge.Source),
              new XAttribute("target", edge.Target),

              new XElement("data", new XAttribute("key", "d8")),
              new XElement("data", new XAttribute("key", "d9"))
              );

            var polyLine = new XElement(_yNamespace + "PolyLineEdge");

            var path = new XElement(_yNamespace + "Path",
                new XAttribute("sx", edge.Sx.ToString(new CultureInfo("en-us"))),
                new XAttribute("sy", edge.Sy.ToString(new CultureInfo("en-us"))),
                new XAttribute("tx", edge.Tx.ToString(new CultureInfo("en-us"))),
                new XAttribute("ty", edge.Ty.ToString(new CultureInfo("en-us"))));
            
            foreach (var p in edge.Points)
            {
                var point = new XElement(_yNamespace + "Point",
                    new XAttribute("x", p.X),
                    new XAttribute("y", p.Y)
                );
                path.Add(point);
            }
            
            polyLine.Add(path);

            var lineStyle = new XElement(_yNamespace + "LineStyle",
                new XAttribute("color", edge.LineProperties.Color),
                new XAttribute("type", _lineStyleConverter.ConvertLineStyle(edge.LineProperties.LineStyle)),
                new XAttribute("width", edge.LineProperties.Width));
            polyLine.Add(lineStyle);

            var arrows = new XElement(_yNamespace + "Arrows",
                new XAttribute("source", _edgeArrowConverter.ConvertArrow(edge.SourceArrow)),
                new XAttribute("target", _edgeArrowConverter.ConvertArrow(edge.TargetArrow)));
            polyLine.Add(arrows);
            
            var bendStyle = new XElement(_yNamespace + "BendStyle",
                new XAttribute("smoothed", edge.LineProperties.SmoothEdges));
            polyLine.Add(bendStyle);

            var d10 = new XElement("data", new XAttribute("key", "d10"));
            d10.Add(polyLine);
            
            edgeElement.Add(d10);

            return edgeElement;
        }
    }
}
