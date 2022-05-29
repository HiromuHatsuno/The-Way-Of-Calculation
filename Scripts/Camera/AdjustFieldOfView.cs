using System.Collections.Generic;
using UnityEngine;

namespace MainAssets.Scripts.Camera
{
    /// <summary>
    /// 毎フレーム全カメラのfieldOfViewを変更する処理
    /// </summary>
    public class AdjustFieldOfView : MonoBehaviour
    {
        public List<UnityEngine.Camera> cameras;
        public UnityEngine.Camera targetCamera;
        void FixedUpdate()
        {
            foreach (var cameral in cameras)
            {
                cameral.fieldOfView = targetCamera.fieldOfView;
            }
        }
    }
}
