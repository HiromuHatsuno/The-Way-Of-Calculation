using KanKikuchi.AudioManager;
using MainAssets.Scripts.Music;
using UnityEngine;

namespace OTHER_Product_Assets.AudioManager_KanKikuchi.Scripts
{
    /// <summary>
    /// フォルダーに入ってるSEをランダムで再生するクラス
    /// </summary>
    public class SeArrayManager : MonoBehaviour
    {
        private static string[][] Se_Array_FolderName;
        public enum FOLDER_NAME
        {
            UnityChan_Jump_Voice = 0,
            Miss_Compute = 1,
            Success_Compute = 2,
            Shot_SE = 3,
            UnityChanDamage=4,
            ARank=5,
            BRank=6,
            CRank=7,
            DRank=8,
            ERAnk=9,
            GameOver=10,
            Shot_UnityVoice=11,
            Sord_Attack_SE=12,
            SRank=13,
            StartGame=14,
            SwordUnityChanVoice=15,
            UnityChanMissVoice=16,
        }



        //全ての配列化したいフォルダは下記のサブディレクトリになる。
        const string SE_ARRAY_Path = "SE/SE_ARRAY/";

        //シングルトン化用の変数
        static public SeArrayManager instance;
        //シングルトン化の初期化処理
        void Awake()
        {
            if (instance == null)
            {

                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {

                Destroy(gameObject);
            }
        }
        //Assets/OTHER_ASSETS/AudioManager_KanKikuchi/Resources
        // Start is called before the first frame update
        void Start()
        { 
            /*上手く行かなかった
             * また今度挑戦したい。
             * したかった事
             * streamingAssetsに音源を入れて、それをランダム再生するプログラム。
             * Andoroidでの相性が悪く。SE_Managerとの相性も悪い為却下
               string[] childPaths = Directory.GetDirectories(Application.streamingAssetsPath, "SE_ARRAY", SearchOption.AllDirectories);
               foreach (var SE in childPaths)
               {
                string[] Folder = Directory.GetDirectories(SE, "*", SearchOption.AllDirectories);
                //ex.FOLDER_NAME.0(UnityChan_Jump_Voice/)=SE_Array_FolderName[0];
                Se_Array_FolderName = new string[Folder.Length][];
                for (int i = 0; i < Folder.Length; i++)
                {
                    //FOLDER_NAME Folder_Name = (FOLDER_NAME)System.Enum.ToObject(typeof(FOLDER_NAME), i);
                    //各フォルダの中に有る音源をファイル事ずつに、一度SE配列に保管する。
                    // AudioClip[] Se = Resources.LoadAll<AudioClip>(Folder[i].ToString());
                    string[] SE_file = Directory.GetFiles(Folder[i], "*", SearchOption.TopDirectoryOnly);
                    //SE配列の長さを基に、
                    //フォルダの中に有る音源の数だけSe_Array_FolderName配列の要素数を確保させる。
                    Se_Array_FolderName[i] = new string[SE_file.Length];
                    //for文を利用して、各フォルダに対応する音源のパスをSe_Array_FolderNameの配列に追加する。
                    for (int j = 0; j < SE_file.Length; j++)
                    {
                        SE_file[j] = SE_file[j].Replace(".meta", "");
                    SE_file[j] = SE_file[j].Replace(Application.streamingAssetsPath+"\\", "");
                    SE_file[j] = SE_file[j].Replace(".mp3", "");
                        Se_Array_FolderName[i][j] = SE_file[j];
                    }
                }
            }
      */


        }
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
        static void Setting_SE()
        {

            //配列化して欲しいフォルダの要素数をenum(フォルダまでの名前)の要素数から取得
            int Folder_Length = System.Enum.GetValues(typeof(FOLDER_NAME)).Length;
            //この時点でenumの数字と配列の要素は対応した。
            //ex.FOLDER_NAME.0(UnityChan_Jump_Voice/)=SE_Array_FolderName[0];
            Se_Array_FolderName = new string[Folder_Length][];
            //Se_Array_FolderName[][x]に、フォルダの中に有るx個のオーディオパスを入れて行く。
            for (int i = 0; i < Folder_Length; i++)
            {
                FOLDER_NAME Folder_Name = (FOLDER_NAME)System.Enum.ToObject(typeof(FOLDER_NAME), i);
                //各フォルダの中に有る音源をファイル事ずつに、一度SE配列に保管する。
                AudioClip[] Se = Resources.LoadAll<AudioClip>(SE_ARRAY_Path + Folder_Name.ToString());
                //SE配列の長さを基に、
                //フォルダの中に有る音源の数だけSe_Array_FolderName配列の要素数を確保させる。
                Se_Array_FolderName[i] = new string[Se.Length];
                //for文を利用して、各フォルダに対応する音源のパスをSe_Array_FolderNameの配列に追加する。
                for (int j = 0; j < Se.Length; j++)
                {
                    Se_Array_FolderName[i][j] = SE_ARRAY_Path + Folder_Name.ToString() + "/" + Se[j].name;
                }
            }

        }

        public void Play_Random_SE(FOLDER_NAME selectedFolderName, bool doEcho = false)
        {
            var folderNumber = (int) selectedFolderName;
            var rand = Random.Range(0, Se_Array_FolderName[folderNumber].Length);
            if (doEcho)
            {
                EchoSeManager.Instance.Play(Se_Array_FolderName[folderNumber][rand]);
                return;
            }
            SEManager.Instance.Play(Se_Array_FolderName[folderNumber][rand]);
        }

    }
}