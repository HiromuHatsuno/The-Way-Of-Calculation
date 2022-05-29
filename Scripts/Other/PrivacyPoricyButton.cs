using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プライバシーポリシーページを再生するクラス
/// </summary>
public class PrivacyPoricyButton : MonoBehaviour
{
   public void PrivacyButton()
   {
      Application.OpenURL("https://syopuro.hatenablog.com/entry/2021/04/05/");//""の中には開きたいWebページのURLを入力します
   }
}
