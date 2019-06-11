﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float damping = 1;
    public float lookAheadFactor = 3;
    public float lookAheadReturnSpeed = 0.5f;
    public float lookAheadMoveThreshold = 0.1f;
    public float upOffset = 1.5f;

    private float m_OffsetZ;
    private Vector3 m_LastTargetPosition;
    private Vector3 m_CurrentVelocity;
    private Vector3 m_LookAheadPos;

    private float closeZoom = 9f;
    private float midZoom = 11f;
    private float farZoom = 18f;
   
    private float zoomTarget;
    public Camera camera;

    public float topConstraint;
    public float bottomConstraint;


    // Use this for initialization
    private void Start()
    {
        // m_LastTargetPosition = transform.position;
        m_OffsetZ = (transform.position - target.position).z;
        transform.position = new Vector3(target.position.x, target.position.y, m_OffsetZ);
        transform.parent = null;

        zoomTarget = midZoom;

  //       if(target.gameObject.name == "Player 1" || target.gameObject.name == "UFO"){
		// 	Debug.Log("camera zoom out");
		// 	zoomTarget = farZoom;
		// } else if (target.gameObject.name == "Van") {
		// 	zoomTarget = midZoom;
		// } else {
		// 	Debug.Log("camera zoom in");
		// 	zoomTarget = closeZoom;
		// }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        // only update lookahead pos if accelerating or changed direction
        float xMoveDelta = (target.position - m_LastTargetPosition).x;

        bool updateLookAheadTarget = Mathf.Abs(xMoveDelta) > lookAheadMoveThreshold;

        if (updateLookAheadTarget)
        {
            m_LookAheadPos = lookAheadFactor*Vector3.right*Mathf.Sign(xMoveDelta);
        }
        else
        {
            m_LookAheadPos = Vector3.MoveTowards(m_LookAheadPos, Vector3.zero, Time.deltaTime*lookAheadReturnSpeed);
        }

        Vector3 aheadTargetPos = target.position + m_LookAheadPos + Vector3.forward*m_OffsetZ + Vector3.up*upOffset;
        Vector3 newPos = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref m_CurrentVelocity, damping);

        transform.position = new Vector3(newPos.x, Mathf.Clamp(newPos.y, bottomConstraint, topConstraint), newPos.z);
        // transform.position = newPos;

        m_LastTargetPosition = target.position;

    	camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, zoomTarget, Time.deltaTime);

        if(Input.GetKey("c")){
            CenterInScreen();
        }
    }

    public void SwitchFollow(GameObject other){
        Debug.Log("camer switch to follow "+other.name);

		target = other.transform;

		if(other.name == "Ship" || other.name == "UFO"){
			Debug.Log("camera zoom out");
			zoomTarget = farZoom;
		} else if (other.name == "Van") {
			zoomTarget = midZoom;
		} else {
			Debug.Log("camera zoom in");
			zoomTarget = closeZoom;
		}
    }

    public void CenterInScreen(){
        //--center on the player 
        Debug.Log("center camera");
        damping = 1;
        lookAheadFactor = 0;
        
    }

}