using System;
using System.Security.Cryptography.X509Certificates;
using KanKikuchi.AudioManager;
using OTHER_Product_Assets.AudioManager_KanKikuchi.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    /// <summary>
    /// ゲームのスコアを統括するクラス
    /// </summary>
    public class GameScore : MonoBehaviour
    {
        public static float time;
        public static int correctAnswer;
        public static int enemyKillNum;
        public static char rank;
        public static int level;
        private static float seconds;

        public Canvas thisCanvas;
        public Canvas thisCanvas2;
        public TextMeshProUGUI correctText;
        public TextMeshProUGUI enemyKillText;
        public TextMeshProUGUI rankText;
        public TextMeshProUGUI levelText;
        public ShowAdMobBanner showAdMobBanner;
        public DayOfScoreManager dayOfScoreManager;
        public void Start()
        {
            Init();
        }

        public void ShowResult()
        {
            
            var now = Time.timeScale;
            showAdMobBanner.ShowInterstitial();
            Time.timeScale = now;
            DecisionRank();
            thisCanvas.enabled = true;
            correctText.text = correctAnswer.ToString();
            enemyKillText.text = enemyKillNum.ToString();
            rankText.text = rank.ToString();
            levelText.text = level.ToString();
            dayOfScoreManager.SetCorrectQ(correctAnswer);
            dayOfScoreManager.SetKillEnemy(enemyKillNum);
            dayOfScoreManager.setNum();
            if (dayOfScoreManager.GetLastLevel()<=level)
            {
                dayOfScoreManager.SetLastLevel(level);
            }
        }

        public void Start2Menu()
        {
            Init();
            thisCanvas.enabled = false;
            thisCanvas2.enabled = false;
            StartManager.isContinue = false;
            StartManager.isRetry = false;
            // 現在のScene名を取得する
            Scene loadScene = SceneManager.GetActiveScene();
            // Sceneの読み直し
            SceneManager.LoadScene(loadScene.name);
        }
        public void Start2Start()
        {
            Init();
            
            thisCanvas.enabled = false;
            thisCanvas2.enabled = false;
            StartManager.isContinue = false;
            StartManager.isRetry=true;
            // 現在のScene名を取得する
            Scene loadScene = SceneManager.GetActiveScene();
            // Sceneの読み直し
            SceneManager.LoadScene(loadScene.name);
        }

        public void DecisionRank()
        { if (level>=8)
            {
                rank = 'S';
                SeArrayManager.instance.Play_Random_SE(SeArrayManager.FOLDER_NAME.SRank);
                dayOfScoreManager.SetRank("S");
                return;
            }
            if (level>=6)
            {
                rank = 'A';
                SeArrayManager.instance.Play_Random_SE(SeArrayManager.FOLDER_NAME.ARank);
                if (dayOfScoreManager.GetLastLevel() <= level)
                {
                    dayOfScoreManager.SetRank("A");
                }
                return;
            }
            if (level>=5)
            {
                rank = 'B';
                SeArrayManager.instance.Play_Random_SE(SeArrayManager.FOLDER_NAME.BRank);
            
                if (dayOfScoreManager.GetLastLevel() <= level)
                {
                    dayOfScoreManager.SetRank("B");
                }
                return;
            }  
            
            if (level>=4)
            {
                rank = 'C';
                SeArrayManager.instance.Play_Random_SE(SeArrayManager.FOLDER_NAME.CRank);               
                if (dayOfScoreManager.GetLastLevel() <= level)
                {
                    dayOfScoreManager.SetRank("C");
                }
                return;

            }


            if (level>=0)
            {
                rank = 'D';
                SeArrayManager.instance.Play_Random_SE(SeArrayManager.FOLDER_NAME.DRank);
                return;
            }

          
        }

        public void Init()
        {
            enemyKillNum = 0;
            correctAnswer = 0;
            rank = 'D';
            level = 0;
        }
        void Update () {
            time += UnityEngine.Time.deltaTime;
        }
    }
}