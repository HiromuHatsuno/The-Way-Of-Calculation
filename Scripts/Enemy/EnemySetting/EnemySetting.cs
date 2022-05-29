using Assets.Assets.Scripts.Enemy.Provider;
using Main_Assets.Scripts.Enemy.Enemy;
using MainAssets.Scripts.Enemy.Animation;
using MainAssets.Scripts.Enemy.Attack;
using MainAssets.Scripts.Enemy.Core;
using MainAssets.Scripts.Enemy.FX;
using MainAssets.Scripts.Enemy.HasAttacked;
using MainAssets.Scripts.Enemy.Move;
using UnityEngine;

//敵にしたいオブジェクトにアタッチすると自動で必要なクラスをアタッチしてくれる。
namespace MainAssets.Scripts.Enemy.EnemySetting
{
    [RequireComponent(typeof(EnemyAnimation)), RequireComponent(typeof(EnemyCore)),
   RequireComponent(typeof(EnemyAttack)), RequireComponent(typeof(EnemyFx)),
   RequireComponent(typeof(EnemyHasAttacked)),RequireComponent(typeof(EnemyMove)),
   RequireComponent(typeof(EnemySe)),RequireComponent(typeof(EnemyProvider))]
    public class EnemySetting : MonoBehaviour
    {
    }
}            