using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 問題の正答を作成するクラス
/// </summary>
public partial class Generate_Question : MonoBehaviour
{
    //生成した数字と符号を用いて、答えを計算します。
    private void calcAnswer() 
    {
        switch (getSign)
        {
            case thisGameSign.plus:
                intAnswerNumber = intLeftNumber + intRightNumber;
                break;
            case thisGameSign.minus:
                intAnswerNumber = intLeftNumber - intRightNumber;
                break;
            case thisGameSign.kakeru:
                intAnswerNumber = intLeftNumber * intRightNumber;
                break;
            case thisGameSign.waru:
                intAnswerNumber = Random.Range(1,9);
                break;
        
        }

    }
}
