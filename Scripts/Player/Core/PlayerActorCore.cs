using MainAssets.Scripts.Actor;
using MainAssets.Scripts.Status.Actor;

namespace MainAssets.Scripts.Player.Core
{
    /// <summary>
    /// Playerの中心要素を統括するクラス
    /// </summary>
    public class PlayerActorCore : ActorCore
    {
        public override void Awake()
        {
            base.Awake();
            base.status = new ActorStatus(maxHp, MINHP, hp, slider, name);
            status.isPlayer = true;
        }
    }
}
