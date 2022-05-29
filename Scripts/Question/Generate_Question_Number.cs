using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//問題の左と右の数字を決定するクラス
public partial class Generate_Question : MonoBehaviour
{
    //左辺・右辺：それぞれの数字の決定
    private void setNumber()
    {
        //割り算のみ別処理を施す。
        if (getSign == thisGameSign.waru)
        {
            int maxNum=ChoiceRandomRangeOfDigitNum(intRightNumber,false);
            if (maxNum==0)
            {
                maxNum++;
            }
            int First_Digits=Random.Range(1,maxNum), Second_Digits=Random.Range(0,2);
            intRightNumber = int.Parse(Second_Digits.ToString() + First_Digits.ToString());
            intLeftNumber = intAnswerNumber * intRightNumber;
            return;
        }

        //以降割り算以外の処理
        intRightNumber = ChoiceNumber_AnyThing_Digits(intRightNumberDigits,false);
        intLeftNumber = ChoiceNumber_AnyThing_Digits(intLeftNumberDigits,true);

        //引き算の時以外は何もしない。
        if (getSign != thisGameSign.minus) return;
        //(引き算∧左辺＜＝右辺の時)⇒左辺と右辺の交換
        if (intLeftNumber <= intRightNumber)
        {
            temp = intRightNumber;
            intRightNumber =intLeftNumberDigits;
            intLeftNumber = temp+1;
        }

    }

    /// <summary>
    /// 割り算以外の左辺Or右辺の数を決定する。
    /// </summary>
    /// <param name="intNumberDigits"></param>
    /// <returns></returns>
    private int ChoiceNumber_AnyThing_Digits(int intNumberDigits,bool isLeftDigit)
    {
        //桁数の初期化処理。まず一桁目の数から常に選択する。
        int intNow_Number_Digits = 1;

        //ランダム数を保存する変数を作る。
        int intRandom;

        //右辺Or左辺の数を所持する引数
        int intNumber = 0;

        //各項の数字をランダム選択する。
        while (intNow_Number_Digits <= intNumberDigits)
        {
            int maxNum=ChoiceRandomRangeOfDigitNum(intNow_Number_Digits,isLeftDigit);
            intRandom = Random.Range(0, maxNum);
            intNumber = int.Parse(intNumber.ToString() + intRandom.ToString());
            //0+0は0となる。よって、1桁目に0が出た時に限りやり直す。
            if (intNumber == 0) continue;
            intNow_Number_Digits++;
        }
        return intNumber;
    }
    //各桁の0-5or5-9のどちらかを選択するかを決定する関数。
    private int ChoiceRandomRangeOfDigitNum(int nowNumDigit,bool isLeftDigit)
    {
        var numPriorityOfZero2Five=0;
        var numPriorityOfFive2Ten=0;
        if (isLeftDigit)
        {
            numPriorityOfZero2Five = numPriorities.numPriorities[playerProvider.data.level-1].leftNumDigit[nowNumDigit-1].priorityOfZero2Five;
            numPriorityOfFive2Ten = numPriorities.numPriorities[playerProvider.data.level-1].leftNumDigit[nowNumDigit-1].priorityOfFive2Ten;
        }
        else
        {
            numPriorityOfZero2Five = numPriorities.numPriorities[playerProvider.data.level-1].rightNumDigit[nowNumDigit-1].priorityOfZero2Five;
            numPriorityOfFive2Ten = numPriorities.numPriorities[playerProvider.data.level-1].rightNumDigit[nowNumDigit-1].priorityOfFive2Ten;
        }

        var sumRandPriority = numPriorityOfFive2Ten + numPriorityOfZero2Five;
        var selectNum= Random.Range(0, sumRandPriority);
        if (selectNum<=numPriorityOfZero2Five)
            return 5;
        if(selectNum<=numPriorityOfFive2Ten)
            return 9;
        //条件に当てはまらない場合は0を５までから選択。
        return 5;
    }

}
