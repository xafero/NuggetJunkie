﻿using System.Xml.Serialization;

namespace NuggetJunkie.Core
{
    public class Package
    {
        [XmlAttribute("id")]
        public string Id { get; set; }

        [XmlAttribute("version")]
        public string Version { get; set; }

        [XmlAttribute("targetFramework")]
        public string TargetFramework { get; set; }
    }
}