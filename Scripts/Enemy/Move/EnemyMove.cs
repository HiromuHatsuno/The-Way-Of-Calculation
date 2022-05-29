using Assets.Scripts.Move;
using Main_Assets.Scripts.@abstract;
using MainAssets.Scripts.InterFace;
using MainAssets.Scripts.Status.Actor;
using UnityEngine;

namespace MainAssets.Scripts.Enemy.Move
{
    /// <summary>
    /// 敵の移動を管理するクラス
    /// </summary>
    public class EnemyMove:MoveObject
    {
        #region 変数
        //Parameter代入用のSpeed
        public float limitSpeed;

        private ActorProvider provider;
        private IMoveAdditionalFeature feature;
        private bool isInitialize=true;
        #endregion

        //初期化処理
        protected override void Start()
        {
            TryGetComponent<ActorProvider>(out provider);
            base.Start();
            feature=this.gameObject.GetComponent<IMoveAdditionalFeature>();

        }
        private void FixedUpdate()            
        {
            if (CanMove())
            {
                if (isInitialize)
                {
                    provider.status.nowSpeed = moveSpeed;
                    provider.status.limitSpeed = limitSpeed;
                    isInitialize = false;
                }
                Move();
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {    
           feature.MoveAdditionalFeature();
        }

        private bool CanMove()
        {
            if (provider.status.actorState == ActorStatus.ActorState.Attacked) return false;
            if (provider.status.actorState == ActorStatus.ActorState.Dead) return false;
            if (provider.status.actorState == ActorStatus.ActorState.Attack) return false;
            return true;
        }

    }
}
