using System.Collections;
using Assets.Scripts.Scritable;
using MainAssets.Scripts.GameOver;
using MainAssets.Scripts.InterFace;
using MainAssets.Scripts.Player.Provider;
using MainAssets.Scripts.PopUpStory;
using MainAssets.Scripts.Weapon;
using UnityEngine;

namespace MainAssets.Scripts.Player.HasAttacked
{
    /// <summary>
    /// Playerがダメージを受けた時の処理を統括するクラス
    /// </summary>
    public class PlayerHasAttacked : Assets.Assets.Scripts.Actor.HasAttacked, IAttackedService
    {
        public GameOverManager gameOverManager1;
        private new PlayerActorProvider actorProvider;
        private Rigidbody2D rigidbody2D;
        [SerializeField] private IHasAttackedAdditionFeature feature;
        public PopUpStoryManager popUpStoryManager13;
        public PopUpStoryGenre popUpStoryGenre3;
        public bool isInvincible;
        public override void Start()
        {
            isInvincible = false;

            base.Start();
            TryGetComponent<PlayerActorProvider>(out actorProvider);
            TryGetComponent<Rigidbody2D>(out rigidbody2D);
            feature= this.gameObject.GetComponent<IHasAttackedAdditionFeature>();
        }

        protected override void ReceiveDamagePostProcessAlive()
        {
            base.ReceiveDamagePostProcessAlive();
        }

        protected override void ReceiveDamagePostProcessDead()
        {
            isInvincible = true;
            actorProvider.anim.PlayDeadAnimation();
            gameOverManager1.GameOver();
            base.ReceiveDamagePostProcessDead();
        }

        public override void ReceiveDamage(WeaponBehavior weaponBehavior)
        {
           
            if (!isInvincible)
            {
                base.ReceiveDamage(weaponBehavior);
                RecieveDamage_Postprocess();
                feature?.KnockBack();
                StartCoroutine(Off2Invicible(actorProvider.anim.GetAnimationPlaySpeed()));
                popUpStoryManager13.PlayPopUpStory(popUpStoryGenre3);
            }
            isInvincible = true;
        }

        IEnumerator Off2Invicible(float delayCountOfSeconds)
        {
            yield return new WaitForSeconds(delayCountOfSeconds);
            isInvincible = false;
            yield break;
        }

        public void On2Invicible()
        {
            isInvincible = true;
            StartCoroutine(Off2Invicible(actorProvider.anim.GetAnimationPlaySpeed()/2));
        }
    }
}

