using KanKikuchi.AudioManager;
using MainAssets.Scripts.Player.Provider;
using MainAssets.Scripts.PostEffect;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MainAssets.Scripts.retry
{
    /// <summary>
    /// ゲームをリトライする処理を統括するクラス
    /// </summary>
    public class RetryGame : MonoBehaviour
    {
        public PlayerActorProvider actorProvider;
        public Canvas SetFalseCanvas;
        public Canvas SetFalseCanvasStart;
        public Canvas SetActiveCanvas;
        public GameObject continueImage;
        public RectTransform retryRect;
        public RectTransform rectTransform;
        private float nowTime;
        public ChangeVigette changeVigette;

        public ShowAdMobBanner showAdMobBanner;
        //コンテニュー処理
        public void Continue()
        {
            nowTime = Time.timeScale;
            showAdMobBanner.ShowReawrd();

        }

        //コンテニュー成功時の処理
        public void ContinueSucceeded()
        {
            continueImage.SetActive(false);
            retryRect.transform.position = rectTransform.position;
            Time.timeScale = nowTime;
            SetFalseCanvas.enabled = false;
            SetActiveCanvas.enabled = true;
            var enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (var enemy in enemies)
            {
                Destroy(enemy);
            }

            actorProvider.status.nowHp = actorProvider.status.maxHP;
            actorProvider.status.slider.value = actorProvider.status.nowHp;
            BGMManager.Instance.Play(BGMPath.START_BGM,.25f);
            actorProvider.anim.PlayReviveAnimation();
            changeVigette.ReturnToDeadVigette();
        }

        //リトライ処理メソッド
        public void Retry()
        {
            StartManager.isRetry = true;
            SetFalseCanvasStart.enabled = false;
            // 現在のScene名を取得する
            var loadScene = SceneManager.GetActiveScene();
            // Sceneの読み直し
            SceneManager.LoadScene(loadScene.name);
            BGMManager.Instance.Play(BGMPath.START_BGM,.25f);
        }

    }
}