using UnityEditor;
using UnityEngine;

namespace MainAssets.Scripts.Debug
{
    /// <summary>
    /// AddForce2Dのデバッククラスです。
    /// ワンボタンでデバックする事が可能です。
    /// </summary>
    [ExecuteInEditMode] //SendMessageでエラーが出ないように
    [RequireComponent(typeof(Rigidbody2D))]

    public class DebugAddForce2D : MonoBehaviour
    {
        #region 変数
        public Rigidbody2D rigidbody2D;
        public Vector2 addDirection;
        public float forceRatio=1;
        public float power=1;
        [SerializeField, Header ("Addforceの吹っ飛び方")]
        public ForceMode2D forceMode2D;
        #endregion

    
        /// <summary>
        /// 計算方法を決めるルール
        /// </summary>
        public enum CalculateRule
        {
            OnlyDirection,
            DirectionPower,
            DirectionPowerRatio,
        }
        [SerializeField, Header ("Addforceの計算方法")]
        public CalculateRule calculateRule;

        //変数で設定できるルールによって、吹っ飛び方を変化できる。
        private void Addforce()
        {
            //nullならTryGetComponentする。
            if (rigidbody2D == null) AttachRigidBody2D();
            rigidbody2D.AddForce(addDirection);
            switch (calculateRule)
            {
                case CalculateRule.OnlyDirection:
                    OnlyDirectionAddforce();
                    break;
                case CalculateRule.DirectionPower:
                    DirectionPowerAddforce();
                    break;
                case CalculateRule.DirectionPowerRatio:
                    DirectionPowerRatio();
                    break;
            }
        }

        #region AddForce

        private void OnlyDirectionAddforce()
        {
            rigidbody2D.AddForce(addDirection, forceMode2D);
        }

        private void DirectionPowerAddforce()
        {
            rigidbody2D.AddForce(addDirection * power, forceMode2D);
        }

        private void DirectionPowerRatio()
        {
            rigidbody2D.AddForce(addDirection * power * forceRatio, forceMode2D);
        }
        #endregion
        //RigidBody2Dがnullの時はアタッチする。
        private void AttachRigidBody2D()
        {
            TryGetComponent<Rigidbody2D>(out rigidbody2D);
        }
    }
#if UNITY_EDITOR
    [CustomEditor(typeof(DebugAddForce2D))]//拡張するクラスを指定
    public class ExampleScriptEditor : Editor {

        /// <summary>
        /// InspectorのGUIを更新
        /// </summary>
        public override void OnInspectorGUI(){
            //元のInspector部分を表示
            base.OnInspectorGUI ();

            //targetを変換して対象を取得
            DebugAddForce2D debugAddForce2D = target as DebugAddForce2D;

            //PrivateMethodを実行する用のボタン
            if (GUILayout.Button("CalculateAddForce")){
                //SendMessageを使って実行
                debugAddForce2D.SendMessage ("CalculateAddForce", null, SendMessageOptions.DontRequireReceiver);
            }

        }
    }
#endif
}