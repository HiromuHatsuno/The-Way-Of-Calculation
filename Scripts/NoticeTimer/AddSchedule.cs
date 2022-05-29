using System;
using KanKikuchi.AudioManager;
using UnityEngine;

namespace MainAssets.Scripts.noticeTimer
{
    /// <summary>
    ///アプリのローカル通知を行うクラス
    /// </summary>
    public class AddSchedule : MonoBehaviour
    {
        [SerializeField]
        private GameObject hour2;

        [SerializeField] private GameObject hour1;

        [SerializeField] private GameObject minute2;
        [SerializeField] private GameObject minute1;
        public void Start()
        {
            LocalPushNotification.RegisterChannel("channelId", "アプリ名（チャンネル名)", "説明");

        }

        public void SetSchedule()
        {
            SEManager.Instance.Play(SEPath.MAOU29,.1f);
            int hour = PlayerPrefs.GetInt("nowCount" + hour2.name)*10+PlayerPrefs.GetInt("nowCount" + hour1.name);
            int minute=PlayerPrefs.GetInt("nowCount"+minute2.name)*10+PlayerPrefs.GetInt("nowCount" + minute1.name);

            LocalPushNotification.AllClear();
            LocalPushNotification.AddScheduleRepeat("そろそろ「暗算の道」で勉強の時間だよ！", "「暗算の道」で勉強しませんか？日々の練習が脳を活性化させますよ！", 0, 0, "channelId",new TimeSpan(hour,minute,0));
        }
    }
}