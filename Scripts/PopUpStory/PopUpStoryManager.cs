using System.Collections;
using Assets.Scripts.Scritable;
using Febucci.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MainAssets.Scripts.PopUpStory
{
    /// <summary>
    /// ポップアップストーリーを表示するクラス
    /// </summary>
    public class PopUpStoryManager : MonoBehaviour
    {
        [SerializeField]
        private Image faceImage;
        [SerializeField]
        private string story;

        [SerializeField]
        private TextMeshProUGUI textMeshProUGUI;
        [SerializeField]
        private Animator anim;    
        [SerializeField]
        private  AnimationClip storyStartAnim;
        [SerializeField]
        private  AnimationClip storyEndAnim;
        [SerializeField]
        private  TextAnimatorPlayer textAnimatorPlayer;
        [SerializeField]
        private bool canStartStory = true;

    
        //ポップアップして表示されるストーリーを表示する
        public  void PlayPopUpStory(PopUpStoryGenre popUpStoryGenre)
        {
            if (!canStartStory) return;
            canStartStory = false;
            PopUpStoryScritable popUpStoryScritable=popUpStoryGenre.stories[Random.Range(0, popUpStoryGenre.stories.Count)]; 
            faceImage.sprite = popUpStoryScritable.topUpImage;
            story = popUpStoryScritable.story;
            anim.SetTrigger("Start");
        }
    

        //ポップアップして表示されるストーリを終了する
        public void PlayEndPopUpStory()
        {   StartCoroutine(DelayMethod(2));
       
        }

        public void AnimText()
        {
            textAnimatorPlayer.ShowText(story);
        }
        private IEnumerator DelayMethod(float delayFrameCount)
        {
            yield return new WaitForSeconds(delayFrameCount);
            canStartStory = true;
            anim.SetTrigger("End");
            yield break;
        }
    }
}
