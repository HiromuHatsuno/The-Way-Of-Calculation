using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///　符合の出現率をレベルを基に決定するクラス
/// </summary>
public partial class Generate_Question : MonoBehaviour
{
    public SignRandomArray signRandomArray;
  
    private  int[,] LEVEL_probability = new int[,] {
        　　//　         出現率一覧表
           /*      +     -      ×    ÷  */
           /*Lv.  */  { 0, 50,  100,   111,  111},  //必要経験値：
           /*Lv.1 */  { 0, 100,  111,   111,  111}, //必要経験値：0
           /*Lv.2 */  { 0, 40,   100,   111,  111}, //必要経験値：3
           /*Lv.3 */  { 0, 15,   100,   111,  111}, //必要経験値：7
           /*Lv.4 */  { 0,  0,    100,  111,  111}, //必要経験値：11
           /*Lv.5 */  {0,   5,    70,   100,  111}, //必要経験値：14
           /*Lv.6 */  {0,   0,    50,   100,  111}, //必要経験値：20
           /*Lv.7 */  {0,   0,    25,   100,  111}, //必要経験値：24
           /*Lv.8 */  {0,   0,     0,   100,  111}, //必要経験値：29
           /*Lv.9 */  {0,   0,     0,    75,  100}, //必要経験値：34
           /*Lv.10*/  {0,   0,     0,    50,  100}, //必要経験値：39
    };
}
