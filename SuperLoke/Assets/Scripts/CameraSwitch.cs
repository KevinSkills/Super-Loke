using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraSwitch : MonoBehaviour {
	public Transform cam;
	public Vector3 position;
	Vector3 Nowpos;
	public Vector3 playerjump;

	public int KillCount = 0;
	public playerMovement playerScript;
	public Text NotificationText;


	// Use this for initialization
	void Start () {
//		playerScript = GameObject.Find ("player").GetComponent<playerMovement>();
//		NotificationText = GameObject.Find ("Notification").GetComponent<Text> ();



	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			NotificationText.gameObject.SetActive (false);
		
		}

	}

	void OnCollisionEnter2D(Collision2D other) {

		if(other.gameObject.tag == "PlayerTag") {
			if (playerScript.kills >= KillCount) {
				Nowpos = position;
				position = cam.position;

				other.transform.Translate (playerjump.x, playerjump.y, 0, Space.World);
				playerjump = -playerjump;
				cam.position = Nowpos;
			} 
			if (playerScript.kills < KillCount) {
				NotificationText.gameObject.SetActive (true);
				NotificationText.text = "You need to kill " + (KillCount - playerScript.kills) + " more";
			
			}

		}

	}


}
