using Assets.Assets.Scripts.Enemy.Provider;
using Main_Assets.Scripts.@abstract;
using Main_Assets.Scripts.Enemy.Enemy;
using UnityEngine;

namespace Main_Assets.Scripts.Enemy.Attack
{
    /// <summary>
    /// Colliderに当たったCollのタグを元に、
    /// 攻撃可能か判定するクラス
    /// </summary>
    public class AttackPossibleJudgment : MonoBehaviour
    {
        //ActorProviderを取得
        [SerializeField]
        private EnemyProvider actorProvider;

        /// <summary>
        /// 何かと敵が当たった際に呼び出されるイベント関数
        /// </summary>
        /// <param name="collisionObj"></param>
        private void OnTriggerEnter2D(Collider2D collisionObj)
        {
            //ターゲットタグとぶつかったオブジェクトが攻撃可能対象でなければメソッドを抜ける。
            if (!CanAttack(collisionObj.gameObject)) return;
            actorProvider.anim.DefaultAttackAnimation();
            //同じタグなので（攻撃対象なので攻撃する）
            actorProvider.attack.Attack();
        }

        /// <summary>
        /// tagを元に攻撃可能オブジェクトか判別する。
        /// </summary>
        /// <param name="collisionObj"></param>
        /// <returns></returns>
        private bool CanAttack(GameObject collisionObj)
        {
            //返り値がtrue⇒当たり判定に当たったオブジェクトが攻撃可能である事を示す。
            return collisionObj.CompareTag(actorProvider.attack.ShowTargetTag());
        }
    }
}