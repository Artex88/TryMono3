using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework.Internal;
using System.Xml.Serialization;
using TryMono3.Map.TileMaps;

namespace Tests
{
    [TestClass]
    public class TileMapDataTest
    {
        private const string testTilemapPath = "./Resources/testmap1.tmx";

        [TestMethod]
        public void TestMethod1()
        {

            XmlSerializer serializer = new XmlSerializer(typeof(TileMapData));

            TileMapData mapData = null;

            using (FileStream stream = new FileStream(testTilemapPath, FileMode.Open))
            {
                mapData = serializer.Deserialize(stream) as TileMapData;
            }

            
        }

    }
}
