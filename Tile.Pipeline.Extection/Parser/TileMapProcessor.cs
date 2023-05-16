using Microsoft.Xna.Framework.Content.Pipeline;
using System.IO;
using TryMono3.Map;
using TryMono3.Map.TileMaps;

namespace TileParser.Parser
{
    [ContentProcessor(DisplayName = "TileMapProcessor")]
    public class TileMapProcessor : ContentProcessor<TileMapData, TileMap>
    {
        public const string TileSetPath = "map";
        public override TileMap Process(TileMapData input, ContentProcessorContext context)
        {
            TileMap tileMap = new TileMap(input.TileWidth, input.TileWidth, input.Width, input.Height);

            foreach(var tsRef in input.TileSets)
            {
                string tsPath = $"{TileSetPath}/{Path.GetFileNameWithoutExtension(tsRef.Source)}";
                tileMap.AddTileSetReference(tsRef.FirstGid, tsPath);
            }          
                foreach (var layer in input.Layers)
                {
                    TileMatrix tileMatrix = TileMatrix.ParseCsv(layer.Data);
                    tileMap.AddLayer(new TileMapTileLayer(layer.Id, layer.Name, tileMatrix));
                }                        
            return tileMap;
        }
    }
}
