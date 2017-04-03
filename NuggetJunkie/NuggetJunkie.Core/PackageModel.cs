using System.IO;
using System.Xml.Serialization;

namespace NuggetJunkie.Core
{
    public static class PackageModel
    {
        public static Packages LoadFile(string file)
        {
            var xml = new XmlSerializer(typeof(Packages));
            using (var stream = File.OpenRead(file))
                return (Packages)xml.Deserialize(stream);
        }

        public static string[] FindFiles(string root)
            => Directory.GetFiles(root, "pack*.conf*", SearchOption.AllDirectories);
    }
}