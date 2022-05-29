using System.Collections.Generic;
using MainAssets.Scripts.Player.Provider;
using MainAssets.Scripts.ProCamera;
using UnityEngine;

namespace MainAssets.Scripts.GenerateEnemies
{
  //敵をフィールドに生成するクラス
  public class GenerateEnemies : MonoBehaviour
  {
    
    [SerializeField] 
    //敵の出現率クラス
    private EnemyAllPriority enemyAllPriority;
    [SerializeField]
    private PlayerActorProvider provider;
    private float callTime;
    private GameObject instanceEnemyGameObject;
    
    /// <summary>
    /// 初期化処理
    /// </summary>
    private void Start()
    {
      DecisionCallTime();
      InstanceEnemy();
    }
    /// <summary>
    /// 敵を生成する処理
    /// </summary>
    public void InstanceEnemy()
    {
      DecisionCallTime();
      SelectInstantiateGameObject();
      InstantiateGameObject();
      Invoke("InstanceEnemy", callTime);
    }

    /// <summary>
    /// 敵が出現する間隔を決めるメソッド
    /// </summary>
    public void DecisionCallTime()
    {
      callTime = enemyAllPriority.enemyPriorityTables[provider.data.level-1].appearanceTime;
    }

    /// <summary>
    /// 登場する敵を選択する処理
    /// </summary>
    public void SelectInstantiateGameObject()
    {
      var sum = 0;
      var numDigit=new List<int>();

      foreach (var enemyPriority in enemyAllPriority.enemyPriorityTables[provider.data.level-1].enemyPriorities)
      {
        sum += enemyPriority.priority;
        numDigit.Add(sum); 
      }

      var rand = UnityEngine.Random.Range(0, sum);
      int j = 0;
      foreach (var i in numDigit)
      {
        if (rand <= i)
        {
          instanceEnemyGameObject=enemyAllPriority.enemyPriorityTables[provider.data.level - 1].enemyPriorities[j].enemy;
          return;
        }
        j++;
      }
    }

    /// <summary>
    ///GameObjectを生成する処理
    /// </summary>
    public void InstantiateGameObject()
    {
      Instantiate(instanceEnemyGameObject,new Vector3(gameObject.transform.position.x,gameObject.transform.position.y,gameObject.transform.position.z+Random.Range(-0.5f,0.5f)),Quaternion.identity);
      ProCamera2DController.SearchNewTarget(provider.gameObject,"Enemy");
    }
  }
}
