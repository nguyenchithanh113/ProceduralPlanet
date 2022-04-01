using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeGenerator
{
    ShapeSetting shapeSetting;
    NoiseFilter[] noiseFilter;

    public ShapeGenerator(ShapeSetting _shapeSetting)
    {
        shapeSetting = _shapeSetting;
        noiseFilter = new NoiseFilter[shapeSetting.noiseSetting.Length];
        for(int i = 0; i < _shapeSetting.noiseSetting.Length; i++)
        {
            noiseFilter[i] = new NoiseFilter(_shapeSetting.noiseSetting[i]);
        }
    }
    public Vector3 PointOnFace(Vector3 point)
    {
        return point * shapeSetting.radius /** (noiseFilter.PointEvaluate(point)+1)*/;
    }
}
