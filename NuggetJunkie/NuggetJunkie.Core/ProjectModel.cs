using FubuCsProjFile;
using System.IO;

namespace NuggetJunkie.Core
{
    public static class ProjectModel
    {
        public static string[] FindFiles(string root)
            => Directory.GetFiles(root, "*.*proj", SearchOption.AllDirectories);

        public static Project LoadFile(string file)
            => new Project(CsProjFile.LoadFrom(file));
    }
}