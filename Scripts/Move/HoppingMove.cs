using Assets.Assets.Scripts.Enemy.Provider;
using Main_Assets.Scripts.Enemy.Enemy;
using MainAssets.Scripts.InterFace;
using MainAssets.Scripts.Status.Actor;
using UnityEngine;

namespace Main_Assets.Scripts.Move
{
    //ホッピングして動く物用の移動クラス
    public class HoppingMove:MonoBehaviour,IMoveAdditionalFeature
    {
        [SerializeField]
        private EnemyProvider provider;

        private void Start()
        {
            TryGetComponent<EnemyProvider>(out provider);
        }
        

        public void MoveAdditionalFeature()
        {
            //ステートで変更する
            switch (provider.status.actorState)
            {
                case ActorStatus.ActorState.Alive:
                    if (provider.attack.canAttack)
                    {
                        provider.status.ChangeState(ActorStatus.ActorState.Attack);
                        provider.attack.canAttack = false;
                        provider.attack.Attack();
                    }
                    break;

                case ActorStatus.ActorState.Attacked:
                case ActorStatus.ActorState.Dead:
                    provider.fx.ShockWaveParticle();
                    provider.se.PlayShockTileSe();
                    break;

                default:
                    break;
            }
        }
   
    }
}