using UnityEngine;

namespace Assets._Project.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "GameConfig", menuName = "Config")]
    public class GameConfig : ScriptableObject
    {
        [field: SerializeField] public ManagerData ManagerData { get; private set; }
        [field: SerializeField] public LogicData LogicData { get; private set; }
        [field: SerializeField] public LevelData LevelData { get; private set; }
    }
}
