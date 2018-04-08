using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GeneratedObjController))]
public class GeneratedObjExpander : Editor
{
    private List<GameObject> objects = new List<GameObject>();

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        GeneratedObjController GOController = (GeneratedObjController)target;

        if(GUILayout.Button("Generate Objects"))
        {
            ClearScene();

            for (int i = 0; i < GOController.objectAmount; i++)
            {
                objects.Add(Instantiate(Resources.Load<GameObject>("Mine"), new Vector3(Random.Range(-13f, 13f), 8f, Random.Range(-10f, 16f)), Quaternion.identity));
                objects.Add(Instantiate(Resources.Load<GameObject>("FirstAidKit"), new Vector3(Random.Range(-13f, 13f), 8f, Random.Range(-10f, 16f)), Quaternion.identity));
            }
        }

        if (GUILayout.Button("Clear"))
            ClearScene();
    }

    private void ClearScene()
    {
        foreach (var obj in objects)
            if (obj != null)
                DestroyImmediate(obj);
    }
}
