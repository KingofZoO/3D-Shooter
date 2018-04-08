using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyRocket : MyAmmunition
{
    [SerializeField]
    private GameObject explodeEffect;

    private float timeToDestruct = 3f;
    private float damage = 10f;
    private float mass = 1f;

    private float currentDamage;

    protected override void Awake()
    {
        base.Awake();

        Destroy(_instanceObject, timeToDestruct);
        currentDamage = damage;
        GetRigidBody.mass = mass;
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "Weapon")
            return;

        SetDamage(col.gameObject.GetComponent<ISetDamage>());
        Instantiate(explodeEffect, transform.position, transform.rotation);
        Destroy(_instanceObject);
    }

    private void SetDamage(ISetDamage obj)
    {
        if (obj != null)
            obj.ApplyDamage(currentDamage);
    }
}
