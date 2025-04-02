using System;
using UnityEngine;

namespace Assets._Project.Scripts.ScriptableObjects
{
    [Serializable]
    public class ManagerData
    {
        public Vector3 StartPosition = new Vector3(-2.5f, 2, 0);
        public Vector3 ReduceSize = new Vector3(0.1f, 0.1f, 0.1f);
        public int MoveCount = 3;
    }
}
