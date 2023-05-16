using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml.Serialization;
using TryMono3.Map.TileSets;

namespace Tests
{
    [TestClass]
    public class TileSetDataTest
    {
        private const string testTilesetPath = "./Resources/CaveBG.tsx";

        [TestMethod]
        public void TestMethod1()
        {
            //string fileContent = File.ReadAllText(testTilesetPath);

            XmlSerializer serializer = new XmlSerializer(typeof(TileSetData));

            TileSetData tileSetData = null;

            using (FileStream stream = new FileStream(testTilesetPath, FileMode.Open))
            {
                tileSetData = serializer.Deserialize(stream) as TileSetData;

            }

            Assert.IsTrue(tileSetData != null && tileSetData.Name == "CaveBG" && tileSetData.TileWidth == 32);
        }
     
    }
}