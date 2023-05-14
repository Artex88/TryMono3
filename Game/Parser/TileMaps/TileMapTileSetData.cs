﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TryMono3.Map.TileMaps
{
    public class TileMapTileSetData
    {
        [XmlAttribute(AttributeName = "firstgid")]
        public int FirstGid { get; set; }

        [XmlAttribute(AttributeName = "source")]
        public string Source { get; set; }
    }
}
