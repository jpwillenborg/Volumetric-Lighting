using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;


public class ZoomCamera : MonoBehaviour
{
    [SerializeField]
    private Camera mainCamera;
    [SerializeField]
	private TextMeshProUGUI display;
    [SerializeField]
    private float minOrtho = 2.5f;
    [SerializeField]
    private float maxOrtho = 5.0f;
    private float initSize;
    private float currentSize;
    private float incOrtho = 0.05f;


    void Start()
    {
        initSize = mainCamera.orthographicSize;
        currentSize = initSize;
        ChangeText();
    }


    void DecreaseOrthoSize()
    {
        mainCamera.orthographicSize -= incOrtho;
        mainCamera.orthographicSize = Mathf.Clamp(mainCamera.orthographicSize, minOrtho, maxOrtho);
        currentSize = mainCamera.orthographicSize;
    }


    void IncreaseOrthoSize()
    {
        mainCamera.orthographicSize += incOrtho;
        mainCamera.orthographicSize = Mathf.Clamp(mainCamera.orthographicSize, minOrtho, maxOrtho);
        currentSize = mainCamera.orthographicSize;
    }


    void LateUpdate()
    {
        if (Gamepad.current != null)
        {
            if (Gamepad.current.rightTrigger.isPressed)
            {
                DecreaseOrthoSize();
                ChangeText();
            }
            if (Gamepad.current.leftTrigger.isPressed)
            {
                IncreaseOrthoSize();
                ChangeText();
            }
        }

        if (Input.GetKey(KeyCode.L))
        {
            DecreaseOrthoSize();
            ChangeText();
        }
        if (Input.GetKey(KeyCode.K))
        {
            IncreaseOrthoSize();
            ChangeText();
        }
    }


    void ChangeText() {
        display.SetText("Zoom: {0:2}",
            currentSize
        );
    }
}