using TMPro;
using UnityEngine;

namespace MainAssets.Scripts.ScreenResolution
{
    //ScreenResolutionTextの変更クラス
    public class ScreenResolutionText : MonoBehaviour
    {
        public TextMeshProUGUI nowText;

        public string rightText;

        //現在の画面解像度を基にテキストの値を変更する
        public void Start()
        {
            switch (PlayerPrefs.GetFloat("ScreenResolution"))
            {
                case 854:
                    rightText="×480";
                    break;
                case 1024:
                    rightText="×576";
                    break;
                case 1280:
                    rightText="×720";
                    break;
                case 1366:
                    rightText="×768";
                    break;
                case 1920:
                    rightText="×1080";
                    break;
            }
            nowText.text = PlayerPrefs.GetFloat("ScreenResolution").ToString()+rightText;
        }

        //テキストの値を現在の画面解像度を基に変更する。
        public void ChangeScreenResorusionText()
        {
            
            switch (PlayerPrefs.GetFloat("ScreenResolution"))
            {
                case 854:
                    rightText="×480";
                    break;
                case 1024:
                    rightText="×576";
                    break;
                case 1280:
                    rightText="×720";
                    break;
                case 1366:
                    rightText="×768";
                    break;
                case 1920:
                    rightText="×1080";
                    break;
            }
            nowText.text = PlayerPrefs.GetFloat("ScreenResolution").ToString()+rightText;
        }
    }
}