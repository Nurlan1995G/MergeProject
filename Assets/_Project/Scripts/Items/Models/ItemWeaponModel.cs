namespace Assets._Project.Scripts
{
    public class ItemWeaponModel : IInventoryItem
    {
        public int ID { get; private set; }
        public int Level { get; private set; }
        public int Price { get; private set; }
        public int Reward { get; private set; }
        public ItemType ItemType { get; private set; }

        public ItemWeaponModel(int id, int level, int price, int reward, ItemType itemType)
        {
            ID = id;
            Level = level;
            Price = price;
            Reward = reward;
            ItemType = itemType;
        }
    }
}
