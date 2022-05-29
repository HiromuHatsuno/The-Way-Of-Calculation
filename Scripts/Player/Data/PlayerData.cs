using System.Collections;
using Assets.Scripts;
using Assets.Scripts.Scritable;
using KanKikuchi.AudioManager;
using MainAssets.Scripts.PopUpStory;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace MainAssets.Scripts.Player.Data
{
    /// <summary>
    /// Playerのデータを管理します。
    /// </summary>
    public class PlayerData : MonoBehaviour
    {
        public Levelpoint levelpoint;

        /*PlayerLevel：プレイヤーレベルによって出現される桁数が変化します。
         1:最大1桁が出力される。
         2:最大2桁が出力される。
         3:最大3桁が出力される。×や÷に関しては、2桁が最大
         4:最大4桁出力される。　　　　　　　　　　　　　　　　*/

        [SerializeField]
        private int watchLevel;
        private int nowLevel;

        public TextMeshProUGUI tmpro;
 
        [SerializeField]
        private UnityEngine.Animation levelUpAnim;

        [SerializeField]
        private PopUpStoryManager popUpStoryManager;
        [SerializeField] private PopUpStoryGenre popUpStoryGenre;

        public int level
        {
            get
            {
                nowLevel = selectNowLevel();
                if (watchLevel == nowLevel) return watchLevel;
                watchLevel = nowLevel;
                GameScore.level = watchLevel;
                PlayerLevelUp();
                tmpro.text = watchLevel.ToString();
                return nowLevel;
            }
        }

        public void ContinueSetLevel(int level,int collect)
        {
            nowLevel = level;
            watchLevel = nowLevel;
            tmpro.text = watchLevel.ToString();
            correctQestions = collect;
        }

        public int selectNowLevel()
        {
            int j = 0;
            foreach (var i in levelpoint.nextLevelPoint)
            {
                j++;
                if(correctQestions <= i)
                {
                    return j;
                }
            }

            return j;
        }

        public void PlayerLevelUp()
        {
            SEManager.Instance.Play(SEPath.LEVEL_UP);
            StartCoroutine(LevelUpPopUp(3));
            levelUpAnim.Play();
          
        }

        public IEnumerator LevelUpPopUp(int delayFrameCount)
        {
            for (var i = 0; i < delayFrameCount; i++)
            {
                yield return null;    
            } 
            popUpStoryManager.PlayPopUpStory(popUpStoryGenre);

        }

        //Playerの正解数をカウントします。
        [FormerlySerializedAs("player_Correct_Qestions")] public int correctQestions=0;

        /// <summary>
        /// 正解数に応じて、プレイヤーのレベルが変更される。
        /// その基準値が集まっている。
        /// </summary>
        enum Player_Correct_Question_Number_Judge_To_Level
        {
            LEVEL_ONE   =    4,
            LEVEL_TWO   =    8,
            LEVEL_THREE =    12,
            LEVEL_FOUR  =    15,
        }
    
    }
}
