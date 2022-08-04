using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour {
	public GameObject Life1;
	public GameObject Life2;
	public GameObject Life3;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void ShowHearts (float health){


		if (health >= 3 && health < 4) {
			Life1.SetActive (true);
			Life2.SetActive (true);
			Life3.SetActive (true);



		}
		if (health >= 2 && health < 3) {
			Life1.SetActive (true);
			Life2.SetActive (true);
			Life3.SetActive (false);



		}
		if (health >= 1 && health < 2) {
			Life1.SetActive (true);
			Life2.SetActive (false);
			Life3.SetActive (false);



		}
		if(health < 1){

			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	
	
	}
	


}
