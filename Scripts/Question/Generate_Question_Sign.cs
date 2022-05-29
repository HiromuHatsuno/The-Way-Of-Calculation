using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

//符号を選択するだけのクラス。
//選択符号は、すべてStored_Signに送られる。
public partial class Generate_Question : MonoBehaviour
{



    //ランダム変数によって生まれた数を用いて、符号を決定する
    private  thisGameSign GetSign()
    {
        int tasuPriority = signRandomArray.signPriority[playerProvider.data.level].tasuPriority;
        int hikuPriority = signRandomArray.signPriority[playerProvider.data.level].hikuPriority;
        int kakeruPriority = signRandomArray.signPriority[playerProvider.data.level].kakeruPriority;
        int waruPriority = signRandomArray.signPriority[playerProvider.data.level].waruPriority;
        int sumOfAllPriority = tasuPriority + hikuPriority + kakeruPriority + waruPriority;
        
        int intRand = Random.Range(0,sumOfAllPriority);

        //符号の決定
        if (0 <= intRand)
        {
            
            if (intRand <= tasuPriority)
            {
                return thisGameSign.plus;
            }

            if (intRand <= tasuPriority+hikuPriority)
            {
                return thisGameSign.minus;
            }

            if (intRand <= tasuPriority+hikuPriority+kakeruPriority)
            {
                return thisGameSign.kakeru;
            }

            if (intRand <= sumOfAllPriority)
            {
                return thisGameSign.waru;
            }
            
        }

        //例外はすべて足し算符号を返す。
        return thisGameSign.plus;
    }


    private string Convert_thidGameSign2String(thisGameSign _sign) 
    {
        string strSign = "";


        switch (_sign)
        {
            case thisGameSign.plus:
                strSign = strSign + "+";
                break;
            case thisGameSign.minus:
                strSign = strSign + "-";
                break;
            case thisGameSign.kakeru:
                strSign = strSign + "×";
                break;
            case thisGameSign.waru:
                strSign = strSign + "÷";
                break;
        }

        strSign = strSign + "";

        return strSign;
    }
}
