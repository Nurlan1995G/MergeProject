namespace Assets._Project.Scripts
{
    public interface IInventoryItem
    {
        public int Level { get; set; }
        public int Price { get; set; }
        public int Reward { get; set; }
    }
}