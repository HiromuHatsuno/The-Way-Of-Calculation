using MainAssets.Scripts.Actor;
using MainAssets.Scripts.InterFace;
using UnityEngine;

namespace MainAssets.Scripts.Player.Animation
{
    [RequireComponent(typeof(Animator))]
    //Playerのアニメーションを再生するクラス
    public class PlayerActorAnimation : ActorAnimation,IShootingAnim
    {
        #region 変数格納
        private readonly int hashRandomSelectedAttack = Animator.StringToHash("AttackType");

        public bool nowAttack=false;
        
        static readonly int Shot = Animator.StringToHash("Shot");
        private static readonly int Damage = Animator.StringToHash("Damage");
        private static readonly int IsDead = Animator.StringToHash("IsDead");
        private static readonly int IsAttack = Animator.StringToHash("IsAttack");

        #endregion

        public override void Start()
        {
            base.Start();
        }
        
        public void EndAnim()
        {
            animator.SetInteger(hashRandomSelectedAttack, 4);
        }

        public override void DefaultAttackAnimation()
        {
            animator.SetTrigger(IsAttack);
            animator.SetInteger(hashRandomSelectedAttack, Random.Range(0, 3));
        }

        public void PlayShootingAnimation()
        {
            animator.SetInteger(hashRandomSelectedAttack, 3);
            animator.SetTrigger(IsAttack);
        }
        
        public void PlayDeadAnimation()
        {
            
            animator.SetBool(IsDead,true);
        }  
        public void PlayReviveAnimation()
        {
            animator.SetBool(IsDead,false);
        }

        public float GetAnimationPlaySpeed()
        {
             return animator.GetCurrentAnimatorClipInfo(0).Length;
        }
    }
}
