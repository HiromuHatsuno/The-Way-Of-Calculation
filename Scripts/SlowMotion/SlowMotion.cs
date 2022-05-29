using UnityEngine;

namespace MainAssets.Scripts.SlowMotion
{
    /// <summary>
    /// スローモーションする処理クラス
    /// </summary>
    public class SlowMotion : MonoBehaviour
    {
        public float slowMotionTime = 0.3f;
        private const float NOMALMOTIONTIME = 1;

        public void DoSlowMotion()
        {
            Time.timeScale = slowMotionTime;
        }

        public void DoNormalMotionTime()
        {
            Time.timeScale = NOMALMOTIONTIME;
        }
    }
}