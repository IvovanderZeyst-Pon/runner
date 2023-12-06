using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Background : MonoBehaviour
{
    private GameObject Cube;
    private int XPosition = 0;
    private int YPosition = 0;
    private int ZPosition = 0;
    private int XScale = 5;
    private int YScale = 1;
    private int ZScale = 5;
    private int GridDimension = 6;
    
    // Start is called before the first frame update
    void Start()
    {
        // create background
        Debug.Log("Started creating background");
        GameObject Background = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Background.transform.localScale = new Vector3(1000, 0, 1000); //TODO: remove hardcode later
        Background.transform.position = new Vector3(12, -1, 12); //TODO: remove hardcode later
        
        // create play grid
        Debug.Log("Started creating grid");
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
        
        // identify start and end tile
        int XStart = GridDimension / 2;
        int ZStart = 0;
        int XEnd = GridDimension / 2;
        int ZEnd = GridDimension - 1;
        Debug.Log("XStart: " + XStart.ToString());
        Debug.Log("XStart: " + ZStart.ToString());
        Debug.Log("XStart: " + XEnd.ToString());
        Debug.Log("XStart: " + ZEnd.ToString());
        
        var start_tile = GameObject.Find(XStart.ToString()+ "-"+ ZStart.ToString());
        start_tile.GetComponent<Renderer>().material.color = new Color(0, 255, 0);

        var end_tile = GameObject.Find(XEnd.ToString()+ "-"+ ZEnd.ToString());
        end_tile.GetComponent<Renderer>().material.color = new Color(255, 0, 0);
    }
    
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
