//using UnityEngine;
//using System.Collections;
//
//public class Dialog : MonoBehaviour {
//
//	private bool talking = false;
//	public static float textboxWidth = Screen.width * 2;
//	public static float textboxHeight = Screen.height / 2;
//	private Rect textboxPosition = new Rect((Screen.width - textboxWidth)/2, Screen.height - textboxHeight, textboxWidth, textboxHeight);
//	public GUITexture dialogBox;
//
//	public string[] dialogStrings;
//	private GUIText currentDialog;
//
//	int currentDialogString = 0;
//
//	// Use this for initialization
//	void Start () {
//		dialogBox = (GUITexture)GameObject.Find("DialogBox");
//		currentDialog = FindObjectsOfType<GUIText>();
//
//		dialogBox.enabled = false;
//	}
//	
//	// Update is called once per frame
//	void Update () {
//	
//	}
//
//	void OnGUI () {
//		if (talking) {
//			dialogBox.enabled = true;
//			currentDialog.text = dialogStrings[currentDialogString];
//			if (currentDialogString < dialogStrings.Length) {
//
//				if (Input.GetKeyDown(KeyCode.E)) {
//					currentDialogString++;
//				}
//			}
//		}
//	}
//
//	public void Talk () {
//		talking = true;
//	}
//
//	public void StopTalking () {
//		talking = false;
//	}
//}
