using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//--script has to be on same obj as trigger collider

public class MoveUntilSeePlayer : MonoBehaviour {

	public float moveSpeed = 1f;
	public bool isMoving = true;
	public GameObject ObjectToMove;

	// Use this for initialization
	void Start () {
		isMoving = true;
	}
	
	// Update is called once per frame
	void Update () {

		if(isMoving == true){
			ObjectToMove.transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
		}
	}

	void OnTriggerEnter2D(Collider2D other) {

		if(isMoving == true && other.transform.name == "PlayerCollider"){
			isMoving = false;
		} 
	}
}
