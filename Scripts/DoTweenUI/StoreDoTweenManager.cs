using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace MainAssets.Scripts.DoTweenUI
{
    /// <summary>
    /// StoreUIのDoTweenアニメーション
    /// </summary>
    public class StoreDoTweenManager : MonoBehaviour
    {
        public Image image;
        public Transform transformObj;
    
        public void PopUp()
        {
            image.enabled=true;
            image.DOFade(.56f, 1.5f).SetUpdate(true);
            transformObj.localScale = new Vector3(0f,0f,0f);
            transformObj.DOScale(1f,1f).SetUpdate(true) .SetEase(Ease.OutBack);;
        }

        public void OnClose()
        {
            image.enabled=false;
            Sequence seq = DOTween.Sequence(); 
            image.DOFade(0f, 1f).SetEase(Ease.InSine).SetUpdate(true);
            transformObj.DOScale(0f, .75f).SetUpdate(true).SetEase(Ease.InSine);
        }
    }
}
