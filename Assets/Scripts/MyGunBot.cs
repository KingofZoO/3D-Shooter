using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyNameSpace;

public class MyGunBot : MyWeapon
{
    public float meleeDamage = 5f;
    [SerializeField]
    private MyAmmunition bullet;

    private Animator animator;
    private MyBotScript botScript;

    private void Start()
    {
        botScript = GetComponentInParent<MyBotScript>();

        if (GetComponent<Animator>() != null)
            animator = GetComponent<Animator>();

        isAutomatic = true;

        collarSize = 30;
        ammoSize = 30;
        currentAmmo = collarSize;
        pickUpAmmo = 15;

        rechargeTime = 1f;

        shootForce = 4000f;
        shootInterval = 0.1f;

        InvokeRepeating("Fire", shootInterval, shootInterval);
    }

    public void Fire()
    {
        if (fireState && botScript.IsAngry)
        {
            MyBullet bul = Instantiate(bullet, shootPos.position, shootPos.rotation) as MyBullet;
            //MyBullet bullet = ammunition as MyBullet;
            //bullet.transform.position = shootPos.transform.position;
            //bullet.transform.rotation = shootPos.transform.rotation;
            //bullet.gameObject.SetActive(true);
            bul.GetComponent<Rigidbody>().AddForce(shootPos.forward * shootForce);
            fireState = false;
            recharge.Start(shootInterval);
            currentAmmo--;
        }
    }

    public override void Recharge()
    {
        if (ammoSize == 0 && currentAmmo == 0)
        {
            CancelInvoke();
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

    private void MeleeAttack()
    {
        MyMain.Instance.GetPlayerHealth.ApplyDamage(meleeDamage);
    }

    public void MeleeAnimationOn()
    {
        if (ammoSize == 0 && currentAmmo == 0)
            animator.SetTrigger("MeleeAttackOn");
    }

    public override void Fire(MyAmmunition ammunition)
    {
        
    }

    public override void PickUpAmmo()
    {
        ammoSize += pickUpAmmo;
    }
}
