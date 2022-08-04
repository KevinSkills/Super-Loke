using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour {
	//Kills

	public int kills = 0;

	//Hp
	public float StartHp;
	float hp;

	//UI
	public Text text;

	//Handtransforms
	public Transform NormalGunArms;
	public Transform MegaGunsarms;
	public Transform FlameGunArms;
	public Transform NormalHands;
	public Transform SniperGunArms;
	public Transform GrenadeLauncherArms;
	Transform CurrentGunArms;

	//public Scripts
	public Shoot ShootScript;
	public GameObject NormalPatron;
	public GameObject FlamePatron;
	public GameObject SniperPatron;
	public GameObject Grenade;
	public Health Health;
	//Private Scripts
	Rigidbody2D rb2d;
	GameObject CurrentPatron;
	//For guns



	public float PatronSpeed;
	public float FireRate = 0;

	float TimeSave = 0;
	//For Rotation and movement
	Vector3 Position;
	Vector3 MousePos;
	public float speed;
	float z_rotMove = 0;
	//Mathf
	float RVelocity;
	float CurrentRotation;
	//Varibales
	bool mouseClick = false;
	//for inventory
	bool slot1 = false;
	bool slot2 = false;
	bool slot3 = false;
	bool slot4 = false;
	public Image slotOb1;
	public Image slotOb2;
	public Image slotOb3;
	public Image slotOb4;

	int slot1Ammo;
	int slot2Ammo;
	int slot3Ammo;
	int slot4Ammo;

	int activatedSlot;
	//keys
	public int keyRightNow;
	public Image KeyImage;






	Vector3 pos;
	// Use this for initialization
	void Start () {
		hp = StartHp;

		CurrentGunArms = NormalHands;
		FireRate = 0;

		rb2d = GetComponent<Rigidbody2D> ();


		CurrentPatron = NormalPatron;






	}



	
	// Update is called once per frame
	void Update () {
		Health.ShowHearts (hp);

		if (activatedSlot == 1) {
			text.text = "" + slot1Ammo;
		}
		if (activatedSlot == 2) {
			text.text = "" + slot2Ammo;
		}
		if (activatedSlot == 3) {
			text.text = "" + slot3Ammo;
		}
		if (activatedSlot == 4) {
			text.text = "" + slot4Ammo;
		}






		if (keyRightNow == 0) {
			KeyImage.sprite = null;
		}


		ChooseInventoryItem ();

		if (Input.GetKey (KeyCode.Space)) {
			Display.displays [0].Activate ();
		
		} else {
			Display.displays [0].Activate ();
		}




		if (Input.GetMouseButton (1) || Input.GetMouseButton (0)) {
			mouseClick = true;

		} else {
			mouseClick = false;
		}
		move ();
		rotateToMouse ();






	}



	void rotateToMouse(){
		if (mouseClick) {
			MousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition) - transform.position;



			MousePos.Normalize ();

			float rot_z = Mathf.Atan2 (MousePos.y, MousePos.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.Euler (0f, 0f, rot_z - 90);

			if (Input.GetMouseButton (0)) {


				if (Time.time > TimeSave && !(CurrentGunArms == NormalHands)) {
					if (!(CurrentGunArms == GrenadeLauncherArms)) {
						StartCoroutine (ShootScript.Fire (CurrentPatron, CurrentGunArms.position, Camera.main.ScreenToWorldPoint (Input.mousePosition), PatronSpeed, 100f));
					
					}
					if (CurrentGunArms == GrenadeLauncherArms) {
						StartCoroutine (ShootScript.GrenadeFire (CurrentPatron, CurrentGunArms.position, Camera.main.ScreenToWorldPoint (Input.mousePosition), PatronSpeed, 2));

					}

					if (activatedSlot == 1) {
						slot1Ammo--;
						if (slot1Ammo < 1) {
							slot1 = false;
							slotOb1.sprite = null;
							CurrentGunArms.gameObject.SetActive (false);
							NormalHands.gameObject.SetActive (true);
							CurrentGunArms = NormalHands;


						
						}
					}
					if (activatedSlot == 2) {
						slot2Ammo--;
						if (slot2Ammo < 1) {
							slot2 = false;
							slotOb2.sprite = null;
							CurrentGunArms.gameObject.SetActive (false);
							NormalHands.gameObject.SetActive (true);
							CurrentGunArms = NormalHands;


						}
					}
					if (activatedSlot == 3) {
						slot3Ammo--;
						if (slot3Ammo < 1) {
							slot3 = false;
							slotOb3.sprite = null;
							CurrentGunArms.gameObject.SetActive (false);
							NormalHands.gameObject.SetActive (true);
							CurrentGunArms = NormalHands;


						}
					}
					if (activatedSlot == 4) {
						slot4Ammo--;
						if (slot4Ammo < 1) {
							slot4 = false;
							slotOb4.sprite = null;
							CurrentGunArms.gameObject.SetActive (false);
							NormalHands.gameObject.SetActive (true);
							CurrentGunArms = NormalHands;


						}
					}
					TimeSave = Time.time + FireRate;






				}
			
			}

		}
	
	
	}

	void move() {
		
		float currentSpeed = speed * Time.deltaTime;


		rb2d.velocity = new Vector2(currentSpeed * Input.GetAxis ("Horizontal"), currentSpeed * Input.GetAxis ("Vertical"));
		

		if (Input.GetKey (KeyCode.W)) {
			z_rotMove = 0;
		
		}
		if (Input.GetKey(KeyCode.S)) {
			z_rotMove = 180;

		}
		if (Input.GetKey (KeyCode.A)) {
			z_rotMove = 90;

		}
		if (Input.GetKey (KeyCode.D)) {
			z_rotMove = 270;

		}
		if (Input.GetKey (KeyCode.W) && Input.GetKey (KeyCode.D)) {
			z_rotMove = 315;

		}
		if (Input.GetKey (KeyCode.W) && Input.GetKey (KeyCode.A)) {
			z_rotMove = 45;

		}
		if (Input.GetKey (KeyCode.S) && Input.GetKey (KeyCode.D)) {
			z_rotMove = 225;

		}
		if (Input.GetKey (KeyCode.S) && Input.GetKey (KeyCode.A)) {
			z_rotMove = 135;

		}

		CurrentRotation = Mathf.SmoothDampAngle(CurrentRotation, z_rotMove, ref RVelocity, 0.1f);

		if (!mouseClick) {
			transform.rotation = Quaternion.Euler (0, 0, CurrentRotation);
		}

}

	void OnTriggerEnter2D (Collider2D other) {
	
		if (other.tag == "Heart") {
			if (hp < 3) {
				hp += 1;
				Destroy (other.gameObject);
			}
		
		}

		if (other.tag == "EnemyPatron") {
			print (gameObject.name + " Hit");
			hp -= 1;
			this.GetComponent<SpriteRenderer> ().color = Color.red;
			StartCoroutine (Waiter());
		}

		if (other.tag == "Weapon") {
			if (slot1 == false) {
				slotOb1.sprite = other.GetComponent<SpriteRenderer> ().sprite;
				activatedSlot = 1;
				CheckerForwhichGun (slotOb1, true, 1);
				slot1 = true;
			} else if (slot2 == false) {
				slotOb2.sprite = other.GetComponent<SpriteRenderer> ().sprite;
				activatedSlot = 2;
				CheckerForwhichGun (slotOb2, true, 2);
				//Destroy (other.gameObject);
				slot2 = true;
			} else if (slot3 == false) {
				slotOb3.sprite = other.GetComponent<SpriteRenderer> ().sprite;
				activatedSlot = 3;
				CheckerForwhichGun (slotOb3, true, 3);
				slot3 = true;
			} else if (slot4 == false) {
				slotOb4.sprite = other.GetComponent<SpriteRenderer> ().sprite;
				activatedSlot = 4;
				CheckerForwhichGun (slotOb4, true, 4);
				slot4 = true;
			} else {
				print ("inventory full");
			}

			Destroy (other.gameObject);


		
		}
		if (other.tag == "Key1") {
			print ("took key1");
			KeyImage.sprite = other.GetComponent<SpriteRenderer> ().sprite;
			keyRightNow = 1;
			Destroy (other.gameObject);
		}
		if (other.tag == "Key2") {
			KeyImage.sprite = other.GetComponent<SpriteRenderer> ().sprite;
			keyRightNow = 2;
			Destroy (other.gameObject);
		}
		if (other.tag == "Key3") {
			KeyImage.sprite = other.GetComponent<SpriteRenderer> ().sprite;
			keyRightNow = 3;
			Destroy (other.gameObject);
		}
		
		
		
		
	
	}



	void ChooseInventoryItem(){
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			if (slot1 == true) {
				
				activatedSlot = 1;
				CheckerForwhichGun (slotOb1, false, 0);

			} else {
				print ("slot is empty");
			}
		
		
		}
		if (Input.GetKeyDown (KeyCode.Alpha2)) {
			if (slot2 == true) {
				
				CheckerForwhichGun(slotOb2, false, 0);
				activatedSlot = 2;
			} else {
				print("slot2 is empty");
			}



		}
		if (Input.GetKeyDown (KeyCode.Alpha3)) {

			if (slot3 == true) {
				CheckerForwhichGun(slotOb3, false, 0);
				activatedSlot = 3;
			} else {
				print("slot3 is empty");
			}



		}
		if (Input.GetKeyDown (KeyCode.Alpha4)) {
			
			if (slot4 == true) {
				CheckerForwhichGun(slotOb4, false, 0);
				activatedSlot = 4;
			} else {
				print("slot4 is empty");
			}



		}
	
	
	}

	void CheckerForwhichGun(Image SlotImage, bool Once, int slotNumber){
	
		if (SlotImage.sprite.name == "NormalGun") {
			FireRate = 0.2f;
			PatronSpeed = 0.4f;

			CurrentGunArms.gameObject.SetActive (false);

			CurrentPatron = NormalPatron;
			CurrentGunArms = NormalGunArms;

			CurrentGunArms.gameObject.SetActive (true);

			if (Once) {
				GiveAmmo (9999, slotNumber);
			
			}


		
		}
		if (SlotImage.sprite.name == "MegaGun") {
			FireRate = 0.02f;
			PatronSpeed = 0.7f;

			CurrentGunArms.gameObject.SetActive (false);

			CurrentPatron = NormalPatron;
			CurrentGunArms = MegaGunsarms;

			CurrentGunArms.gameObject.SetActive (true);

			if (Once) {
				GiveAmmo (60, slotNumber);

			}




		}
		if (SlotImage.sprite.name == "FlameGun") {
			FireRate = 0.02f;
			PatronSpeed = 0.3f;

			CurrentGunArms.gameObject.SetActive (false);

			CurrentPatron = FlamePatron;
			CurrentGunArms = FlameGunArms;

			CurrentGunArms.gameObject.SetActive (true);

			if (Once) {
				GiveAmmo (200, slotNumber);

			}



		}
		if (SlotImage.sprite.name == "Sniper") {
			FireRate = 2f;
			PatronSpeed = 2f;

			CurrentGunArms.gameObject.SetActive (false);

			CurrentPatron = SniperPatron;
			CurrentGunArms = SniperGunArms;

			CurrentGunArms.gameObject.SetActive (true);

			if (Once) {
				GiveAmmo (5, slotNumber);

			}



		}
		if (SlotImage.sprite.name == "GrenadeLauncher") {
			FireRate = 3f;
			PatronSpeed = 1f;

			CurrentGunArms.gameObject.SetActive (false);

			CurrentPatron = Grenade;
			CurrentGunArms = GrenadeLauncherArms;

			CurrentGunArms.gameObject.SetActive (true);

			if (Once) {
				GiveAmmo (5, slotNumber);

			}



		}



	
	
	
	
	
	
	}

	void GiveAmmo (int AmmoGiven, int slotNumber){
		if (slotNumber == 1) {
			slot1Ammo = AmmoGiven;
		}
		if (slotNumber == 2) {
			slot2Ammo = AmmoGiven;
		}
		if (slotNumber == 3) {
			slot3Ammo = AmmoGiven;
		}
		if (slotNumber == 4) {
			slot4Ammo = AmmoGiven;

		}

	
	
	}
	IEnumerator Waiter () {
		yield return new WaitForSeconds (0.2f);

		this.GetComponent<SpriteRenderer> ().color = Color.white;





	}


	
	
	}




