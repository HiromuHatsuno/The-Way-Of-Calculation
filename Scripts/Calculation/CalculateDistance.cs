using System;
using UnityEngine;
using System.Collections;
/// <summary>
/// X軸Y軸の距離の差を求めるクラス
/// </summary>
public static class CalculateDistance
{
    public static float XAxisDistance(Vector2 a, Vector2 b)
    {
        return Math.Abs(a.x - b.x);
    }
    public static float YAxisDistance(Vector2 a, Vector2 b)
    {
        return Math.Abs(a.y - b.y);
    }
}
