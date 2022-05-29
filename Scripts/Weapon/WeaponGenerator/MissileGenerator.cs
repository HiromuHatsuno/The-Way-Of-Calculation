using UnityEngine;

namespace Main_Assets.Scripts.Weapon
{
    public class MissileGenerator : MonoBehaviour
    {

        //弾丸のゲームオブジェクト
        [SerializeField] private GameObject missile;

        //弾丸の発射FX
        [SerializeField] private ParticleSystem flashFX;

        [SerializeField] private Vector3 generateMissilePosition;

        //弾丸を生成するプログラム
        public void GenerateMissile()
        {
            Instantiate(missile, gameObject.transform.position+generateMissilePosition, Quaternion.identity);
        }

    }
}