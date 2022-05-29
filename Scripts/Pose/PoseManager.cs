using KanKikuchi.AudioManager;
using UnityEngine;

namespace MainAssets.Scripts.Pose
{
    /// <summary>
    /// Poseを統括するクラス
    /// </summary>
    public class PoseManager : MonoBehaviour
    {
        [SerializeField] private GameObject poseUI;

        [SerializeField] private GameObject poseUIButton;

        [SerializeField] private GameObject poseUIBackButton;

        [SerializeField] private Animator poseAnim;
    
        private float setTime = 1;

        public void PoseGame()
        {
            setTime = Time.timeScale;
            Time.timeScale = 0;
            poseUI.SetActive(true);
            poseUIBackButton.SetActive(true);
            poseUIButton.SetActive(false);
            poseAnim.Play("poseAnimation");
            SEManager.Instance.Play(SEPath.SE_DICIDE,.1f);
        }

        public void Return2Game()
        {
            SEManager.Instance.Play(SEPath.SERETURN,.1f);

            poseUI.SetActive(false);
            poseUIBackButton.SetActive(false);
            poseUIButton.SetActive(true);
            Time.timeScale = setTime;
            poseAnim.Play("poseReturnAnimation");
        }
    }
}
