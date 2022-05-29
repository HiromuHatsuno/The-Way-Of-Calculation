using Com.LuisPedroFonseca.ProCamera2D;
using UnityEngine;

namespace MainAssets.Scripts.ProCamera
{
    /// <summary>
    /// カメラを揺らすクラス
    /// </summary>
    public class Shake_Camera : MonoBehaviour
    {
        bool _constantShaking;

        public static void Tap_to_Shake()
        {

            var shakePreset = ProCamera2DShake.Instance.ShakePresets[3];

            ProCamera2DShake.Instance.Shake(shakePreset);

        }

    }
}