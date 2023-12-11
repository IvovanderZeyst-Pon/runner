using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class GridSystem
{

    public event EventHandler<OnGridValueChangedEventArgs> OnGridValueChanged;

    public class OnGridValueChangedEventArgs : EventArgs
    {
        public int x;
        public int y;
    }

    private int width;
    private int height;
    private float cellSize;
    //private Vector3 originPosition;
    private int[,] gridArray;

    private GameObject Cube;
    private int XPosition = 0;
    private int YPosition = 0;
    private int ZPosition = 0;
    private int XScale = 10;
    private int YScale = 10;
    private int ZScale = 0;
    private int GridDimension = 60;

    public GridSystem(int width, int height, float cellSize)//public GridSystem(int width, int height, float cellSize, Vector3 originPosition)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        //this.originPosition = originPosition;

        gridArray = new int[width, height];

        bool showDebug = true;
        if (showDebug)
        {
            TextMesh[,] debugTextArray = new TextMesh[width, height];
            var XIncrease = 5;
            for (int x = 0; x < gridArray.GetLength(0); x++)
            {
                var YIncrease = 5;
                for (int y = 0; y < gridArray.GetLength(1); y++)
                {
                    debugTextArray[x, y] = UtilsClass.CreateWorldText(gridArray[x, y].ToString(), null,
                        GetWorldPosition(x, y) + new Vector3(cellSize, cellSize) * .5f, 30, Color.black,
                        TextAnchor.MiddleCenter);
                    Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1), Color.black, 100f);
                    Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x + 1, y), Color.black, 100f);
                    
                    GameObject Cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    Cube.transform.localScale = new Vector3(XScale, YScale, ZScale);
                    Cube.transform.position = new Vector3(XPosition + XIncrease, YPosition + YIncrease, ZPosition);
                    Cube.name = x.ToString() + "-" + y.ToString();
                    YIncrease = YIncrease + 10;
                }
                XIncrease = XIncrease + 10;
            }

            Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.black, 100f);
            Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.black, 100f);

            OnGridValueChanged += (object sender, OnGridValueChangedEventArgs eventArgs) =>
            {
                debugTextArray[eventArgs.x, eventArgs.y].text = gridArray[eventArgs.x, eventArgs.y].ToString();
            };
        }
    }

    public int GetWidth()
    {
        return width;
    }

    public int GetHeight()
    {
        return height;
    }

    public float GetCellSize()
    {
        return cellSize;
    }

    public Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * cellSize;//return new Vector3(x, y) * cellSize + originPosition;
    }

    private void GetXY(Vector3 worldPosition, out int x, out int y)
    {
        x = Mathf.FloorToInt((worldPosition).x / cellSize);//        x = Mathf.FloorToInt((worldPosition - originPosition).x / cellSize);
        y = Mathf.FloorToInt((worldPosition).y / cellSize);//        x = Mathf.FloorToInt((worldPosition - originPosition).x / cellSize);
    }

    public void SetValue(int x, int y, int value)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            gridArray[x, y] = value;
            if (OnGridValueChanged != null)
                OnGridValueChanged(this, new OnGridValueChangedEventArgs { x = x, y = y });
        }
    }

    public void SetValue(Vector3 worldPosition, int value)
    {
        int x, y;
        GetXY(worldPosition, out x, out y);
        SetValue(x, y, value);
    }

    public int GetValue(int x, int y)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            return gridArray[x, y];
        }
        else
        {
            return 0;
        }
    }

    public int GetValue(Vector3 worldPosition)
    {
        int x, y;
        GetXY(worldPosition, out x, out y);
        return GetValue(x, y);
    }

    // create background
    //Debug.Log("Started creating background");
    //GameObject Background = GameObject.CreatePrimitive(PrimitiveType.Cube);
    //Background.transform.localScale = new Vector3(1000, 0, 1000); //TODO: remove hardcode later
    //Background.transform.position = new Vector3(12, -1, 12); //TODO: remove hardcode later

    // create play grid
    //Debug.Log("Started creating grid");
    /*
    public void testGrid(){
    var XIncrease = 0;
    for (int i = 0; i < GridDimension; i++)
    {
        var ZIncrease = 0;
        for (int j = 0; j < GridDimension; j++)
        {
            GameObject Cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            Cube.transform.localScale = new Vector3(XScale, YScale, ZScale);
            Cube.transform.position = new Vector3(XPosition + XIncrease, YPosition, ZPosition + ZIncrease);
            Cube.name = i.ToString() + "-" + j.ToString();
            ZIncrease = ZIncrease + 6;
        }
        XIncrease = XIncrease + 6;
    }

    // make path
    int XStart = GridDimension / 2;
    int ZStart = 0;
    for (int i = 0; i < GridDimension; i++)
    {
        var tile = GameObject.Find(XStart.ToString() + "-" + ZStart.ToString());
        tile.GetComponent<Renderer>().material.color =
            new Color(0, 255, 0); //TODO: replace with tags, or other properties or object like
        ZStart++;
    }
    */
}