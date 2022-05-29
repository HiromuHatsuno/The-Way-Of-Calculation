using System;
using System.Collections;
using System.Collections.Generic;
 using KanKikuchi.AudioManager;
using MainAssets.Scripts.ProCamera;
using OTHER_Product_Assets.AudioManager_KanKikuchi.Scripts;
using UnityEngine;

namespace Assets.Scripts.StartScript
{
    //タップするとスタートする処理
    public class StartTap : MonoBehaviour
    {
        [SerializeField] private Canvas falseGameObj;
        [SerializeField] private List<Animation> animations;
        public static bool startGame=false;
        private bool firstFrame=true;
        public GameObject player;

        //ゲームが開始時動かない様にするためにTimeScaleを0にする。
        void Start()
        {
            StartCoroutine(StopTime(0, () => { Time.timeScale = 0;}));
            
        }

   
        //時間を止めるメソッド
        IEnumerator StopTime(int delayFrameCount, Action action)
        {
            for (var i = 0; i < delayFrameCount; i++)
            {
                yield return null;
            }
            action();
            yield break;
        }
        
        //時間を止めている間でもアニメーションを動かすようにする処理
        void Update()
        {
            if (Time.timeScale == 0)
            {
                foreach (var animation1 in animations)
                {
                    animation1.wrapMode = WrapMode.Default;
                    animation1[animation1.clip.name].time =
                        Time.realtimeSinceStartup % animation1[animation1.clip.name].length;
                }
            }

        
        }

        //タップするとゲームが開始する事メソッド
        public void TapStart()
        {
            Time.timeScale = 1;
            falseGameObj.enabled = false;
            SeArrayManager.instance.Play_Random_SE(SeArrayManager.FOLDER_NAME.StartGame);
            BGMSwitcher.FadeOutAndFadeIn(BGMPath.PLAYY_GAME,.25f,.025f,0.25f);
            Invoke("CameraSet",.85f);
            foreach (var animation1 in animations)
            {
                animation1.wrapMode = WrapMode.Default;
            }
        }
        //開始時にカメラのターゲットを新しく設定する処理
        public void CameraSet()
        {
            ProCamera2DController.SearchNewTarget(player.gameObject,"Enemy");
        }
        
    }
}
 