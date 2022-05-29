using System;
using Main_Assets.Scripts.@abstract;
using Main_Assets.Scripts.ExtendMethod;
using MainAssets.Scripts.ExtendMethod;
using MainAssets.Scripts.InterFace;
using MainAssets.Scripts.KnockBack;
using MainAssets.Scripts.Status.Actor;
using UnityEngine;

namespace MainAssets.Scripts.Enemy.HasAttacked
{
    
    //攻撃を受けた際ノックバックする処理
    public class HasAttackedKnockBack : MonoBehaviour,IHasAttackedAdditionFeature
    {
        #region 変数
        //ActorProvider格納変数
        [SerializeField]
        private ActorProvider actorProvider;

        //KnockBackObjectStatus格納変数
        [SerializeField] 
        private KnockBackObjectStatus knockBackObjectStatus;

        //IKnockBackWeaponインターフェイス格納変数
        private IKnockBackWeapon knockBackWeaponStatus;

        private Rigidbody2D rigidBody2D;
        #endregion

        /// <summary>
        /// このクラスの初期化を行う。
        /// </summary>
        public void Start()
        {
            actorProvider = GetComponent<ActorProvider>();
            TryGetComponent<ActorProvider>(out actorProvider);
            TryGetComponent<Rigidbody2D>(out rigidBody2D);

        }

        //-----------------------------------------------------------------------------------------------------------//
        //------------------------------------KnockBack処理----------------------------------------------------------//
        //----------------------------------------------------------------------------------------------------------//
        public void KnockBack()
        {
            rigidBody2D.ToDynamic();
            knockBackWeaponStatus= actorProvider.hasAttacked.haveAttackedWeapon.ConvertKnockBackWeapon();
            //生存時か死亡時で吹っ飛ぶ時の処理が変わる。
            switch (actorProvider.status.actorState)
            {
                //KnockBackの計算の為の前処理
                //KnockBack対象生存時の処理
                case  ActorStatus.ActorState.Alive:
                    WhenAliveKnockBackRatio();
                    WhenAliveChangeSharedMaterial(knockBackObjectStatus);
                    break;
                //KnockBack対象死亡時の処理
                case ActorStatus.ActorState.Dead:
                    WhenDeadKnockBackRatio(); 
                    WhenDeadChangeSharedMaterial(knockBackObjectStatus);
                    break;
            }
            //実際に吹っ飛ばす処理(AddForce)
            KnockBackFunction.DoKnockBack(knockBackWeaponStatus.GetKnockBackStatus(), knockBackObjectStatus);
        }


        //-----------------------------------------------------------------------------------------------------------//
        //------------------------------------生存時の処理-------------------------------------------------------------//
        //----------------------------------------------------------------------------------------------------------//
        
        private void WhenAliveKnockBackRatio()
        {
            KnockBackFunction.ChangeRatioPower(knockBackWeaponStatus.GetKnockBackStatus(),
                knockBackObjectStatus.aliveKnockBackRatio);
        }
        
        private void WhenAliveChangeSharedMaterial(KnockBackObjectStatus status)
        {
            status.boxCollider2D.sharedMaterial = knockBackObjectStatus.alivePhysicsMaterial;
        }

        //-----------------------------------------------------------------------------------------------------------//
        //------------------------------------死亡時の処理-------------------------------------------------------------//
        //----------------------------------------------------------------------------------------------------------//
        private void WhenDeadKnockBackRatio()
        {
            KnockBackFunction.ChangeRatioPower(knockBackWeaponStatus.GetKnockBackStatus(), 
                knockBackObjectStatus.deadKnockBackRatio);

        }
        
        private void WhenDeadChangeSharedMaterial(KnockBackObjectStatus status)
        {
            status.boxCollider2D.sharedMaterial =knockBackObjectStatus.deadPhysicsMaterial;

        }
    }
}