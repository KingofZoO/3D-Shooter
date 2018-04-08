using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MyNameSpace;
using System.IO;

/// <summary>
/// Класс, отображающий заряд батареи на экран. Предположительно висит на объекте Image Canvas'а
/// </summary>
public class UIHUDController : MonoBehaviour
{
    private MyFlashlightController myFLController;
    private Image chargeImage;  

    private MyWeaponController myWController;
    private Text ammoText;

    private PlayerHealthScript playerHealth;
    private Slider hpSlider;
    private float MaxHP;
    private Text dieMessage;

    [SerializeField]
    private RectTransform PauseMenu;
    private DataController dataController;

    private void Start()
    {
        myFLController = MyMain.Instance.FlashlightController;
        chargeImage = transform.Find("BatteryCharge").GetComponent<Image>();

        myWController = MyMain.Instance.WeaponController;
        ammoText = transform.Find("Ammo").GetComponent<Text>();

        playerHealth = MyMain.Instance.GetPlayerHealth;
        hpSlider = transform.Find("HPSlider").GetComponent<Slider>();
        MaxHP = playerHealth.GetHPCount;
        dieMessage = transform.Find("DieMessage").GetComponent<Text>();

        dataController = MyMain.Instance.DataController;
    }

    private void Update()
    {   
        chargeImage.fillAmount = myFLController.ChargeAmount;

        hpSlider.value = playerHealth.GetHPCount / MaxHP;
        if (playerHealth.GetHPCount <= 0)
            dieMessage.enabled = true;

        if (myWController.GetWeapon == null)
            ammoText.text = "-/-";
        else ammoText.text = myWController.GetWeapon.CurrentAmmo + "/" + myWController.GetWeapon.AmmoSize;
    }

    public void NewGame()
    {
        dieMessage.enabled = false;
    }

    public void ShowPauseMenu()
    {
        Time.timeScale = 0f;
        PauseMenu.gameObject.SetActive(true);

        if (!File.Exists(dataController.GetPath()))
            PauseMenu.Find("LoadButton").GetComponent<Button>().interactable = false;
        else
            PauseMenu.Find("LoadButton").GetComponent<Button>().interactable = true;
    }

    public void HidePauseMenu()
    {
        Time.timeScale = 1f;
        PauseMenu.gameObject.SetActive(false);
    }
}
