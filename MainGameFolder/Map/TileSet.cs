using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryMono3.game.Map
{
    public class TileSet
    {

        public string Name { get; set; }

        public int TileWidth { get; }

        public int TileHeight { get; }

        public Texture2D Texture { get; private set; }

        public int ColumnCount { get; }

        public int TileCount { get; }

        public int RowCount => TileCount / ColumnCount;

        public TileSet(string name, int tileWidth, int tileHeight, Texture2D texture, int columnCount, int tileCount)
        {
            Name = name;
            TileWidth = tileWidth;
            TileHeight = tileHeight;
            //Texture = texture ?? throw new ArgumentException(nameof(texture));
            Texture = texture;
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
    }
}
