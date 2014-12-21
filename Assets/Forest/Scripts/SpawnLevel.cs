using UnityEngine;
using System.Collections;

public class SpawnLevel : MonoBehaviour {

	public GameObject[] levelSelection;

	// Use this for initialization
	void Start () {
		int level = Random.Range(0, levelSelection.Length);
		Instantiate(levelSelection[level], transform.position, transform.rotation);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
