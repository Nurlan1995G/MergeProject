using UnityEngine;

namespace Assets._Project.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "ItemWeaponData", menuName = "ItemWeapon/Data")]
    public class ItemWeaponData : ScriptableObject
    {
        [SerializeField] private int _level;
        [SerializeField] private int _price;
        [SerializeField] private int _reward;
        [SerializeField] private ItemType _itemType;
        [SerializeField] private ItemWeaponView _prefabItemWeapon;

        public int Level => _level;
        public int Price => _price;
        public int Reward => _price;
        public ItemType ItemType => _itemType;
        public ItemWeaponView PrefabItemWeapon => _prefabItemWeapon;
    }
}
