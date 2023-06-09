﻿using Microsoft.Xna.Framework.Content.Pipeline;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TryMono3.Map.TileMaps;

namespace TileParser.Parser
{
    [ContentImporter(".tmx", DisplayName ="TileMapImporter", DefaultProcessor ="TileMapProcessor")]
    public class TileMapImporter : ContentImporter<TileMapData>
    {
        public override TileMapData Import(string filename, ContentImporterContext context)
        {
            using (FileStream fileStream = new FileStream(filename, FileMode.Open)) 
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(TileMapData));

                TileMapData tileMapData = xmlSerializer.Deserialize(fileStream) as TileMapData;

                return tileMapData;

            }
        }
    }
}
