using Microsoft.Xna.Framework.Content.Pipeline;
using System.IO;
using System.Xml.Serialization;
using TryMono3.Map.TileSets;
using TImport = System.String;

namespace TryMono3.Map
{
    [ContentImporter(".tsx", DisplayName = "TileSet Importer", DefaultProcessor = "TileSetProcessor")]
    public class TileSetImporter: ContentImporter<TileSetData>
    {
        public override TileSetData Import(string filename, ContentImporterContext context)
        {
            using (FileStream fileStream = new FileStream(filename, FileMode.Open))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(TileSetData));

                TileSetData data = xmlSerializer.Deserialize(fileStream) as TileSetData;

                return data;
            }
        }
    }
}
