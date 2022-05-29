using TMPro;
using UnityEngine;
using UnityEngine.UI;


    public class UI_Answer : MonoBehaviour
    {

        [SerializeField] public static TextMeshProUGUI answer_text;

        void Start()
        {
            UI_Answer.answer_text = this.GetComponent<TextMeshProUGUI>();
        }

        void Update()
        {
        
        }
    }

