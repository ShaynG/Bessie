using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target : MonoBehaviour {

	public float health = 50f;

	public void damage( float amount)
	{
		health -= amount;

		if (health <= 0f) {

			Destroy (gameObject);

		}

	}


}
