using UnityEngine;

namespace MainAssets.Scripts.Player.FX
{
    /// <summary>
    /// Playerのエフェクトを統括するクラス
    /// </summary>
    public class PlayerFX : MonoBehaviour
    {
        public GameObject footDustParticle;
        public GameObject shockWaveParticle;
        public GameObject damageParticle;
        
        public void DamageParticle()
        {
            var position = transform.position;
            Instantiate(damageParticle, new Vector3(position.x,position.y,position.z+1f), Quaternion.identity);
        }
    }
}