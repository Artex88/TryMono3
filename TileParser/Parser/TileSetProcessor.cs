using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;
using Microsoft.Xna.Framework.Graphics;
using TryMono3.Map.TileSets;

namespace TryMono3.Map
{
    [ContentProcessor(DisplayName = "TileSetProcessor")]
    public class TileSetProcessor : ContentProcessor<TileSetData, TileSet>
    {
        private const string TextureRootPath = "map";
        public override TileSet Process(TileSetData input, ContentProcessorContext context)
        {

            string tileSetPath = Path.GetFileNameWithoutExtension(input.Image.Source);

            tileSetPath = Path.Combine(TextureRootPath, tileSetPath).Replace("\\","/");
            

            TileSet tileSet = new TileSet(input.Name, input.TileWidth, input.TileHeight, tileSetPath, input.Columns, input.TileCount);

            return tileSet;
        }
    }
}
