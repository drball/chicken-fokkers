using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCenter : MonoBehaviour
{
    public Camera cam;
    public GameObject P1Obj; 
    public GameObject P2Obj; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        P1Obj.transform.position = cam.ScreenToWorldPoint( new Vector3(Screen.width/4f, Screen.height/1.9f, 1f) );
        P2Obj.transform.position = cam.ScreenToWorldPoint( new Vector3((Screen.width/4f)*3, Screen.height/1.9f, 1f) );
    }
}
