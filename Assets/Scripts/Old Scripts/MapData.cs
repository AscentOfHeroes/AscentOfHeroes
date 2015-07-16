using UnityEngine;
using System.Collections;

public class MapData : MonoBehaviour {
	private const int mapSize = 10;
	public static int[][] mapMatrix = new int[mapSize][];
	public static bool mapCreated = false;

	public static void CreateMatrix () {
		//mapMatrix = new int[mapSize][];
		for (int i = 0; i < mapSize; i++) {
			mapMatrix[i] = new int[mapSize];
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}