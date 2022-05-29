using DG.Tweening;
using MainAssets.Scripts.InterFace;
using MainAssets.Scripts.Status.Actor;
using MainAssets.Scripts.Status.Weapon;
using MainAssets.Scripts.Weapon;
using UnityEngine;

namespace MainAssets.Scripts.KnockBack
{
    /// <summary>
    /// ノックバック機能を統括するクラス
    /// </summary>
    public static class KnockBackFunction
    {
        /// <summary>
        /// ノックバックするメソッド
        /// </summary>
        /// <param name="weaponStatus"></param>
        /// <param name="objectStatus"></param>
        public static void DoKnockBack(KnockBackWeaponStatus weaponStatus, KnockBackObjectStatus objectStatus)
        {
           
            //一度速度をゼロにする事で、予定通りの角度に吹っ飛ばす。
            objectStatus.rigidBody.velocity = Vector2.zero;
            objectStatus.rigidBody.AddForce(
                weaponStatus.isRightDirection
                    ? new Vector2(GetKnockBackValue(weaponStatus).x, GetKnockBackValue(weaponStatus).y)
                    : new Vector2(GetKnockBackValue(weaponStatus).x - 1, GetKnockBackValue(weaponStatus).y),
                ForceMode2D.Impulse);
        }

        //ノックバックパワーに係数をかける
        public static void ChangeRatioPower(KnockBackWeaponStatus weaponStatus,float ratio)
        {
            weaponStatus.knockBackPower *= ratio;
        }

        //ノックバック角度を得る関数
        private static Vector2 GetKnockBackValue(KnockBackWeaponStatus weaponStatus)
        {
            return weaponStatus.knockBackDirection;
        }
        public static bool HasKnockBackObjectStatus(GameObject gameObject)
        {
            return gameObject.GetComponent<KnockBackObjectStatus>()!=null;
        }
        public static bool HasKnockBackWeaponStatus(GameObject gameObject)
        {
            return gameObject.GetComponent<KnockBackObjectStatus>()!=null;
        }
        public static void ChangePhysicsMaterial(KnockBackObjectStatus status,PhysicsMaterial2D physicsMaterial)
        {
            status.boxCollider2D.sharedMaterial = physicsMaterial;
        }

        public static bool IsImplementation(WeaponBehavior weapon)
        {
           return weapon.IsSameOrSubclassOf<IKnockBackWeapon>();
        }
    }
}