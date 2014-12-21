using UnityEngine;
using System.Collections;

public class Exit : MonoBehaviour {

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
		if(Input.GetKeyDown(KeyCode.Escape)) {
			Application.Quit();
		}
	}
}
