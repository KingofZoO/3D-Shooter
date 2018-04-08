using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyObjectController : MonoBehaviour
{
    [SerializeField] private MyAmmunition[] ammunitionList = new MyAmmunition[5];
    [SerializeField] private MyWeapon[] weaponList = new MyWeapon[5];

    private int weaponCount = 0;
    private int takingWeapon = 0;

    //private List<MyAmmunition> bulletPool = new List<MyAmmunition>();

    private void Start()
    {
        foreach (var weapon in weaponList)
            if (weapon != null)
            {
                weapon.IsVisible = false;
                weaponCount++;
            }

        /*for(int i = 0; i < 30; i++)
        {
            MyBullet bullet = Instantiate(ammunitionList[0]) as MyBullet;
            bullet.gameObject.SetActive(false);
            bulletPool.Add(bullet);
        }*/
    }

    public MyWeapon GetNextWeapon()
    {
        if (takingWeapon == weaponCount)
            takingWeapon = 0;
        takingWeapon++;
        return weaponList[takingWeapon - 1];
    }

    public MyWeapon GetPreviousWeapon()
    {
        takingWeapon--;
        if (takingWeapon <= 0)
            takingWeapon = weaponCount;
        return weaponList[takingWeapon - 1];
    }

    public MyAmmunition GetAmmo()
    {
        return ammunitionList[takingWeapon - 1];
        /*for(int i = 0; i < 30; i++)
        {
            if (bulletPool[i].enabled == false)
                return bulletPool[i];
        }
        return null;*/
    }

    public void PickUpAmmo()
    {
        foreach (var weapon in weaponList)
        {
            if (weapon != null)
                weapon.PickUpAmmo();
        }
    }

    public MyAmmunition[] GetAmmunitionList
    {
        get { return ammunitionList; }
    }

    public MyWeapon[] GetWeaponList
    {
        get { return weaponList; }
    }
}
