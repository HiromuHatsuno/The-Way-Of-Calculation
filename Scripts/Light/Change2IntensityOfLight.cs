using System;
using System.Collections.Generic;
using Main_Assets.Scripts.ExtendMethod;
using MainAssets.Scripts.ExtendMethod;
using UnityEngine;

namespace Main_Assets.Scripts
{
    
    /// <summary>
    /// Lightの明るさを変更するプログラム。
    /// </summary>
    [System.SerializableAttribute]
    public class Change2IntensityOfLight : MonoBehaviour
    {
        /// <summary>
        /// Lightに関するデータをまとめたStruct
        /// </summary>
        [System.Serializable]
        public struct LightSet
        {
            //光らせたいライトを格納する変数
            [SerializeField]
            private Light targetTargetLight;
            
            //Lightのプロパティ
            public Light TargetLight  
            {
                get => this.targetTargetLight;
                set => this.targetTargetLight = value;
            }
            
            //ライトの最初の明るさを保存する変数
            [SerializeField] public float intensityAtInitialize;
            
            public float IntensityAtInitialize
            {
                get => this.IntensityAtInitialize;
                set => this.IntensityAtInitialize = value;
            }
        }

        /// <summary>
        /// LightSetを格納するList型変数。
        /// </summary>
        [SerializeField]
        private List<LightSet> lightList;
        
        [SerializeField]
        private float intensity;
        
        /// <summary>
        /// 初期化時に呼び出される。
        /// </summary>
        private void Start()
        {
            // forループで値を変更する
            for (int i = 0; i < lightList.Count;  i++)
            {
                var lightSet = lightList[i];
                lightSet.intensityAtInitialize = lightSet.TargetLight.intensity;
                lightList[i] = lightSet;
            }
        }

        /// <summary>
        /// 毎フレーム呼び出される。
        /// </summary>
        private void Update()
        {
            // forループで値を変更する
            foreach (var t in lightList)
            {
                t.TargetLight.LightLerp(t.intensityAtInitialize, Time.deltaTime);
            }
        }
        
        
        /// <summary>
        /// 指定した明るさにライト全体を変更する。
        /// </summary>
        [ContextMenu("Method")]
        public void Changing2IntensityOfLight()
        {
            foreach (var t in lightList)
            {
                t.TargetLight.intensity = intensity;
            }
        }
    }
}