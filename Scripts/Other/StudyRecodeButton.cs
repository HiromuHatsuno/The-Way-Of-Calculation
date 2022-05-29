using UnityEngine;

namespace MainAssets.Scripts.Other
{
   /// <summary>
   /// 勉強記録記録UIを表示するクラス
   /// </summary>
   public class StudyRecodeButton : MonoBehaviour
   {
      [SerializeField] private Canvas studyRecord;

      public void ArriveRecode()
      {
         studyRecord.enabled = true;
      }
      public void DefalseRecode()
      {
         studyRecord.enabled = false;
      }
   
   }
}
