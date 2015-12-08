using UnityEngine;
using System.Collections;

public class ShowDebugPanel : MonoBehaviour {

    GameObject debugPanel;

	// Use this for initialization
	void Start () {
        debugPanel = GameObject.Find("DebugPanel");
        debugPanel.SetActive(Application.isEditor);
    }
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.BackQuote)) {
            debugPanel.SetActive(!debugPanel.activeSelf);
        }
	}
}
