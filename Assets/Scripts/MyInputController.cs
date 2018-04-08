using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyNameSpace;
using MyNameSpace.Data;

/// <summary>
/// Класс-контроллер действий игрока
/// </summary>
public class MyInputController : MyBaseController
{
    //Ссылки на остальные контроллеры, управляемые действиями игрока. Сделано для сокарщения синтаксиса
    private MyFlashlightController myFLController;
    private SelectionController mySController;
    private MyWeaponController myWControler;
    private MyObjectController myObjController;
    private DataController dataController;
    private UIHUDController uiHUDController;

    private void Start()
    {
        myFLController = MyMain.Instance.FlashlightController;
        mySController = MyMain.Instance.SelectionController;
        myWControler = MyMain.Instance.WeaponController;
        myObjController = MyMain.Instance.ObjectController;
        dataController = MyMain.Instance.DataController;
        uiHUDController = MyMain.Instance.UIHUDController;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
            myFLController.SwitchFlashlightState();

        if (Input.GetKeyDown(KeyCode.O))
            mySController.SelectObj();

        if (Input.GetKey(KeyCode.E))
            mySController.MovingSelection();

        if (Input.GetKeyUp(KeyCode.E))
            mySController.MovingDeselection();

        if (Input.GetKeyDown(KeyCode.Alpha0))
            myWControler.DeselectWeapon();

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            myWControler.DeselectWeapon();
            myWControler.SelectWeapon(myObjController.GetNextWeapon(), myObjController.GetAmmo());
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            myWControler.DeselectWeapon();
            myWControler.SelectWeapon(myObjController.GetPreviousWeapon(), myObjController.GetAmmo());
        }

        if (Input.GetButton("Fire1") && myWControler.GetWeapon != null && myWControler.GetWeapon.IsAutomatic && myWControler.GetWeapon.CurrentAmmo != 0)
            myWControler.GetWeapon.Fire(myWControler.GetAmmo);

        if (Input.GetButtonDown("Fire1") && myWControler.GetWeapon != null)
            myWControler.GetWeapon.Fire(myWControler.GetAmmo);

        if (Input.GetKeyDown(KeyCode.F5))
        {
            dataController.SaveData();
        }

        if (Input.GetKeyDown(KeyCode.F9))
        {
            dataController.LoadData();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            uiHUDController.ShowPauseMenu();
        }
    }
}
