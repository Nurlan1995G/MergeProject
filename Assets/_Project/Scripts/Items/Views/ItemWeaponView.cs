using UnityEngine;

namespace Assets._Project.Scripts
{
    public class ItemWeaponView : MonoBehaviour
    {
        [SerializeField] private ItemType _itemType;
        [SerializeField] private int _level;
        [SerializeField] private int _price;
        [SerializeField] private int _reward;

        private ItemWeaponModel _weaponModel;

        public ItemWeaponModel ItemWeaponModel => _weaponModel;

        public void SetItemWeaponModel(int id)
        {
            _weaponModel = new ItemWeaponModel(id, _level, _price, _reward, _itemType);
        }
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
