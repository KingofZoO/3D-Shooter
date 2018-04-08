using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MyNameSpace
{
    /// <summary>
    /// Класс-обеспечивающий обмен данными между контроллерами и объектами
    /// </summary>
    public class MyMain : MonoBehaviour
    {
        private GameObject controllerGameObject;
        private MyInputController inputController;
        private MyFlashlightController flashlightController;
        private SelectionController selectionController;
        private MyWeaponController weaponController;
        private MyObjectController objectController;
        private SpawnController spawnController;
        private WayPointsController wayPointsController;
        private PlayerHealthScript playerHealthScript;
        private DataController dataController;
        private GeneratedObjController goController;
        private UIHUDController uiHUDController;

        private GameObject playerObject;

        public static MyMain Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
            //Добавление контроллеров на сцену
            controllerGameObject = new GameObject { name = "Controllers" };
            inputController = controllerGameObject.AddComponent<MyInputController>();
            flashlightController = controllerGameObject.AddComponent<MyFlashlightController>();
            selectionController = controllerGameObject.AddComponent<SelectionController>();
            weaponController = controllerGameObject.AddComponent<MyWeaponController>();
            objectController = GetComponent<MyObjectController>();
            spawnController = controllerGameObject.AddComponent<SpawnController>();
            wayPointsController = controllerGameObject.AddComponent<WayPointsController>();
            playerObject = GameObject.Find("FPSController");
            playerHealthScript = playerObject.GetComponent<PlayerHealthScript>();
            dataController = controllerGameObject.AddComponent<DataController>();
            goController = GetComponent<GeneratedObjController>();
            uiHUDController = GameObject.Find("Canvas").GetComponent<UIHUDController>();

            //Включение контроллеров
            inputController.Enabled = true;
            flashlightController.Enabled = true;
            selectionController.Enabled = true;
            weaponController.Enabled = true;
            spawnController.Enabled = true;
            wayPointsController.Enabled = true;
            dataController.Enabled = true;
        }

        #region Access to controllers
        public MyInputController InputController
        {
            get { return inputController; }
        }

        public MyFlashlightController FlashlightController
        {
            get { return flashlightController; }
        }

        public SelectionController SelectionController
        {
            get { return selectionController; }
        }

        public MyWeaponController WeaponController
        {
            get { return weaponController; }
        }

        public MyObjectController ObjectController
        {
            get { return objectController; }
        }

        public SpawnController SpawnController
        {
            get { return spawnController; }
        }

        public WayPointsController WayPointsController
        {
            get { return wayPointsController; }
        }

        public PlayerHealthScript GetPlayerHealth
        {
            get { return playerHealthScript; }
        }

        public DataController DataController
        {
            get { return dataController; }
        }

        public GameObject GetPlayerObject
        {
            get { return playerObject; }
        }

        public GeneratedObjController GeneratedObjectController
        {
            get { return goController; }
        }

        public UIHUDController UIHUDController
        {
            get { return uiHUDController; }
        }
        #endregion
    }
}
