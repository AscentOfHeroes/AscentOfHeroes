using UnityEngine;
using System.Collections;

public class ReturnToTitleScreen : MonoBehaviour {
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape))
			Application.LoadLevel("titlescreen");
	}
}