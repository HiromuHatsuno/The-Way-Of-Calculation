using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Scritable;
using UnityEngine;

[CreateAssetMenu(menuName = "MyScriptable/Create EnemyPriority")]
public class EnemyPriorityTable:ScriptableObject
{
    public List<EnemyPriority> enemyPriorities;
    public float appearanceTime;
}
[System.Serializable]
public class EnemyPriority
{
    public GameObject enemy;
    public int priority;
}