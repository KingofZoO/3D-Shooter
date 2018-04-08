using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyNameSpace;

public class PlayerHealthScript : MyBaseObjectScene, ISetDamage
{
    [SerializeField]
    private float hp = 100f;

    private float maxHp;

    private void Start()
    {
        maxHp = hp;
    }

    private void FixedUpdate()
    {
        if (hp <= 0)
        {
            hp = 0;
            Time.timeScale = 0;
        }
    }

    public void ApplyDamage(float damage)
    {
        hp -= damage;

        if (hp > maxHp)
            hp = maxHp;
    }

    public float GetHPCount
    {
        get { return hp; }
    }

    public float SetHPCount
    {
        set { hp = value; }
    }
}
