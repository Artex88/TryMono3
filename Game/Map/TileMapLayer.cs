namespace TryMono3.Map
{
    public abstract class TileMapLayer
    {
        public int Id { get; private set; }

        public string Name { get; set; }

        public abstract TileMapLayerType LayerType { get; }
        protected TileMapLayer()
        {

        }

        protected TileMapLayer(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
