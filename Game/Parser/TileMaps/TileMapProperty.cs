﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TryMono3.Map.TileMaps
{
    [XmlRoot("property")]
    public class TileMapProperty
    {
        [XmlAttribute(AttributeName = "value")]

        public string Value { get; set; }

        [XmlAttribute(AttributeName = "name")]

        public string Name { get; set; }
    }
}
