using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Класс-контроллер выделения объектов
/// </summary>
public class SelectionController : MyBaseController
{
    private Color originalColor;    //Сохранение оригинального цвета
    private Color highlightColor = new Color(0f, 255f, 0f); //Цвет выделенного объекта

    private GameObject selectedObj; //Выделенный объект
    private bool isSelected;    //Проверка наличия уже выделенного объекта

    private GameObject movingSelectedObj;
    private bool isMovingSelected;

    private void Update()
    {
        if (!Enabled)
            return;
    }

    private GameObject RayToSelect(float distance)
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, distance))
            return hit.collider.gameObject;
        else return null;
    }

    /// <summary>
    /// Метод, выделяющий объект
    /// </summary>
    /// <param name="obj">Выделяемый объект</param>
    public void SelectObj()
    {
        GameObject obj = RayToSelect(100f);

        if (selectedObj == obj) //Если выделяется уже выделенный объект - выделение убирается
        {
            DeselectObj();
            return;
        }
        else if (isSelected)    //Если выделяется другой объект - выделение с прошлого спадает, далее выделяется новый
            DeselectObj();

        if (obj.GetComponent<Renderer>() == null)
            return;
        else
        {
            selectedObj = obj;
            originalColor = obj.GetComponent<Renderer>().material.color;
            obj.GetComponent<Renderer>().material.color = highlightColor;
            isSelected = true;
        }
    }

    /// <summary>
    /// Метод, убирающий выделение
    /// </summary>
    public void DeselectObj()
    {
        if (isSelected)
        {
            selectedObj.GetComponent<Renderer>().material.color = originalColor;
            selectedObj = null;
            isSelected = false;
        }
    }

    public void MovingSelection()
    {
        GameObject obj = RayToSelect(2f);

        if (obj == null && movingSelectedObj != null)
            MovingDeselection();
        else if (obj == null || obj.GetComponent<ISelectableObject>() == null)
            return;
        else
        {
            movingSelectedObj = obj;
            obj.GetComponent<ISelectableObject>().GettingSelected();
        }
    }

    public void MovingDeselection()
    {
        if (movingSelectedObj != null)
        {
            movingSelectedObj.GetComponent<ISelectableObject>().GettingDeselected();
            movingSelectedObj = null;
        }
    }
}
