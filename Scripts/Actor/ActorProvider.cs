using System;
using Assets.Assets.Scripts.Actor;
using MainAssets.Scripts.Actor;
using MainAssets.Scripts.Status.Actor;
using UnityEngine;
using UnityEngine.Serialization;

namespace Main_Assets.Scripts.@abstract
{
    
    /// <summary>
    /// Actorの各機能を所持し統括する抽象クラス
    /// </summary>
    public abstract class ActorProvider:MonoBehaviour
    {
        #region 変数一覧
        [NonSerialized]
        public ActorCore core;
        [NonSerialized]
        public ActorAttack attack;
        [NonSerialized]
        public HasAttacked hasAttacked;
        [NonSerialized]
        public ActorAnimation anim;
        [NonSerialized]
        public ActorStatus status;
        #endregion

        
        /// <summary>
        /// 初期化処理
        /// </summary>
        /// <param name="core"></param>
        /// <param name="attack"></param>
        /// <param name="hasAttacked"></param>
        /// <param name="anim"></param>
        public virtual void Start(ActorCore core,ActorAttack attack,HasAttacked hasAttacked,ActorAnimation anim)
        {
            this.core = core;
            this.attack = attack;
            this.hasAttacked = hasAttacked;
            this.anim = anim;
            status = core.status;
        }
      
    }
}