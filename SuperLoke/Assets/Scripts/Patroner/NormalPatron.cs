using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalPatron : MonoBehaviour {
	public float dmg;
	public bool DestroyedWhenHitsEnemy;
	public bool CanGoThroughWalls;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Wall" && CanGoThroughWalls == false) {
			
			Destroy (gameObject);



		}
		if (other.tag == "Enemy" && DestroyedWhenHitsEnemy) {
			Destroy (gameObject);

		}

	}


}
