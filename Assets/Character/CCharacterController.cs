using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCharacterController : MonoBehaviour {



	// Use this for initialization
	void Start () {
		Cursor.lockState = CursorLockMode.Locked;
	}
		
	void UpdateMouseLook() {
		// TODO: Implement me
	}
		
	void UpdatePosition() {
		// TODO: Implement me
	}

	// Update is called once per frame
	void Update () {
		UpdateMouseLook ();
		UpdatePosition ();

		if (Input.GetKey (KeyCode.Escape)) {
			Cursor.lockState = CursorLockMode.None;
		}
	}
}
