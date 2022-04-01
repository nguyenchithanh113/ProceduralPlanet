using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class NoiseSetting
{
    
    public float baseRoughness = 1;
    public float strength = 1;
    public float roughness = 2;
    [Range(1,8)]
    public int layer = 1;
    [Range(0.1f,0.9f)]
    public float persistance = 0.5f;
    public Vector3 center;
    public float minValue;
}
