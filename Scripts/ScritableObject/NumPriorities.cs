using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Scritable;
using UnityEngine;
[CreateAssetMenu(menuName = "MyScriptable/Create NumPriorities")]
public class NumPriorities : ScriptableObject
{
    public List<NumPriority> numPriorities;
}
