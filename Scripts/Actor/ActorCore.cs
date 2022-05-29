using MainAssets.Scripts.Status.Actor;
using UnityEngine;
using UnityEngine.UI;

namespace MainAssets.Scripts.Actor
{
   /// <summary>
   /// Actorに必要な状態を統括する抽象クラス
   /// </summary>
   public abstract class ActorCore : MonoBehaviour
   {
      #region 変数一覧
      //初期化用パラメータ一覧
      //Hp最大値
      [SerializeField]
      protected int maxHp;
      
      //hp現在値
      [SerializeField]
      protected int hp;
      
      //hp最低値
      protected const int MINHP=0;

      //名前
      [SerializeField]
      protected string name;
      
      //HpSlider格納用
      protected Slider slider;

      //各種コンポーネント格納用
      protected Rigidbody2D rigidBody2D;
      protected Transform coreTransform;
      public BoxCollider2D boxCollider2D;
      
      //ActorStatus格納用変数
      public ActorStatus status;
      
      #endregion

      public virtual void Awake()
      {         
         #region 初期化処理
         slider=GetComponentInChildren<Slider>();
         TryGetComponent<Rigidbody2D>(out rigidBody2D);
         TryGetComponent<BoxCollider2D>(out boxCollider2D);
         TryGetComponent<Transform>(out coreTransform);
         status = new ActorStatus(maxHp, MINHP, hp, slider);
         #endregion
      }
   }
}
