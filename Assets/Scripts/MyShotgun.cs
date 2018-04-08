using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyShotgun : MyWeapon
{
    private Animator animator;

    private MyBullet[] shotgunFraction;

    private void Start()
    {
        if (GetComponent<Animator>() != null)
            animator = GetComponent<Animator>();

        collarSize = 8;
        ammoSize = 30;
        currentAmmo = collarSize;
        pickUpAmmo = 4;

        rechargeTime = 2f;

        shootForce = 4000f;
        shootInterval = 0.8f;
    }

    public override void Fire(MyAmmunition ammunition)
    {
        if (fireState && ammunition != null)
        {
            MyShotgunBullet bullet = Instantiate(ammunition, shootPos.position, shootPos.rotation) as MyShotgunBullet;
            //MyBullet bullet = ammunition as MyBullet;
            //bullet.transform.position = shootPos.transform.position;
            //bullet.transform.rotation = shootPos.transform.rotation;
            //bullet.gameObject.SetActive(true);
            shotgunFraction = bullet.ShotgunFraction;
            for(int i = 0; i < shotgunFraction.Length; i++)
            {
                shotgunFraction[i].GetRigidBody.AddForce(shootPos.forward * shootForce);
            }
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
