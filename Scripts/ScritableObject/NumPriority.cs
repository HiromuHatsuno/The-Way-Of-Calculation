using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Scritable
{
    [CreateAssetMenu(menuName = "MyScriptable/Create NumPriority")]
    public class NumPriority : ScriptableObject
    {
        public List<NumDigits> leftNumDigit;
        public List<NumDigits> rightNumDigit;
    }

    [System.Serializable]
    public class NumDigits
    {
        public int priority;
        public int priorityOfZero2Five;
        public int priorityOfFive2Ten;
    }
}