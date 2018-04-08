using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyNameSpace;

public class BoxScript : SceneModelScript, ISelectableObject, ISetDamage
{
    [SerializeField] private float hp = 8f;
    private bool isDead = false;

    private float dis = 2f;
    private float Xdis;
    private float Ydis;
    private float Zdis;
    private Transform cameraPos;

    private void Start()
    {
        cameraPos = Camera.main.transform;
    }

    private void Update()
    {
        if (isDead)
            Destroy(gameObject);
    }

    public void ApplyDamage(float damage)
    {
        if (hp > 0)
            hp -= damage;

        if (hp <= 0)
        {
            hp = 0;
            isDead = true;
        }
    }

    public void GettingSelected()
    {
        SetRigidbody(false);
        Xdis = dis * Mathf.Sin(cameraPos.eulerAngles.y * Mathf.Deg2Rad);
        Ydis = dis * Mathf.Sin(-cameraPos.eulerAngles.x * Mathf.Deg2Rad);
        Zdis = dis * Mathf.Cos(cameraPos.eulerAngles.y * Mathf.Deg2Rad);
        transform.position = new Vector3(cameraPos.position.x + Xdis, cameraPos.position.y + Ydis, cameraPos.position.z + Zdis);
    }

    public void GettingDeselected()
    {
        SetRigidbody(true);
    }
}
