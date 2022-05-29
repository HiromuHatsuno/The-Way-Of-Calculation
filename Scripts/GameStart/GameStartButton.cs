using System;
using System.Collections;
using System.Collections.Generic;
using Com.LuisPedroFonseca.ProCamera2D;
using KanKikuchi.AudioManager;
using MainAssets.Scripts.ProCamera;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStartButton : MonoBehaviour
{
    public Canvas startUI;
    public Fade fade;
    public static bool initGame=true;
    public GameObject player;

    public void Start()
    {
        if (StartManager.isRetry ==true||StartManager.isContinue==true)
        {
            startUI.enabled = false;
        }
    }

    public void tapStart()
    {
        fade.FadeIn(1, () => fade.FadeOut(1));
        SEManager.Instance.Play(SEPath.DECISION42);
        StartCoroutine(Actiond(1, () => startUI.enabled = false));
        Invoke("CameraSet",.25f);
    }

    public void CameraSet()
    {
        ProCamera2DController.SearchNewTarget(player,"Enemy");
    }

    public void StartMenuFalse()
    {
        startUI.enabled = false;
    }
    IEnumerator Actiond (float time, System.Action action)
    {
        float currentTime = 0;
        float endTime = time;
		
        var endFrame = new WaitForEndOfFrame ();

        while (currentTime <= endTime)
        {
            currentTime += Time.unscaledDeltaTime;
            yield return endFrame;
        }

        if (action != null) {
            action ();
        }
    }
  
}
