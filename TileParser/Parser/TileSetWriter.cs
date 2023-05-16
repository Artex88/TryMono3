using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TryMono3.Managers;
using TryMono3.Map;
using TryMono3.Map.TileSets;

namespace TileParser.Parser
{
    public class TileSetWriter : ContentTypeWriter<TileSet>
    {
        public override string GetRuntimeReader(TargetPlatform targetPlatform)
        {
            return typeof(TileSetReader).AssemblyQualifiedName;
        }

        public override string GetRuntimeType(TargetPlatform targetPlatform)
        {
            return typeof(TileSet).AssemblyQualifiedName;
        }
        protected override void Write(ContentWriter output, TileSet value)
        {
            output.Write(value.Name);
            output.Write(value.TileWidth);
            output.Write(value.TileHeight);
            output.Write(value.TexturePath);
            output.Write(value.ColumnCount);
            output.Write(value.TileCount);
        }
    }
}
