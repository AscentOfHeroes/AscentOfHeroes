using UnityEngine;
using System.Collections;

public class GoToScene : MonoBehaviour {

    /// <summary>
    /// Detects when the player collides with an object and loads a level if the object
    /// has a LoadScene tag.
    /// </summary>
    /// <param name="hit">The object collided with.</param>
	void OnControllerColliderHit (ControllerColliderHit hit) {
        // Check if the object has a LoadScene tag
		if (hit.gameObject.tag == "LoadScene") {
            // Load the scene with the same name as the LoadScene game object
            LoadLevel(hit.gameObject.name);
		}
	}

    /// <summary>
    /// Loads a scene or quits the game.
    /// </summary>
    public void LoadLevel(string levelName)
    {
        if (levelName == "Quit")
        {
            Application.Quit();
        }
        else
        {
            Application.LoadLevel(levelName);
        }
    }
}
