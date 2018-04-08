using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratedObjController : MonoBehaviour
{
    public int objectAmount = 5;

    private GameObject mine;
    private GameObject firstAidKit;
    private GameObject ammoBox;

    private List<GameObject> generatedObjects = new List<GameObject>();

    private void Start()
    {
        ammoBox = Resources.Load<GameObject>("AmmoBox");
        mine = Resources.Load<GameObject>("Mine");
        firstAidKit = Resources.Load<GameObject>("FirstAidKit");

        generatedObjects.Add(ammoBox);
        generatedObjects.Add(mine);
        generatedObjects.Add(firstAidKit);

        for(int i = 0; i < objectAmount; i++)
        {
            Instantiate(mine, new Vector3(Random.Range(-13f, 13f), 8f, Random.Range(-10f, 16f)), Quaternion.identity);
            Instantiate(firstAidKit, new Vector3(Random.Range(-13f, 13f), 8f, Random.Range(-10f, 16f)), Quaternion.identity);
        }
    }

    public void AddSceneObject(Vector3 position)
    {
        Instantiate(generatedObjects[Random.Range(0, generatedObjects.Count)], position, Quaternion.identity);
    }

    public GameObject GetMineObj
    {
        get { return mine; }
    }

    public GameObject GetFirstAidObj
    {
        get { return firstAidKit; }
    }

    public GameObject GetAmmoBox
    {
        get { return ammoBox; }
    }
}
