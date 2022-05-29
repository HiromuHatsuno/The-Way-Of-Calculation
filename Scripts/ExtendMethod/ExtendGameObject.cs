using UnityEngine;

namespace MainAssets.Scripts.ExtendMethod
{
    public static  class ExtendGameObject 
    {
        public static void ChangeTag(this GameObject self,string tagName)
        {
            self.tag = tagName;
        }
    }
}