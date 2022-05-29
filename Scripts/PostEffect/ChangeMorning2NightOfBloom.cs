using Assets.Scripts.OneDay;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace MainAssets.Scripts.PostEffect
{
    //朝から夜にBloomを変更する処理
    public class ChangeMorning2NightOfBloom:MonoBehaviour
    {
        private Bloom morningBloom;
        private Bloom eveningBloom;
        private Bloom nightBloom;
        private Bloom nowBloom;

        [SerializeField] private Volume morningVolume;

        [SerializeField] private Volume nowVolume;

        [SerializeField] private Volume nightVolume;

        [SerializeField] private TimeOfDayManager time;

        [SerializeField]
        private bool changeIntensity;
        [SerializeField]
        private bool changeThreshold;
        [SerializeField]
        private bool changeTint;
        
        [SerializeField] float endOfTime = 1;
        private float startTime;
        
        void Start()
        {
            startTime = Time.timeSinceLevelLoad;

            nowBloom.intensity.value = morningBloom.intensity.value;
        }
        //BloomのIntensityを変更していくメソッド
        public void SmoothDamp2SmoothnessOfNight()
        {
            if (changeIntensity) nowBloom.intensity.value = Mathf.MoveTowards(nowBloom.intensity.value,nightBloom.intensity.value,0.001f);
            if (changeTint)
                nowBloom.tint.value = Color.red; 
        }
    }
}
