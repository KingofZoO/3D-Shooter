using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGun : MyWeapon
{
    private Animator animator;

    private void Start()
    {
        if (GetComponent<Animator>() != null)
            animator = GetComponent<Animator>();

        isAutomatic = true;

        collarSize = 30;
        ammoSize = 150;
        currentAmmo = collarSize;
        pickUpAmmo = 15;

        rechargeTime = 1f;

        shootForce = 4000f;
        shootInterval = 0.1f;
    }

    public override void Fire(MyAmmunition ammunition)
    {
        if(fireState && ammunition != null)
        {
            MyBullet bullet = Instantiate(ammunition, shootPos.position, shootPos.rotation) as MyBullet;
            //MyBullet bullet = ammunition as MyBullet;
            //bullet.transform.position = shootPos.transform.position;
            //bullet.transform.rotation = shootPos.transform.rotation;
            //bullet.gameObject.SetActive(true);
            bullet.GetRigidBody.AddForce(shootPos.forward * shootForce);
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
