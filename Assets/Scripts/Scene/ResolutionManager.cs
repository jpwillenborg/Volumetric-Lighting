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
    
    // Optional: Reference to your UI Toggle so it can be unchecked automatically on Escape
    [SerializeField]
    private Toggle fullscreenToggle;

    private bool isFullScreen = false;

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern int GetBrowserCanvasWidth();
    [DllImport("__Internal")]
    private static extern int GetBrowserCanvasHeight();
    [DllImport("__Internal")]
    private static extern void RegisterFullscreenListener();
    #endif

    void Awake ()
    {
        #if UNITY_WEBGL && !UNITY_EDITOR
            Screen.SetResolution(960, 540, false);
            RegisterFullscreenListener();
        #else
            Screen.SetResolution(1280, 720, false);
        #endif

        StartCoroutine(UpdateDisplay());
    }

    public void FullscreenSwitch(bool value)
    {
        // Prevent toggle feedback loops if state is already synced
        if (isFullScreen == value) return;
        
        isFullScreen = value;
        
        #if UNITY_WEBGL && !UNITY_EDITOR
        if (value)
        {
            // Only request if not already in fullscreen to avoid browser conflicts
            Application.ExternalEval("if (!document.fullscreenElement) { document.getElementById('unity-canvas').requestFullscreen(); }");
        }
        else
        {
            // Only exit if currently in fullscreen to prevent 'Document not active' errors
            Application.ExternalEval("if (document.fullscreenElement) { document.exitFullscreen(); }");
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

    // Called automatically via WebBrowserBridge when the user presses Escape or exits fullscreen
    public void OnFullscreenExitExternal()
    {
        isFullScreen = false;
        
        if (fullscreenToggle != null)
        {
            fullscreenToggle.isOn = false;
        }

        StartCoroutine(UpdateDisplay());
    }

    // Called automatically via WebBrowserBridge when the browser window is resized
    public void OnWindowResizedExternal()
    {
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