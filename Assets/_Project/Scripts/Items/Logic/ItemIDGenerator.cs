using System.Collections.Generic;
using UnityEngine;

namespace Assets._Project.Scripts.Items.Logic
{
    public static class ItemIDGenerator
    {
        private static HashSet<int> usedIDs = new HashSet<int>();

        public static int GetUniqueID()
        {
            int id;
            do
                id = Random.Range(100, 1000);
            while (usedIDs.Contains(id));

            usedIDs.Add(id);
            return id;
        }
    }
}
