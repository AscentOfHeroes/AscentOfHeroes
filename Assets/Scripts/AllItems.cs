using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AllItems : MonoBehaviour {

	public List<GameObject> allItems;

	public GameObject getItemFromDatabase (string name) {
		foreach (GameObject item in allItems) {
			if (name == item.name) {
				return item;
			}
		}
		return null;
	}
}
