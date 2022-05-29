using UnityEngine;

namespace MainAssets.Scripts.PostEffect
{
    /// <summary>
    /// 攻撃をした際や攻撃を受けた際にVigetteを変更するクラス
    /// </summary>
    public class ChangeVigette : MonoBehaviour
    {
        public GameObject[] ChangeLowVigtte;
        public GameObject[] ChangeNowVigtte;
        public GameObject[] ChangeHighVigtte;

        public void ChangeMorning2NightOfVignette()
        {
            switch (PlayerPrefs.GetInt("Quality"))
            {
                case 1:
                    ChangeLowVigtte[0].SetActive(true);
                    break;
                case 2:
                    ChangeNowVigtte[0].SetActive(true);
                    break;
                case 3 :
                    ChangeHighVigtte[0].SetActive(true);
                    break;
            }
        }

        public void ReturnToVigette()
        {
            switch (PlayerPrefs.GetInt("Quality"))
            {
                case 1:
                    ChangeLowVigtte[0].SetActive(false);
                    break;
                case 2:
                    ChangeNowVigtte[0].SetActive(false);
                    break;
                case 3 :
                    ChangeHighVigtte[0].SetActive(false);
                    break;
            }
        }   public void ReturnToDeadVigette()
        {
            switch (PlayerPrefs.GetInt("Quality"))
            {
                case 1:
                    ChangeLowVigtte[1].SetActive(false);
                    break;
                case 2:
                    ChangeNowVigtte[1].SetActive(false);
                    break;
                case 3 :
                    ChangeHighVigtte[1].SetActive(false);
                    break;
            }
        }
        public void DeadChangeMorning2NightOfVignette()
        {
            switch (PlayerPrefs.GetInt("Quality"))
            {
                case 1:
                    ChangeLowVigtte[1].SetActive(true);
                    break;
                case 2:
                    ChangeNowVigtte[1].SetActive(true);
                    break;
                case 3 :
                    ChangeHighVigtte[1].SetActive(true);
                    break;
            }
        }

    }
}
