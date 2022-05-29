using System.Collections;
using System.Collections.Generic;
using KanKikuchi.AudioManager;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// BGMや、SEのボリュームをスライダーで変更できるクラス
/// </summary>
public class ChangeSliderVolume : MonoBehaviour
{
    public Slider slider;
    public void ChangeSESlider(){
        SEManager.Instance.ChangeBaseVolume(slider.value);
    }
    
    public void ChangeBGMSlider(){
        BGMManager.Instance.ChangeBaseVolume(slider.value);
    }
}
