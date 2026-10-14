using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;


public class SwitchLights : MonoBehaviour
{
    [SerializeField]
    private Slider slider;
    [SerializeField]
    private GameObject lightGroupWindows;
    [SerializeField]
    private GameObject lightGroupLamps;
    [SerializeField]
    private List<VolumetricAdditionalLight> windowRays;


    public void AdjustRays(float value)
    {
        foreach (VolumetricAdditionalLight ray in windowRays)
        {
            ray.Scattering = value;
        }
    }


    public void Switch(int toggleIndex, bool isOn)
    {
        if (toggleIndex == 0)
        {
            slider.interactable = isOn;
            lightGroupWindows.SetActive(isOn);
        }

        if (toggleIndex == 1)
        {
            lightGroupLamps.SetActive(isOn);
        }
    }
}