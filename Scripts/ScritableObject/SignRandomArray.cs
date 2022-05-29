using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MyScriptable/Create SignRandoms")]
public class SignRandomArray : ScriptableObject
{
    public int maxLv;
    public List<SignRandom> signPriority;
}