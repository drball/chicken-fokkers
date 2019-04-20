using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowRandomChild : MonoBehaviour {

	public GameObject[] children;

	// Use this for initialization
	void Start () {

		///--hide all in array
		foreach( GameObject child in children ){
			child.SetActive(false);
           
        }

        //--show a random entry
        children[Random.Range(0,children.Length)].SetActive(true);
	}
}
