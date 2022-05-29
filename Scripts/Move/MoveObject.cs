using UnityEngine;

namespace Assets.Scripts.Move
{
    //動くオブジェクトにアタッチする抽象クラス
    public abstract class MoveObject : MonoBehaviour
    {
        #region 変数
        [SerializeField] 
        protected bool moveDirectionIsLeft=false;
        private int direction;
        [SerializeField]
        protected float moveSpeed;
        public Rigidbody2D rigidBody;
        #endregion
        
        /// <summary>
        /// 初期化処理
        /// </summary>
        protected virtual void Start()
        {
            this.gameObject.TryGetComponent<Rigidbody2D>(out rigidBody);
        }
        /// <summary>
        /// 移動スクリプト
        /// </summary>
        protected void Move()
        {
            direction = moveDirectionIsLeft ? -1 : 1;
             rigidBody.velocity = 
                 new Vector2(direction*moveSpeed, rigidBody.velocity.y);
        }
    }
}