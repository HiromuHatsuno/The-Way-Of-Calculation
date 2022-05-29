using UnityEngine;

namespace Assets.Scripts.Scritable
{
    [CreateAssetMenu(menuName = "MyScriptable/Create PlayerParameter")]
    public class PlayerParameter : ScriptableObject
    {
        public int nowLv;
        public int maxHp;
        public int atk;
    }
}