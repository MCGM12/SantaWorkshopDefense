using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Grid
{
    private int width;
    private int height;
    private int[,] gridArray;
    private float cellSize;
    private TextMesh[,] debugTextArray;
    private Vector3 originPositon;

    

        public Grid(int width, int height,float cellSize,Vector3 originPosition)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.originPositon = originPosition;

        gridArray = new int[width, height];
        debugTextArray = new TextMesh[width, height];

        for (int x=0; x < gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < gridArray.GetLength(1); y++) 
            {
               debugTextArray[x,y] = WorldText.CreateWorldText(gridArray[x, y].ToString(), Color.white, null, GetWorldPosition(x, y)+new Vector3(cellSize,cellSize)*.5f, 20,TextAnchor.MiddleCenter);

                {
                    Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1), Color.white, 100f);
                    Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x + 1, y), Color.white, 100f);
                } 


            }
            Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width,height), Color.white, 100f);
            Debug.DrawLine(GetWorldPosition(width,0), GetWorldPosition(width,height), Color.white, 100f);
           
        }
        Setvalue(1, 2, 88);
     
    }

    private Vector3 GetWorldPosition (int x,int y)
    {
        return new Vector3(x, y) * cellSize+originPositon;
    }
    
    private void GetXY (Vector3 worldposition, out int x, out int y)
    {
        x = Mathf.FloorToInt((worldposition-originPositon).x / cellSize);
        y = Mathf.FloorToInt((worldposition-originPositon).y / cellSize);
    }
    public void Setvalue(int x,int y, int value)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            gridArray[x, y] = value;
            debugTextArray[x, y].text = gridArray[x, y].ToString();
        }
   
    }
    public void SetVale(Vector3 worldPos, int value)
    {
        int x, y;
        GetXY(worldPos, out x, out y);
        Setvalue(x, y, value);
    }

    public int GetValue(int x, int y)
    {
        if (x >= 0 && x < width && y < height)
        {
            return gridArray[x, y];
        }
        else
        {
            return 0;
        }
    }

    public int GetValve(Vector3 worldPosition)
    {
        int x, y;
        GetXY(worldPosition, out x, out y);

        return GetValue(x, y);
    }








}
