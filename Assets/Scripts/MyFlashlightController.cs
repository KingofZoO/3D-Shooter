using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Класс-контроллер фонарика
/// </summary>
public class MyFlashlightController : MyBaseController
{
    [SerializeField]
    private float chargeSpeed = 0.001f; //Скорость заряда/разряда
    private float chargeAmount = 1f;    //Величина заряда. Должна находиться в пределах [0,1] - это ограничение свойства Image.fillAmount

    private Light _light;   //Непосредственно сам фонарик

    protected override void Awake()
    {
        _light = GameObject.Find("Flashlight").GetComponent<Light>();
    }

    private void Update()
    {
        if (!Enabled)
            return;
    }

    private void FixedUpdate()
    {
        if (_light.enabled) //В зависимости от состояния фонаря разряжаем или заряжаем его
            chargeAmount -= chargeSpeed;
        else chargeAmount += chargeSpeed;

        if (chargeAmount <= 0f) //Выключаем фонарь при полной разрядке
            Off();

        chargeAmount = Mathf.Clamp(chargeAmount, 0f, 1f);
    }

    /// <summary>
    /// Метод, выключающий фонарь
    /// </summary>
    private void Off()
    {
        _light.enabled = false;
    }

    /// <summary>
    /// Метод, включающий фонарь
    /// </summary>
    private void On()
    {
        _light.enabled = true;
    }

    public void SwitchFlashlightState()
    {
        if (_light.enabled)
            Off();
        else On();
    } 

    /// <summary>
    /// Свойство - количество заряда фонаря
    /// </summary>
    public float ChargeAmount
    {
        get { return chargeAmount; }
    }
}
