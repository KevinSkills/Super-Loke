using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiScriptBasic : MonoBehaviour {
	float TimeSave = 0;

	public float health = 3;

	public Transform player;
	public bool hit;
	public LayerMask WallLayer;
	Shoot Fire;

	public GameObject patron;
	public float EnemySpeed;

	float enemySpeedWithDeltaTime;

	public float patronSpeed;
	public float FireRate = 0;

	public Vector2 Path1;
	public Vector2 Path2;
	public Vector2 Path3;
	public Vector2 Path4;
	public Vector2 Path5;
	public Vector2 Path6;
	Vector2 Vnull = new Vector2(0 ,0);
	bool p1 = false;
	bool p2 = false;
	bool p3 = false;
	bool p4 = false;
	bool p5 = false;
	bool p6 = false;


	bool died = false;


	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("PlayerTag").GetComponent<Transform>();
		Fire = GameObject.FindGameObjectWithTag ("PlayerTag").GetComponent<Shoot>();

	}
	
	// Update is called once per frame
	void Update () {
		if (Path2 == Vnull) {
			Path2 = Path1;
		}
		if (Path3 == Vnull) {
			Path3 = Path2;
		}
		if (Path4 == Vnull) {
			Path4 = Path3;
		}
		if (Path5 == Vnull) {
			Path5 = Path4;
		}
		if (Path6 == Vnull) {
			Path6 = Path5;
		}


		enemySpeedWithDeltaTime = EnemySpeed * Time.deltaTime;

		if (health <= 0) {

			if (died == false) {
				Destroy (this.gameObject.transform.GetChild (0).gameObject);
				Destroy (gameObject.GetComponent<Rigidbody2D> ());
				Destroy (gameObject.GetComponent<BoxCollider2D> ());
				player.gameObject.GetComponent<playerMovement> ().kills += 1;
				died = true;

			}
		}


		movePath ();
		Checker ();


		float rot_z = Mathf.Atan2 (player.position.y - transform.position.y, player.position.x - transform.position.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler (0f, 0f, rot_z - 90);
	}




	void Checker () {
		hit = Physics2D.Linecast (transform.position, player.position, WallLayer);

		if (hit == false && died == false) {
			if (Time.time > TimeSave) {
				StartCoroutine (Fire.Fire (patron, transform.position, player.position, patronSpeed, 1));
				TimeSave = Time.time + FireRate;


	
		
		}


	}



}



	void movePath() {
		if (!(Path1 == Vnull)) {
			p1 = true;
		}
		if (p1 && p2 == false && p3 == false && p4 == false && p5 == false && p6 == false) {
			transform.position = Vector2.MoveTowards (transform.position, Path1, enemySpeedWithDeltaTime);
			if ((Vector2)transform.position == Path1) {
				p2 = true;
			}
		
		}
		if (p2) {
			
			transform.position = Vector2.MoveTowards (transform.position, Path2, enemySpeedWithDeltaTime);
			if ((Vector2)transform.position == Path2) {
				p2 = false;
				p3 = true;
			}

		}
		if (p3) {
			transform.position = Vector2.MoveTowards (transform.position, Path3, enemySpeedWithDeltaTime);
			if ((Vector2)transform.position == Path3) {
				p3 = false;
				p4 = true;
			}

		}
		if (p4) {
			transform.position = Vector2.MoveTowards (transform.position, Path4, enemySpeedWithDeltaTime);
			if ((Vector2)transform.position == Path4) {
				p4 = false;
				p5 = true;
			}

		}
		if (p5) {
			transform.position = Vector2.MoveTowards (transform.position, Path5, enemySpeedWithDeltaTime);
			if ((Vector2)transform.position == Path5) {
				p5 = false;
				p6 = true;
			}

		}
		if (p6) {
			transform.position = Vector2.MoveTowards (transform.position, Path6, enemySpeedWithDeltaTime);
			if ((Vector2)transform.position == Path6) {
				p6 = false;
				p1 = true;
			}

		}


	
	
	}



	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Patron" || other.tag == "FlamePatron" || other.tag == "SniperPatron") {
			health = health - other.gameObject.GetComponent<NormalPatron>().dmg;
			//print ("toke " );

		

	}

}
}
