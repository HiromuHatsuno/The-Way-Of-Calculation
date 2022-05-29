using MainAssets.Scripts.Status.Weapon;

namespace MainAssets.Scripts.InterFace
{
    /// <summary>
    /// ノックバックさせる武器を表すインターフェイス
    /// </summary>
    public interface IKnockBackWeapon
    {
        KnockBackWeaponStatus GetKnockBackStatus();
    }
}