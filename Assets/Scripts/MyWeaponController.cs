using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyWeaponController : MyBaseController
{
    private MyWeapon weapon;
    private MyAmmunition ammunition;

    public MyWeapon GetSelectedWeapon
    {
        get { return weapon; }
    }

    public void SelectWeapon(MyWeapon weapon, MyAmmunition ammo)
    {
        this.weapon = weapon;
        ammunition = ammo;
        weapon.IsVisible = true;
    }

    public void DeselectWeapon()
    {
        if (weapon != null)
        {
            weapon.IsVisible = false;
            weapon = null;
            ammunition = null;
        }
    }

    public MyWeapon GetWeapon
    {
        get { return weapon; }
    }

    public MyAmmunition GetAmmo
    {
        get { return ammunition; }
    }
}
