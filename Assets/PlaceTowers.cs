using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceTowers : MonoBehaviour
{
    public  GameObject  TowersPrefab;
    private GameObject Tower;
    public GameObject[] Towers;
    int Towercounter = 0;

    private bool CanPlaceTower()
    {
        return Tower == null;
    }

    private void OnMouseUp()
    {
        if (CanPlaceTower())
        {
            Tower =Instantiate(TowersPrefab, transform.position, Quaternion.identity);

        }
    }
   


  /*  void Start()
    {
        Towers[0].SetActive(false);

    }

    // Update is called once per frame
  void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            Towercounter = 0;

            for (int i = 0; i < Towers.Length; i++)
            {
                if (i != Towercounter)

                    Towers[i].SetActive(false);

                else
                    Towers[i].SetActive(true);



            }
        }
        else if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            Towercounter = 1;

            for (int i = 1; i < Towers.Length; i++)
            {
                if (i != Towercounter)

                    Towers[i].SetActive(false);

                else
                    Towers[i].SetActive(true);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            Towercounter = 2;

            for (int i = 2; i < Towers.Length; i++)
            {
                if (i != Towercounter)

                    Towers[i].SetActive(false);

                else
                    Towers[i].SetActive(true);
            }
        }
    }*/
}
