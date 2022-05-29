using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Scritable
{
    [CreateAssetMenu(menuName = "MyScriptable/Create LevelTable")]
    public class LevelTable : ScriptableObject
    {
        public PlayerPropaties playerPropatieses;
        public EnemyAllPriority enemyAllPrioritieses;
        public NumPriorities numPriorities;
        public SignRandomArray signRandomArray;
        public Levelpoint nextLevelpoints;
    }
}