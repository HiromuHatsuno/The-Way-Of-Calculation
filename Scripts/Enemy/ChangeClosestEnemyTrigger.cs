using Assets.Assets.Scripts.Enemy.Provider;
using MainAssets.Scripts.ProCamera;
using UnityEngine;

namespace MainAssets.Scripts.Enemy
{
    /// <summary>
    /// プレイヤーと一番近い敵を変更する処理クラス
    /// </summary>
    public class ChangeClosestEnemyTrigger : MonoBehaviour
    {  

        //別オブジェクトにアタッチしてるので必ず手動で代入すること
        [SerializeField]
        private EnemyProvider provider;
        
        /// <summary>
        /// 一番近いオブジェクトと入れ替わった時の処理
        /// </summary>
        /// <param name="other"></param>
        public void OnTriggerExit2D(Collider2D other)
        {
            //タグが一致した場合のみ処理を継続。
            if (!other.gameObject.CompareTag(gameObject.tag)) return; 
            //現在のオブジェクトが一番プレイヤーに近いオブジェクトでない場合処理を中断
            if (provider.core.isMostClosestTarget != true) return;
            //現在の一番近い敵フラグをオフにする
            provider.core.isMostClosestTarget = false; 
            //通り抜けた敵を現在の一番近い敵とする。
            other.GetComponent<EnemyProvider>().core.isMostClosestTarget = true;
            //プレイヤーと誰が一番近いか再計算する。
            ProCamera2DController.SearchNewTarget(provider.attack.targetGameObject, other.gameObject.tag);
            
        }
    }
}