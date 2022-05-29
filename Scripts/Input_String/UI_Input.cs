using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using MainAssets.Scripts.Player.Provider;

/// <summary>
/// 回答を表すpartialクラス 
/// </summary>
public partial class UI_Input : MonoBehaviour
{

    private float size = .2f;

    private float duration = .2f;
    Tweener tweener = null;

    [Range(0, 9)] [SerializeField] private int Button_Number;

    //答えの数：この情報を基に
    public static string Answer_Number;
    public GameObject Answer_Text;
    /// <summary>
    /// 初期化処理
    /// </summary>
    void Start()
    {
        Answer_Number = "";
         Answer_Text= GameObject.FindGameObjectWithTag("Answer");
        generateQuestion = GameObject.FindGameObjectWithTag("Question").GetComponent<Generate_Question>();
        playerProvider = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerActorProvider>();
    }


    /// <summary>
    /// 引数の値を回答欄に”上書き”する
    /// </summary>
    /// <param name="_buf"></param>
    private void set_Text(string _buf)
    {
        UI_Answer.answer_text.text = UI_Input.Answer_Number;
        // 再生中のアニメーションを停止/初期化
        if (tweener != null)
        {
            tweener.Kill();
            tweener = null;
            Answer_Text.transform.localScale = Vector3.one;
        }
        tweener = Answer_Text.transform.DOPunchScale(
            punch: Vector3.one * size,
            duration: 0.45f,
            vibrato: 2
        ).SetEase(Ease.OutExpo);
    }

    /// <summary>
    /// 引数の値を回答欄に”追記”する
    /// </summary>
    /// <param name="number"></param>
    private void Add_Text(int number)
    {
        UI_Input.Answer_Number = String.Concat(UI_Input.Answer_Number, Convert.ToString(number));

        //回答欄に設定
        this.set_Text(UI_Input.Answer_Number);
    }



    //入力数値のチェックと更新
    private void checkAndSetNumber(int _button_Number)
    {
        //入力チェック：
        //ゼロは先頭に入らないようにする
        if (_button_Number == 0)
        {
            if (UI_Input.Answer_Number == null) { return; }
            if (UI_Input.Answer_Number == "") { return; }
        }

        //値の設定
        this.Add_Text(_button_Number);

    }

 

}
