namespace GraphMLWriter.Elements.NodeFactories
{
    public class NodeLabel : INodeLabel
    {
        /*
         <y:NodeLabel 
                alignment="center" 
                autoSizePolicy="content" 
                fontFamily="Dialog" 
                fontSize="12" 
                fontStyle="plain" 
                hasBackgroundColor="false" 
                hasLineColor="false" 
                height="18.701171875" 
                horizontalTextPosition="center" 
                iconTextGap="4" 
                modelName="custom" 
                textColor="#000000" 
                verticalTextPosition="bottom" 
                visible="true" 
                width="66.015625" 
                x="6.9921875" 
                xml:space="preserve" 
                y="10.6494140625">
            Hello World
            <y:LabelModel>
                <y:SmartNodeLabelModel distance="4.0"/>
            </y:LabelModel>
        
            <y:ModelParameter>
                <y:SmartNodeLabelModelParameter labelRatioX="0.0" labelRatioY="0.0" nodeRatioX="0.0" nodeRatioY="0.0" offsetX="0.0" offsetY="0.0" upX="0.0" upY="-1.0"/>
            </y:ModelParameter>
        </y:NodeLabel>
         
         */

        public enum LabelAlignment
        {
            Center,
            Left,
            Right
        }

        public LabelAlignment Alignment { get; set; } = LabelAlignment.Center;

        public string FontFamily { get; set; } = "Dialog";

        public int FontSize { get; set; } = 12;

        public string FontStyle { get; set; } = "plain";

        public bool HasBackgroundColor { get; set; } = false;

        public bool HasLineColor { get; set; } = false;

        public string TextColor { get; set; } = "#000000";

        public bool UnderlineText { get; set; } = false;

        public bool IsVisible { get; set; } = true;
    }
}