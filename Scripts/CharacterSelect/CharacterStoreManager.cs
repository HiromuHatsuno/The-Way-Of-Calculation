using System.Collections;
using System.Collections.Generic;
using KanKikuchi.AudioManager;
using MainAssets.Scripts.DoTweenUI;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Tables;
using UnityEngine.UI;

namespace MainAssets.Scripts.CharacterSelect
{
    /// <summary>
    /// キャラクター選択兼ストアでの操作を統括するクラス。
    /// </summary>
    public class CharacterStoreManager : MonoBehaviour
    {
        [SerializeField]
        private LocalizedStringTable _localizedStringTable;
        [SerializeField]
        private StringTable _currentStringTable;

        public StoreDoTweenManager storeDoTweenManager;
        public List<TextMeshProUGUI> haveCoinText;
        public TextMeshProUGUI popUpText;
        public Image image;
        public List<Sprite> characterImages;
        public TextMeshProUGUI charName;
        public List<string> charNameString;
        public TextMeshProUGUI valueOfCharacter;
        public List<int> valueOfCharacterList;
        public Animator animator;
        public List<RuntimeAnimatorController> animatorControllers;
        public int iterator;
        public string purchaseText;
        
        /// <summary>
        /// 初期化処理
        /// </summary>
        public void Start()
        {
            iterator = PlayerPrefs.GetInt("Iterator");
            charName.text = charNameString[0];
            PlayerPrefs.SetInt(charName.text,1);
            image.sprite = characterImages[iterator];
            charName.text = charNameString[iterator];
            StartCoroutine (ChangeWord(charNameString[iterator],charName.text));
            valueOfCharacter.text = valueOfCharacterList[iterator].ToString() + "Coin";
            animator.runtimeAnimatorController = animatorControllers[iterator];

            if (PlayerPrefs.GetInt(charName.text,0)==1)
            {
                PlayerPrefs.SetInt(charName.text,1);
                StartCoroutine (ChangeWord("doEuipment",purchaseText));

            }
        }

        /// <summary>
        /// キャラクター選択画面で左UIボタンを押した時の処理
        /// </summary>
        public void LeftButton()
        {
            if (iterator == 0) 
            {
                //一番左の為移動できない時の処理
                SEManager.Instance.Play(SEPath.CAN_NOT_DELEATE,0.1f);
                return;
            }
            //移動成功処理
            SEManager.Instance.Play(SEPath.SE_DICIDE,.1f);
            iterator--;
            PlayerPrefs.SetInt("Iterator", iterator);
            image.sprite = characterImages[iterator];
            StartCoroutine (ChangeWord(charNameString[iterator],charName.text));

            valueOfCharacter.text = valueOfCharacterList[iterator].ToString()+"Coin";
            if (PlayerPrefs.GetInt(charName.text,0)==0)   
            {
                StartCoroutine (ChangeWord("Purchase",purchaseText));

            }
            else
            {
                StartCoroutine (ChangeWord("doEuipment",purchaseText));

            }
        }
        /// <summary>
        /// キャラクター選択画面で右UIボタンを押した時の処理
        /// </summary>
        public void RightButton()
        {
            if (iterator == characterImages.Count-1) 
            {
                //一番右の為移動できない時の処理
                SEManager.Instance.Play(SEPath.CAN_NOT_DELEATE,0.1f);
                return;
            }
            //移動成功処理
            SEManager.Instance.Play(SEPath.SE_DICIDE,.1f);
            iterator++;
            PlayerPrefs.SetInt("Iterator", iterator);
            image.sprite = characterImages[iterator];
            StartCoroutine (ChangeWord(charNameString[iterator],charName.text));

            valueOfCharacter.text = valueOfCharacterList[iterator].ToString()+"Coin";
            if (PlayerPrefs.GetInt(charName.text,0)==0)
            {
                StartCoroutine (ChangeWord("Purchase",purchaseText));

            }
            else
            {
                StartCoroutine (ChangeWord("doEuipment",purchaseText));
            }
        }

        public void Purchase()
        {
            //購入処理
            if (PlayerPrefs.GetInt(charName.text,0)==0)
            {
                //購入成功処理
                if (PlayerPrefs.GetInt("Coin")>=valueOfCharacterList[iterator])
                {                                
                    StartCoroutine (ChangeWord("Purchase",purchaseText));
                    PlayerPrefs.SetInt("Coin",PlayerPrefs.GetInt("Coin")-valueOfCharacterList[iterator]);
                    StartCoroutine (ChangeWord("purchaseCompleted",popUpText.text));
                    foreach (var textMeshProUGUI in haveCoinText)
                    {
                        textMeshProUGUI.text = PlayerPrefs.GetInt("Coin").ToString();
                    }
                    storeDoTweenManager.PopUp();
                    SEManager.Instance.Play(SEPath.SE_DICIDE,.1f);
                    PlayerPrefs.SetInt(charName.text, 1);

                }
                //購入失敗処理
                else
                {
                    StartCoroutine (ChangeWord("haveNotCoin",popUpText.text));
                    storeDoTweenManager.PopUp();
                    SEManager.Instance.Play(SEPath.CAN_NOT_DELEATE,.1f);
                }
            }
            //装備処理
            else
            {
                StartCoroutine (ChangeWord("equipment",popUpText.text));
                storeDoTweenManager.PopUp();
                SEManager.Instance.Play(SEPath.SE_DICIDE,.1f);
                animator.runtimeAnimatorController = animatorControllers[iterator];
            }
        }

        /// <summary>
        /// ローカライズテーブルを基にテキストを変更する処理
        /// ローカライズ化は途中の為、提出時は未実装
        /// </summary>
        /// <param name="key"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public IEnumerator ChangeWord( string key, string text)
        {
            var tableLoading = _localizedStringTable.GetTable();
            yield return tableLoading;
            _currentStringTable = tableLoading.Result;
            var str =
                _currentStringTable[key].LocalizedValue;
            text= str;
        }
    }
}
