﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thirdPersonCam : MonoBehaviour {

	public Transform lookAt;
	public Transform camTransform;

	//private Camera cam;
	private const float Y_MIN = 0.0f;
	private const float Y_MAX = 50.0f;
	private float distance = 10.0f;
	private float currX = 0.0f;
	private float currY = 0.0f;



	private void Start()
	{
		camTransform = transform;
		//cam = Camera.main;
	}
	private void Update()
	{
		currX += Input.GetAxis ("Mouse X");
		currY += Input.GetAxis ("Mouse Y");

		distance += Input.GetAxis ("Mouse ScrollWheel");
		distance = Mathf.Clamp (distance, 10, 50);

		currY = Mathf.Clamp (currY, Y_MIN, Y_MAX);
	}


	private void LateUpdate()
	{
		Vector3 dir = new Vector3 (0, 0, -distance);
		Quaternion rotation = Quaternion.Euler (currY, currX, 0);
		camTransform.position = lookAt.position + rotation * dir;
		camTransform.LookAt (lookAt.position);
	}
}
