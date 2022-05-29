using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MyScriptable/Create EnemyParameter")]
public class EnemyParameter : ScriptableObject
{    
    public string enemyName;
    public int maxHp;
    public int atk;
    public float speed;
    public int gold;
}
