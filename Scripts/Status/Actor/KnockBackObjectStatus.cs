using UnityEngine;

namespace MainAssets.Scripts.Status.Actor
{
    /// <summary>
    /// KnockBackオブジェクトのステータス
    /// </summary>
    public class KnockBackObjectStatus : MonoBehaviour
    {
        #region
        //死亡時の変更用変数。
        [SerializeField] 
        public float deadKnockBackRatio=1f;

        //生存時の変更用変数
        [SerializeField] 
        public float aliveKnockBackRatio = 0.2f;
        
        [SerializeField]
        public BoxCollider2D boxCollider2D;

        //ターゲット初期化用変数
        public Rigidbody2D rigidBody;
        public PhysicsMaterial2D deadPhysicsMaterial;
        public PhysicsMaterial2D alivePhysicsMaterial;
        #endregion
        private void Start()
        {
            TryGetComponent<Rigidbody2D>(out rigidBody);
            TryGetComponent<BoxCollider2D>(out boxCollider2D);
            
        }

      
    }
}