using System.Collections.Generic;
using System.Diagnostics;

namespace GraphMLWriter
{
    [DebuggerDisplay("{Name}")]
    public class Dependency
    {
        public string Name { get; set; }
        public string Version { get; set; }
        public string SourceDirectory { get; set; }

        public bool IsThirdPartyDependency
        {
            get
            {
                return SourceDirectory.ToLower().Contains("3rdparty");
            }
        }

        public List<Dependency> Dependencies { get; private set; }

        public Dependency()
        {
            Dependencies = new List<Dependency>();
        }

        public string BuildSvnLink()
        {
            return string.Format("{0}/{2}/{1}/{1}", SourceDirectory, Name, Version/*.StartsWith("tags") ? "trunk" : Version*/);
        }

        public override string ToString()
        {
            //return string.Format("{0}->{1} (v: {2})", SourceDirectory, Name, Version);
            return Name;
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            return GetHashCode() == obj.GetHashCode();
        }
    }
}