using UnityEngine;

namespace MainAssets.Scripts.Other
{
    //HPバーを常にカメラの正面に表示されるようにするクラス
    public class LookUtCameraHp : MonoBehaviour
    {
        void LateUpdate()
        {
            //　カメラと同じ向きに設定
            transform.rotation = UnityEngine.Camera.main.transform.rotation;
        }
    }
}
