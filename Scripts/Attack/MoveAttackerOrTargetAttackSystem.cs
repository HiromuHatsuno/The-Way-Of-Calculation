using Main_Assets.Scripts.@abstract;
using Main_Assets.Scripts.ExtendMethod;
using MainAssets.Scripts.ExtendMethod;
using MainAssets.Scripts.InterFace;
using MainAssets.Scripts.Search;
using MainAssets.Scripts.Status.Actor;
using UnityEngine;

namespace Assets.Scripts.Attack
{
    /// <summary>
    /// 敵or味方のどちらか一方が動くゲームにおける攻撃システム
    /// 攻撃アニメーションの再生まで行う。
    /// </summary>
    public static class MoveAttackerOrTargetAttackSystem
    {
        #region 変数
        
        //Targetタグの名前
        private static readonly  string TargetTagName="TargetObject";
        
        //GameObject取得
        private static GameObject attackTargetObj;
        private static GameObject attackerTargetObj;
        
        //ActorProviderの取得
        private static ActorProvider attackTarget;
        private static ActorProvider attackerTarget;
        
        //BoxColliderの取得
        private static BoxCollider2D attackTargetCol;
        private static BoxCollider2D attackerTargetCol;
        
        //Positionの取得
        private static Vector2 attackTargetPosition;
        private static Vector2 attackerTargetPosition;
        
        //遠距離攻撃可能かのbool
        private static bool canAttackLongRangeAttack;
        
        //動く速さの計算用変数
        private  static  float moveSpeed;

        //攻撃者と攻撃される側との距離
        private static float distanceOfTarget;
        
        //近距離攻撃の限界距離
        private static float maxShortRangeAttackOfDistance=2.5f;

        //colliderOffset距離
        private static float colliderOffset;
        
        #endregion
        
        //-----------------------------------------------------------------------------------------------------------//
        //------------------------------------Attack部分--------------------------------------------------------------//
        //----------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// 攻撃処理
        /// </summary>
        /// <param name="attackerTargetObj">攻撃者</param>
        /// <param name="attackTargetTag">攻撃されるターゲット</param>
        public static void Attack(GameObject attackerTargetObj, string attackTargetTag)
        {
            if (ExistAttackTarget(attackTargetTag))
            {
                attackTargetObj = SearchTarget.SearchClosestTargetObject(attackTargetTag,attackerTargetObj);
            }
            GameObjectConvertProvider(attackTargetObj,attackerTargetObj);
            //それぞれのステートの変更処理
            ChangeState2Attack();
            //TargetとAttackerの位置を調べる。いわゆる攻撃範囲
            distanceOfTarget=SettingDistanceOfAttacker2Target();
            //TargetとAttackerの攻撃を決定する。遠距離攻撃か近距離攻撃
            PlayAnimationOfAttackAnim();
        }
        /// <summary>
        /// プレイヤーの場合のアタック処理
        /// </summary>
        /// <param name="attackerTargetObj"></param>
        /// <param name="attackTargetTag"></param>
        /// <param name="maxShortRangeAttackOfDistance"></param>
        public static void Attack(GameObject attackerTargetObj, string attackTargetTag,float maxShortRangeAttackOfDistance)
        {
            MoveAttackerOrTargetAttackSystem.maxShortRangeAttackOfDistance = maxShortRangeAttackOfDistance;
            if (ExistAttackTarget(attackTargetTag))
            {
                attackTargetObj = SearchTarget.SearchClosestTargetObject(attackTargetTag,attackerTargetObj);
            }
            GameObjectConvertProvider(attackTargetObj,attackerTargetObj);
            //それぞれのステートの変更処理
            ChangeState2Attack();
            //TargetとAttackerの位置を調べる。いわゆる攻撃範囲
            distanceOfTarget=SettingDistanceOfAttacker2Target();
            //TargetとAttackerの攻撃を決定する。遠距離攻撃か近距離攻撃
            PlayAnimationOfAttackAnim();
        }

        //-----------------------------------------------------------------------------------------------------------//
        //------------------------------------攻撃ターゲットが存在するか調べるメソッド--------------------------------------//
        //----------------------------------------------------------------------------------------------------------//
        public static bool ExistAttackTarget(string searchTargetTag)
        {
            var existTarget = SearchTarget.ExistTarget(searchTargetTag);
            //探したいオブジェクトのタグがいなければそのままメソッドを閉じる。
            if (existTarget) return true;
            return false;
        }

        //-----------------------------------------------------------------------------------------------------------//
        //------------------------------------攻撃アニメーションを再生する。----------------------------------------------//
        //----------------------------------------------------------------------------------------------------------//
        
