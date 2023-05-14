using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;
using Microsoft.Xna.Framework.Graphics;
using TryMono3.Map.TileSets;

namespace TryMono3.Map
{
    [ContentProcessor(DisplayName = "TileSet Processor")]
    public class TileSetProcessor : ContentProcessor<TileSetData, TileSet>
    {
        public override TileSet Process(TileSetData input, ContentProcessorContext context)
        {
            ExternalReference<string> extRef = new ExternalReference<string>(input.Image.Source);

            Texture2DContent texture = context.BuildAndLoadAsset<string, Texture2DContent>(extRef, "TextureProcessor");
           


            TileSet tileSet = new TileSet(input.Name, input.TileWidth, input.TileHeight, null, input.Columns, input.TileCount);

            return tileSet;
        }
    }
}
