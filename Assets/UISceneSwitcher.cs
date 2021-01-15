using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UISceneSwitcher : MonoBehaviour
{
    public void Credits()
    {
        SceneManager.LoadScene("");
    }

    public void Level()
    {
        SceneManager.LoadScene("AITest2");
    }

}
