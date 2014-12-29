using UnityEngine;
using System.Collections;

public class Travel : MonoBehaviour {

	void OnTriggerEnter (Collider col) {
		switch(col.gameObject.tag) {
		case "Exit":
			TravelData.level = "map1";
			break;
		case "EnterVillage":
			TravelData.level = "village";
			TravelData.playerSpawnPosition = col.transform.position + new Vector3(20,2,0);
			TravelData.playerSpawnRotation = Quaternion.identity;
			break;
		}
		Application.LoadLevel(TravelData.level);
	}
}