using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeGenerator
{
    ShapeSetting shapeSetting;
    public ShapeGenerator(ShapeSetting _shapeSetting)
    {
        shapeSetting = _shapeSetting;
    }
    public Vector3 PointOnFace(Vector3 point)
    {
        return point * shapeSetting.radius;
    }
}
