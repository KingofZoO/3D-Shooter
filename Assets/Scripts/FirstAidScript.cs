using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyNameSpace;

public class FirstAidScript : MyBaseObjectScene
{
    public float healAmount = 10f;

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
            obj.ApplyDamage(-healAmount);
            Destroy(_instanceObject);
        }
    }
}
