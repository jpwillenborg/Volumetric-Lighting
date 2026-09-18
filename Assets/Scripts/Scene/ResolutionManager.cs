using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using System.Runtime.InteropServices;


public class ResolutionManager : MonoBehaviour
{
    [SerializeField]
    private CanvasScaler screenInfoCanvas;
    [SerializeField]
    private TextMeshProUGUI display;
    private bool isFullScreen = false;

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern int GetBrowserCanvasWidth();
    [DllImport("__Internal")]
    private static extern int GetBrowserCanvasHeight();
    #endif


    void Awake ()
    {
        #if UNITY_WEBGL && !UNITY_EDITOR
            Screen.SetResolution(960, 540, false);
        #else
            Screen.SetResolution(1280, 720, false);
        #endif

        StartCoroutine(UpdateDisplay());
    }

    public void FullscreenSwitch(bool value)
    {
        isFullScreen = value;
        
        #if UNITY_WEBGL && !UNITY_EDITOR
        if (value)
        {
            Application.ExternalEval("document.getElementById('unity-canvas').requestFullscreen();");
        }
        else
        {
            Application.ExternalEval("document.exitFullscreen();");
        }
        #else

        if (value)
        {
            Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, true);
        } 
        else
        {
            #if UNITY_WEBGL && !UNITY_EDITOR
                Screen.SetResolution(960, 540, false);
            #else
                Screen.SetResolution(1280, 720, false);
            #endif
        }
        #endif

        StartCoroutine(UpdateDisplay());
    }

    private IEnumerator UpdateDisplay()
    {
        yield return new WaitForSeconds(0.15f);

        #if UNITY_WEBGL && !UNITY_EDITOR
        int webWidth = GetBrowserCanvasWidth();
        int webHeight = GetBrowserCanvasHeight();
        
        display.SetText("Resolution\n" + webWidth + " x " + webHeight);
        #else

        display.SetText("Resolution" + "\n" + Screen.width + " x " + Screen.height);

        #endif
    }
}