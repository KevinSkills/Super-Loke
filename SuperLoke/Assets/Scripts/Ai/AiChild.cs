using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiChild : MonoBehaviour {



	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Patron" || other.tag == "FlamePatron" ) {
			print ("hej trigger is ok");
			this.GetComponent<SpriteRenderer> ().color = Color.red;
			StartCoroutine (Waiter());

		}


	}




	IEnumerator Waiter () {
		yield return new WaitForSeconds (0.2f);

			this.GetComponent<SpriteRenderer> ().color = Color.white;

		



	}
}
