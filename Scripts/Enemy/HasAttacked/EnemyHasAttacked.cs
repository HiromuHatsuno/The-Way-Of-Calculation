using Assets.Assets.Scripts.Enemy.Provider;
using Assets.Scripts;
using Assets.Scripts.Scritable;
using MainAssets.Scripts.GameOver;
using MainAssets.Scripts.InterFace;
using MainAssets.Scripts.PopUpStory;
using MainAssets.Scripts.ProCamera;
using MainAssets.Scripts.Status.Actor;
using MainAssets.Scripts.Weapon;
using UnityEngine;

namespace MainAssets.Scripts.Enemy.HasAttacked
{
    /// <summary>
    /// Enemyが攻撃を受けた時の処理をまとめたファイル
    /// </summary>
    public class EnemyHasAttacked :Assets.Assets.Scripts.Actor.HasAttacked,IAttackedService
    {
        #region 変数
        private new EnemyProvider actorProvider; 
        [SerializeField]
        private float destroyTime=1f; //敵が消滅する時間
        
        //ポップアップストーリーマネージャー
        [SerializeField]
        PopUpStoryManager popUpStoryManager;
        //ポップアップストーリーのジャンル格納変数
        [SerializeField]
        private PopUpStoryGenre popUpStoryGenre;
        
        //攻撃を受けた際に実装したい機能に付けるインターフェイスを格納する変数
        private IHasAttackedAdditionFeature feature;

        //Enemyのx軸の位置保存用
        private float xPosition=0;
        //現在値xと前フレームのxの差
        private int compareX=0;
        #endregion
        
        /// <summary>
        /// このクラスの初期化を行う。
        /// </summary>
        public override void Start()
        {
            base.Start();
            TryGetComponent<EnemyProvider>(out actorProvider);
            feature= this.gameObject.GetComponent<IHasAttackedAdditionFeature>();
            popUpStoryManager = GameObject.FindGameObjectWithTag("PopUp").GetComponent<PopUpStoryManager>();
        }

        //ステートを攻撃されたから生存に変更するクラス。
        public void FixedUpdate()
        {
            //ステートが攻撃された状態でなければ、メソッドを閉じる。
            if (!IsAttacked()) return;
            //敵の速度が0意外ならば、メソッドを閉じる。
            if(!IsStopped())return;
            //ステートがattacked∧速度=0の時実行される。
            	
            //敵の吹っ飛びFXを消去する
            Destroy(gameObject.transform.Find("SmokeTrail(Clone)").gameObject);
            //敵の角度を初期値に戻す。
            actorProvider.transform.rotation=new Quaternion(0,0,0,0);
            //StateをAliveに戻す。
            actorProvider.status.ChangeState(ActorStatus.ActorState.Alive);
        }

        //-----------------------------------------------------------------------------------------------------------//
        //------------------------------------攻撃を受けた時の一連の処理-------------------------------------------------//
        //----------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// ダメージを受けた時の処理
        /// </summary>
        /// <param name="weaponBehavior">攻撃した武器</param>
        public override void ReceiveDamage(WeaponBehavior weaponBehavior)
        {
            //敵が攻撃を受けた時のFXを再生する。
            actorProvider.fx.DamageParticle();
            
            //ステートをattackedに変更する。
            actorProvider.status.ChangeState(ActorStatus.ActorState.Attacked); 
            
            //引数をセットする。
            haveAttackedWeapon = weaponBehavior;
            
            //ダメージ処理
            base.ReceiveDamage(weaponBehavior);
            
            //後処理
            RecieveDamage_Postprocess();

            //ノックバック処理
            feature?.KnockBack();
        }
        //-----------------------------------------------------------------------------------------------------------//
        //--------------------------攻撃を受けて死んだとき生きてた時に実行する別々の処理--------------------------------------//
        //----------------------------------------------------------------------------------------------------------//
        
        /// <summary>
        /// 攻撃を受けて生きていた時に個別で実行する処理
        /// </summary>
        protected override void ReceiveDamagePostProcessAlive()
        {
            
        }
        /// <summary>
        /// 攻撃を受けて死んだときの処理
        /// </summary>
        protected override void ReceiveDamagePostProcessDead()
        {
            CoinManager.Instance.AddCoin(actorProvider.core.status.gold);
            var obj = this.gameObject;
            Destroy(obj, destroyTime);
        }


        //-----------------------------------------------------------------------------------------------------------//
        //------------------------------------敵が消える瞬間に実行される処理----------------------------------------------//
        //----------------------------------------------------------------------------------------------------------//
         /// <summary>
         /// ///消える直前に、次のターゲット（一番近い敵)を索敵する。
         /// </summary>
         public virtual void OnDestroy()
         {
             if (Random.Range(0, 100) > 80)
             {
                 popUpStoryManager.PlayPopUpStory(popUpStoryGenre);
             }
             if (!GameOverManager.isGameOver)
             {
                 GameScore.enemyKillNum += 1;
             }

             ProCamera2DController.SearchNewTarget(GameObject.FindGameObjectWithTag("Player"),this.gameObject);
         }
        
        /// <summary>
        /// 現在のステートがAttackedか調べ、
        /// AttackedならTrueを表示。
        /// </summary>
        private bool IsAttacked()
        {
            //ステートが攻撃された状態でなければ、メソッドを閉じる。
            return actorProvider.status.actorState == ActorStatus.ActorState.Attacked;
        }

        private bool IsStopped()
        {
            return (int)actorProvider.move.rigidBody.velocity.x == 0;
            
        }
    }
}
    




