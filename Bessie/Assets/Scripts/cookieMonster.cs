using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class cookieMonster : MonoBehaviour {
	public Transform player;
	//static Animator anim;
	public int coolDownPeriod = 10;
	private float timeStamp;
	private Vector3 direction;
	private CharacterController controller;

	// Use this for initialization
	void Start () {
		//anim = GetComponent<Animator>();
		controller = GetComponent<CharacterController> ();
		timeStamp = Time.time + coolDownPeriod;
	}

	// Update is called once per frame
	void Update () {


		direction = player.position - this.transform.position;
		//float angle = Vector3.Angle (direction, this.transform.forward);
		//float distance = Vector3.Distance(transform.position,player.position);


		if(Vector3.Distance(player.position, this.transform.position) < 400  /* && angle < 30 */ ){
			//direction.y = 0;

			this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
				Quaternion.LookRotation(direction), 0.1f);

			//anim.SetBool("isIdle", false);

			if(direction.magnitude > 3){
				this.transform.Translate(0,0,0.15f);
				//anim.SetBool("isWalking", true);
				//anim.SetBool("isAttacking", false);
			}else{
				//anim.SetBool("isWalking", false);
				//anim.SetBool("isAttacking", true);
			}
		} else {
			//anim.SetBool("isIdle", true);
			//anim.SetBool("isWalking", false);
			//anim.SetBool("isAttacking",false);
		}

		direction.y -= 10.0f * Time.deltaTime;
		controller.Move (direction/8 * Time.deltaTime);

	}

	void DoCharge(){

		//anim.SetBool("isCharging", true);
		direction.y = 0;
		//direction.y -= 20.0f * Time.deltaTime;
		//this.transform.Translate(0,0,0.9f);
	}
}