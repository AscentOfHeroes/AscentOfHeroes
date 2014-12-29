using UnityEngine;
using System.Collections;

public class ReturnToMap : MonoBehaviour {
	void OnTriggerEnter (Collider col) {
		if (col.gameObject.tag == "teleport") {
			Application.LoadLevel("map1");
		}
	}
}