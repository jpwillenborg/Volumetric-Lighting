using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;


public class SwitchLightmaps : MonoBehaviour
{
    [SerializeField]
    private LightingScenariosAsset lightingAsset;


    public void Switch(bool toggle01, bool toggle02)
    {
        if (toggle01 && !toggle02)
        {
            ApplyScenario(0);
        }

        if (!toggle01 && toggle02)
        {
            ApplyScenario(1);
        }

        if (toggle01 && toggle02)
        {
            ApplyScenario(2);
        }

        if (!toggle01 && !toggle02)
        {
            ApplyScenario(3);
        }
    }


    public void ApplyScenario(int index)
    {
        if (lightingAsset == null || index < 0 || index >= lightingAsset.scenarios.Length)
        {
            Debug.LogError("Invalid lighting scenario index or asset.");
            return;
        }

        LightmapScenarioData scenario = lightingAsset.scenarios[index];

        // Create LightmapData array from stored textures
        LightmapData[] newLightmaps = new LightmapData[scenario.lightmapColor.Length];
        for (int i = 0; i < scenario.lightmapColor.Length; i++)
        {
            newLightmaps[i] = new LightmapData();
            newLightmaps[i].lightmapColor = scenario.lightmapColor[i];
            newLightmaps[i].lightmapDir = scenario.lightmapDirection[i];
            // newLightmaps[i].shadowMask = scenario.shadowMask[i];
        }

        LightmapSettings.lightmaps = newLightmaps;
        // LightmapSettings.lightProbes.CopyFrom(scenario.lightProbes);
    }
}