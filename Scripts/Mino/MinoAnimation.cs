using MainAssets.Scripts.Enemy.Animation;
using UnityEngine;

namespace MainAssets.Scripts.Mino
{
    /// <summary>
    /// ミノタウロス（敵）のアニメーションを統括するクラス
    /// </summary>
    public class MinoAnimation : EnemyAnimation
    {
        private static readonly int AttackType = Animator.StringToHash("AttackType");

        public override void DefaultAttackAnimation()
        {                        
            base.DefaultAttackAnimation();
            animator.SetInteger("AttackType",Random.Range(0,2));
        }
    }
}