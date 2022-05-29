using MainAssets.Scripts.InterFace;
using MainAssets.Scripts.Status.Weapon;
using UnityEngine;

namespace MainAssets.Scripts.Weapon
{
    /// <summary>
    /// 遠距離武器を表すクラス
    /// </summary>
    public class LongRangeWeaponBehavior : WeaponBehavior,IKnockBackWeapon
    {

        #region 変数一覧

        #region ステータス初期化用変数
        [SerializeField]
        private float limitBalletSpeed;
        [SerializeField]
        private float balletSpeed;
        #endregion


        //KnockBackWeaponStatus保存変数
        private KnockBackWeaponStatus knockBackStatus;
        
        //吹っ飛ぶ力
        [SerializeField]
        private Vector2 knockBackDirection;
        [SerializeField]
        private float knockBackPower; 
        [SerializeField]
        private bool isRightDirection;

        
        //弾丸の現在位置保存用
        private Vector2 nowMissilePosition;
        
        private Rigidbody2D rigidBody2D;
        #endregion

        public void Start()
        {
            weaponStatus =
                new WeaponStatus(maxAttackPoint, nowAttackPoint, name, limitBalletSpeed, balletSpeed);
           
            knockBackStatus=
                new KnockBackWeaponStatus(knockBackDirection,knockBackPower,isRightDirection);
            
            TryGetComponent<Rigidbody2D>(out rigidBody2D);
            MoveBallet();
        }
        
        /// <summary>
        /// 攻撃処理のオーバライド版
        /// </summary>
        protected override void Attack()
        {
            base.Attack();
            VanishBallet();
        }

        /// <summary>
        /// 弾丸を消滅させる
        /// </summary>
        private void VanishBallet()
        {
            Destroy(this.gameObject);
        }

        /// <summary>
        /// 弾丸を動かす
        /// </summary>
        private void MoveBallet()
        { 
            rigidBody2D.AddForce(Vector2.right*weaponStatus.GetSpeed(), ForceMode2D.Force);
        }
        public WeaponBehavior　ConvertWeapon()
        {
            WeaponBehavior weaponBehavior = this;
            return null != weaponBehavior ? weaponBehavior : null;
        }

        public override void OnTriggerEnter2D(Collider2D other)
        {
            base.OnTriggerEnter2D(other);
            if (other.gameObject.CompareTag(targetName))
            {
                Destroy(gameObject);
            }
        }

        public KnockBackWeaponStatus GetKnockBackStatus()
        {
            return knockBackStatus;
        }
    }
}
