using UnityEngine;
using System.Collections;

public class TakeDamage : MonoBehaviour {

	private static float TIMER_MAX_TIME = 1;
	private float timer = TIMER_MAX_TIME;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "DamageZone") {
			ApplyDamage();
		}
	}

	void OnTriggerStay (Collider other) {
		if (other.gameObject.tag == "DamageZone") {
			timer -= Time.deltaTime;
			if (TimerIsOut()) {
				ApplyDamage();
				ResetTimer();
			}
		}
	}

	void OnTriggerExit (Collider other) {
		if (other.gameObject.tag == "DamageZone") {
			ResetTimer();
		}
	}

	void ResetTimer () {
		timer = TIMER_MAX_TIME;
	}

	void ApplyDamage () {
		GetComponent<PlayerStats>().TakeDamage(5);
	}

	bool TimerIsOut () {
		return (timer <= 0);
	}
}
