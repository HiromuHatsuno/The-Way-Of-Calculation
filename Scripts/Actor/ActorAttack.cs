using System;
using Assets.Scripts.Attack;
using UnityEngine;

namespace MainAssets.Scripts.Actor
{
    /// <summary>
    /// Actorの攻撃を統括する抽象クラス
    /// </summary>
    public abstract class ActorAttack : MonoBehaviour
    {
        #region 変数
        //攻撃者のオブジェクトを格納する変数
        private GameObject attackerObject;
        
        //攻撃する敵のタグ
        [SerializeField]
        protected string targetTag;

        //攻撃するオブジェクトを格納する変数
        [NonSerialized]
        public GameObject targetGameObject;
        #endregion
        
        protected void Start()
        {            
            //ActorAttackをアタッチしているオブジェクトをattackerObjectとする。
            attackerObject = this.gameObject;
            //targetTagを基にターゲットゲームオブジェクトを指定する。
            targetGameObject = GameObject.FindGameObjectWithTag(targetTag);
        }
        //攻撃メソッド
        public virtual void Attack()
        {
            //MoveAttackerOrTargetAttackSystemを利用してアタックメソッドを呼び出す
            MoveAttackerOrTargetAttackSystem.Attack(attackerObject,targetTag);
        }
        /// <summary>
        /// 攻撃メソッド
        /// 短距離攻撃か遠距離攻撃化の判定距離を持っている際に呼び出される。
        /// </summary>
        /// <param name="maxShortRangeAttackOfDistance">短距離攻撃か遠距離攻撃化の判定距離</param>
        public virtual void Attack(float maxShortRangeAttackOfDistance)
        {
            MoveAttackerOrTargetAttackSystem.Attack(attackerObject,targetTag,maxShortRangeAttackOfDistance);
        }

        public string ShowTargetTag()
        {
            return targetTag;
        }
    }
}