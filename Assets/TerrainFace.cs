using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainFace 
{
    public int resolution;
    public Vector3 localUp;
    public Vector3 axisA;
    public Vector3 axisB;
    Mesh mesh;
    public TerrainFace(Mesh _mesh,Vector3 _up, int _resolution)
    {
        mesh = _mesh;
        resolution = _resolution;
        localUp = _up;
        axisA = new Vector3(localUp.y, localUp.z, localUp.x);
        axisB = Vector3.Cross(localUp, axisA);
        axisB = axisB.normalized * localUp.magnitude;
    }

    public void ConstructMesh(ShapeGenerator shapeGenerator)
    {
        Vector3[] verts = new Vector3[resolution * resolution];
        int[] tris = new int[(resolution - 1) * (resolution - 1) * 2 * 3];
        Vector2[] uvs = new Vector2[verts.Length];
        int trisIndex = 0;
        int vertIndex = 0;
        for(int y = 0; y < resolution; y++)
        {
            for(int x = 0; x < resolution; x++)
            {
                Vector2 percent = new Vector2(x, y) / (resolution-1);
                Vector3 pointInFace = (localUp - axisA - axisB) + axisA * 2 * percent.x + axisB*2*percent.y ;
                pointInFace = pointInFace.normalized;
                pointInFace = shapeGenerator.PointOnFace(pointInFace);
                //Vector3 pointInFace = localUp + (percent.x - 0.5f) * axisA * 2 + (percent.y - 0.5f) * axisB * 2;
                //Debug.Log(pointInFace);
                verts[vertIndex] = pointInFace;
                uvs[vertIndex] = percent;
                if(x != resolution - 1 && y != resolution - 1)
                {
                    tris[trisIndex] = x + resolution * y;
                    tris[trisIndex + 1] = x + 1 + resolution * y;
                    tris[trisIndex + 2] = x + 1 + resolution * (y + 1);

                    tris[trisIndex + 3] = x + resolution * y;
                    tris[trisIndex + 4] = x + 1 + resolution * (y + 1);
                    tris[trisIndex + 5] = x + resolution * (y + 1);
                    trisIndex += 6;
                    
                }
                if(x!=0 && y != 0)
                {
                    
                }
                vertIndex += 1;
            }
        }
        mesh.Clear();
        mesh.vertices = verts;
        mesh.triangles = tris;
        mesh.uv = uvs;
        mesh.RecalculateNormals();
    }
}
