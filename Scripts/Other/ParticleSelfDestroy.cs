using UnityEngine;

namespace MainAssets.Scripts.Other
{
    //パ―ティクルを自動で消去するクラス
    public class ParticleSelfDestroy : MonoBehaviour
    {

        ParticleSystem particle;
        void Start()
        {
            particle = this.GetComponent<ParticleSystem>();
        }

        void Update()
        {
            if (particle.isStopped) //パーティクルが終了したか判別
            {
                Destroy(this.gameObject);//パーティクル用ゲームオブジェクトを削除
            }
        }
    }
}
