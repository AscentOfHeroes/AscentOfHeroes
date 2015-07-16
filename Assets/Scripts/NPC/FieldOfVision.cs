using UnityEngine;
using System.Collections;

/* Attached to a field of view object.
 * Other scripts can use playerInSight to
 * determine how they interact with the player.
 */

public class FieldOfVision : MonoBehaviour {
	
	public bool playerInSight;

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "Player") {
			playerInSight = true;
		}
	}

	void OnTriggerExit (Collider other) {
		if (other.gameObject.tag == "Player") {
			playerInSight = false;
		}
	}
}
