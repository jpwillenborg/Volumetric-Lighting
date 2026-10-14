using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;


public class LightingManager : MonoBehaviour
{
    [SerializeField]
    private List<Toggle> toggles;
    private SwitchMaterials switchMaterials;
    private SwitchLights switchLights;
    private SwitchLightmaps switchLightmaps;
    private SwitchLightingScenarios switchLightingScenarios;
    private int toggleIndex;
    private bool toggle01;
    private bool toggle02;
    

    void Awake()
    {
        switchMaterials = GetComponent<SwitchMaterials>();
        switchLights = GetComponent<SwitchLights>();
        switchLightmaps = GetComponent<SwitchLightmaps>();
        switchLightingScenarios = GetComponent<SwitchLightingScenarios>();

        foreach (Toggle toggle in toggles)
        {
            toggle.onValueChanged.AddListener((isOn) => OnToggleValueChanged(toggle, isOn));
        }
    }


    private void OnToggleValueChanged(Toggle changedToggle, bool isOn)
    {
        toggleIndex = toggles.IndexOf(changedToggle);
        toggle01 = toggles[0].isOn;
        toggle02 = toggles[1].isOn;

        switchLights.Switch(toggleIndex, isOn);
        switchMaterials.Switch(toggleIndex, isOn);
        switchLightmaps.Switch(toggle01, toggle02);
        switchLightingScenarios.Switch(toggle01, toggle02);
    }
}