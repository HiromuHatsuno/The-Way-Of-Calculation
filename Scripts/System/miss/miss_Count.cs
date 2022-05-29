using UnityEngine;

namespace MainAssets.Scripts.System.miss
{
    /// <summary>
    /// 間違えた問題数を数えるクラス
    /// </summary>
    public class MissCount : MonoBehaviour
    {
        public int addition_miss;
        public int subtraction_miss;
        public int multiplication_miss;
        public int division_miss;
        public int Change_Level_MissCount;

        private void Start()
        {
            addition_miss = PlayerPrefs.GetInt("addition_miss", 0);
            subtraction_miss = PlayerPrefs.GetInt("subtraction_miss", 0);
            multiplication_miss = PlayerPrefs.GetInt("multiplication_miss",0);
            division_miss = PlayerPrefs.GetInt("division_miss",0);
            Change_Level_MissCount = multiplication_miss + division_miss;
        }
        public void miss_Counter(string miss_type)
        {
            switch (miss_type)
            {
                case "+":
                    PlayerPrefs.SetInt("addition_miss",addition_miss+1);
                    PlayerPrefs.Save();
                    break;
                case "-":
                    PlayerPrefs.SetInt("subtraction_miss", subtraction_miss + 1);
                    PlayerPrefs.Save();
                    break;
                case "×":
                    PlayerPrefs.SetInt("multiplication_miss", multiplication_miss + 1);
                    PlayerPrefs.Save();
                    break;
                case "÷":
                    PlayerPrefs.SetInt("division_miss", division_miss + 1);
                    PlayerPrefs.Save();
                    break;
            }
        }
    }
}