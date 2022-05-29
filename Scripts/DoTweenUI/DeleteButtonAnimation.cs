using DG.Tweening;
using UnityEngine;

namespace MainAssets.Scripts.DoTweenUI
{
    /// <summary>
    /// デリートボタンのアニメーション
    /// </summary>
    public class DeleteButtonAnimation : MonoBehaviour
    {

        bool now_Anim=false;
        [SerializeField]
        RectTransform rectTran;
        Tweener tweener = null;
        [SerializeField]
        private float _to = -1f;
    

        public void can_Not_Delete_Anim()
        {
            // 再生中のアニメーションを停止/初期化
            if (tweener != null)
            {
                tweener.Kill();
                tweener = null;
                transform.localScale = Vector3.one;
            }
            Sequence seq = DOTween.Sequence();
            //スタートメソッドで、テキストの位置を取得して、
            //それを元に、位置を移動させる。
            seq.Append(rectTran.DOLocalMoveX( - 35, .1f));
            seq.Append(rectTran.DOLocalMoveX(0,.15f));
          
        }
  
    }
}
