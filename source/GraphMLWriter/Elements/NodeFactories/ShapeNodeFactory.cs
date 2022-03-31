using System.Diagnostics.CodeAnalysis;
using GraphMLWriter.Elements.Nodes;

namespace GraphMLWriter.Elements.NodeFactories
{
    [SuppressMessage("ReSharper", "StringLiteralTypo")]
    public class ShapeNodeFactory
    {
        public virtual ShapeNode CreateRectangle(int nodeNumber, string text = null)
        {
            return new ShapeNode(text, nodeNumber)
            {
                ShapeType = "rectangle"
            };
        }
        public virtual ShapeNode Create3dRectangle(int nodeNumber, string text = null)
        {
            return new ShapeNode(text, nodeNumber)
            {
                ShapeType = "rectangle3d"
            };
        }
        public virtual ShapeNode CreateRoundRectangle(int nodeNumber, string text = null)
        {
            return new ShapeNode(text, nodeNumber)
            {
                ShapeType = "roundrectangle"
            };
        }
        public virtual ShapeNode CreateDiamond(int nodeNumber, string text = null)
        {
            return new ShapeNode(text, nodeNumber)
            {
                ShapeType = "diamond"
            };
        }
        public virtual ShapeNode CreateEllipse(int nodeNumber, string text = null)
        {
            return new ShapeNode(text, nodeNumber)
            {
                ShapeType = "ellipse"
            };
        }
        public virtual ShapeNode CreateFatArrow(int nodeNumber, string text = null)
        {
            return new ShapeNode(text, nodeNumber)
            {
                ShapeType = "fatarrow"
            };
        }
        public virtual ShapeNode CreateFatArrow2(int nodeNumber, string text = null)
        {
            return new ShapeNode(text, nodeNumber)
            {
                ShapeType = "fatarrow2"
            };
        }
        public virtual ShapeNode CreateHexagon(int nodeNumber, string text = null)
        {
            return new ShapeNode(text, nodeNumber)
            {
                ShapeType = "hexagon"
            };
        }
        public virtual ShapeNode CreateOctagon(int nodeNumber, string text = null)
        {
            return new ShapeNode(text, nodeNumber)
            {
                ShapeType = "octagon"
            };
        }
        public virtual ShapeNode CreateParallelogram(int nodeNumber, string text = null)
        {
            return new ShapeNode(text, nodeNumber)
            {
                ShapeType = "parallelogram"
            };
        }
        public virtual ShapeNode CreateParallelogram2(int nodeNumber, string text = null)
        {
            return new ShapeNode(text, nodeNumber)
            {
                ShapeType = "parallelogram2"
            };
        }
        public virtual ShapeNode CreateStar5(int nodeNumber, string text = null)
        {
            return new ShapeNode(text, nodeNumber)
            {
                ShapeType = "star5"
            };
        }
        public virtual ShapeNode CreateStar6(int nodeNumber, string text = null)
        {
            return new ShapeNode(text, nodeNumber)
            {
                ShapeType = "star6"
            };
        }
        public virtual ShapeNode CreateStar8(int nodeNumber, string text = null)
        {
            return new ShapeNode(text, nodeNumber)
            {
                ShapeType = "star8"
            };
        }
        public virtual ShapeNode CreateTrapezoid(int nodeNumber, string text = null)
        {
            return new ShapeNode(text, nodeNumber)
            {
                ShapeType = "trapezoid"
            };
        }
        public virtual ShapeNode CreateTrapezoid2(int nodeNumber, string text = null)
        {
            return new ShapeNode(text, nodeNumber)
            {
                ShapeType = "trapezoid2"
            };
        }
        public virtual ShapeNode CreateTriangle(int nodeNumber, string text = null)
        {
            return new ShapeNode(text, nodeNumber)
            {
                ShapeType = "triangle"
            };
        }
        public virtual ShapeNode CreateTriangle2(int nodeNumber, string text = null)
        {
            return new ShapeNode(text, nodeNumber)
            {
                ShapeType = "triangle2"
            };
        }
    }
}
