using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBullet : MyAmmunition
{
    private float timeToDestruct = 2f;
    private float damage = 1f;
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
        if (col.collider.tag == "Bullet" || col.collider.tag == "Weapon")
            return;

        SetDamage(col.gameObject.GetComponent<ISetDamage>());
        Destroy(gameObject);
        //Deactivate();
    }

    private void SetDamage(ISetDamage obj)
    {
        if (obj != null)
            obj.ApplyDamage(currentDamage);
    }

    /*private void OnEnable()
    {
        Invoke("Deactivate", 2f);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }*/
}
