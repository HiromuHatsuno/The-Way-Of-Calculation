using KanKikuchi.AudioManager;
using UnityEngine;

namespace MainAssets.Scripts.Music
{
    /// <summary>
    /// BGMを再生するクラス
    /// </summary>
    public class SoundBGM : MonoBehaviour
    {
        public void Start()
        {
            GameStartBGM();
        }

        public void GameStartBGM()
        {
            BGMSwitcher.FadeOutAndFadeIn(BGMPath.START_BGM,1,1,1f); ;
        }

        public void PlayMainGame()
        {
            BGMSwitcher.FadeOutAndFadeIn(BGMPath.PLAYY_GAME,1,1,.85f); ;


        }

        public void GameOver()
        {
            BGMSwitcher.FadeOutAndFadeIn(BGMPath.GAME_OVER_BGM,1,1,.85f); ;


        }  
        public void Result()
        {
            BGMSwitcher.FadeOutAndFadeIn(BGMPath.RESULT_BGM,1,1,.85f); ;


        }
    }
}
