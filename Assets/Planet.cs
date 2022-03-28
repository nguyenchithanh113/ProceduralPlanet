using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    [SerializeField] MeshFilter meshFilter;
    TerrainFace TerrainFace;
    void Start()
    {
        CreateFace();
    }
    void CreateFace()
    {
        TerrainFace = new TerrainFace(Vector3.right*2 , 4);
        meshFilter.mesh = TerrainFace.ConstructMesh();
    }
    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(transform.position, TerrainFace.localUp,Color.green);
        Debug.DrawLine(transform.position, TerrainFace.axisA, Color.red );
        Debug.DrawLine(transform.position, TerrainFace.axisB, Color.blue);
    }
}
