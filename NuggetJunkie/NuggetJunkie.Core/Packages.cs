using System.Collections.Generic;
using System.Xml.Serialization;

namespace NuggetJunkie.Core
{
    [XmlRoot("packages")]
    public class Packages
    {
        [XmlElement("package")]
        public List<Package> Entries { get; set; } = new List<Package>();
    }
}