using MainAssets.Scripts.Actor;
using UnityEngine;

namespace MainAssets.Scripts.Enemy.Animation
{
    /// <summary>
    /// Enemyクラスのアニメーション処理を纏めたスクリプト
    /// </summary>
    public class EnemyAnimation:ActorAnimation
    {

        private static readonly int CanAttack = Animator.StringToHash("CanAttack");


        /// <summary>
        /// 初期化処理
        /// </summary>
        public override void Start()
        {
            gameObject.TryGetComponent<Animator>(out animator);
        }
 
        /// <summary>
        /// このメソッドが無いと物理演算が動作しません。
        /// </summary>
        void OnAnimatorMove()
        {
            transform.position = GetComponent<Animator>().rootPosition;
            transform.rotation = GetComponent<Animator>().rootRotation;
        }
        
        //-----------------------------------------------------------------------------------------------------------//
        //------------------------------------本来の処理--------------------------------------------------------------//
        //----------------------------------------------------------------------------------------------------------//
        public override void DefaultAttackAnimation()
        {           
            animator.SetTrigger(CanAttack);
        }

        public override void DamageAnimation()
        {
            base.DamageAnimation();
        }
    }
}
