using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyNameSpace;
using MyNameSpace.Data;
using System.IO;

public class DataController : MyBaseController
{
    private IData data;

    private void Start()
    {
        var path = Application.dataPath;
        SetData<MyJsonData>();
        SetPath(path);
    }

    private void SetData<T>() where T : IData, new()
    {
        data = new T();
    }

    private void Save(SavedData savedData)
    {
        if (data != null)
        {
            data.Save(savedData);
        }
    }

    private SavedData Load()
    {
        if (!File.Exists(data.GetPath()))
            SaveData();

        if (data != null)
        {
            return data.Load();
        }

        return new SavedData();
    }

    public string GetPath()
    {
        if (data != null)
        {
            return data.GetPath();
        }

        return null;
    }

    public void SetPath(string path)
    {
        if (data != null)
        {
            data.SetPath(path);
        }
    }

    public void SaveData()
    {
        var weapons = MyMain.Instance.ObjectController.GetWeaponList;
        List<int> currentAmmo = new List<int>();
        List<int> ammoSize = new List<int>();

        for(int i = 0; i < weapons.Length; i++)
        {
            if (weapons[i] != null)
            {
                currentAmmo.Add(weapons[i].CurrentAmmo);
                ammoSize.Add(weapons[i].AmmoSize);
            }
        }

        var savedData = new SavedData
        {
            Hp = MyMain.Instance.GetPlayerHealth.GetHPCount,
            Position = MyMain.Instance.GetPlayerObject.transform.position,
            Rotation = MyMain.Instance.GetPlayerObject.transform.rotation,
            CurrentAmmo = currentAmmo,
            AmmoSize = ammoSize,
            BotPosition = MyMain.Instance.SpawnController.GetBot.transform.position,
            BotRotation = MyMain.Instance.SpawnController.GetBot.transform.rotation,
        };

        Save(savedData);
    }

    public void LoadData()
    {
        var savedData = Load();

        var weapons = MyMain.Instance.ObjectController.GetWeaponList;

        MyMain.Instance.GetPlayerHealth.SetHPCount = savedData.Hp;
        MyMain.Instance.GetPlayerObject.transform.position = savedData.Position;
        MyMain.Instance.GetPlayerObject.transform.rotation = savedData.Rotation;
        List<int> currentAmmo = savedData.CurrentAmmo;
        List<int> ammoSize = savedData.AmmoSize;
        MyMain.Instance.SpawnController.GetBot.transform.position = savedData.BotPosition;
        MyMain.Instance.SpawnController.GetBot.transform.rotation = savedData.BotRotation;

        for(int i = 0; i < currentAmmo.Count; i++)
        {
            weapons[i].CurrentAmmo = currentAmmo[i];
            weapons[i].AmmoSize = ammoSize[i];
        }
    }
}
