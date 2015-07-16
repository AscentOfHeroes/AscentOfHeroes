using UnityEngine;
using System.Collections;

/* This script should be attached to an enemy's head.
 * It tells the enemy's head to point toward the player
 * while the player is in the enemy's field of vision.
 * This script requires a field of view to work.
 * (Recommended that FoV is child of head object)
 */

public class LookAtPlayer : MonoBehaviour {

	public FieldOfVision fov;

	// The default rotation of the head
	private Vector3 initialAngles;

	void Start () {
		initialAngles = transform.localEulerAngles;
	}
	
	// Update is called once per frame
	void Update () {

		// If the player is in sight, look at the player's head
		if (fov.playerInSight) {
			transform.LookAt(Camera.main.transform.position);
		}

		// If the player is out of sight, look in the default direction
		else if (transform.eulerAngles != initialAngles) {
			transform.localEulerAngles = initialAngles;
		}
	}
}
