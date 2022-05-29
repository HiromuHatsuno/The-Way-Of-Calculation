using MainAssets.Scripts.Weapon;

namespace MainAssets.Scripts.InterFace
{
    /// <summary>
    /// 攻撃される側を表すinterface
    /// </summary>
    public interface IAttackedService {
        void ReceiveDamage(WeaponBehavior weapon);
    }
}
