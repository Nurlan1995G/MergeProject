using UnityEngine;

namespace Assets._Project.Scripts
{
    public class ItemWeapon : MonoBehaviour, IInventoryItem
    {
        [SerializeField] private ItemType _itemType;
        [SerializeField] private int _level;
        [SerializeField] private int _price;
        [SerializeField] private int _reward;

        public int Level { get => _level; set => _level = value; }
        public int Price { get => _price; set => _price = value; }
        public int Reward { get => _reward; set => _reward = value; }
    }

    public enum ItemType
    {
        HunterKnif = 1,
        AssassinDagger,
        SharpenedInfantrySword,
        BalancedSword,
        ManticoreSword
    }
}
