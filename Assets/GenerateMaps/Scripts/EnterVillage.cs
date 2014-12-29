using UnityEngine;
using System.Collections;

public class EnterVillage : MonoBehaviour {
	void OnTriggerEnter (Collider col) {
		if (col.gameObject.tag == "toVillage")
			Application.LoadLevel("village");
	}
}