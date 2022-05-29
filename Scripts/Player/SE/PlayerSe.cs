using KanKikuchi.AudioManager;
using OTHER_Product_Assets.AudioManager_KanKikuchi.Scripts;
using UnityEngine;

namespace MainAssets.Scripts.Player.SE
{
    /// <summary>
    /// PlayerのSEを統括するクラス
    /// </summary>
    public class PlayerSe : MonoBehaviour
    {
        
        /// <summary>
        /// 0,は一番上のアニメーション
        /// 1,は二番目のアニメーション
        /// 2,は三番目のアニメーション
        /// </summary>
        public void SwordActionSe(int actionNumber)
        {
            //Actionは上から、０．１．２．です
            switch (actionNumber)
            {
                case 0:  SEManager.Instance.Play(SEPath.SORD_ATTACK_SE,.5f);
                    return;
                case 1:  SEManager.Instance.Play(SEPath.SORD_ATTACK_SE2,.5f);
                    return;                             
                case 2:  SEManager.Instance.Play(SEPath.SORD_ATTACK_SE3,.5f);
                    return;                             
                default: SEManager.Instance.Play(SEPath.SORD_ATTACK_SE,.5f);
                    return;
            }
        
        }
        public void PlayRandomSe(SeArrayManager.FOLDER_NAME folderName)
        {
            SeArrayManager.instance.Play_Random_SE(folderName);
        }
        public void PlayRandomEchoSe(SeArrayManager.FOLDER_NAME folderName)
        {
            SeArrayManager.instance.Play_Random_SE(folderName,true);
        }
    }
}