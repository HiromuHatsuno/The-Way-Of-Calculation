using UnityEngine.UI;

namespace MainAssets.Scripts.Status.Actor
{
    /// <summary>
    /// HPもSpeedその他もろもろ一元管理するクラス。
    /// </summary>
    public class ActorStatus 
    {
        //Name
        public string name;
        //HP
        public  float  maxHP=0;
        public  float  HPDeadLine=0;
        public  float  nowHp=0;
        public int gold=0;

        //HPSlider
        public Slider slider;

        //Speed
        public float  limitSpeed=5f;
        public float  nowSpeed;

        //Playerか否か
        public bool isPlayer = false;
        public ActorState actorState;
        public enum ActorState
        {
            Move,
            Stop,
            Attack,
            Attacked,
            Alive,
            Dead,    
        }


        /// <summary>
        /// 速度を持たないオブジェクトの初期化処理
        /// </summary>
        /// <param name="maxHP"></param>
        /// <param name="HPDeadLine"></param>
        /// <param name="nowHP"></param>
        /// <param name="name"></param>
        public ActorStatus(float maxHP, float HPDeadLine, float nowHP,Slider slider,string name = "none")
        {   
            //代入処理
            this.name = name;
         
            this.maxHP = maxHP;
            this.HPDeadLine = HPDeadLine;
            this.nowHp = nowHP;
            this.slider = slider;
            AdjustHp();
            //Debug.Logにステータスが表示される
            DisplayStatus();
            this.actorState = ActorState.Alive;
        }

        /// <summary>
        /// 値のセットを行う。不正値が入力されれば警告になるよ。
        /// </summary>
        private void AdjustHp()
        {
            //HPの最大値よりもHPが多い場合は、HPを最大値に調整
            if (nowHp > maxHP)
            {
                this.nowHp = maxHP;
                UnityEngine.Debug.Log("設定された最小値が現在値よりも大きい値でした。");
            }
            //HPの最小値よりもHPが少ない場合は、死亡したことにする。
            if (nowHp <= HPDeadLine)
            {
                UnityEngine.Debug.Log("HPが無くなりました。");
                actorState = ActorState.Dead;
            };
            //HPの最大値よりもHPの最小値が大きい場合は、エラーを呼び出す
            if (maxHP<HPDeadLine) 
            {
                UnityEngine.Debug.LogError("設定されたHPが不正値です。");
            }
            SetSlider();
        }


        /// <summary>
        /// 値のセットを行う。不正値が入力されれば警告になるよ。
        ///</summary>
        private void AdjustSpeed()
        {
            //Speedの最大値よりもSpeedが多い場合は、nowSpeedを最大値に調整
            if (nowSpeed > limitSpeed)
            {
                this.nowSpeed = limitSpeed;
                UnityEngine.Debug.LogWarning("設定された最小値が現在値よりも大きい値でした。");
            }
        }

        /// <summary>
        /// 引数分HPを減らす
        /// </summary>
        /// <param name="value"></param>
        public void DamageHp(int value)
        {
            nowHp -= value;
            AdjustHp();
        }
        /// <summary>
        /// 引数分HPを回復する。
        /// </summary>
        /// <param name="value"></param>
        public void RecoveryHp(float value)
        {
            nowHp += value;
            AdjustHp();
        }

        private void SetSlider()
        {            
            this.slider.maxValue = maxHP;
            slider.value = nowHp;
        }

        /// <summary>
        /// 引数分Speedを減らす
        /// </summary>
        /// <param name="value"></param>
        public void MinusSpeed(float value)
        {
            nowSpeed -= value;
            AdjustSpeed();
        }
        /// <summary>
        /// 引数分HPを回復する。
        /// </summary>
        /// <param name="value"></param>
        public void AddSpeed(float value)
        {
            nowSpeed += value;
            AdjustSpeed();
        }

        /// <summary>
        /// HPの平均を小数点で表示する。
        /// </summary>
        /// <returns></returns>
        public float GetHpRate()
        {
            return nowHp / maxHP;
        }

        /// <summary>
        /// 外からステートを変更する際はココから呼び出すと安全
        /// </summary>
        /// <param name="actorState"></param>
        public void ChangeState(ActorState actorState)
        {
            var temp = this.actorState;
            this.actorState = actorState;
        }

        /// <summary>
        /// 速度を元に秒速を取得する
        /// </summary>
        /// <returns></returns>
        public float GetPerSeCond()
        { 
            return nowSpeed / 60;
        }

        private void DisplayStatus()
        {
            UnityEngine.Debug.Log("----設定された値----\n"
                                  +"・名前："+name
                                  + "\n・最大値：" + maxHP
                                  + "\n・現在値：" + nowHp
                                  + "\n・最小値：" + HPDeadLine);
                      
        }
    }
}
