using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SceneObjectEnablerScript : EditorWindow
{
    private string[] tagArray;
    private List<bool> toggles = new List<bool>();
    private Dictionary<string, GameObject[]> objPool = new Dictionary<string, GameObject[]>();

    [MenuItem("Window/Object Enabler")]
    private static void ShowWindow()
    {
        GetWindow(typeof(SceneObjectEnablerScript));
    }

    private void OnEnable()
    {
        tagArray = UnityEditorInternal.InternalEditorUtility.tags;
    }

    private void OnGUI()
    {
        GUILayout.Label("List of tags", EditorStyles.boldLabel);

        for(int i = 0; i < tagArray.Length; i++)
        {
            toggles.Add(true);
            toggles[i] = EditorGUILayout.Toggle(tagArray[i], toggles[i]);
        }

        if(GUILayout.Button("Refresh objects"))
        {
            for (int i = 0; i < tagArray.Length; i++)
            {
                var objects = GameObject.FindGameObjectsWithTag(tagArray[i]);

                if (!toggles[i] && !objPool.ContainsKey(tagArray[i]))
                {
                    objPool.Add(tagArray[i], objects);

                    foreach (var obj in objects)
                        obj.SetActive(false);
                }

                if(toggles[i] && objPool.ContainsKey(tagArray[i]))
                {
                    foreach (var obj in objPool[tagArray[i]])
                        obj.SetActive(true);

                    objPool.Remove(tagArray[i]);
                }
            }
        }

        EditorGUILayout.HelpBox("Set state of objects using toggles", MessageType.Info);
    }
}
