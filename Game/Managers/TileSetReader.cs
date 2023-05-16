using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TryMono3.Map;

namespace TryMono3.Managers
{
    public class TileSetReader : ContentTypeReader<TileSet>
    {
        protected override TileSet Read(ContentReader input, TileSet existingInstance)
        {

            if (existingInstance != null)
                return existingInstance;

            string name = input.ReadString();
            int tileWidth = input.ReadInt32();
            int tileHeight = input.ReadInt32();
            string texturePath = input.ReadString();
            int colCount = input.ReadInt32();
            int tileCount = input.ReadInt32();

            return new TileSet(name, tileWidth, tileHeight, texturePath, colCount, tileCount);
            
        }
    }
}
