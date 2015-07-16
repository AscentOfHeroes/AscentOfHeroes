using UnityEngine;
using System.Collections;

public class DeathBarrier : MonoBehaviour {
	
	void OnTriggerEnter (Collider other) { 
		if (other.gameObject.tag == "Player") {
			other.gameObject.GetComponent<PlayerStats>().TakeDamage(999999);
		}
	}
}
