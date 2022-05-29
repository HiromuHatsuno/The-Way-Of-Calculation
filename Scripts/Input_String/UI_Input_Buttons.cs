using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;
using KanKikuchi.AudioManager;
using Com.LuisPedroFonseca.ProCamera2D;
using Main_Assets.Scripts.@abstract;
using MainAssets.Scripts.Player.Provider;
using MainAssets.Scripts.ProCamera;
using OTHER_Product_Assets.AudioManager_KanKikuchi.Scripts;
using UnityEngine.Serialization;

//回答のボタンを表すpartialクラス 
public partial class UI_Input : MonoBehaviour
{
    
    [SerializeField]
    private PlayerActorProvider playerProvider;
    Generate_Question generateQuestion;

    
    /// <summary>
    /// ボタン押下：数字のボタン
    /// </summary>
    public void click_Input_Number()
    {
      
        this.checkAndSetNumber(Button_Number);
    }

    /// <summary>
    /// ボタン押下：デリート
    /// </summary>
    public void ClickDeleteKey()
    {
        switch (UI_Input.Answer_Number)
        {
            //チェック処理
            case null:
                SEManager.Instance.Play(SEPath.CAN_NOT_DELEATE,1,0,0.55f);
                return;
            case "":
                SEManager.Instance.Play(SEPath.CAN_NOT_DELEATE, 1, 0, 0.55f);
                return;
        }

        SEManager.Instance.Play(SEPath.DECISION42);
        //1文字削除
        UI_Input.Answer_Number = Answer_Number.Substring(0, UI_Input.Answer_Number.Length - 1);

        //画面に反映        
        this.set_Text(UI_Input.Answer_Number);
        
    }
   

    /// <summary>
    /// ボタン押下：決定
    /// </summary>
    public void ClickDecisionsKey()
    {
        switch (UI_Input.Answer_Number)
        {
            //チェック処理
            case null:
                Shake_Camera.Tap_to_Shake();
                SeArrayManager.instance.Play_Random_SE(SeArrayManager.FOLDER_NAME.Miss_Compute); 
                return;
            case "":
                Shake_Camera.Tap_to_Shake();
                SeArrayManager.instance.Play_Random_SE(SeArrayManager.FOLDER_NAME.Miss_Compute);
                return;
        }
        
        if (int.Parse(UI_Input.Answer_Number) == Generate_Question.intAnswerNumber)
        {
            //正解時処理
            //正解時のアニメーション変化
            //正解するとUnityちゃんが攻撃する
            playerProvider.attack.Attack();

            //正解時SE再生
            SeArrayManager.instance.Play_Random_SE(SeArrayManager.FOLDER_NAME.Success_Compute);
            //回答欄の初期化処理
            UI_Input.Answer_Number = "";
            this.set_Text(UI_Input.Answer_Number);
 
            //問題が合っているので、次の問題を生成します。
            generateQuestion.generate_Question();
            playerProvider.data.correctQestions++;
            GameScore.correctAnswer++;

        }
        else
        {
            Shake_Camera.Tap_to_Shake();
            SeArrayManager.instance.Play_Random_SE(SeArrayManager.FOLDER_NAME.Miss_Compute);
            UI_Input.Answer_Number = "";
            this.set_Text(UI_Input.Answer_Number);
        }
    }






}
