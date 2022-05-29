using MainAssets.Scripts.Player.Provider;
using UnityEngine;

namespace MainAssets.Scripts.Actor
{
    /// <summary>
    /// キャラクターのアニメーションを統括する抽象クラス
    /// </summary>
    public abstract class ActorAnimation : MonoBehaviour
    {
        #region 変数一覧
        
        protected static readonly int Speed = Animator.StringToHash("Speed");
      
        private static readonly int Damage = Animator.StringToHash("Damage");

        //Animator格納用変数
        [SerializeField] protected Animator animator;
        //PlayerActorProvider格納変数
        protected PlayerActorProvider playerProvider;
        #endregion
        
        public virtual void Start()
        {
            animator = GetComponent<Animator>();
            PlayMoveAnimation();
        }
       

        /// <summary>
        /// 歩行アニメーションのメソッド
        /// </summary>
        private void PlayMoveAnimation()
        {
            //常時歩行アニメーションを行わせる処理
            animator.SetFloat(Speed, 0.2f);
        }
        /// <summary>
        /// 攻撃アニメーションのメソッド
        /// </summary>
        public virtual void DefaultAttackAnimation()
        {
        }

        /// <summary>
        /// ダメージアニメーションのメソッド
        /// </summary>
        public virtual void DamageAnimation()
        {
            animator.SetTrigger(Damage);
        }
    }
}