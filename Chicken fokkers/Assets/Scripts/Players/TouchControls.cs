using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//--onscreen controls for whether left or right is being pressed

public class TouchControls : MonoBehaviour {

	public bool LeftPressed = false;
	public bool RightPressed = false;
	
	// Update is called once per frame
	void Update () {

		RightPressed = false;
		LeftPressed = false;
		
		//--touch controls
		if (Input.touchCount > 0){

			var myTouches = Input.touches;
			// Debug.Log(myTouches);
			
			foreach (Touch touch in Input.touches) {
				
				if ((touch.position.x < Screen.width/2) )
				{
		        	LeftPressed = true;
		        } 
		        
		        if ((touch.position.x > Screen.width/2) )
		        {
		        	RightPressed = true;
		        } 
			}

		} else {


			if(Input.GetKey("left") && Input.GetKey("right") )
			{
				Debug.Log("both pressed");
				RightPressed = true;
				LeftPressed = true;

				return;
	        }

			//--of cursor key fallback
			if(Input.GetKey("left")) 
			{
				// Debug.Log("L pressed");
				LeftPressed = true;
	        } 
			
			if(Input.GetKey("right"))
			{
				// Debug.Log("R pressed");
				RightPressed = true;
	        } 
		}
	}
}
