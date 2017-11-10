using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeTrigger : MonoBehaviour {

	public GameObject Door;

	private bool active = false;
	private float doorRotationPerSecond = 30.0f;
	private float rotationTime = 3.0F;

	// Use this for initialization
	void Start () {}

	void OnTriggerEnter(Collider other) {
		Debug.Log ("Something has hit our CubeTrigger");

		// CompareTag check if the other object has the provided tag (editor warning if Tag does not exist)
		if (other.CompareTag("PuzzleCube") && !active) {
			active = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		// Pseudo animation to open door slowly
		if (active && rotationTime >= 0.0F) {
			Door.transform.Rotate(0, doorRotationPerSecond * Time.deltaTime, 0);
			rotationTime -= Time.deltaTime;
		}
	}
}
