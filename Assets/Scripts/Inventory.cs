using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {

	public List<GameObject> inventory;
	public GameObject itemDatabase;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.E)) {
			if ( LookingAtPickup() ) {
				AddPickupToInventory();
			}
		}
	}

	bool LookingAtPickup () {
		Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, 3)) {
			if (hit.collider.gameObject.tag == "Pickup") {
				return true;
			}
		}
		return false;
	}

	void AddPickupToInventory() {
		Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, 3)) {
			if (hit.collider.gameObject.tag == "Pickup") {
				inventory.Add(getItemFromDatabase(hit.collider.gameObject.name));
				Destroy(hit.collider.gameObject);
			}
		}
	}

	public GameObject getInventoryItem (int i) {
		return inventory[i];
	}

	public GameObject getItemFromDatabase (string name) {
		return itemDatabase.GetComponent<AllItems>().getItemFromDatabase(name);
	}
}
