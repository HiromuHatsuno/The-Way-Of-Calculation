using JetBrains.Annotations;
using KanKikuchi.AudioManager;
using TMPro;
using UnityEngine;

//時間の2桁目を変更するプログラム
namespace MainAssets.Scripts.noticeTimer
{
   public class Count10Digit : MonoBehaviour
   {
      [CanBeNull] public Count1Digit count1Digit;
      public TextMeshProUGUI textMesh;
      public int nowCount;
      public int maxNum;
      public int minNum;
      public int changeOneDigitNum;
      //10桁目が２の時は1桁目の上限を4にしないと行けない為必要になるbool
      public bool isChangeOneDigit;
      public void Start()
      {
         nowCount = PlayerPrefs.GetInt("nowCount"+this.gameObject.name);

         if (nowCount>=changeOneDigitNum) isChangeOneDigit = true;
      
         if (nowCount<=changeOneDigitNum) isChangeOneDigit = false;
      
         textMesh.text = nowCount.ToString();
      }

      //UIで上キーを押したときの処理
      public void PushUpKey()
      {
         //範囲外を設定しようとしたとき
         if (nowCount>=maxNum)
         {
            //失敗SE流す
            SEManager.Instance.Play(SEPath.CAN_NOT_DELEATE,.05f);
            return;
         }

         if (nowCount>=changeOneDigitNum)
         {
            isChangeOneDigit = true;
            count1Digit.nowCount = count1Digit.when10DigitMaxNum;
            count1Digit.textMesh.text = count1Digit.nowCount.ToString();
         }

         nowCount += 1;
         PlayerPrefs.SetInt("nowCount"+this.gameObject.name,nowCount);
         textMesh.text = nowCount.ToString();
         SEManager.Instance.Play(SEPath.DECISION42,.1f);

         //UIで下キーを押したときの処理
      }  
      public void PushDownKey()
      {
         //範囲外を設定しようとしたとき
         if (nowCount<=minNum)
         {
            //失敗SE流す
       
            SEManager.Instance.Play(SEPath.CAN_NOT_DELEATE,.05f);
            return;
         }
         if (nowCount-1<=changeOneDigitNum)
         {
            isChangeOneDigit = false;
         }
         //成功処理入れる
         nowCount -= 1;
         PlayerPrefs.SetInt("nowCount"+this.gameObject.name,nowCount);
         textMesh.text = nowCount.ToString();
         SEManager.Instance.Play(SEPath.DECISION42,.1f);

      }
   }
}
