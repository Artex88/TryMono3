using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryMono3.Map
{
    public class TileSet
    {
        
        public string Name { get; set; }

        public int TileWidth { get; private set; }

        public int TileHeight { get; private set; }

        public Texture2D Texture { get; private set; }

        public string TexturePath { get; private set; }

        public int ColumnCount { get; private set; }

        public int TileCount { get; private set; }

        public int RowCount => TileCount / ColumnCount;

        public TileSet(string name, int tileWidth, int tileHeight, string texturePath, int columnCount, int tileCount)
        {
            Name = name;
            TileWidth = tileWidth;
            TileHeight = tileHeight;
            TexturePath = texturePath;
            ColumnCount = columnCount;
            TileCount = tileCount;
        }

        private TileSet()
        {

        }

        public Rectangle GetTileBounds(int x, int y)
        {
            return new Rectangle
            {
                X = x * TileWidth,
                Y = y * TileHeight,
                Width = TileWidth,
                Height = TileHeight
            };
        }

        public Rectangle GetTileBoundsByLocalId(int tileId)
        {
            int x = (tileId - 1) % ColumnCount;
            int y = (tileId - 1) / ColumnCount;

            return GetTileBounds(x, y);
        }

        public bool LoadTexture(ContentManager contentManager)
        {
            if (contentManager is null)
                throw new ArgumentException(nameof(contentManager));

            string t = TexturePath.Trim(new[] { '\\', '/' });
            Texture = contentManager.Load<Texture2D>(t);

            return Texture != null;
        }
    }
}
