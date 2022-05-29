using KanKikuchi.AudioManager;
using TMPro;
using UnityEngine;

namespace MainAssets.Scripts.noticeTimer
{

    //時間の1桁目を変更するプログラム
    public class Count1Digit : MonoBehaviour
    {
        public Count10Digit count10Digit;
        public TextMeshProUGUI textMesh;
        public int nowCount;
        public int maxNum;
        public int when10DigitMaxNum;

        public int minNum;

        public void Start()
        {
            nowCount = PlayerPrefs.GetInt("nowCount"+this.gameObject.name);
            textMesh.text = nowCount.ToString();
        }

        public void PushUpKey()
        {
            int nowMaxNum;
            nowMaxNum = maxNum;
            //二桁目が2なので最大値を4に変更する
            if (count10Digit.isChangeOneDigit==true)
            {
                nowMaxNum = when10DigitMaxNum;
            }
            if (nowCount>=nowMaxNum)
            {
                //失敗SE流す
                SEManager.Instance.Play(SEPath.CAN_NOT_DELEATE,.05f);
                return;
            }
            SEManager.Instance.Play(SEPath.DECISION42,.1f);

            nowCount += 1;
            PlayerPrefs.SetInt("nowCount"+gameObject.name,nowCount);
            textMesh.text = nowCount.ToString();
            //成功処理入れる
        }  
        public void PushDownKey()
        {
            if (nowCount<=minNum)
            {
                //失敗SE流す
                SEManager.Instance.Play(SEPath.CAN_NOT_DELEATE,.05f);
                return;
            }
            SEManager.Instance.Play(SEPath.DECISION42,.1f);
            //成功処理入れる
            nowCount -= 1;
            PlayerPrefs.SetInt("nowCount"+gameObject.name,nowCount);
            textMesh.text = nowCount.ToString();
        }
    }
}