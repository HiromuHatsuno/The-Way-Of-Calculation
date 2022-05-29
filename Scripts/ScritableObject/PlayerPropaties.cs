using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Scritable
{
    [CreateAssetMenu(menuName = "MyScriptable/Create PlayerProp")]
    public class PlayerPropaties : ScriptableObject
    {
        private List<PlayerParameter> playerParameters;
    }
}