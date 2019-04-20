using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateAtInterval : MonoBehaviour
{

	public GameObject obj;
	public float interval;
	public GameObject parent;

    void OnEnable()
    {
        Debug.Log("start instantiateAtInterval");
        InvokeRepeating("CreateNew",interval / 2,interval);
    }

    void CreateNew(){
    	if(parent.activeSelf){
    		GameObject newObj = Instantiate(obj, transform.position, transform.rotation);
		} else {
			CancelInvoke("CreateNew");
		}

    	
    }
}
