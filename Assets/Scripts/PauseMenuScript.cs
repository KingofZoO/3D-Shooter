using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using MyNameSpace;

public class PauseMenuScript : MonoBehaviour
{
    private UIHUDController uiHUDController;
    private DataController dataController;

    private void Start()
    {
        uiHUDController = MyMain.Instance.UIHUDController;
        dataController = MyMain.Instance.DataController;
    }

    public void NewGame()
    {
        uiHUDController.HidePauseMenu();
        uiHUDController.NewGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadGame()
    {
        uiHUDController.HidePauseMenu();
        uiHUDController.NewGame();
        dataController.LoadData();
    }

    public void Continue()
    {
        uiHUDController.HidePauseMenu();
    }

    public void Exit()
    {
        Application.Quit();
    }
}
