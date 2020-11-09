using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

[System.Serializable]
public class MyGrid 
{
    private int width;
    private int height;
    private float cellSize;
    [SerializeField]
    private int[,] gridArray;


    public MyGrid(int width, int height, float cellSiZe)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSiZe;

        gridArray = new int[width, height];

        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                UtilsClass.CreateWorldText(gridArray[y, y].ToString(), null, GetWorldPosition(x, y), 20,
                    Color.white, TextAnchor.MiddleCenter);
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1),Color.white, 100f);
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x + 1, y), Color.white, 100f);
            }
        }
    }

    private Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * cellSize;
    }
}
