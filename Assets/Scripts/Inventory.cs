using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {

	public List<GameObject> inventory;
	public GameObject itemDatabase;
	public Text interactionDescriptorText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if ( LookingAtPickup() ) {
			if (Input.GetKeyDown(KeyCode.E)) {
				AddPickupToInventory();
			}
		}
	}

	bool LookingAtPickup () {
		Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, 3)) {
			if (hit.collider.gameObject.tag == "Pickup") {
				interactionDescriptorText.text = hit.collider.gameObject.name;
				return true;
			}
			else {
				interactionDescriptorText.text = "";
			}
		}
		else {
			interactionDescriptorText.text = "";
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
