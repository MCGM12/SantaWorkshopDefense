using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMaker : MonoBehaviour
{
    public Grid grid;

    public void Start()
    {
      
       grid = new Grid(8, 6, 5, new Vector3(-31, -19));
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
