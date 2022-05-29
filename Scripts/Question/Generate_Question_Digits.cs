
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEditor;
using UnityEngine;

/// <summary>
/// 問題の桁数を決定するクラス
/// </summary>
public partial class 
    Generate_Question : MonoBehaviour
{
    public NumPriorities numPriorities;
    //送られて来た符号を基に、桁数の決定を行います。
    private void setNumberDigits(thisGameSign Sign)
    {
        //min_Digitsが無いのは、どのレベルでも一桁の計算を出現させたい為。
        int leftMaxDigits = numPriorities.numPriorities[playerProvider.data.level-1].leftNumDigit.Count;
        int rightMaxDigits=numPriorities.numPriorities[playerProvider.data.level-1].rightNumDigit.Count;
        //桁数選択
        switch (Sign)
        {
            //足し算
            //最大桁数は上記のleftMaxDigit参照
            case thisGameSign.plus:
                break;
            //引き算
            //最大桁数は上記のleftMaxDigit参照
            case thisGameSign.minus:
                break;
            //掛け算：レベル２以降の登場
            case thisGameSign.kakeru:
                intLeftNumberDigits = (int)thisGameDisits.one;
                intRightNumberDigits=(int)thisGameDisits.one;
                return;
                break;
            //割り算：
            case thisGameSign.waru:
                intLeftNumberDigits= (int) thisGameDisits.two;
                intRightNumberDigits= (int)thisGameDisits.one;
                return;
                break;

        }
        
        //桁数を設定:1からそれぞれ指定の桁数まで。
        //++を付ける理由は、intのランダムメソッドは、min以上max未満
        intLeftNumberDigits = Random.Range(1,SelectRandomDigit(true)+1);
        if(intLeftNumberDigits>=2)
        {
            leftMaxDigits--;
        }
        intRightNumberDigits = Random.Range(1, SelectRandomDigit(false) + 1);
    }

    //各桁のPriorityを元に桁数を指定する。
    public int SelectRandomDigit(bool isLeftDigit)
    {
        var sumNum = 0;
        List<int> numDigit=new List<int>();
        if (isLeftDigit)
        {
            foreach (var numDigitse in numPriorities.numPriorities[playerProvider.data.level-1].leftNumDigit)
            {
                sumNum += numDigitse.priority;
                numDigit.Add(sumNum);
            }

            var rand = Random.Range(0, sumNum);
            int j = 0;
            foreach (var i in numDigit)
            {
                j++;
                if (rand <= i)
                {
                    return j;
                }
            }

        }
        else
        {
            foreach (var numDigitse in numPriorities.numPriorities[playerProvider.data.level-1].rightNumDigit)
            {
                sumNum = numDigitse.priority;
                numDigit.Add(numDigitse.priority);
            }

            var rand = Random.Range(0, sumNum);
            int j = 0;
            foreach (var i in numDigit)
            {
                j++;
                if (rand <= i)
                {
                    return j;
                }
            }
        }

        return 0;
    }
}

