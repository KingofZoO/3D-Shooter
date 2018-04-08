using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyNameSpace;

public abstract class MyWeapon : MyBaseObjectScene
{
    [SerializeField] protected Transform shootPos;
    protected float shootForce;
    protected float shootInterval;

    protected float rechargeTime;
    protected int collarSize;
    protected int ammoSize;
    protected int currentAmmo;
    protected int pickUpAmmo;

    protected MyTimer recharge = new MyTimer();
    protected bool fireState = true;
    protected bool isAutomatic = false;
    protected bool isRecharging = false;

    public abstract void Fire(MyAmmunition ammunition);
    public abstract void Recharge();
    public abstract void PickUpAmmo();

    protected virtual void Update()
    {
        Recharge();

        if (isRecharging)
            return;

        recharge.Update();
        if (recharge.IsEvent())
        {
            fireState = true;
        }
    }

    public virtual void ShootingAvaliable()
    {
        fireState = true;
        isRecharging = false;
    }

    public virtual void ShootingIsNotAvaliable()
    {
        isRecharging = true;
        fireState = false;
    }

    public int CurrentAmmo
    {
        get { return currentAmmo; }
        set { currentAmmo = value; }
    }

    public int AmmoSize
    {
        get { return ammoSize; }
        set { ammoSize = value; }
    }

    public bool IsAutomatic
    {
        get { return isAutomatic; }
    }
}
