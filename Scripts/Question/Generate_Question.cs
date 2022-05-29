using Assets.Scripts.StartScript;
using DG.Tweening;
using MainAssets.Scripts.Player.Provider;
using TMPro;
using UnityEngine;


/// <summary>
/// 問題を作成するクラス
/// </summary>
    public partial class Generate_Question : MonoBehaviour
    {
    
        int temp;
        //生成した問題文
        public string strCreateQuestion = "";
        //生成した問題文の回答
        public static int intAnswerNumber = 0;

        //問題の左の項の数字
        private int intLeftNumber;
        //問題の右の項の数字
        private int intRightNumber;

        private bool isStart = true;
    
        //問題の左の項の数字の桁数
        private int intLeftNumberDigits;
        //問題の右の項の数字の桁数
        private int intRightNumberDigits;
        //符号
        private  thisGameSign getSign;
    
        //回答のテキスト
        [SerializeField]
        private TextMeshProUGUI _text = default;
    

    
        [SerializeField]
        private AudioSource _audioSource = default;

        //答え用のサウンド
        public AudioClip sound1;

        //文字を表示する速度
        public float Display_Word_Speed=.43f;
        enum thisGameSign : int
        {
            plus =1,
            minus =2,
            kakeru =3,
            waru =4
        }

        enum thisGameDisits : int
        {
            one=1,
            two=2,
            three=3,
            four=4
        }


        //Player保存用
        [SerializeField]
        private PlayerActorProvider playerProvider;

        void Start()
        {
            this.generate_Question();
        }

        void Update()
        {
            if (StartTap.startGame&&isStart)
            { 
                isStart = false;
                generate_Question();
            }
        }

        public void generate_Question()
        { 
            //変化前のテキスト
            //符号決定
            getSign = this.GetSign();

            //割り算のみ別処理を行う。
            /*割り算は、答え、右辺の両方をランダムで求める。それらを掛けたものを左辺とすると答えが求められる。*/
            if (getSign == thisGameSign.waru)
            {
                //回答を設定
                this.calcAnswer();
                //数字の決定
                this.setNumber();
                //出力
                strCreateQuestion = intLeftNumber.ToString()+this.Convert_thidGameSign2String(getSign)+intRightNumber.ToString();

       
                //回答を設定
                this.calcAnswer();

            }
            //割り算以外の処理
            else
            {
                var beforeText = _text.text;

                //右と左の数値の決定
                this.setNumberDigits(getSign);

                //数字の決定
                this.setNumber();

                //出力
                strCreateQuestion = intLeftNumber.ToString()+this.Convert_thidGameSign2String(getSign)+intRightNumber.ToString();

            
                //2秒でテキスト表示
                _text.DOText(strCreateQuestion, Display_Word_Speed).SetEase(Ease.Linear).OnUpdate(() => {//更新される度に実行される(※テキストが変更された時ではない)
                    //テキストの変化が有ったか調べる為の変数
                    var currentText = _text.text;

                    //現在のテキストを取得、変化していなければ処理しない
                    if (beforeText == currentText)
                    {
                        return;
                    }

                    //SEを鳴らさないやつでなければ鳴らす
                    _audioSource.PlayOneShot(sound1);
                    //次のチェック用にテキスト更新
                    beforeText = currentText;
                });
                //回答を設定
                this.calcAnswer();
            }
        }
  
    }

