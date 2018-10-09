using System.Collections;
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
    private float farZoom = 17f;
   
    public float zoomTarget;
    public Camera camera;


    // Use this for initialization
    private void Start()
    {
        Debug.Log("transform "+transform.position);
        // m_LastTargetPosition = transform.position;
        m_OffsetZ = (transform.position - target.position).z;
        transform.position = new Vector3(target.position.x, target.position.y, m_OffsetZ);
        Debug.Log("transform now "+transform.position);
        transform.parent = null;

        zoomTarget = closeZoom;

        if(target.gameObject.name == "Ship" || target.gameObject.name == "UFO"){
			Debug.Log("camera zoom out");
			zoomTarget = farZoom;
		} else if (target.gameObject.name == "Van") {
			zoomTarget = midZoom;
		} else {
			Debug.Log("camera zoom in");
			zoomTarget = closeZoom;
		}
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

        transform.position = newPos;

        m_LastTargetPosition = target.position;

    	camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, zoomTarget, Time.deltaTime);
    }

    public void SwitchFollow(GameObject other){

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
}