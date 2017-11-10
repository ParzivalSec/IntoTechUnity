using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DCarryAbility : MonoBehaviour {

	public Camera PlayerCamera;
	public float CarryDistance;

	private bool isCarrying;
	private GameObject carriedObject;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (isCarrying) {
			Carry (carriedObject);
		} else {
			PickUp();
		}
	}

	void Carry(GameObject o) {
		if (Input.GetKeyDown (KeyCode.Mouse0)) {
			o.GetComponent<Rigidbody> ().isKinematic = false;
			isCarrying = false;
			carriedObject = null;
			return;
		}

		o.GetComponent<Rigidbody>().isKinematic = true;
		o.transform.position = PlayerCamera.transform.position + PlayerCamera.transform.forward * CarryDistance;
	}

	void PickUp() {
		if (Input.GetKeyDown (KeyCode.Mouse0)) {
			int screenMidX = Screen.width / 2;
			int screenMidY = Screen.height / 2;

			Ray pickupRay = PlayerCamera.ScreenPointToRay (new Vector3 (screenMidX, screenMidY));
			RaycastHit hit;
			if (Physics.Raycast (pickupRay, out hit)) {
				Pickupable p = hit.collider.GetComponent<Pickupable> ();
				if (p != null) {
					isCarrying = true;
					carriedObject = p.gameObject;
				}
			}
		}
	}
}
