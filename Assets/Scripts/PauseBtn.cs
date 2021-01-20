using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseBtn : MonoBehaviour
{
    public GameObject Pausemenu, PauseButton;

    public void Pause()
    {
        Pausemenu.SetActive(true);
        PauseButton.SetActive(false);
        Time.timeScale = 0;
    }

    public void Resume()
    {
        Pausemenu.SetActive(false) ;
        PauseButton.SetActive(true);
        Time.timeScale = 1;
    }

    public void LoadMenu()
    {
        Debug.Log("loading Menu ....");
        SceneManager.LoadScene("MainMenu");
    }
    
}
