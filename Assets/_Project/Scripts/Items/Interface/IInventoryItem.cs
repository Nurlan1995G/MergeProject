namespace Assets._Project.Scripts
{
    public interface IInventoryItem
    {
        public int ID { get; }
        public int Level { get; }
        public int Price { get; }
        public int Reward { get; }
        public ItemType ItemType { get; }
    }
}