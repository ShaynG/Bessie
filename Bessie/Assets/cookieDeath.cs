﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class cookieDeath : MonoBehaviour {

	public int startingHealth = 10;
	public int currentHealth;
	public float sinkSpeed = 2.5f;
	public int scoreVal = 10;

	CapsuleCollider hitBox;
	ParticleSystem hitParticles;
	bool isDead;
	bool isSinking;
	// Use this for initialization

	void Awake()
	{
		hitParticles = GetComponent <ParticleSystem> ();
		hitBox = GetComponent<CapsuleCollider> ();

		currentHealth = startingHealth;

	}


	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (isSinking) {
			transform.Translate (-Vector3.up * sinkSpeed * Time.deltaTime);
		}


	}

	public void takeDamage ( int damage, Vector3 hitPoint)
	{
		
		currentHealth -= damage;

		hitParticles.transform.position = hitPoint;
		hitParticles.Play ();

		if (currentHealth <= 0) {
			Death ();
		}

	}

	void Death ()
	{
		// The enemy is dead.
		isDead = true;

		// Turn the collider into a trigger so shots can pass through it.
		hitBox.isTrigger = true;
		Score.score += scoreVal;
		// Tell the animator that the enemy is dead.

	}


	public void StartSinking ()
	{
		// Find and disable the Nav Mesh Agent.
		GetComponent<NavMeshAgent>().enabled = false;

		// Find the rigidbody component and make it kinematic (since we use Translate to sink the enemy).
		GetComponent <Rigidbody>().isKinematic = true;

		// The enemy should no sink.
		isSinking = true;

		// Increase the score by the enemy's score value.
		//ScoreManager.score += scoreValue;

		// After 2 seconds destory the enemy.
		Destroy (gameObject, 2f);
	}
}
