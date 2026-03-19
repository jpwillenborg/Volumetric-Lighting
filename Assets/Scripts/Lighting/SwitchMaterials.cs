using UnityEngine;
using System;
using UnityEngine.UI;


[Serializable]
public struct ObjectDataWindows
{
    public MeshRenderer renderer;
    public int materialIndex;
    public Material onMaterial;
    public Material offMaterial;
}

[Serializable]
public struct ObjectDataLamps
{
    public MeshRenderer renderer;
    public int materialIndex;
    public Material onMaterial;
    public Material offMaterial;
}


public class SwitchMaterials : MonoBehaviour
{
    [SerializeField]
    private ObjectDataWindows[] objectDataWindows;
    [SerializeField]
    private ObjectDataLamps[] objectDataLamps;
    private Material[] materialsWindows;
    private Material[] materialsLamps;


    public void Switch(int toggleIndex, bool isOn)
    {
        if (toggleIndex == 0)
        {
            for (int i = 0; i < objectDataWindows.Length; i++)
            {
                materialsWindows = objectDataWindows[i].renderer.materials;
                if (isOn)
                {
                    materialsWindows[objectDataWindows[i].materialIndex] = objectDataWindows[i].onMaterial;
                } else
                {
                    materialsWindows[objectDataWindows[i].materialIndex] = objectDataWindows[i].offMaterial;
                }
                objectDataWindows[i].renderer.materials = materialsWindows;
            }
        }

        if (toggleIndex == 1)
        {
            for (int i = 0; i < objectDataLamps.Length; i++)
            {
                materialsLamps = objectDataLamps[i].renderer.materials;
                if (isOn)
                {
                    materialsLamps[objectDataLamps[i].materialIndex] = objectDataLamps[i].onMaterial;
                } else
                {
                    materialsLamps[objectDataLamps[i].materialIndex] = objectDataLamps[i].offMaterial;
                }
                objectDataLamps[i].renderer.materials = materialsLamps;
            }
        }
    }
}