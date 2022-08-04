using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public IEnumerator Fire(GameObject Patron, Vector3 CurrentPos, Vector3 TargetPos, float PatronSpeed, float rangeMultiplier){
		GameObject GunShot;
		Vector3 Ratio = TargetPos - CurrentPos;
		Vector3 Range = new Vector3 (Ratio.x, Ratio.y, 0);

		GunShot = Instantiate (Patron, CurrentPos, Quaternion.identity);
		bool hit = false;
		while (hit == false && !(GunShot == null)) {

			GunShot.transform.position = Vector3.MoveTowards (GunShot.transform.position, TargetPos + Range * rangeMultiplier, PatronSpeed);
		
			if (GunShot.transform.position == TargetPos + Range) {
				Destroy (GunShot);
			}



			float rot_z = Mathf.Atan2 (TargetPos.y - CurrentPos.y, TargetPos.x - CurrentPos.x) * Mathf.Rad2Deg;
			GunShot.transform.rotation = Quaternion.Euler (0f, 0f, rot_z - 270);


		
			yield return new WaitForSeconds(Time.deltaTime);
		}

	
	
	
	}
	public IEnumerator GrenadeFire(GameObject Patron, Vector3 CurrentPos, Vector3 TargetPos, float PatronSpeed, int SecondsTillExplode){
		GameObject GunShot;
		Vector3 adder = new Vector3 (0, 0, 10);

		GunShot = Instantiate (Patron, CurrentPos, Quaternion.identity);
		bool hit = false;
		while (hit == false && !(GunShot == null)) {

			GunShot.transform.position = Vector3.MoveTowards (GunShot.transform.position, TargetPos + adder, PatronSpeed);

			if (GunShot.transform.position == TargetPos + adder) {


				yield return new WaitForSeconds(SecondsTillExplode);
				Destroy (GunShot.GetComponent<SpriteRenderer> ());
				GunShot.transform.GetChild (0).gameObject.SetActive(true);
				GunShot.transform.GetChild (1).gameObject.SetActive(true);
				yield return new WaitForSeconds(0.2f);
				Destroy (GunShot.transform.GetChild (0).gameObject);
				yield return new WaitForSeconds(4);
				Destroy (GunShot);
			}



			float rot_z = Mathf.Atan2 (TargetPos.y - CurrentPos.y, TargetPos.x - CurrentPos.x) * Mathf.Rad2Deg;
			GunShot.transform.rotation = Quaternion.Euler (0f, 0f, rot_z - 270);



			yield return new WaitForSeconds(Time.deltaTime);
		}




	}
}
