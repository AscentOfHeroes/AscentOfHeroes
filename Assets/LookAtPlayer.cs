using UnityEngine;
using System.Collections;

public class LookAtPlayer : MonoBehaviour {

	public Vector3 playerPosition;
	
	// Update is called once per frame
	void Update () {
		playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
		transform.LookAt(Camera.main.transform.position);
	}
}
