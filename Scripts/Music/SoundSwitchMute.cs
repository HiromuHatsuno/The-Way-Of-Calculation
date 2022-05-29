using KanKikuchi.AudioManager;
using UnityEngine;

namespace MainAssets.Scripts.Music
{
   /// <summary>
   /// BGMやSEをミュートにしたり解除したりするクラス
   /// </summary>
   public class SoundSwitchMute : MonoBehaviour
   {
      private float saveBGMvol;
      private float saveSEvol;
      public void BGMMuteOn()
      {      
         SEManager.Instance.Play(SEPath.SE_DICIDE);
         BGMManager.Instance.ChangeBaseVolume(0);
      }

      public void SEMuteOn()
      {
         SEManager.Instance.ChangeBaseVolume(0);
      }
      public void BGMMuteOff()
      {
         SEManager.Instance.Play(SEPath.SE_DICIDE);
         BGMManager.Instance.ChangeBaseVolume(100);
      }

      public void SEMuteOff()
      {
         SEManager.Instance.Play(SEPath.SE_DICIDE);
         SEManager.Instance.ChangeBaseVolume(100);
      }
   }
}
