using MainAssets.Scripts.Actor;
using MainAssets.Scripts.Player.Provider;
using MainAssets.Scripts.ProCamera;
using UnityEngine;

namespace MainAssets.Scripts.Player.Attack
{
    [RequireComponent(typeof(Transform))]
    //Playerの攻撃を統括するクラス
    public class PlayerActorAttack : ActorAttack
    {
        [SerializeField] private float shortRangeAttack;
        private PlayerActorProvider playerActorProvider;
        
        private void Awake()
        { 
            TryGetComponent<PlayerActorProvider>(out playerActorProvider);
        }

        public void Update()
        {
            var position = transform.position;
        }

        public override void Attack()
        {
            playerActorProvider.hasAttacked.On2Invicible();
            base.Attack(shortRangeAttack);
            ProCamera2DController.SearchNewTarget(this.gameObject,GameObject.FindGameObjectWithTag(targetTag));
        }
        
    }
}