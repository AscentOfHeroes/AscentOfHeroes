using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {

    public GameObject playerCamera;
    public GameObject pauseMenu;

	void Start () {
        // Hide the pause menu on initialization
        pauseMenu.SetActive(false);

        // Make sure the game is unpaused on initialization
        Time.timeScale = 1;
	}

	void Update () {
	    if (Input.GetKeyDown(KeyCode.Escape)) {
            TogglePause();
        }
	}

    /// <summary>
    /// Pauses/unpauses the gameplay and shows/hides the pause menu.
    /// </summary>
    public void TogglePause()
    {
        // Toggle the timescale between 1 and 0
        Time.timeScale = (Time.timeScale + 1) % 2;

        // Toggle MouseLook scripts on both Player and Main Camera
        GetComponent<MouseLook>().enabled = !GetComponent<MouseLook>().enabled;
        playerCamera.GetComponentInChildren<MouseLook>().enabled = !playerCamera.GetComponentInChildren<MouseLook>().enabled;

        // Toggle the pause menu on or off
        pauseMenu.SetActive(!pauseMenu.activeSelf);
    }
}
