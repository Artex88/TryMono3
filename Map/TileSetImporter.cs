using Microsoft.Xna.Framework.Content.Pipeline;
using TryMono3.Map.TileSets;
using TImport = System.String;

namespace TryMono3.Map
{
    [ContentImporter(".txt", DisplayName = "Importer1", DefaultProcessor = "Processor1")]
    public class Importer1: ContentImporter<TileSetData>
    {
        public override TileSetData Import(string filename, ContentImporterContext context)
        {
            return default(TileSetData);
        }
    }
}
