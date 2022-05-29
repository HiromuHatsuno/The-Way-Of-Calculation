using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace MainAssets.Scripts.Weapon.FX
{
    /// <summary>
    /// 武器のエフェクトを表示するクラス
    /// </summary>
    public class WeaponFX : MonoBehaviour
    {
        [SerializeField]
        private int selectedShowAttackFx;
        
        [SerializeField]
        private List<GameObject> hitSwordParticle;

        [FormerlySerializedAs("GenerateFXPositionOffset")] [SerializeField]
        private Vector3 generateFXPositionOffset;

        public void SuccessAttackShowFX()
        {
            Vector3 position = transform.position;
            Instantiate(hitSwordParticle[selectedShowAttackFx],position+generateFXPositionOffset, Quaternion.identity);
        }
        public void SuccessAttackShowRandomFX()
        {
            Vector3 position = transform.position;
            var random = Random.Range(0, hitSwordParticle.Count);
            Instantiate(hitSwordParticle[selectedShowAttackFx],position+generateFXPositionOffset, Quaternion.identity);
        }
    }
}