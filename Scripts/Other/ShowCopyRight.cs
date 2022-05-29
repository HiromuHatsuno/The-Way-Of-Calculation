using UnityEngine;

namespace MainAssets.Scripts.Other
{
    //コピーライトを表示するクラス
    public class ShowCopyRight : MonoBehaviour
    {
        public void onClick()
        {
            Application.OpenURL("https://syopuro.hatenablog.com/entry/2021/04/07/%E6%9A%97%E7%AE%97%E3%81%AE%E9%81%93_%E8%91%97%E4%BD%9C%E6%A8%A9%E8%A1%A8%E7%A4%BA");//""の中には開きたいWebページのURLを入力します
        }
    }
}
