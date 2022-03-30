using System;
using System.Diagnostics.CodeAnalysis;
using GraphMLWriter.Elements.Nodes;
using GraphMLWriter.Elements.Shapes;

namespace GraphMLWriter.Elements.NodeFactories
{
    [SuppressMessage("ReSharper", "StringLiteralTypo")]
    public class EntityRelationshipNodeFactory
    {
        public virtual GenericNode CreateBigEntity(int nodeNumber, string text = null)
        {
            return new GenericNode(text, nodeNumber)
            {
                Configuration = "com.yworks.entityRelationship.big_entity",
                Width = 80,
                StyleProperties =
                {
                    StyleProperty.BooleanProperty("y.view.ShadowNodePainter.SHADOW_PAINTING", true)
                }
            };
        }

        public virtual GenericNode CreateSmallEntity(int nodeNumber, string text = null)
        {
            return new GenericNode(text, nodeNumber)
            {
                Configuration = "com.yworks.entityRelationship.small_entity",
                Width = 80,
                StyleProperties =
                {
                    StyleProperty.BooleanProperty("y.view.ShadowNodePainter.SHADOW_PAINTING", true)
                }
            };
        }

        public virtual GenericNode CreateWeakEntity(int nodeNumber, string text = null)
        {
            return new GenericNode(text, nodeNumber)
            {
                Configuration = "com.yworks.entityRelationship.small_entity",
                Width = 80,
                StyleProperties =
                {
                    StyleProperty.BooleanProperty("y.view.ShadowNodePainter.SHADOW_PAINTING", true),
                    StyleProperty.BooleanProperty("doubleBorder", true)
                }
            };
        }

        public virtual GenericNode CreateRelationship(int nodeNumber, string text = null)
        {
            return new GenericNode(text, nodeNumber)
            {
                Configuration = "com.yworks.entityRelationship.relationship",
                Width = 80,
                StyleProperties =
                {
                    StyleProperty.BooleanProperty("y.view.ShadowNodePainter.SHADOW_PAINTING", true)
                }
            };
        }

        public virtual GenericNode CreateWeakRelationship(int nodeNumber, string text = null)
        {
            return new GenericNode(text, nodeNumber)
            {
                Configuration = "com.yworks.entityRelationship.relationship",
                Width = 80,
                StyleProperties =
                {
                    StyleProperty.BooleanProperty("y.view.ShadowNodePainter.SHADOW_PAINTING", true),
                    StyleProperty.BooleanProperty("doubleBorder", true)
                }
            };
        }

        public virtual GenericNode CreateAttribute(int nodeNumber, string text = null)
        {
            return new GenericNode(text, nodeNumber)
            {
                Configuration = "com.yworks.entityRelationship.attribute",
                Width = 80,
                StyleProperties =
                {
                    StyleProperty.BooleanProperty("y.view.ShadowNodePainter.SHADOW_PAINTING", true)
                }
            };
        }

        public virtual GenericNode CreateMultiValuedAttribute(int nodeNumber, string text = null)
        {
            return new GenericNode(text, nodeNumber)
            {
                Configuration = "com.yworks.entityRelationship.attribute",
                Width = 80,
                StyleProperties =
                {
                    StyleProperty.BooleanProperty("y.view.ShadowNodePainter.SHADOW_PAINTING", true),
                    StyleProperty.BooleanProperty("doubleBorder", true)
                }
            };
        }

        public virtual GenericNode CreatePrimaryKeyAttribute(int nodeNumber, string text = null)
        {
            throw new NotImplementedException("This node type requires text customization");

            //< y:NodeLabel alignment = "center" autoSizePolicy = "content" fontFamily = "Dialog" fontSize = "12"
            //fontStyle = "bold" hasBackgroundColor = "false" hasLineColor = "false" height = "18.701171875"
            //horizontalTextPosition = "center" iconTextGap = "4" modelName = "custom" textColor = "#000000"
            //underlinedText = "true" verticalTextPosition = "bottom" visible = "true" width = "53.9921875"
            //x = "13.00390625" xml: space = "preserve" y = "10.6494140625" > Attribute < y:LabelModel >< y:SmartNodeLabelModel distance = "4.0" /></ y:LabelModel >< y:ModelParameter >< y:SmartNodeLabelModelParameter labelRatioX = "0.0" labelRatioY = "0.0" nodeRatioX = "0.0" nodeRatioY = "0.0" offsetX = "0.0" offsetY = "0.0" upX = "0.0" upY = "-1.0" /></ y:ModelParameter ></ y:NodeLabel >

            //return new GenericNode(text, nodeNumber)
            //{
            //    Configuration = "com.yworks.entityRelationship.attribute",
            //    Width = 80,
            //    StyleProperties =
            //    {
            //        StyleProperty.BooleanProperty("y.view.ShadowNodePainter.SHADOW_PAINTING", true)
            //    }
            //};
        }

        public virtual GenericNode CreateInheritedAttribute(int nodeNumber, string text = null)
        {
            return new GenericNode(text, nodeNumber)
            {
                Configuration = "com.yworks.entityRelationship.attribute",
                Width = 80,
                BorderStyle = "dashed",
                StyleProperties =
                {
                    StyleProperty.BooleanProperty("y.view.ShadowNodePainter.SHADOW_PAINTING", true)
                }
            };
        }
    }
}
