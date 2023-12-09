using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using CodeMonkey.Utils;

public class Testing : MonoBehaviour {

    private GridSystem grid;

    private void Start() {
        grid = new GridSystem(10, 10, 10f, new Vector3(0, 0));
    }

    private void Update() {
        if (Input.GetMouseButtonDown(0)) 
        {
            grid.SetValue(GridSystem.GetMouseWorldPosition(), 1);
            Debug.Log(grid.GetValue(GridSystem.GetMouseWorldPosition()));
            Debug.Log ("mouseDown = x: " + Input.mousePosition.x + " y: " + Input.mousePosition.y 
                       + " z: " + Input.mousePosition.z);
        }
    }
}

