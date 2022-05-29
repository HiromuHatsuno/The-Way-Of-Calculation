using KanKikuchi.AudioManager;
using MainAssets.Scripts.Music;
using UnityEngine;

namespace Main_Assets.Scripts.Enemy.Enemy
{
    /// <summary>
    /// EnemyのSEを統括するクラス
    /// </summary>
    public class EnemySe : MonoBehaviour
    {
        public void PlayFotSe()
        {
            SEManager.Instance.Play(SEPath.PIPO_MOVE_SOUND);
        }

        public void PlayShockTileSe()
        {
            SEManager.Instance.Play(SEPath.TAILE_ATTACKED,.15f);
        }
       public void PlayEnemyDamageSe()
       {
            EchoSeManager.Instance.Play(SEPath.PIPO_DAMAGE,.1f);
            
       }
       public void PlayPipoAttackSE()
       {
           EchoSeManager.Instance.Play(SEPath.PIPO_ATTACK,.5f);
            
       }
    }
}