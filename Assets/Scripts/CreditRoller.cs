using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditRoller : MonoBehaviour
{
    private static int nScreens = 7;
    private GameObject[] creditScreens = new GameObject[nScreens];
    private static int swapCount = 0;


    // Use this for initialization
    void Start()
    {

        creditScreens[0] = GameObject.Find("Credits1");
        creditScreens[1] = GameObject.Find("Credits2");
        creditScreens[2] = GameObject.Find("Credits3");
        creditScreens[3] = GameObject.Find("Credits4");
        creditScreens[4] = GameObject.Find("Credits5");
        creditScreens[5] = GameObject.Find("Credits6");
        creditScreens[6] = GameObject.Find("Credits7");




        //Turn them all off...
        for (int i = 0; i < nScreens; i++)
        {
            creditScreens[i].SetActive(false);
        }
        //Except, turn back on element 0
        creditScreens[0].SetActive(true);
    } //Start


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.C))
        {
            //Toggle
            int currentScene = swapCount % nScreens;
            creditScreens[currentScene].SetActive(false);
            swapCount++;
            currentScene = swapCount % nScreens;
            creditScreens[currentScene].SetActive(true);
            Debug.Log(currentScene);


        }
    } //Update
}