using Assets.Assets.Scripts.Attack;
using MainAssets.Scripts.InterFace;
using MainAssets.Scripts.KnockBack;
using MainAssets.Scripts.Status.Weapon;
using UnityEngine;

namespace MainAssets.Scripts.Weapon
{
    /// <summary>
    /// 武器を表す抽象クラス
    /// </summary>
    public abstract class WeaponBehavior : MonoBehaviour
    {
        [HideInInspector]
        public WeaponStatus weaponStatus;
        protected IAttackedService attackedService;

        //攻撃力の初期値
        [SerializeField] protected string targetName = "Enemy";
        
        //攻撃力の初期値
        [SerializeField]
        protected int maxAttackPoint;
        [SerializeField]
        protected int nowAttackPoint;

        [SerializeField] protected string weaponName;




        /// <summary>
        /// 武器の当たり判定が物体に当たった時に呼び出される。
        /// </summary>
        /// <param name="collision"></param>
        public virtual void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag(targetName))
            {
                AttackSuccessService.SuccessAttack(collision.gameObject, this);
            }
        }

        /// <summary>
        /// 攻撃を与えられるオブジェクトに攻撃する。
        /// </summary>
        protected virtual void Attack()
        {
            //当たったオブジェクトに攻撃された時の処理を呼び出させる。
            attackedService.ReceiveDamage(this);
        
        }
      
        public IKnockBackWeapon ConvertKnockBackWeapon()
        {
            if (KnockBackFunction.IsImplementation(this))
            {
                IKnockBackWeapon knockBackWeapon = (IKnockBackWeapon) this;
                return knockBackWeapon;
            }
            else
            {
                return null;
            }
        }
    }
}
