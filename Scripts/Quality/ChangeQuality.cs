using System.Collections;
using KanKikuchi.AudioManager;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Tables;

namespace MainAssets.Scripts.Quality
{
    /// <summary>
    /// クオリティを変化するクラス
    /// </summary>
    public class ChangeQuality : MonoBehaviour
    {
        [SerializeField]
        private LocalizedStringTable _localizedStringTable;
        [SerializeField]
        private StringTable _currentStringTable;
        public TextMeshProUGUI text;
        public GameObject lowVolume; //1
        public GameObject midiumVolume; //2
        public GameObject highVolume; //3

        public void Start()
        {
            //初期化はキーを入れる。
            if (!PlayerPrefs.HasKey("Quality"))
            {
                PlayerPrefs.SetInt("Quality", 2);
            }
            ChangeQualityMethod(PlayerPrefs.GetInt("Quality"));
        }
    
        //左ボタンを押した時のクオリティ変化処理
        public void Left2ChangeQuality()
        {
            switch (PlayerPrefs.GetInt("Quality"))
            {
                case 1:
                    SEManager.Instance.Play(SEPath.CAN_NOT_DELEATE);
                    break;
                case 2:
                    SEManager.Instance.Play(SEPath.SE_MAOUDAMASHII_SYSTEM45);
                    ChangeQualityMethod(1);
                    break;
                case 3:
                    SEManager.Instance.Play(SEPath.SE_MAOUDAMASHII_SYSTEM45);
                    ChangeQualityMethod(2);
                    break;
            }
        }
        //右ボタンを押した時のクオリティ変化処理
        public void Right2ChangeQuality()
        {
            switch (PlayerPrefs.GetInt("Quality"))
            {
                case 1:
                    SEManager.Instance.Play(SEPath.CAN_NOT_DELEATE);
                    ChangeQualityMethod(2);
                    break;
                case 2:
                    SEManager.Instance.Play(SEPath.CAN_NOT_DELEATE);
                    ChangeQualityMethod(3);
                    break;
                case 3:
                    SEManager.Instance.Play(SEPath.CAN_NOT_DELEATE);
                    break;
            }
        }

        //クオリティを変更するメソッド
        public void ChangeQualityMethod(int i)
        {
            PlayerPrefs.SetInt("Quality", i);
            switch (PlayerPrefs.GetInt("Quality"))
            {
                case 1:
                    lowVolume.SetActive(true);
                    midiumVolume.SetActive(false);
                    highVolume.SetActive(false);
                    StartCoroutine(ChangeWord("low", text));
                    break;
                case 2:
                    lowVolume.SetActive(false);
                    midiumVolume.SetActive(true);
                    highVolume.SetActive(false);
                    StartCoroutine(ChangeWord("Mid", text));

                    break;
                case 3:
                    lowVolume.SetActive(false);
                    midiumVolume.SetActive(false);
                    highVolume.SetActive(true);
                    StartCoroutine(ChangeWord("high", text));

                    break;
            }
        
        }
        //ストア画面の文章を変更する処理
        public IEnumerator ChangeWord( string key, TextMeshProUGUI textMeshProUGUI)
        {
            var tableLoading = _localizedStringTable.GetTable();
            yield return tableLoading;
            _currentStringTable = tableLoading.Result;
            var str =
                _currentStringTable[key].LocalizedValue;
            textMeshProUGUI.text = str;
        }
    }
}
