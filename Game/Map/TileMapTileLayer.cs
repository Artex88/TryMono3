using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryMono3.Map
{
    public class TileMapTileLayer : TileMapLayer
    {
        public  TileMatrix TileMatrix { get; private set; }

        public int Height => TileMatrix.Height;
        public int Width => TileMatrix.Width;

        public override TileMapLayerType LayerType => TileMapLayerType.Tile;

        public TileMapTileLayer(int id , string name , int width, int height) : base(id,name)
        {
            TileMatrix = new TileMatrix(width, height);
        }

        public TileMapTileLayer(int id,  string name, TileMatrix tileMatrix) : base(id, name)
        {
            TileMatrix = tileMatrix;
        }
         
    }
}
