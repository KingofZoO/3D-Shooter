using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBazooka : MyWeapon
{
    private Animator animator;

    private void Start()
    {
        if (GetComponent<Animator>() != null)
            animator = GetComponent<Animator>();

        collarSize = 1;
        ammoSize = 5;
        currentAmmo = collarSize;
        pickUpAmmo = 1;

        rechargeTime = 3f;

        shootForce = 2000f;
        shootInterval = 1f;
    }
    public override void Fire(MyAmmunition ammunition)
    {
        if (fireState && ammunition != null)
        {
            MyRocket rocket = Instantiate(ammunition, shootPos.position, shootPos.rotation) as MyRocket;
            rocket.GetRigidBody.AddForce(shootPos.forward * shootForce);
            fireState = false;
            recharge.Start(shootInterval);
            currentAmmo--;
        }
    }

    public override void Recharge()
    {
        if (ammoSize == 0 && currentAmmo == 0)
        {
            fireState = false;
            return;
        }

        if (currentAmmo == 0)
        {
            if (animator == null)
                recharge.Start(rechargeTime);
            else animator.SetTrigger("AnimationOn");

            ammoSize -= collarSize;
            currentAmmo = collarSize;
        }
    }

    public override void PickUpAmmo()
    {
        ammoSize += pickUpAmmo;
    }
}
