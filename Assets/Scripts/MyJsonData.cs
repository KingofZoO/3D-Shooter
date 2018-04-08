using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyNameSpace.Data;
using System.IO;

public class MyJsonData : IData
{
    private string path;

    public SavedData Load()
    {
        var str = File.ReadAllText(path);
        return JsonUtility.FromJson<SavedData>(Crypto(str));
    }

    public void Save(SavedData data)
    {
        var str = JsonUtility.ToJson(data);
        File.WriteAllText(path, Crypto(str));
    }

    public void SetPath(string path)
    {
        this.path = Path.Combine(path, "MyData");
    }

    public string GetPath()
    {
        return path;
    }

    private string Crypto(string str)
    {
        string result = string.Empty;

        foreach (char c in str)
            result += (char)(c ^ 25);

        return result;
    }
}
