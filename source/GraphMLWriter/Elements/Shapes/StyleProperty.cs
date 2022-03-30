namespace GraphMLWriter.Elements.NodeFactories
{
    public class StyleProperty
    {
        public string ClassName { get; }

        public string Name { get; }

        public string Value { get; }
        
        public StyleProperty(string className, string name, object value)
        {
            ClassName = className;
            Name = name;
            Value = value?.ToString();
        }

        public static StyleProperty BooleanProperty(string name, bool value)
        {
            return new StyleProperty("java.lang.Boolean", name, value);
        }
    }
}