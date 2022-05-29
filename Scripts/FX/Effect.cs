using UnityEngine;

namespace MainAssets.Scripts.FX
{
    /// <summary>
    /// Effect(Particle)を表示するクラス
    /// </summary>
    public static class Effect
    {
        /// <summary>
        /// FX表示メソッド
        /// </summary>
        /// <param name="fx"></param>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="Z"></param>
        /// <param name="quaternion"></param>
        public static void Play(GameObject fx, float X,float Y,float Z,Quaternion quaternion)
        {
            UnityEngine.Object.Instantiate(fx,new Vector3(X,Y,Z),quaternion);
        }
        /// <summary>
        /// 3D∧回転指定なし
        /// </summary>
        /// <param name="fx"></param>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="Z"></param>
        public static void Play(GameObject fx, float X,float Y,float Z)
        {
            UnityEngine.Object.Instantiate(fx,new Vector3(X,Y,Z),Quaternion.identity);
        }
        /// <summary>
        /// 2D∧回転指定有。
        /// </summary>
        /// <param name="fx"></param>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="quaternion"></param>
        public static void Play(GameObject fx, float X,float Y,Quaternion quaternion)
        {
            UnityEngine.Object.Instantiate(fx,new Vector2(X,Y),quaternion);
        } 
        /// <summary>
        /// 2D∧回転指定無。
        /// </summary>
        /// <param name="fx"></param>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        public static void Play(GameObject fx, float X,float Y)
        {
            UnityEngine.Object.Instantiate(fx,new Vector2(X,Y),Quaternion.identity);
        }
    }
}