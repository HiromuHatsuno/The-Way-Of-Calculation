using UnityEngine;

namespace MainAssets.Scripts.Status.Weapon
{
    /// <summary>
    /// KnockBackWeaponのステータス
    /// </summary>
    public class KnockBackWeaponStatus
    {
        //吹っ飛ぶ力
        public Vector2 knockBackDirection;
        public float knockBackPower;
        public bool isRightDirection;

        public KnockBackWeaponStatus(Vector2 knockBackDirection,float knockBackPower,bool isRightDirection)
        {
            this.knockBackDirection = knockBackDirection;
            this.knockBackPower = knockBackPower;
            this.isRightDirection = isRightDirection;
        }
    }        
}