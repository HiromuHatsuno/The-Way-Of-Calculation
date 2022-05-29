using System;
using System.Collections.Generic;
using UnityEngine;

namespace MainAssets.Scripts.Material
{
    /// <summary>
    /// EmissionMaterialHDRColorを変更する。
    /// </summary>
    public class ChangeMaterialHDRColor:MonoBehaviour
    {

        #region 変数

        [ColorUsage(false, true)]
        [Header("変更するHDRColor")]
        public List<Color> Change2Color;
        
        private Renderer targetRenderer;
        private Color return2Color;
        
        #endregion    
        
        /// <summary>
        /// 初期化処理
        /// </summary>
        void Start()
        {
            targetRenderer = GetComponent<Renderer>();
            targetRenderer.material.EnableKeyword("_EMISSION4");
            //Return2Colorに現在の色を代入。
            this.return2Color = targetRenderer.material.GetColor("_Color");
        }

        /// <summary>
        /// MaterialのEmissionColorをチェンジする。
        /// </summary>
        public void ChangeEmissionHDRColor(int colorArrayNum=0)
        {
            try
            {
                targetRenderer.material.SetColor("_Color",Change2Color[colorArrayNum]);
            }
            catch (Exception e)
            {
                Console.WriteLine("引数値が正しくないです。正しい値を入れ直してください。");
                throw;
            }
        }

        /// <summary>
        /// Material元々のEmissionColorに戻す。
        /// </summary>
        public void EmissionColorToReturn()
        {
            targetRenderer.material.SetColor("_Color",return2Color);
        }
    }
}