        private static void PlayAnimationOfAttackAnim()
        {
           //ターゲットとの距離が近距離攻撃を可能とする最大距離よりも
           //小さければ近距離攻撃のアニメーションを再生する。
           if (distanceOfTarget <= maxShortRangeAttackOfDistance)
           {
               attackerTarget.anim.DefaultAttackAnimation();
               return;
           }
           //それ以外なら遠距離攻撃を再生する。
           var a = attackerTarget.anim is IShootingAnim;
            if (attackerTarget.anim is IShootingAnim==false) return;
            //ダウンキャスト
            var shootingActorAnim =(IShootingAnim)attackerTarget.anim;
            shootingActorAnim.PlayShootingAnimation();
        }

        /// <summary>
        /// GameObjectを元にActorProviderをTryGetComponentして変数を設定する
        /// </summary>
        /// <param name="attackTargetObj"></param>
        /// <param name="attackerTargetObj"></param>
        private static void GameObjectConvertProvider(GameObject attackTargetObj,GameObject attackerTargetObj)
        {
            //アタッチできなければエラーを出力する。
            if (!attackerTargetObj.TryGetComponent<ActorProvider>(component: out attackerTarget)) ;
            if(!attackTargetObj.TryGetComponent<ActorProvider>(component: out attackTarget));
        }

        
        //-----------------------------------------------------------------------------------------------------------//
        //------------------------------------Stateを変更するメソッド---------------------------------------------------//
        //----------------------------------------------------------------------------------------------------------//
        private static void ChangeState2Attack()
        {
            attackerTarget.core.status.ChangeState(ActorStatus.ActorState.Attack);
        }


        //-----------------------------------------------------------------------------------------------------------//
        //------------------------------------近距離攻撃と遠距離攻撃を決定する計算---------------------------------------//
        //------------------------------------それに必要な変数を設定する----------------------------------------------//
        private static float SettingDistanceOfAttacker2Target()
        {
            //計算に必要な変数を設定する
            SettingVariable();
            
            colliderOffset = SettingCollisionOffset();

            //最終的な位置
            var targetOfDistance = SettingCanAttackDistance();
            return targetOfDistance;
        }

     

        //-----------------------------------------------------------------------------------------------------------//
        //------------------------------------変数代入メソッド--------------------------------------------------------------//
        //----------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// 攻撃範囲の計算の為の変数を代入する。
        /// </summary>
        private static void SettingVariable()
        {
            SettingBoxColliderVar();
            SettingPositionVar();
            SettingMoveSpeedVar();
        }
        /// <summary>
        /// BoxColliderを設定する。
        /// </summary>
        private static void SettingBoxColliderVar()
        {
            //BoxColliderの取得
            //攻撃される側attackと攻撃する側attackerのColliderを指定する。
            attackTargetCol = attackTarget.core.boxCollider2D;
            attackerTargetCol = attackerTarget.core.boxCollider2D;
        }

        /// <summary>
        /// Positionを設定する
        /// </summary>
        private static void SettingPositionVar()
        {
            //Positionの取得
            //攻撃される側attackと攻撃する側attackerのPositionを指定する。
            attackTargetPosition = attackTarget.core.transform.position;
            attackerTargetPosition = attackerTarget.core.transform.position;
        }

        /// <summary>
        /// 動く速度を変数に設定する。
        /// </summary>
        private static void SettingMoveSpeedVar()
        {
            //長距離攻撃が出来るかのbool変数を設定する
            canAttackLongRangeAttack = attackerTarget.core.status.isPlayer;
            
            //遠距離攻撃可能ならば、プレイヤーで有る為、プレイヤーの現在速度を代入
            //遠距離攻撃不可能ならば、敵で有る為敵の現在速度を代入
            if (canAttackLongRangeAttack)
                moveSpeed = attackTarget.core.status.nowSpeed;
            else
                moveSpeed = attackerTarget.core.status.nowSpeed;
        }
        //-----------------------------------------------------------------------------------------------------------//
        //------------------------------------計算メソッド--------------------------------------------------------------//
        //----------------------------------------------------------------------------------------------------------//
        private static float SettingCollisionOffset()
        {
            return attackTargetCol.GetRadius().x+attackerTargetCol.GetRadius().x;
        }
        private static float SettingCanAttackDistance()
        {
            return  CalculateDistance.XAxisDistance(attackTargetPosition, attackerTargetPosition)
                - colliderOffset - (moveSpeed/60);
        }
    }        
}