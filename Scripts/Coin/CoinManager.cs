using TMPro;
using UnityEngine;

   /// <summary>
   /// ゲーム内通貨をマネジメントするクラス
   /// </summary>
   public class CoinManager : MonoBehaviour
   {
      private static CoinManager instance;
      public int coin;
      public TextMeshProUGUI coinText;
      public TextMeshProUGUI totalCoinText;
      public TextMeshProUGUI totalCoinText2;

      /// <summary>
      /// シングルトン化処理
      /// </summary>
      public static CoinManager Instance{
         get{
            if( null == instance ){
               instance = (CoinManager)FindObjectOfType(typeof(CoinManager));
               if( null == instance ){
               }
            }
            return instance;
         }
      }
      /// <summary>
      /// 初期化処理
      /// </summary>
      void Awake(){
         GameObject[] obj = GameObject.FindGameObjectsWithTag("CoinManager");
         if( 1 < obj.Length ){
            // 既に存在しているなら削除
            Destroy( gameObject );
         }else{
            // シーン遷移では破棄させない
            DontDestroyOnLoad( gameObject );
         }
      }

      public void Start()
      {
         totalCoinText.text = PlayerPrefs.GetInt("Coin").ToString();
         totalCoinText2.text = PlayerPrefs.GetInt("Coin").ToString();
         coin = 0;
      }

      /// <summary>
      /// コインを追加してセーブする処理
      /// </summary>
      /// <param name="add"></param>
      public  void AddCoin(int add)
      {
         CoinManager.instance.coin += add;
         CoinManager.Instance.coinText.text = CoinManager.instance.coin.ToString();
         PlayerPrefs.SetInt("Coin",CoinManager.instance.coin);
      }
   
   }
