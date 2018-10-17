using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkThenRemove : MonoBehaviour {

	public float delay = 2.5f;
	public Renderer[] childRends;

	// Use this for initialization
	void Start () {
		childRends = GetComponentsInChildren<Renderer>( ) as Renderer[];
		Invoke("StartFlashing", delay);
	}
	
    void StartFlashing(){
    	Debug.Log("start flashing");
    	StartCoroutine("Blink");
    }

    IEnumerator Blink(){
    	Hide();
    	yield return new WaitForSeconds(0.04f);
    	Show();
    	yield return new WaitForSeconds(0.04f);
    	Hide();
    	yield return new WaitForSeconds(0.04f);
    	Show();
    	yield return new WaitForSeconds(0.04f);
    	Hide();
    	Destroy(gameObject);
    }

    void Hide(){
		//-disable renderer of all children
    	foreach( Renderer childRend in childRends ){
            childRend.enabled = false;
            // Debug.Log("make "+childRend+" hidden");
        }

    }

    void Show(){
		//-enable renderer of all children
    	foreach( Renderer childRend in childRends ){
            childRend.enabled = true;
            // Debug.Log("make "+childRend+" show");
        }
    }
}