using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace MainAssets.Scripts.EmissionMap
{
    [ExecuteInEditMode] //SendMessageでエラーが出ないように

    //EmissionMapをアニメーションで変更できるシステム。
    public class ChangeEmissionMapSystem : MonoBehaviour
    {
        private SpriteRenderer meshRenderer;
        [ColorUsage(false, true)] public Color toEmissionChangeColor;
        [ColorUsage(false, true)] public Color initializeEmissionColor;
        [SerializeField]private Sprite emissionMap;
        private Sprite lastEmissionMap;
        private static readonly int Map = Shader.PropertyToID("_EmissionMap");

        /// <summary>
        /// EmissionMapのproperty
        /// </summary>
        public Sprite EmissionMap
        {
            get { return emissionMap;}
            set
            {        
                emissionMap = value;
                ChangeEmissionMap();
            }
        }

        /// <summary>
        /// 初期化処理ここでキーワード宣言する必要がある。
        /// </summary>
        public void Start()
        {
            UnityEngine.Debug.unityLogger.logEnabled = false;
            meshRenderer = GetComponent<SpriteRenderer>();
            meshRenderer.material.EnableKeyword("_EMISSION");
            initializeEmissionColor = meshRenderer.material.GetColor("_EmissionColor");
        }

        /// <summary>
        /// この関数によってアニメーションで値の変更を行った時にもプロパティが正常に呼び出される。
        /// </summary>
        private void OnDidApplyAnimationProperties()
        {
            if (emissionMap !=lastEmissionMap&&emissionMap!=null)
            {
                ChangeEmissionMap();
            }

            lastEmissionMap = emissionMap;
        }

        /// <summary>
        /// EmissionMapを変更します。
        /// </summary>
        public void ChangeEmissionMap()
        {
            meshRenderer.material.SetColor("_EmissionColor",toEmissionChangeColor);
            meshRenderer.material.SetTexture(Map,emissionMap.texture);
        }
        /// <summary>
        /// EmmisionMapをnullに変更後EmissionColorも通常時と同じ色に変更。
        /// </summary>
        public void EmissionMap2Null()
        {
            meshRenderer.material.SetTexture("_EmissionMap",null);
            meshRenderer.material.SetColor("_EmissionColor",initializeEmissionColor);

        }
    }
#if UNITY_EDITOR
    [CustomEditor(typeof(ChangeEmissionMapSystem))] //拡張するクラスを指定
    public class ChangeEmissionMapEditor : Editor
    {

        /// <summary>
        /// InspectorのGUIを更新
        /// </summary>
        public override void OnInspectorGUI()
        {
            //元のInspector部分を表示
            base.OnInspectorGUI();

            //targetを変換して対象を取得
            ChangeEmissionMapSystem changeEmission = target as ChangeEmissionMapSystem;

            //PrivateMethodを実行する用のボタン
            if (GUILayout.Button("ChangeEmissionMap"))
            {
                //SendMessageを使って実行
                changeEmission.SendMessage("ChangeEmissionMap", null, SendMessageOptions.DontRequireReceiver);
            }

        }
    }
#endif
}