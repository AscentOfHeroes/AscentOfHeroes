using UnityEngine;
using System.Collections;

public class GoToScene : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnControllerColliderHit (ControllerColliderHit hit) {
		if (hit.gameObject.tag == "LoadScene") {
			Application.LoadLevel (hit.gameObject.name);
		}
	}
}
