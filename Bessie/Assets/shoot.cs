using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour {
	public float damage = 10.0f;
	public float range = 100.0f;

	public GameObject udder;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1")) {

			fire();
		}
	}

	void fire(){

		RaycastHit hit;
		if (Physics.Raycast (udder.transform.position, udder.transform.forward, out hit, range)) {

			Debug.Log (hit.transform.name);

			target enemy = hit.transform.GetComponent<target> ();
			if (enemy != null) {
				enemy.damage (damage);
			}
		}

	}
}
