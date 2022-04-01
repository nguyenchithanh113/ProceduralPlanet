using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class NoiseFilter
{
    public Noise noise;
    public NoiseSetting noiseSetting;
    public NoiseFilter(NoiseSetting _noiseSetting)
    {
        noise = new Noise();
        noiseSetting = _noiseSetting;
    }
    public float PointEvaluate(Vector3 point)
    {
        float evaluate = 1;
        float noiseValue = 0;
        float frequency = noiseSetting.baseRoughness;
        float roughness = noiseSetting.roughness;
        float persistance = noiseSetting.persistance;
        float amplitude = 1;
        for(int i = 0; i < noiseSetting.layer; i++)
        {
            evaluate = (noise.Evaluate(point * frequency + noiseSetting.center) + 1) * 0.5f;
            noiseValue += evaluate * amplitude;
            amplitude *= persistance;
            frequency *= roughness;

        }
        noiseValue = Mathf.Max(noiseValue, noiseSetting.minValue);
        //evaluate *= 0.1f;
        //float noiseEvaluate = (noise.Evaluate(point * noiseSetting.roughness + noiseSetting.center) + 1) * 0.5f;
        return noiseValue * noiseSetting.strength;
    }
}
