using UnityEngine;

namespace MainAssets.Scripts.ExtendMethod
{
    public static  class ExtendCollider
    {
        public static void EnableIsFalse(this Collider2D self)
        {
            self.enabled = false;
        }
        public static void EnableIsTrue(this Behaviour self)
        {
            self.enabled = true;
        }
    }
}