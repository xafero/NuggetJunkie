using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace NuggetJunkie.Core
{
    public static class PackageModel
    {
        static readonly XmlSerializer xml = new XmlSerializer(typeof(Packages));
        static readonly XmlSerializerNamespaces ns = new XmlSerializerNamespaces(
            new[] { new XmlQualifiedName("", "") });

        public static Packages LoadFile(string file)
        {
            using (var stream = File.OpenRead(file))
                return (Packages)xml.Deserialize(stream);
        }

        public static void StoreFile(Packages model, string file)
        {
            using (var stream = File.Create(file))
            using (var writer = XmlWriter.Create(stream, new XmlWriterSettings
            {
                Encoding = Encoding.UTF8,
                Indent = true
            }))
                xml.Serialize(writer, model, ns);
        }

        public static string[] FindFiles(string root)
            => Directory.GetFiles(root, "pack*.conf*", SearchOption.AllDirectories);
    }
}