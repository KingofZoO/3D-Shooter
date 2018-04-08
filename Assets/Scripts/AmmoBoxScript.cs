using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyNameSpace;

public class AmmoBoxScript : MonoBehaviour
{
    private MyObjectController myObjController;

    private void Start()
    {
        myObjController = MyMain.Instance.ObjectController;
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            myObjController.PickUpAmmo();
            Destroy(gameObject);
        }
    }
}
