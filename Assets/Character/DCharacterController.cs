﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DCharacterController : MonoBehaviour {

	// An exposed public variable to control the characters speed
	public float Speed = 10.0F;

	// Look related variables
	public GameObject PlayerCamera;
	public float Sensitivity = 5.0F;
	public float Smoothing = 2.0F;

	private Vector2 mouseLook;
	private Vector2 smoothV;

	// Use this for initialization
	void Start () {
		
	}

	void UpdateMouseLook() {
		Vector2 DeltaLook = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
		DeltaLook = Vector2.Scale(DeltaLook, new Vector2(Smoothing * Sensitivity, Smoothing * Sensitivity));
		smoothV.x = Mathf.Lerp (smoothV.x, DeltaLook.x, 1.0F / Smoothing);
		smoothV.y = Mathf.Lerp (smoothV.y, DeltaLook.y, 1.0F / Smoothing);
		mouseLook += smoothV;
		// Apply clamping to look directions/angles
		mouseLook.y = Mathf.Clamp(mouseLook.y, -90.0F, 90.0F);

		PlayerCamera.transform.localRotation = Quaternion.AngleAxis (-mouseLook.y, Vector3.right);
		transform.localRotation = Quaternion.AngleAxis (mouseLook.x, transform.up);
	}


	void UpdatePosition() {
		// The input tags "Vertical" and "Horizontal" can be set/changed via the the Unity editor
		// See: Edit -> Project Settings -> Input [Axes Dropdown]
		float translation = Input.GetAxis("Vertical") * Speed;
		float strave = Input.GetAxis ("Horizontal") * Speed;

		// To allow for movement over time (frames) we have to multiply by DeltaTime
		translation *= Time.deltaTime;
		strave *= Time.deltaTime;

		// Now apply the movement values for the current frame to the characters translation
		transform.Translate(strave, 0, translation);
	}
	
	// Update is called once per frame
	void Update () {
		UpdateMouseLook ();
		UpdatePosition ();
	}
}