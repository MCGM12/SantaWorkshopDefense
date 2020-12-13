using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    public Grid grid;

    public void Start()
    {
      
       grid = new Grid(4, 3, 10f, new Vector3(-30, -19));
    }

   public void Update()
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
