using SharpDX.MediaFoundation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TryMono3.Map
{
    public class TileMatrix : IEnumerable<TileMapTile>
    {
        private readonly TileMapTile[,] _tiles;

        public TileMapTile this[int x, int y]
        {
            get => GetTile(x, y);          
            set => SetTile(x, y, value);
        }

        public int Width => _tiles.GetLength(0);
        public int Height => _tiles.GetLength(1);
        public TileMatrix(int width, int height)
        {
            _tiles = new TileMapTile[width, height];
        }

        public TileMatrix(IEnumerable<IEnumerable<TileMapTile>> tiles)
        {
            if (tiles == null)
            {
                throw new ArgumentException(nameof(tiles));          
            }
            var x = 0;
            var y = 0;

            _tiles = new TileMapTile[tiles.Max(t => t.Count()), tiles.Count()];
            foreach (IEnumerable<TileMapTile> tileRow in tiles)
            {
                foreach (TileMapTile t in tileRow)
                {
                    SetTile(x, y, t);
                    x++;
                }
                y++;
            }
        }

        public bool IsInBounds(int x, int y)
        {
            return x >= 0 && x < _tiles.GetLength(0) && y >= 0 && y < _tiles.GetLength(1);
        }

        public void SetTile(int x , int y, TileMapTile tile)
        {
            _tiles[x, y] = tile;
        }

        public void ClearTile(int x, int y)
        {
            _tiles[x, y] = null;
        }

        public TileMapTile GetTile(int x, int y)
        {
            return IsInBounds(x, y) ? _tiles[x, y] : null;
        }

        public IEnumerator<TileMapTile> GetEnumerator()
        {
            return _tiles.GetEnumerator() as IEnumerator<TileMapTile>;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _tiles.GetEnumerator();
        }

        public static TileMatrix ParseCsv(string csv)
        {
            string[] csvLines = csv.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            
            List<List<TileMapTile>> _tiles = new List<List<TileMapTile>>();

            for (int i = 0; i < csvLines.Length; i++)
            {
                var tileList = new List<TileMapTile>();

                string[] ids = csvLines[i].Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                tileList.AddRange(ids.Select(i => new TileMapTile(Convert.ToInt32(i))));
                _tiles.Add(tileList);
            }
            return new TileMatrix(_tiles);
        }
    }
}
