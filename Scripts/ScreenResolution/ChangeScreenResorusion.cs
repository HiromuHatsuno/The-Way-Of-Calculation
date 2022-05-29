using KanKikuchi.AudioManager;
using UnityEngine;

namespace MainAssets.Scripts.ScreenResolution
{
    /// <summary>
    ///画面の解像度変更クラス
    /// </summary>
    public class ChangeScreenResorusion : MonoBehaviour
    {
        public void Awake()
        {
            Application.targetFrameRate = 60; //FPSを60に設定 
            //初期化はキーを入れる。
            if(!PlayerPrefs.HasKey("ScreenResolution")) {
                PlayerPrefs.SetFloat("ScreenResolution",1280);
            }
            float screenRate = (float)PlayerPrefs.GetFloat("ScreenResolution")/ Screen.height;
            if( screenRate > 1 ) screenRate = 1;
            int width = (int)(Screen.width * screenRate);
            int height = (int)(Screen.height * screenRate);
            Screen.SetResolution( width , height, true, 15);
        }

        //左ボタンを押したときに画面解像度を変化させるメソッド
        public void Left2ChangeScreenResorusionButton()
        {
            switch (PlayerPrefs.GetFloat("ScreenResolution"))
            {
                case 854:
                    SEManager.Instance.Play(SEPath.CAN_NOT_DELEATE);
                    break;
                case 1024:
                    SEManager.Instance.Play(SEPath.SE_MAOUDAMASHII_SYSTEM45);
                    ChangeResolusion(854);
                    break;
                case 1280:
                    SEManager.Instance.Play(SEPath.SE_MAOUDAMASHII_SYSTEM45);
                    ChangeResolusion(1024);
                    break;
                case 1366:
                    SEManager.Instance.Play(SEPath.SE_MAOUDAMASHII_SYSTEM45);
                    ChangeResolusion(1280);
                    break;
                case 1920:
                    SEManager.Instance.Play(SEPath.SE_MAOUDAMASHII_SYSTEM45);
                    ChangeResolusion(1366);
                    break;
            }
        }
        //右ボタンを押したときに画面解像度を変化させるメソッド
        public void Right2ChangeScreenResorusionButton()
        {
            switch (PlayerPrefs.GetFloat("ScreenResolution"))
            {
                case 854:
                    ChangeResolusion(1024);
                    SEManager.Instance.Play(SEPath.SE_MAOUDAMASHII_SYSTEM45);
                    break;
                case 1024:
                    ChangeResolusion(1280);
                    SEManager.Instance.Play(SEPath.SE_MAOUDAMASHII_SYSTEM45);
                    break;
                case 1280:
                    ChangeResolusion(1366);
                    SEManager.Instance.Play(SEPath.SE_MAOUDAMASHII_SYSTEM45);
                    break;
                case 1366:
                    ChangeResolusion(1920);
                    SEManager.Instance.Play(SEPath.SE_MAOUDAMASHII_SYSTEM45);
                    break;
                case 1920:
                    SEManager.Instance.Play(SEPath.CAN_NOT_DELEATE);
                    break;
            }
        }

        //画面解像度変更メソッド
        public void ChangeResolusion(float resolution)
        {
            PlayerPrefs.SetFloat("ScreenResolution",resolution);
            float screenRate = (float)PlayerPrefs.GetFloat("ScreenResolution")/ Screen.height;
            if( screenRate > 1 ) screenRate = 1;
            int width = (int)(Screen.width * screenRate);
            int height = (int)(Screen.height * screenRate);
            Screen.SetResolution( width , height, true, 15);
        }
    }
}
