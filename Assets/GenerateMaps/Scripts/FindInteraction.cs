using UnityEngine;
using System.Collections;

public class FindInteraction : MonoBehaviour {

	public static bool interacting;
	public bool interactionHit;
	public Texture2D texture;

	private RaycastHit hit;
	private Rect texturePosition;

	// Use this for initialization
	void Start () {
		interacting = false;
		interactionHit = false;
		texturePosition = new Rect(Screen.width/2 - texture.width,Screen.height/2 - texture.height,texture.width,texture.height);
	}
	
	// Update is called once per frame
	void Update () {
		if (!interacting && Physics.Raycast(transform.position,transform.forward,out hit,2)) {
			interactionHit = (hit.collider.gameObject.tag == "Interaction") ? true : false;
			if (Input.GetKeyDown(KeyCode.E)) {
//				if (hit.collider.gameObject.GetComponent<Dialog>() != null) {
//					hit.collider.gameObject.GetComponent<Dialog>().Talk();
//				}
			}
		}
		else {
			interactionHit = false;
		}
	}

	void OnGUI () {
		if (interactionHit)
			GUI.DrawTexture(texturePosition,texture);
	}
}
