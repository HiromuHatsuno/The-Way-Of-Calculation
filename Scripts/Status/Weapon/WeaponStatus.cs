using UnityEngine;

namespace MainAssets.Scripts.Status.Weapon
{
    /// <summary>
    /// 武器のステータスを表すクラス
    /// </summary>
    public class WeaponStatus 
    {
        //AttackPoint
        private int maxAttackPoint;
        
        public int nowAttackPoint;
        public string name;

        //BalletSpeed
        [SerializeField]
        private float  limitSpeed = 5f;
        
        [SerializeField]
        private float  nowSpeed;



        public WeaponStatus(int maxAttackPoint,int attackPoint,string weaponName)
        {
            this.name = weaponName;
            this.maxAttackPoint = maxAttackPoint;
            this.nowAttackPoint = attackPoint;

            AdjustAttackPoint();
            UnityEngine.Debug.Log(
                "----設定された値----\n"
                        + "名前" + name
                        + "最大攻撃力" +maxAttackPoint
                        + "基本攻撃力" +attackPoint );

        }
        public WeaponStatus(int maxAttackPoint, int attackPoint,string weaponName, float limitSpeed, float nowSpeed) 
        {
            this.name = weaponName;
            this.maxAttackPoint = maxAttackPoint;
            this.nowAttackPoint = attackPoint;
            this.limitSpeed = limitSpeed;
            this.nowSpeed = nowSpeed;
            AdjustSpeed();
            
            AdjustAttackPoint();
            UnityEngine.Debug.Log(
                "----設定された値----\n"
                + "名前" + name
                + "最大攻撃力" +maxAttackPoint
                + "基本攻撃力" +attackPoint 
                + "基本攻撃力" +attackPoint 
                + "基本攻撃力" +attackPoint 
                
                );

        }

        private void AdjustAttackPoint()
        {
            //Attackの最大値よりもAttackの基礎値が多い場合は調整
            if (nowAttackPoint <= maxAttackPoint) return;
            this.nowAttackPoint = maxAttackPoint;
            UnityEngine.Debug.LogWarning("設定された現在値が最大値よりも大きい値でした。");
        }
     

        /// <summary>
        /// 引数分攻撃力を増加する
        /// </summary>
        /// <param name="value"></param>
        public void AddAttackPoint(int value)
        {
            nowAttackPoint += value;
            AdjustAttackPoint();
        }
        
        /// <summary>
        /// Speedを調整する
        /// </summary>
        private void AdjustSpeed()
        {
            //Speedの最大値よりもSpeedが多い場合は、Speedを最大値に調整
            if (nowSpeed < limitSpeed) return;
            this.nowSpeed = limitSpeed;
            
            UnityEngine.Debug.LogWarning("設定された現在値が最大値よりも大きい値でした。");
        }

        /// <summary>
        /// nowSpeedを取得するメソッド
        /// </summary>
        /// <returns></returns>
        public float GetSpeed()
        {
            return nowSpeed;
        }

        /// <summary>
        /// 引数分弾速を増加する
        /// </summary>
        /// <param name="value"></param>
        public void AddSpeed(float value)
        {
            nowSpeed += value;
            AdjustSpeed();
        }

    }
}