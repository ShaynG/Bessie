﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bessieScript : MonoBehaviour {

	private CharacterController controller;
	private ParticleSystem p;
	public float speed = 1000.0f;
	public float turnSpeed = 60.0f;
	private Vector3 moveDirection = Vector3.zero;
	public float gravity = 20.0f;
	private float jumpSpeed = 10.0f;
	public GameObject particle;

	// Use this for initialization
	void Start () {
		
		controller = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (controller.isGrounded) {
			moveDirection = transform.forward * Input.GetAxis ("Vertical") * speed;
			if(Input.GetKey("space"))
			{
				moveDirection.y = jumpSpeed;
			} else {
				moveDirection.y = 0;
			}
		}

		float turn = Input.GetAxis ("Horizontal") * speed;
		transform.Rotate (0, turn * turnSpeed * Time.deltaTime, 0);
		controller.Move (moveDirection * Time.deltaTime * speed);
		moveDirection.y -= gravity * Time.deltaTime;


		if (moveDirection.y < -40.0f) {
			
			transform.position = new Vector3 (0, 10, 0);
		}



		if (Input.GetButtonDown ("Fire1")) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

			if (Physics.Raycast (ray))
				Instantiate (particle, transform.position, transform.rotation);

			Debug.Log (Input.mousePosition.x);
		} else {
			//particle.Stop ();
		}
	}
}
