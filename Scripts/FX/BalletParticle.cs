using UnityEngine;

namespace MainAssets.Scripts.FX
{
    public class BalletParticle: MonoBehaviour
    {
        public ParticleSystem flashFX;
        
        public void Start()
        {
            flashFX = GetComponent<ParticleSystem>();
        }
        private void OnParticleSystemStopped()
        {
            flashFX.Play();
        }
    }
}
