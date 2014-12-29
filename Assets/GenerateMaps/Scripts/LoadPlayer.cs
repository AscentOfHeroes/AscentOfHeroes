using UnityEngine;
using System.Collections;

public class LoadPlayer : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () {
		if (Application.loadedLevelName == "map1") {
			// Make sure map is loaded first
			gameObject.GetComponent<GenerateMap2>().Generate();
			if (TravelData.playerSpawnPosition == new Vector3(0,0,0)) {
				TravelData.playerSpawnPosition = GameObject.FindGameObjectWithTag("EnterVillage").transform.position + new Vector3(20,2,0);
				TravelData.playerSpawnRotation = Quaternion.identity;
			}
			Instantiate(player, TravelData.playerSpawnPosition, TravelData.playerSpawnRotation);
		}
		else {
			Instantiate(player, this.transform.position, this.transform.rotation);
		}
	}
}