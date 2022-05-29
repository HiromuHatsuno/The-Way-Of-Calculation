using UnityEngine;

// シングルトン化され、シーン遷移しても残る
public class StartManager : MonoBehaviour
{
    public static int playerLv;
    public static int clearQ;
    public static bool isContinue;
    public static bool isRetry;
}