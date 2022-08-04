using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyGame : MonoBehaviour {
	public int WorkForKey;
	public playerMovement playerScript;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D (Collision2D col) {
	
		if (col.gameObject.tag == "PlayerTag") {
			print ("col worked");
			if (playerScript.keyRightNow == WorkForKey) {
				Destroy( this.GetComponent<BoxCollider2D>());
				playerScript.keyRightNow = 0;
			}
		
		}
		if (col.gameObject.tag == "Patron" || col.gameObject.tag == "FlamePatron" ) {
			print ("col worked");

			Destroy (col.gameObject);

		}
	
	
	}



}
