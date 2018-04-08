using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyNameSpace;

public class MineScript : MyBaseObjectScene
{
    public float damage = 10f;

    [SerializeField]
    private GameObject explodeEffect;

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Environment")
            return;

        SetDamage(col.gameObject.GetComponent<ISetDamage>());
    }

    private void SetDamage(ISetDamage obj)
    {
        if (obj != null)
        {
            obj.ApplyDamage(damage);
            Instantiate(explodeEffect, transform.position, transform.rotation);
            Destroy(_instanceObject);
        }
    }
}
