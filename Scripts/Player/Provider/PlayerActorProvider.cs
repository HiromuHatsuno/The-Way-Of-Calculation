using Main_Assets.Scripts.@abstract;
using MainAssets.Scripts.Player.Animation;
using MainAssets.Scripts.Player.Attack;
using MainAssets.Scripts.Player.Core;
using MainAssets.Scripts.Player.Data;
using MainAssets.Scripts.Player.HasAttacked;
using MainAssets.Scripts.Player.SE;

namespace MainAssets.Scripts.Player.Provider
{

    /// <summary>
    /// Playerの様々な機能を統括するクラス
    /// </summary>
    public  class PlayerActorProvider :ActorProvider
    {
        #region 変数一覧
        public new PlayerActorCore core;
        public new PlayerActorAttack attack; 
        public new PlayerHasAttacked hasAttacked;
        public new PlayerActorAnimation anim;
        public PlayerData data;  
        public PlayerSe se;  
        #endregion

        

        public void Start()
        {
           
            #region GetComponent処理
            TryGetComponent<PlayerActorCore>(out core);
            TryGetComponent<PlayerActorAttack>(out attack);
            TryGetComponent<PlayerHasAttacked>(out hasAttacked);
            TryGetComponent<PlayerActorAnimation>(out anim);
            TryGetComponent<PlayerData>(out data);
            base.Start(core,attack,hasAttacked,anim);
            #endregion
        }
    }
}
