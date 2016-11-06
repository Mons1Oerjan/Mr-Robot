using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {

	Transform target;
	public Transform projectile;
	public Transform gunTip;
	public float shootingRange;
	public float shootingDelta;
	bool canShoot;

	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag ("Player").transform;
		shootingRange = 20;
		shootingDelta = 2;
		canShoot = true;
	}
	
	// Update is called once per frame
	void Update () {

		//check if target is in range
		if (inRange ()) {
			//look at target
			this.transform.LookAt (target);
			//repeat firing every shootingDelta seconds
			if (canShoot){
				InvokeRepeating("Fire", 0, shootingDelta);
			}
		} else {
			//cancel invokes when out of range
			if (IsInvoking ()) {
				CancelInvoke ();
				canShoot = true;
			}
		}
	}

	//check if target is in range
	bool inRange(){
		return (Vector3.Distance (target.transform.position, this.transform.position) < shootingRange);
	}

	//shoot projectile
	void Fire() {
		Instantiate (projectile, gunTip.transform.position, gunTip.transform.rotation);
		canShoot = false;
	}
}
