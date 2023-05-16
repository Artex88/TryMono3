using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryMono3.Map
{
    public class TileMapTile
    {
        
        public int Id { get; private set; }

        public bool IsEmpty => Id <= 0;
        public TileMapTile()
        {

        }
        public TileMapTile(int id)
        {
            Id = id;
        }
    }
}
