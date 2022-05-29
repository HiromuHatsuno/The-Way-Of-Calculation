using System.Collections;
using UnityEngine;

namespace MainAssets.Scripts.Other
{
    /// <summary>
    /// SEをテスト的に再生するクラス
    /// </summary>
    public class PlaySeTest : MonoBehaviour
    {
        public AudioClip testsSe;
        private AudioSource audioSource;

        public KeyCode keyCode;
        public void Start()
        {
            audioSource = gameObject.GetComponent<AudioSource>();
            StartCoroutine ("Enumerator");
        }
        IEnumerator Enumerator()
        {
            while(true) {
                if (Input.GetKey(keyCode))
                {
                    //音(sound1)を鳴らす
                    audioSource.PlayOneShot(testsSe);
                    yield return new WaitForSeconds(0.5f);
                } 
                yield return null;
            }
        }
    }
}
