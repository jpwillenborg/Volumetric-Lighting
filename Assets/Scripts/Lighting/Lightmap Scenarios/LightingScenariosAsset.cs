using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;


[CreateAssetMenu(fileName = "LightingScenariosAsset", menuName = "Custom/Lighting Scenarios")]
public class LightingScenariosAsset : ScriptableObject
{
    public LightmapScenarioData[] scenarios;
}