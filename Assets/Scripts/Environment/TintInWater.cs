using UnityEngine;
using System.Collections;

public class TintInWater : MonoBehaviour {

	public Camera cam;
	private bool underwater = false;
	private Color defaultAmbient;
	private Color underwaterAmbient = new Color(0,0,1);
	private float waterLevel = -1000;

	// Use this for initialization
	void Start () {
		defaultAmbient = RenderSettings.ambientLight;
	}
	
	// Update is called once per frame
	void Update () {
		if (cam.transform.position.y < waterLevel) {
			if (!underwater) {
				underwater = true;
				RenderSettings.ambientLight = underwaterAmbient;
			}
		} else {
			if (underwater) {
				underwater = false;
				RenderSettings.ambientLight = defaultAmbient;
			}
		}
	}

	void OnTriggerEnter (Collider other) {
		if (other.name == "Daylight Simple Water") {
			waterLevel = other.transform.position.y;
		}
	}
}
