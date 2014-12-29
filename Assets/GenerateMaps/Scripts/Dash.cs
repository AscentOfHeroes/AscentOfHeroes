using UnityEngine;
using System.Collections;

public class Dash : MonoBehaviour {

	int keyW;
	float countdown = 0.5f;
	float timer;
	bool startTimer;
	CharacterMotor motor;
	float dashCountdown = 0.5f;
	float dashTimer;
	float dashAcceleration = 10.0f;

	// Use this for initialization
	void Start () {
		keyW = 0;
		timer = countdown;
		motor = this.GetComponent<CharacterMotor>();
		dashTimer = dashCountdown;
	}
	
	// Update is called once per frame
	void Update () {
		this.rigidbody.AddForce(this.transform.forward);
		if (Input.GetKeyDown(KeyCode.W)) {
			if (keyW == 0) {
				keyW = 1;
			}
			else if (keyW == 1) {
//				keyW = 2;
				this.rigidbody.AddForce(this.transform.forward * 100);
				keyW = 0;
			}
		}
//		else if (keyW == 2) {
////			motor.movement.maxGroundAcceleration = dashAcceleration;
////			motor.movement.maxForwardSpeed = 200.0f;
//			this.rigidbody.AddForce(this.transform.forward * 1000 + new Vector3(0,10,0));
//			keyW = 0;
//			startTimer = false;
//			timer = countdown;
//		}
//		else {
//			if (keyW == 1 && Input.GetKeyUp(KeyCode.W)) {
//				startTimer = true;
//			}
//			if (startTimer) {
//				timer -= Time.deltaTime;
//			}
//			if (timer <= 0) {
//				keyW = 0;
//				startTimer = false;
//				timer = countdown;
//			}
//
//			if (keyW == 0 && Input.GetKeyUp(KeyCode.W)) {
//				Debug.Log("Wup");
//				dashTimer = dashCountdown;
////				motor.movement.maxGroundAcceleration = 10000.0f;
////				motor.movement.maxForwardSpeed = 10.0f;
//			}
//		}
//		if (motor.movement.maxGroundAcceleration == dashAcceleration) {
//			dashTimer -= Time.deltaTime;
//			if (dashTimer <= 0) {
//				dashTimer = dashCountdown;
////				motor.movement.maxGroundAcceleration = 10000.0f;
////				motor.movement.maxForwardSpeed = 10.0f;
//			}
//		}
	}
}
