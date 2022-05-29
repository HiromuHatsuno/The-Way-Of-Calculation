using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Scritable
{
    [CreateAssetMenu(menuName = "MyScriptable/Create PopUpStoryGenre")]
    public class PopUpStoryGenre : ScriptableObject
    {
        public string genreNames;
        public List<PopUpStoryScritable> stories;
    }
}