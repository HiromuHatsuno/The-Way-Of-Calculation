using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace MainAssets.Scripts.DoTweenUI
{

    /// <summary>
    ///押しボタンのアニメーション
    /// </summary>
    public class ButtonPushAnimation : Button
    {
        [SerializeField]
        private float size = .7f;

        [SerializeField]
        private float duration = .5f;
        Tweener tweener = null;
        new void Start()
        {
            base.Start();

            // ボタンアニメーション
            onClick.AddListener(() =>
            {
                // 再生中のアニメーションを停止/初期化
                if (tweener != null)
                {
                    tweener.Kill();
                    tweener = null;
                    transform.localScale = Vector3.one;
                }
                tweener = transform.DOPunchScale(
                    punch: Vector3.one * size,
                    duration: 0.45f,
                    vibrato: 2
                ).SetEase(Ease.OutExpo).SetUpdate(true);
            });
        }
    }
}