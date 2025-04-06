using Assets._Project.Scripts.Cells;
using Assets._Project.Scripts.ScriptableObjects;
using Assets._Project.Scripts.Service;

namespace Assets._Project.Scripts
{
    public interface IItemWeaponController : IService
    {
        ItemWeaponView SpawnItems(ItemWeaponData itemData, CellView targetCell);
    }
}