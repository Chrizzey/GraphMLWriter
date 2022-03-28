using System.Collections.Generic;
using System.Diagnostics;

namespace GraphMLWriter
{
    [DebuggerDisplay("{Name}")]
    public class Dependency
    {
        public string Name { get; set; }
        public IEnumerable<Dependency> Dependencies { get; set; }
        public bool IsThirdPartyDependency { get; set; }
    }
}