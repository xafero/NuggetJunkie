using FubuCsProjFile;
using System.IO;
using System.Linq;
using System.Runtime.Versioning;

namespace NuggetJunkie.Core
{
    public class Project
    {
        readonly CsProjFile file;

        public Project(CsProjFile file)
        {
            this.file = file;
        }

        public string AssemblyName => file.AssemblyName;

        public string ProjectDirectory => Path.GetDirectoryName(file.FileName);

        public string ProjectName => file.ProjectName;

        public string TargetFramework => file.TargetFrameworkVersion;

        public FrameworkName FrameworkName => file.FrameworkName;

        public BinaryRef[] Entries => file.All<AssemblyReference>()
            .Select(a => new BinaryRef(a)).ToArray();
    }
}