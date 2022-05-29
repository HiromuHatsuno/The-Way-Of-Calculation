using System.Collections;
using Assets.Assets.Scripts.Enemy.Provider;
using Main_Assets.Scripts.ExtendMethod;
using MainAssets.Scripts.Actor;
using MainAssets.Scripts.ExtendMethod;
using MainAssets.Scripts.Status.Actor;
using UnityEngine;

//Playerの場合は処理が異なる。
namespace MainAssets.Scripts.Enemy.Attack
{
    /// <summary>
    /// EnemyクラスのAttack処理を
    /// 纏めたスクリプト
    /// </summary>
    public class EnemyAttack:ActorAttack
    {
        //攻撃可能を表すbool

        #region 変数
        
        //攻撃の可否を表すbool
        public bool canAttack=false;
        
        //攻撃の可否を判定する為の当たり判定。
        [SerializeField]
        private BoxCollider2D canAttackColl;
        
        //EnemyProvider
        private EnemyProvider provider;
        
        //RigidBody格納用
        private Rigidbody2D rigidBody2D;
        
        #endregion
        
        /// <summary>
        /// 初期化処理
        /// </summary>
        private void Awake()
        {
            gameObject.TryGetComponent<EnemyProvider>(out provider);
            gameObject.TryGetComponent<Rigidbody2D>(out rigidBody2D);
        }
        

        /// <summary>
        ///ここで攻撃アニメーションを再生するまでの一連の処理を行う。
        /// </summary>
        public override void Attack()
        {
            //攻撃の準備を行う。
            AttackSetUp();
        }
        
        /// <summary>
        /// 攻撃の準備を行うメソッド
        /// </summary>
        private void AttackSetUp()
        {
            canAttackColl.enabled=false;
            StartCoroutine(CollEnableTrue(2.5f));
            rigidBody2D.ToKinematic();
            rigidBody2D.ToVelocityZero();
        }

        /// <summary>
        /// 攻撃が終わった時に呼び出されるメソッド
        /// </summary>
        public void AttackEnd()
        {
            provider.status.ChangeState(ActorStatus.ActorState.Alive);
        }
        private IEnumerator CollEnableTrue(float waitTime)
        {
            yield return new WaitForSeconds(waitTime);
            canAttackColl.enabled=true;
            yield break;
            
        }
    }
}
