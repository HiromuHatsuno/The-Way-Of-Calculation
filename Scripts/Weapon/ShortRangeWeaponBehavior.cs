using MainAssets.Scripts.InterFace;
using MainAssets.Scripts.Status.Weapon;
using UnityEngine;

namespace MainAssets.Scripts.Weapon
{
    /// <summary>
    /// 短距離武器を表すクラス
    /// </summary>
    public class ShortRangeWeaponBehavior : WeaponBehavior,IKnockBackWeapon
    {
        //KnockBackWeaponStatus保存変数
        private KnockBackWeaponStatus knockBackStatus;
        
        //吹っ飛ぶ力
        public Vector2 knockBackDirection;
        public float knockBackPower;
        public bool isRightDirection;

        public void Start()
        {
            weaponStatus = new WeaponStatus(maxAttackPoint, nowAttackPoint,weaponName);
            knockBackStatus=
                new KnockBackWeaponStatus(knockBackDirection,knockBackPower,isRightDirection);
        }
        
        protected override void Attack()
        {
            base.Attack();
        }
        public WeaponBehavior　ConvertWeapon()
        {
            WeaponBehavior weaponBehavior = this;
            return null != weaponBehavior ? weaponBehavior : null;
        }

        public KnockBackWeaponStatus GetKnockBackStatus()
        {
            return knockBackStatus;
        }
    }
}
