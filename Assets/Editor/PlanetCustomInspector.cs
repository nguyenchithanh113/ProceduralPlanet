using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(Planet))]
public class PlanetCustomInspector : Editor
{
    Planet planet;
    Editor shapeEditor;
    Editor colorEditor;
    private void OnEnable()
    {
        if (planet == null)
        {
            planet = (Planet)target;
        }
        
    }
    public override void OnInspectorGUI()
    {
        using (var check = new EditorGUI.ChangeCheckScope())
        {
            base.OnInspectorGUI();
            if (GUILayout.Button("GeneratePlanet"))
            {
                planet.GeneratePlanet();
            }
            if (check.changed)
            {
                planet.GeneratePlanet();
                
            }
            DrawSetting(planet.shapeSetting, ref shapeEditor, ref planet.shapeSettingFoldout, planet.OnUpdateShapeSetting);
            DrawSetting(planet.colorSetting, ref colorEditor, ref planet.colorSettingFoldout, planet.OnUpdateColorSetting);
        }
        
    }
    void DrawSetting(Object objectSetting, ref Editor settingEditor, ref bool foldOut, System.Action onSettingChange)
    {
        if(settingEditor == null)
        {
            CreateCachedEditor(objectSetting, null, ref settingEditor);
        }
        using(var check = new EditorGUI.ChangeCheckScope())
        {
            foldOut = EditorGUILayout.InspectorTitlebar(foldOut, settingEditor); 
            if (foldOut)
            {
                CreateCachedEditor(objectSetting, null, ref settingEditor);
                settingEditor.OnInspectorGUI();
                if (check.changed)
                {
                    onSettingChange?.Invoke();
                }
            }
            
        }
    }
}
