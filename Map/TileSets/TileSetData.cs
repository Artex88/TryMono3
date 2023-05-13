using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TryMono3.Map.TileSets
{
    [XmlRoot(ElementName = "tileSet")]
    public class TileSetData
    {
        [XmlAttribute(AttributeName = "version")]
        public string Version { get; set; }

        [XmlAttribute(AttributeName = "tiledversion")]
        public string TiledVersion { get; set; }

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [XmlAttribute(AttributeName = "tilewidth")]
        public int TileWidth { get; set; }

        [XmlAttribute(AttributeName = "tileheight")]
        public int TileHeight { get; set; }

        [XmlAttribute(AttributeName = "tilecount")]
        public int TileCount { get; set; }

        [XmlAttribute(AttributeName = "columns")]
        public int ColumnCount { get; set; }

        [XmlAttribute(AttributeName = "image")]
        public ImageData Image { get; set; }
    }
}
