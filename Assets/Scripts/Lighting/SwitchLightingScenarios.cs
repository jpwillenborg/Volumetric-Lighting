using UnityEngine;
using UnityEngine.Rendering;


public class SwitchLightingScenarios : MonoBehaviour
{
    private string scenario01 = "Windows On";
    private string scenario02 = "Lamps On";
    private string scenario03 = "Both On";
    private string scenario04 = "Both Off";
    private ProbeReferenceVolume probeRefVolume;


    void Start()
    {
        probeRefVolume = ProbeReferenceVolume.instance;
        probeRefVolume.BlendLightingScenario(scenario01, 0.0f);
    }


    public void Switch(bool toggle01, bool toggle02)
    {
        if (toggle01 && !toggle02)
        {
            probeRefVolume.BlendLightingScenario(scenario01, 0.0f);
        }

        if (!toggle01 && toggle02)
        {
            probeRefVolume.BlendLightingScenario(scenario02, 0.0f);
        }

        if (toggle01 && toggle02)
        {
            probeRefVolume.BlendLightingScenario(scenario03, 0.0f);
        }

        if (!toggle01 && !toggle02)
        {
            probeRefVolume.BlendLightingScenario(scenario04, 0.0f);
        }
    }
}