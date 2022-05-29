using System;
using Main_Assets.Scripts.@abstract;
using Main_Assets.Scripts.Enemy.Enemy;
using MainAssets.Scripts.Enemy.Animation;
using MainAssets.Scripts.Enemy.Attack;
using MainAssets.Scripts.Enemy.Core;
using MainAssets.Scripts.Enemy.FX;
using MainAssets.Scripts.Enemy.HasAttacked;
using MainAssets.Scripts.Enemy.Move;

namespace Assets.Assets.Scripts.Enemy.Provider
{
    /// <summary>
    /// Enemyの機能を統括するクラス
    /// </summary>
    public class EnemyProvider :ActorProvider
    {
        #region 変数一覧
        [NonSerialized]
        public new EnemyCore core;
        [NonSerialized]
        public new EnemyAttack attack; 
        [NonSerialized]
        public new EnemyHasAttacked hasAttacked;
        [NonSerialized]
        public new EnemyAnimation anim;
        [NonSerialized]
        public EnemyFx fx;
        [NonSerialized]
        public EnemySe se;

        public int gold;

        [NonSerialized] 
        public EnemyMove move;
        #endregion
        public virtual void Start()
        {         
            #region GetComponent処理
            TryGetComponent<EnemyCore>(out core);
            TryGetComponent<EnemyAttack>(out attack);
            TryGetComponent<EnemyHasAttacked>(out hasAttacked);
            TryGetComponent<EnemyAnimation>(out anim);
            TryGetComponent<EnemyFx>(out fx);
            TryGetComponent<EnemySe>(out se);
            TryGetComponent<EnemyMove>(out move);
            #endregion
            status = core.status;
            base.Start(core,attack,hasAttacked,anim);
            status.gold = gold;

        }
    }
}