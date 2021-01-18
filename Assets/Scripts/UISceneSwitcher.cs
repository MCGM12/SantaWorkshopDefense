using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UISceneSwitcher : MonoBehaviour
{
    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void Level()
    {
        SceneManager.LoadScene("AITest2");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            MainMenu();

        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Application.Quit();

        }
    }
}
