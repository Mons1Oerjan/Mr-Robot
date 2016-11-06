using UnityEngine;
using System.Collections;

public class rotateObjectAroundY : MonoBehaviour {

	public float rotationMultiplier = 10.0f;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		
		transform.Rotate(Vector3.up * Time.deltaTime * rotationMultiplier, Space.World);

	}
}
