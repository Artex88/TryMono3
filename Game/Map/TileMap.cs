using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryMono3.Map
{
    public class TileMap
    {
        private readonly List<TileMapLayer> _layers = new List<TileMapLayer>();

        private readonly List<TileSetReference> tileSetReferences = new List<TileSetReference>();

        public int TileWidth { get; private set; }

        public int TileHeight { get; set; }

        public int Width { get; private set; }

        public int Height { get; private set; }

        public IEnumerable<TileMapLayer> Layers => new ReadOnlyCollection<TileMapLayer>(_layers);

        public int LayerCount => _layers.Count;
        public int TileSetReferenceCount => tileSetReferences.Count;

        public IEnumerable<TileSetReference> TileSetReferences => new ReadOnlyCollection<TileSetReference>(tileSetReferences);
        

        private TileMap()
        {

        }
        public TileMap(int tileHeight, int tileWidth, int width, int height)
        {
            TileWidth = tileWidth;
            TileHeight = tileHeight;
            Width = width;
            Height = height;
        }


        public void AddTileSet(int firstGid, TileSet tileSet)
        {
            tileSetReferences.Add(new TileSetReference(firstGid, tileSet));
        }

        public void AddTileSetReference(int firstGid, string tileSetPath)
        {
            tileSetReferences.Add(new TileSetReference(firstGid, tileSetPath));
        }

        public void AddTileSetReference(TileSetReference tileSetReference)
        {
            tileSetReferences.Add(tileSetReference);
        }

        public void LoadTileSets(ContentManager contentManager)
        {
            foreach (var tilesetRef in tileSetReferences)
                tilesetRef.LoadTileSet(contentManager);
        }

        public void AddLayer(TileMapLayer layer)
        {
            if (layer is null)
            {
                throw new ArgumentNullException(nameof(layer));
            }

            _layers.Add(layer);

        }
        public void AddLayer(TileMapLayerType layerType, int id, string name)
        {
            if (layerType == TileMapLayerType.Tile)
            {
                TileMapTileLayer tileLayer = new TileMapTileLayer(id, name, Width, Height);
                _layers.Add(tileLayer);
            }
            else if(layerType == TileMapLayerType.Object)
            {

            }
            else
            {
                throw new ArgumentException("unknown tile layer type.");
            }
        }

        

    }
}
