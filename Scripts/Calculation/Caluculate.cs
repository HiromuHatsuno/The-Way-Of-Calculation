using MainAssets.Scripts.Actor;
using UnityEngine;

namespace MainAssets.Scripts.Calculation
{
    /// <summary>
    /// 計算を行うクラス（1秒間に進む距離を計算する）
    /// </summary>
    public static class Caluculate
    {
        //TargetObjectが1秒間に進む距離を返す。
        public static float caluculateMoveSpeed(GameObject TargetObject)
        {
            //speedは、1秒間に進む距離
            return  TargetObject.GetComponent<ActorCore>().status.GetPerSeCond();
        }   
    
    }
}
