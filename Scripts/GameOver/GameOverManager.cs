using System;
using System.Collections;
using KanKikuchi.AudioManager;
using UnityEngine;

namespace MainAssets.Scripts.GameOver
{
    /// <summary>
    /// ゲームオーバー時の処理を統括するクラス
    /// </summary>
    public class GameOverManager : MonoBehaviour
    {
        public static bool isGameOver;
        public Fade fade;
        public Canvas gameOverUI;

        public void Start()
        {
            isGameOver = false;
        
        }

        /// <summary>
        /// ゲームオーバー時の処理
        /// </summary>
        public void GameOver()
        {
            var enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (var enemy in enemies)
            {
                Destroy(enemy);
            }
            //時間を止める
            StartCoroutine(StopTime(2.5f, () => Time.timeScale = 0));
            //GameOverUIを表示する
            StartCoroutine(StopTime(1.6f, () =>gameOverUI.enabled = true));
            //BGMをゲームオーバー時のものに変更する
            BGMSwitcher.FadeOutAndFadeIn(BGMPath.GAME_OVER_BGM, 1, 1, .85f);
            //FadeIn後FadeOutする
            StartCoroutine(StopTime(.5f, () => fade.NormalFadeIn(1f,()=>fade.NormalFadeOut(1f))));
            isGameOver = true;

        }
        
        /// <summary>
        /// ゲームオーバーなので時間を止める処理
        /// </summary>
        /// <param name="time"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        private  IEnumerator StopTime(float time,Action action)
        {       
            float currentTime = 0;
            float endTime = time;
		
            var endFrame = new WaitForEndOfFrame ();

            while (currentTime <= endTime)
            {
                currentTime += Time.unscaledDeltaTime;
                yield return endFrame;
            }

            if (action != null) {
                action ();
            }
       

        }
    }
}
