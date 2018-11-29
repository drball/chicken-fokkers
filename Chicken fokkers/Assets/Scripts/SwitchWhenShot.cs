// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//--used for stalactite

public class SwitchWhenShot : MonoBehaviour {

	public bool alive = true;
	public GameObject InitialObj; //-- the initial object
	public GameObject SwitchTo; //--the object we'll switch to
    public PolygonCollider2D Collider; //--for disabling when enemy is dead
    public int health;
    public Slider HealthBar;
	public GameObject HealthBarObj;
	public SpriteRenderer[] Rends; //--for colour change
	private Color initialColour;
	private int initialHealth;

	// Use this for initialization
	void Start () {
		initialHealth = health;
        InitialObj.SetActive(true);
		SwitchTo.SetActive(false);
		HealthBar.value = 1;
		foreach(SpriteRenderer Rend in Rends){
			initialColour = Rend.color;
		}
		HealthBarObj.SetActive(false);
	}
	
	void OnTriggerEnter2D(Collider2D other) {

		Debug.Log("boulder hit. other = "+other.name);

        if (other.tag == "PlayerCollider" || other.tag == "Bullet"){

        	health--;
			Invoke("ResetColour", 0.06f);
			HealthBarObj.SetActive(true);

        	foreach(SpriteRenderer Rend in Rends){
				Rend.color = new Color(255, 0, 0, 0.5f); //--make it red
			}

			if(health <= 0 ){
				Die();
			}

			Debug.Log("health = "+health + ". initial = "+initialHealth);
			
			float newHealthBarValue = (float)health / (float)initialHealth;

			Debug.Log("new healthbar = "+newHealthBarValue);

			HealthBar.value = newHealthBarValue;
        }
    }

    void Die(){
    	alive = false;
        InitialObj.SetActive(false);
        SwitchTo.SetActive(true);
        Collider.enabled = false;
        Invoke("RemoveHealthBar", 0.1f);
    }

    void ResetColour(){
		foreach(SpriteRenderer Rend in Rends){
			Rend.color = initialColour;
		}
	}

	void RemoveHealthBar(){
		HealthBarObj.SetActive(false);
	}
}
