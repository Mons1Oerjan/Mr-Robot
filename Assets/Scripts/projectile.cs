using UnityEngine;
using System.Collections;

public class projectile : MonoBehaviour {

	Transform target;
	public Transform spawn;
	public float speed;
	public float range;
	Vector3 direction;

	// Use this for initialization
	void Start () {
		speed = 5;
		range = 20;
		//set the target direction when object is created
		target = GameObject.FindGameObjectWithTag ("Player").transform;
		direction = target.transform.forward * Time.deltaTime * speed;
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt (target); //look at target
		transform.Translate (direction); //travel in the desired direction

		//destroy projectile if it travels too far away from the turret
		if (Vector3.Distance (transform.position, spawn.transform.position) > range) {
			if (this.gameObject.name.Contains ("Clone")) {
				DestroyObject (gameObject);
			}

		}
	}

	//destroy object when colliding with any object
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag != "Player") {
			if (this.gameObject.name.Contains ("Clone")) {
				DestroyObject (gameObject);
			}
		}
	}

}
