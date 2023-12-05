using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    private GameObject Cube;
    private int XPosition = 0;
    private int YPosition = 0;
    private int ZPosition = 0;
    private int XScale = 5;
    private int YScale = 1;
    private int ZScale = 5;
    
    // Start is called before the first frame update
    void Start()
    {
        // create background
        Debug.Log("Started creating background");
        GameObject Background = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Background.transform.localScale = new Vector3(1000, 0, 1000);
        Background.transform.position = new Vector3(12, -1, 12);
        
        // create play grid
        Debug.Log("Started creating grid");
        for (int i = 0; i <= 24; i = i + 6) 
        {
            for (int j = 0; j <= 24; j = j + 6)
            {
                GameObject Cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                Cube.transform.localScale = new Vector3(XScale, YScale, ZScale);
                Cube.transform.position = new Vector3(XPosition + i, YPosition, ZPosition + j);

                Cube.name = i.ToString() + '-' + j.ToString();
            }
        }
        
        
        
        
        
        
    }
    
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
