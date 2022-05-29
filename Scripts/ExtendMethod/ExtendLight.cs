using UnityEngine;

namespace MainAssets.Scripts.ExtendMethod
{
  public static class ExtendLight {

    public static void LightLerp(this Light a, float b, float t)
    {
      t = Mathf.Clamp01(t);
      var intensity = a.intensity;
      intensity= intensity + (b - intensity) * t;
      a.intensity = intensity;
    }
  }
}
