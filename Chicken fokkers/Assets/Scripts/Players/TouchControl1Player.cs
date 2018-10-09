using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //--enables us to use image color

//--onscreen controls to detect if screen pressed

public class TouchControl1Player : MonoBehaviour {

	public bool LeftPressed = false;
	public GameObject LBtn;
	private Color LBtnColour;
	private Color LBtnStartColour;
	private float TintAmt = 0.25f;

	void Start(){
		LBtnStartColour = LBtn.GetComponent<Image>().color;
	}
	
	// Update is called once per frame
	void Update () {

		LeftPressed = false;
		LBtnColour = LBtnStartColour;
		
		//--touch controls
		if (Input.touchCount > 0){

			var myTouches = Input.touches;
			// Debug.Log(myTouches);
			
			foreach (Touch touch in Input.touches) {
		        LeftPressed = true;
			}

		} else {

			if(Input.GetKey("left"))
			{
				// Debug.Log("both pressed");
				LeftPressed = true;
				LBtnColour.a = LBtnColour.a + TintAmt;

				return;
	        }

			//--of cursor key fallback
			if(Input.GetKey("left")) 
			{
				// Debug.Log("L pressed");
				LeftPressed = true;
				LBtnColour.a = LBtnColour.a + TintAmt;
	        } 
		}

		LBtn.GetComponent<Image>().color = LBtnColour;
	}
}
