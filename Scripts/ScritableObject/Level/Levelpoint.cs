using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "MyScriptable/Create Level")]
public class Levelpoint : ScriptableObject
{
    public List<int> nextLevelPoint;
}
