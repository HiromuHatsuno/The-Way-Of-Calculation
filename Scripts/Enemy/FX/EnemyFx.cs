using MainAssets.Scripts.FX;
using UnityEngine;

namespace MainAssets.Scripts.Enemy.FX
{
    /// <summary>
    /// EnemyのEffectを再生するクラス。
    /// </summary>
    public class EnemyFx : MonoBehaviour
    {
        #region Particle保存変数
        public GameObject footDustParticle;
        public GameObject shockWaveParticle;
        public GameObject damageParticle;
        public GameObject knockBackParticle;
        #endregion
        
        /// <summary>
        /// 歩いた時の砂ぼこりを表示する。
        /// </summary>
        public void FootDustParticle()
        {
            var position = transform.position;
            Effect.Play(footDustParticle, position.x,position.y-.35f,position.z-.75f, Quaternion.identity);
        }

        //攻撃を受けた後の衝撃波のエフェクト
        public void ShockWaveParticle()
        {
            var position = transform.position;
            Instantiate(shockWaveParticle, new Vector3(position.x,0.1f,position.z), Quaternion.identity);
        }

        //ダメージを受けた際のエフェクトを表示
        public void DamageParticle()
        {
            var position = transform.position;
            Instantiate(damageParticle, new Vector3(position.x,position.y,position.z+1f), Quaternion.identity);
        }
        //KnockBackした際のエフェクトを表示
        public void KnockBackFX()
        {
            var position = transform.position;
            var particle =(GameObject)Instantiate(knockBackParticle, new Vector3(position.x-.5f,position.y-.5f,position.z+.1f), Quaternion.identity);
            particle.transform.parent = this.transform;
        }
    }
}