using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //--enables us to use image color

//--onscreen controls for whether left or right is being pressed

public class TouchControls : MonoBehaviour {

	public bool LeftPressed = false;
	public bool RightPressed = false;
	public GameObject LBtn;
	public GameObject RBtn;
	private Color LBtnColour;
	private Color RBtnColour;
	private Color LBtnStartColour;
	private Color RBtnStartColour;
	private float TintAmt = 0.25f;

	void Start(){
		LBtnStartColour = LBtn.GetComponent<Image>().color;
		RBtnStartColour = RBtn.GetComponent<Image>().color;
	}
	
	// Update is called once per frame
	void Update () {

		RightPressed = false;
		LeftPressed = false;

		LBtnColour = LBtnStartColour;
		RBtnColour = RBtnStartColour;
		
		//--touch controls
		if (Input.touchCount > 0){

			var myTouches = Input.touches;
			// Debug.Log(myTouches);
			
			foreach (Touch touch in Input.touches) {
				
				if ((touch.position.x < Screen.width/2) )
				{
		        	LeftPressed = true;
		        	LBtnColour.a = RBtnColour.a + TintAmt;
		        	
		        } 
		        
		        if ((touch.position.x > Screen.width/2) )
		        {
		        	RightPressed = true;
		        	RBtnColour.a = RBtnColour.a + TintAmt;
		        } 
			}

		} else {


			if(Input.GetKey("left") && Input.GetKey("right") )
			{
				// Debug.Log("both pressed");
				RightPressed = true;
				LeftPressed = true;
				LBtnColour.a = LBtnColour.a + TintAmt;
				RBtnColour.a = RBtnColour.a + TintAmt;

				return;
	        }

			//--of cursor key fallback
			if(Input.GetKey("left")) 
			{
				// Debug.Log("L pressed");
				LeftPressed = true;
				LBtnColour.a = LBtnColour.a + TintAmt;
	        } 
			
			if(Input.GetKey("right"))
			{
				// Debug.Log("R pressed");
				RightPressed = true;
				RBtnColour.a = RBtnColour.a + TintAmt;
	        } 
		}

		LBtn.GetComponent<Image>().color = LBtnColour;
		RBtn.GetComponent<Image>().color = RBtnColour;
	}
}
