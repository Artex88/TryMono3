using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TryMono3.Map.TileMaps
{
    [XmlRoot(ElementName = "map")]
    public class TileMapData
    {
        [XmlAttribute(AttributeName = "tilewidth")]
        public int TileWidth { get; set; }

        [XmlAttribute(AttributeName = "tileheight")]
        public int TileHeight { get; set; }

        [XmlAttribute(AttributeName = "width")]
        public int Width { get; set; }

        [XmlAttribute(AttributeName = "tilewidth")]
        public int Height { get; set; }

        [XmlArray(ElementName = "tileset")]
        public List<TileMapTileSetData> TileSets { get; set; }

        [XmlArray(ElementName = "layer")]
        public List<TileMapLayerData> Layers { get; set; }

        
    }
}
