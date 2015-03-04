using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EquipWeapon : MonoBehaviour {

	GameObject equip;
	List<GameObject> inventory;
	int currentlyEquipped = -1;

	// Use this for initialization
	void Start () {
		inventory = transform.parent.parent.gameObject.GetComponent<Inventory>().inventory;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Alpha0)) {
			UnequipWeapon();
		} else if (Input.GetKeyDown(KeyCode.Alpha1)) {
			equipInventoryItem(0);
		} else if (Input.GetKeyDown(KeyCode.Alpha2)) {
			equipInventoryItem(1);
		} else if (Input.GetKeyDown(KeyCode.Alpha3)) {
			equipInventoryItem(2);
		} else if (Input.GetKeyDown(KeyCode.Alpha4)) {
			equipInventoryItem(3);
		} else if (Input.GetKeyDown(KeyCode.Q)) {
			DropWeapon ();
		}
	}

	void equipInventoryItem (int i) {
		UnequipWeapon();
		if (!alreadyEquipped(i) && InventoryIsLargeEnough(i)) {
			equip = (GameObject)Instantiate(getInventoryItem(i));
			equip.name = getInventoryItem(i).name;
			equip.transform.parent = transform;
			equip.transform.position = transform.position;
			equip.transform.rotation = transform.rotation;
			currentlyEquipped = i;
		}
	}

	bool alreadyEquipped (int i) {
		if (currentlyEquipped == i) {
			return true;
		}

//		if (equip && InventoryIsLargeEnough(i)) {
//			if (inventory[i].gameObject.name+"(Clone)" == equip.name) {
//				return true;
//			}
//		}
		return false;
	}

	bool InventoryIsLargeEnough (int i) {
		return inventory.Count >= i+1;
	}

	GameObject getInventoryItem (int i) {
		return inventory[i];
	}

	void UnequipWeapon () {
		if (equip != null) {
			Destroy(equip);
			currentlyEquipped = -1;
		}
	}

	void DropWeapon () {
		if (equip != null) {
			equip.transform.parent = null;
			inventory.RemoveAt(currentlyEquipped);
			equip = null;
			currentlyEquipped = -1;
		}
	}
}
