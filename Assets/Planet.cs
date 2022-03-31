using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    struct Face
    {
        public Vector3 direction;
        public string directionName;
    }
    public ShapeSetting shapeSetting;
    public ColorSetting colorSetting;
    public bool AutoUpdate;
    [HideInInspector] public bool shapeSettingFoldout;
    [HideInInspector] public bool colorSettingFoldout;
    [Range(2, 256)]
    [SerializeField] int resolution = 2;
    [SerializeField, HideInInspector] TerrainFace[] terrainFaces;
    [SerializeField, HideInInspector] MeshFilter[] faceMeshFilters;
    [SerializeField] Material matFace;
    TerrainFace _TerrainFace;
    ShapeGenerator shapeGenerator;
    Face[] Faces = new Face[] {
            new Face(){ direction = Vector3.up, directionName = "Face up" },
            new Face(){ direction = Vector3.down, directionName = "Face down" },
            new Face(){ direction = Vector3.right, directionName = "Face right" },
            new Face(){ direction = Vector3.left, directionName = "Face left" },
            new Face(){ direction = Vector3.forward, directionName = "Face forward" },
            new Face(){ direction = Vector3.back, directionName = "Face back" },
     };
    void Start()
    {

    }

    void Update()
    {

    }
    public void Initializing()
    {
        
        if (faceMeshFilters == null || faceMeshFilters.Length == 0)
        {
            faceMeshFilters = new MeshFilter[6];
        }
        if (terrainFaces == null || terrainFaces.Length == 0)
        {
            terrainFaces = new TerrainFace[6];
        }
        shapeGenerator = new ShapeGenerator(shapeSetting);
        for (int i = 0; i < 6; i++)
        {
            if (faceMeshFilters[i] == null)
            {
                GameObject face = new GameObject(Faces[i].directionName);

                face.transform.SetParent(transform);
                face.transform.localPosition = Vector3.zero;

                faceMeshFilters[i] = face.AddComponent<MeshFilter>();
                MeshRenderer _faceMeshRender = face.AddComponent<MeshRenderer>();
                _faceMeshRender.sharedMaterial = matFace;
                _faceMeshRender.sharedMaterial.color = colorSetting.color;
            }
            terrainFaces[i] = new TerrainFace(Faces[i].direction, resolution);
        }
    }
    public void GeneratePlanet()
    {
        Initializing();
        GenertateMesh();
    }

    public void OnUpdateShapeSetting()
    {
        if (AutoUpdate)
        {
            GeneratePlanet();
        }
    }
    public void OnUpdateColorSetting()
    {
        if (AutoUpdate)
        {
            GenerateColor();
        }

    }
    void GenertateMesh()
    {
        for (int i = 0; i < faceMeshFilters.Length; i++)
        {
            faceMeshFilters[i].mesh = terrainFaces[i].ConstructMesh(shapeGenerator);
        }
    }
    void GenerateColor()
    {
        for (int i = 0; i < faceMeshFilters.Length; i++)
        {
            faceMeshFilters[i].GetComponent<MeshRenderer>().sharedMaterial.color = colorSetting.color;
        }
    }
    
}
