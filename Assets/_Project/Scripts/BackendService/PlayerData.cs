using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Assets._Project.Scripts
{
    [Serializable]
    public class PlayerData
    {
        public int Balance { get; set; } = 0;
        public ItemWeaponView Item { get; set; }
        public List<ItemWeaponView> ItemWeaponViews;
    }
}