using UnityEngine;

namespace MainAssets.Scripts.Search
{
    /// <summary>
    /// 一番近い敵などを調べるクラス
    /// </summary>
    public static class SearchTarget
    {

        #region 変数

        //距離用一時変数
        private static float  tmpObjectDistance = 0;    
        //最も近いオブジェクトの距離
        private static float nowClosestObjectDistance = Mathf.Infinity;

        private static GameObject closestObject=null; 
        
        #endregion
        
        /// <summary>
        ///  TarGetObjectに一番近いclosestObjectを調べる。
        /// </summary>
        /// <param name="searchTargetObjectTag"></param>
        /// <param name="comparisonTarget"></param>
        /// <returns></returns>
        public static GameObject SearchClosestTargetObject(string searchTargetObjectTag,/*誰に近いか*/GameObject comparisonTarget)
        {
            closestObject = null;

            //探したいオブジェクトのタグがいなければそのままメソッドを閉じる。
            if (!ExistTarget(searchTargetObjectTag))
            {
                return null;
            }
            SearchClosestTargetProcessing(searchTargetObjectTag,comparisonTarget);
           

            //最も近いオブジェクトを返す
            return closestObject;
        }

        /// <summary>
        ///  TarGetObjectに一番近いclosestObjectを調べる。
        /// </summary>
        /// <param name="searchTargetObject"></param>
        /// <param name="comparisonTargetTag"></param>
        /// <returns></returns>
        public static GameObject SearchClosestTargetObject(/*誰に近いか*/GameObject searchTargetObject,string comparisonTargetTag)
        {
            closestObject = null;

            //探したいオブジェクトのタグがいなければそのままメソッドを閉じる。
            if (!ExistTarget(searchTargetObject.tag))
            {
                return null;
            }

            var comparisonTarget=GameObject.FindGameObjectWithTag(comparisonTargetTag);
            SearchClosestTargetProcessing(searchTargetObject.tag,comparisonTarget);
           

            //最も近いオブジェクトを返す
            return closestObject;
        }    
        
        /// <summary>
        ///  TarGetObjectに一番近いclosestObjectを調べる。
        /// </summary>
        /// <param name="searchTargetObjectTag"></param>
        /// <param name="comparisonTarget"></param>
        /// <returns></returns>
        public static GameObject SearchPlayerToClosestTargetObject(string searchTargetObjectTag)
        {
            closestObject = null;

            var comparisonTarget =GameObject.FindGameObjectWithTag("Player");
            //探したいオブジェクトのタグがいなければそのままメソッドを閉じる。
            if (!ExistTarget(searchTargetObjectTag))
            {
                return null;
            }
            
            SearchClosestTargetProcessing(searchTargetObjectTag,comparisonTarget);
           

            //最も近いオブジェクトを返す
            return closestObject;
        }


        private static void SearchClosestTargetProcessing(string searchTargetObjectTag,GameObject comparisonTarget)
        {
            nowClosestObjectDistance = Mathf.Infinity;
            //タグ指定されたオブジェクトを配列で取得する
            foreach (var closeObject in GameObject.FindGameObjectsWithTag(searchTargetObjectTag))
            {              

                //自身と取得したオブジェクトの距離をtmpDistanceに代入
                tmpObjectDistance = Vector3.Distance(closeObject.transform.position, comparisonTarget.transform.position);

                //tmpObjectDistanceとnowClosestObjectを比較して,tmpObjectDistanceは近ければ値の交換を行う
                //注意：nowClosestObjectDistanceの初期値は0の為以下の様な文になっている。
                if (!(tmpObjectDistance < nowClosestObjectDistance)) continue;
                //距離の値の交換
                nowClosestObjectDistance = tmpObjectDistance;
                //オブジェクトの値交換
                closestObject = closeObject;
            }
        }

        //単体での使用も可能。
        /// <summary>
        /// 探したいターゲットが居るのかをCheckするメソッド
        /// </summary>
        /// <returns></returns>
        public static bool ExistTarget(string closesObjectTagName)
        {
            var nowObject = GameObject.FindGameObjectWithTag(closesObjectTagName);
            //敵がいればTrueを返す
            return nowObject != null;
        }
    }
}
