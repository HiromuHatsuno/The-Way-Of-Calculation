using Com.LuisPedroFonseca.ProCamera2D;
using MainAssets.Scripts.ExtendMethod;
using UnityEngine;

namespace MainAssets.Scripts.ProCamera
{
    /// <summary>
    /// Cameraをコントロールするクラス
    /// </summary>
    public static class ProCamera2DController
    {
        public static ProCamera2D proCamera2D;
        private static GameObject mainCameraObject;

        static ProCamera2DController()
        {
            
        }
        
        private static void AttachCamera()
        {
            mainCameraObject = GameObject.FindGameObjectWithTag("MainCamera");
            mainCameraObject.TryGetComponent<ProCamera2D>(out proCamera2D);
        }

        public static void SearchNewTarget(GameObject compareObject,GameObject removeObject)
        {
            AttachCamera();
            proCamera2D.SearchNewTarget(compareObject,removeObject);
        }
        
        public static void SearchNewTarget(GameObject compareObject,string searchTarget)
        {
            AttachCamera();
            proCamera2D.SearchNewTarget(compareObject,searchTarget);
        }
        
        public static void SearchNewTarget(string compareObject,GameObject searchTarget)
        {
            AttachCamera();
            proCamera2D.SearchNewTarget(compareObject,searchTarget);
        }

        public static void RemoveTarget(string detachObjectTag,GameObject leaveObjectTag)
        {
            AttachCamera();
            proCamera2D.Remove2GameObject(detachObjectTag,leaveObjectTag);
        }

    }
}