using UnityEngine;
using System.Collections;

public class LookAtPlayer : MonoBehaviour {

	public Vector3 playerPosition;
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance(transform.position, Camera.main.transform.position) < EnemyStats.aggroRange) {
			transform.LookAt(Camera.main.transform.position);
		}
	}
}
