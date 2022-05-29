using Com.LuisPedroFonseca.ProCamera2D;
using MainAssets.Scripts.Search;
using UnityEngine;

namespace MainAssets.Scripts.ExtendMethod
{
    public static class ExtendProCamera2D
    {
        /// <summary>
        /// 現在のターゲットを外し、新しいタグのターゲットを追加する。
        /// </summary>
        /// <param name="self"></param>
        /// <param name="compareObject"></param>
        /// <param name="searchTargetTag"></param>
        public static void SearchNewTarget(this ProCamera2D self, GameObject compareObject, string searchTargetTag)
        {
            self.RemoveAllCameraTargets();
            var targetObject = SearchTarget.SearchClosestTargetObject(searchTargetTag, compareObject);
            if (targetObject != null)
            {
                self.AddCameraTarget(targetObject.transform,
                    1, 1, 0, new Vector2(1.06f, 0));
                self.AddCameraTarget(compareObject.transform,1,0,0,new Vector2(-2.88f, 0));
            }
            else
            {
            }
        }
        public static void SearchNewTarget(this ProCamera2D self, string compareObjectString, GameObject searchTargetTag)
        {
            var compareObject = GameObject.FindGameObjectWithTag(compareObjectString);
            self.RemoveAllCameraTargets();
            var targetObject = SearchTarget.SearchClosestTargetObject(searchTargetTag.tag,compareObject);
            if (targetObject != null)
            {
                self.AddCameraTarget(targetObject.transform,
                    1, 1, 0, new Vector2(1.06f, 0));
                self.AddCameraTarget(compareObject.transform,1,0,0,new Vector2(-2.88f, 0));
            }
            else
            {
            }
        }

        /// <summary>
        /// 現在のターゲットを外し、新しいタグのターゲットを追加する。消去したターゲットと同じタグ名で探す。
        /// </summary>
        /// <param name="self"></param>
        /// <param name="compareObject"></param>
        /// <param name="removeObject"></param>
        public static void SearchNewTarget(this ProCamera2D self, GameObject compareObject, GameObject removeObject)
        {
            self.RemoveAllCameraTargets();
            var searchTargetTag = removeObject.tag;
            var targetObject = SearchTarget.SearchClosestTargetObject(searchTargetTag, compareObject);
            if (targetObject != null)
            {
                self.AddCameraTarget(compareObject.transform,1,1,0,new Vector2(-2.88f, 0));
                self.AddCameraTarget(targetObject.transform,
                    1 , 0, 0,new Vector2(1.06f, 0));
            }
        }
        /// <summary>
        /// 指定したターゲットのみを消去する。
        /// </summary>
        /// <param name="self"></param>
        /// <param name="compareObject"></param>
        /// <param name="removeObject"></param>
        public static void Remove2GameObject(this ProCamera2D self, string detachObjTag,GameObject leaveObject)
        {
            var compareObject = GameObject.FindGameObjectWithTag(detachObjTag);
            self.RemoveAllCameraTargets();
            var targetObject = SearchTarget.SearchClosestTargetObject(leaveObject.tag, compareObject);
            if (targetObject != null)
            {
                self.AddCameraTarget(leaveObject.transform,1,1,0,new Vector2(-2.88f, 0));
            }
        }

    }
}