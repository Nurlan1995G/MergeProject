using Assets._Project.Scripts.BackendService;
using Assets._Project.Scripts.Cells;
using Assets._Project.Scripts.ScriptableObjects;
using System.Collections.Generic;

namespace Assets._Project.Scripts.Levels.Controllers
{
    public interface ILevelController
    {
        void Initialize(IItemWeaponController itemsController, List<CellView> cells, List<ItemWeaponData> itemWeaponDatas, GamesBeckendHandler beckendHandler);
        void RestoreItems(List<ItemWeaponSaveData> savedItems);
        void SpawnInitialItems(GamesBeckendHandler backend);
    }
}