using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;


[System.Serializable]
public class LightmapScenarioData
{
    public Texture2D[] lightmapColor;
    public Texture2D[] lightmapDirection;
    // public Texture2D[] shadowMask;
    // public SphericalHarmonicsL2[] lightProbes; // For light probe data
}