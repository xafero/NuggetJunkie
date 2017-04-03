using FubuCsProjFile;
using System.Reflection;

namespace NuggetJunkie.Core
{
    public class BinaryRef
    {
        readonly AssemblyReference obj;

        public BinaryRef(AssemblyReference obj)
        {
            this.obj = obj;
        }

        public string HintPath => obj.HintPath;

        public bool? Private => obj.Private;

        public bool? Specific => obj.SpecificVersion;

        public string Name => obj.AssemblyName;

        public AssemblyName Info => new AssemblyName(obj.Include);
    }
}