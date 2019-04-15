using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//--move this gameobject into the root
//--ideal for an rb spawned as part of another object that has it's own rb 

public class MoveToRoot : MonoBehaviour {

	// Use this for initialization
	void Start () {
		transform.parent = null;
	}
	
}
