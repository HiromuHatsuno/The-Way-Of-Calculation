using UnityEngine;

namespace MainAssets.Scripts.Other
{
    /// <summary>
    /// EchoFilterを自動でアタッチするクラス
    /// </summary>
    public class CreateEcho : MonoBehaviour
    {
        void Start()
        {
            gameObject.AddComponent(typeof(AudioEchoFilter));
        }
    }
}
