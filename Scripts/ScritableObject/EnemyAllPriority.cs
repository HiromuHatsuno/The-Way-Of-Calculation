using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Scritable;
using UnityEngine;

[CreateAssetMenu(menuName = "MyScriptable/Create EnemyPriorities")]
public class EnemyAllPriority : ScriptableObject
{
    public List<EnemyPriorityTable> enemyPriorityTables;
    
}