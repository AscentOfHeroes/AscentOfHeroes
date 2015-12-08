using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {

	private string level;

	// Use this for initialization
	void Start () {
		if (TravelData.level == null) {
			level = "village";
		}
		else
			level = TravelData.level;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Mouse0)) {
			Application.LoadLevel(level);
		}
	}
}