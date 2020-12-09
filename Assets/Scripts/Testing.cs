using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    private Grid grid;

    private void Start()
    {
      
       grid = new Grid(20, 20, 10f, new Vector3(0,0));
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
         grid.SetVale(mousePos.GetMouseWorldPosition(), 56);
        }

        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log(grid.GetValve(mousePos.GetMouseWorldPosition()));
        }
    }

}
