using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//--used for stalactite

public class SwitchWhenHit : MonoBehaviour {

	public bool alive = true;
	public GameObject InitialObj; //-- the initial object
	public GameObject SwitchTo; //--the object we'll switch to - this must he disabled at start if using destroyAfterTime on any children
    public PolygonCollider2D Collider; //--for disabling when enemy is dead

    void Awake(){
    	InitialObj.SetActive(true);
		SwitchTo.SetActive(false);
    }

	// Use this for initialization
	void Start () {
  //       InitialObj.SetActive(true);
		// SwitchTo.SetActive(false);
	}
	
	void OnTriggerEnter2D(Collider2D other) {

		Debug.Log("stalac hit. other = "+other.name);

        if (other.tag == "PlayerCollider" || other.tag == "Bullet"){
            alive = false;
            InitialObj.SetActive(false);
            SwitchTo.SetActive(true);
            Collider.enabled = false;
        }

    }
}
