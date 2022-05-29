using MainAssets.Scripts.Player.Animation;
using MainAssets.Scripts.Player.Attack;
using MainAssets.Scripts.Player.Core;
using MainAssets.Scripts.Player.Data;
using MainAssets.Scripts.Player.HasAttacked;
using MainAssets.Scripts.Player.Provider;
using MainAssets.Scripts.Player.SE;
using UnityEngine;

namespace MainAssets.Scripts.Player.Setting
{
    [RequireComponent(typeof(PlayerActorAnimation)), RequireComponent(typeof(PlayerActorCore)),
     RequireComponent(typeof(PlayerActorProvider)), RequireComponent(typeof(PlayerActorAttack)),
     RequireComponent(typeof(PlayerHasAttacked)),RequireComponent(typeof(PlayerData)),
     RequireComponent(typeof(PlayerSe))]
    //これをアタッチするとプレイヤーに必要なコンポーネントを自動でアタッチする
    public class PlayerSetting : MonoBehaviour
    {
        
    }
}