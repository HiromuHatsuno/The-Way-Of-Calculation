using System;
using Main_Assets.Scripts.@abstract;
using MainAssets.Scripts.Status.Actor;
using MainAssets.Scripts.Weapon;
using UnityEngine;

namespace Assets.Assets.Scripts.Actor 
{
    /// <summary>
    ///攻撃を受けた際に呼び出される抽象クラス
    /// </summary>
    public abstract class HasAttacked : MonoBehaviour
    {
        //攻撃を受けるオブジェクトのActorProviderを格納する変数
        [NonSerialized]
        protected ActorProvider  actorProvider;
        
        //攻撃してきた武器を格納する変数
        [NonSerialized]
        public  WeaponBehavior haveAttackedWeapon;
        
        /// <summary>
        /// 初期化処理
        /// </summary>
        public virtual void Start()
        {
            TryGetComponent<ActorProvider>(out actorProvider);
        }

        
        /// <summary>
        /// ダメージを受けた際に最初に呼び出されるメソッド
        /// </summary>
        /// <param name="weaponBehavior"></param>
        public virtual void ReceiveDamage(WeaponBehavior weaponBehavior)
        {
            //攻撃してきた武器を格納する
            haveAttackedWeapon = weaponBehavior;
            //ダメージ減少処理メソッド
            DamageHp();
            //ActorProviderを経由してDamageAnimationを再生する。
            actorProvider.anim.DamageAnimation();
        }

        /// <summary>
        /// ダメージ減少処理メソッド
        /// </summary>
        private void DamageHp()
        {
            //HPをWeaponの攻撃力分減らす。
            actorProvider.status.DamageHp(haveAttackedWeapon.weaponStatus.nowAttackPoint);
        }

        //攻撃を受けた後の処理をまとめたメソッド
        public void RecieveDamage_Postprocess()
        {
            //actorのステートに応じて処理を変更する。
            switch (actorProvider.status.actorState)
            {
                //生存時の処理
                case ActorStatus.ActorState.Alive:
                    ReceiveDamagePostProcessAlive();
                    break;
                //死亡時の処理
                case ActorStatus.ActorState.Dead:
                    ReceiveDamagePostProcessDead();
                    break;
                default:
                    break;
            }
        }

        //生存時に呼び出されるメソッド
        protected virtual void ReceiveDamagePostProcessAlive()
        {
            
        }
        //死亡に呼び出されるメソッド
        protected virtual void ReceiveDamagePostProcessDead()
        {
    
        }

    }
}