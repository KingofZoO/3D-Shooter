using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyShotgunBullet : MyAmmunition
{
    [SerializeField]
    private MyAmmunition bullet;
    private MyBullet[] shotgunBullet = new MyBullet[12];

    protected override void Awake()
    {
        base.Awake();

        for(int i = 0; i < shotgunBullet.Length; i++)
        {
            var pos = new Vector3(transform.position.x + Random.Range(0, 0.05f), transform.position.y + Random.Range(0, 0.05f), transform.position.z + Random.Range(0, 0.05f));
            shotgunBullet[i] = Instantiate(bullet, pos, transform.rotation) as MyBullet;
        }

        Destroy(_instanceObject);
    }

    public MyBullet[] ShotgunFraction
    {
        get { return shotgunBullet; }
    }
}
