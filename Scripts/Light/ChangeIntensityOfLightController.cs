using UnityEditor;
using UnityEngine;

namespace Main_Assets.Scripts
{
    [ExecuteInEditMode] //SendMessageでエラーが出ないように

    //Lightをコントロールするクラス
    public class ChangeIntensityOfLightController:MonoBehaviour
    {
        public Change2IntensityOfLight change2IntensityOfLight;

        public void DoIntensityOfLight()
        {
            change2IntensityOfLight.Changing2IntensityOfLight();
        }
    }
  

}