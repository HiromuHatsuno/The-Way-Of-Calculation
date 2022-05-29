using MainAssets.Scripts.InterFace;
using MainAssets.Scripts.Weapon;
using UnityEngine;

namespace Assets.Assets.Scripts.Attack
{
    /// <summary>
    /// 攻撃成功時に呼び出されるクラス
    /// </summary>
    public static class AttackSuccessService 
    {
        /// <summary>
        /// 攻撃成功処理
        /// </summary>
        /// <param name="attackTarget">攻撃を受けるターゲット</param>
        /// <param name="attackWeapon">攻撃する武器</param>
        public static void SuccessAttack(GameObject attackTarget,WeaponBehavior attackWeapon)
        {
            if (!attackTarget.TryGetComponent<IAttackedService>(out var attackService))
            { 
                //TryGetComponent失敗時の処理
                return;
            }
            attackService.ReceiveDamage(attackWeapon);
          
        }
    }
}