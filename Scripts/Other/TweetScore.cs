using Assets.Scripts;
using UnityEngine;

namespace MainAssets.Scripts.Other
{
    /// <summary>
    /// スコアを表示するクラス
    /// </summary>
    public class TweetScore : MonoBehaviour
    {
        // ツイートするボタン
                        
        public string text = "今回の僕の記録は";    // ツイートに挿入するテキスト
        public string rankDetail = "総合ランクは";    // ツイートに挿入するテキスト
        public string rank = "Sランク";    // ツイートに挿入するテキスト
        public string correctQDetail = "正答数は";    // ツイートに挿入するテキスト
        public string correctQ = "〇問";    // ツイートに挿入するテキスト
        public string EnemyDeadNumDetail = "倒した敵数は";    // ツイートに挿入するテキスト
        public string EnemyDeadNum = "〇匹";    // ツイートに挿入するテキスト
        public string linkUrl = "";   // ツイートに挿入するURL
        public string hashtags = "算数道";        // ツイートに挿入するハッシュタグ

        // ツイート画面を開く
        public void Tweeting ()
        {
            rank = GameScore.rank.ToString();
            correctQ = GameScore.correctAnswer.ToString();
            EnemyDeadNum = GameScore.enemyKillNum.ToString();
            var url = "https://twitter.com/intent/tweet?"
                      + "text=" + text +"%0a" + rankDetail + rank + "ランク"+"%0a" + correctQDetail + correctQ +"問"+ "%0a" +
                      EnemyDeadNumDetail + EnemyDeadNum+"匹"+"%0a"
                      + "&url=" + linkUrl
                      + "&hashtags=" + hashtags;

#if UNITY_EDITOR
            Application.OpenURL ( url );
#elif UNITY_WEBGL
            // WebGLの場合は、ゲームプレイ画面と同じウィンドウでツイート画面が開かないよう、処理を変える
            Application.ExternalEval(string.Format("window.open('{0}','_blank')", url));
#else
            Application.OpenURL(url);
#endif
        }
    }
}
