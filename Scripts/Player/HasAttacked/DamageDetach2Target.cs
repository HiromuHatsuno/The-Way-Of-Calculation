using MainAssets.Scripts.ProCamera;
using UnityEngine;

namespace MainAssets.Scripts.Player.HasAttacked
{
    
    /// <summary>
    /// ダメージを受けたら敵をカメラターゲットから外してカメラをプレイヤー中心に持って行く処理
    /// </summary>
    public class DamageDetach2Target : MonoBehaviour
    {
        public GameObject leaveTarget;
        public string detachObjectTag;
        public void Detach2Target()
        {
            ProCamera2DController.RemoveTarget(detachObjectTag,leaveTarget);
        }
        public void Attach2DetachTarget()
        {
        
            ProCamera2DController.SearchNewTarget(leaveTarget,detachObjectTag);
        }
    }
}
