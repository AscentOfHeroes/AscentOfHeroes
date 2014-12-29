using UnityEngine;
using System.Collections;

public class GenerateMap2 : MonoBehaviour {
	private bool templePlaced;

	private int mapSize = 10;
	private float squareLength;

	public GameObject[] mapSquares;
	public GameObject village;
	public GameObject temple;
	public GameObject character;

	public int spawnHeight;
	public int spawnOffset;

	// Use this for initialization
	public void Generate () {
		if (!MapData.mapCreated) {
			CreateMap();
		}
		else {
			LoadMap();
		}
	}
	
	void CreateMap () {
		MapData.CreateMatrix();

		for (int x = 0; x < mapSize; x++) {
			for (int z = 0; z < mapSize; z++) {
				int planeType = Random.Range(0,mapSquares.Length);
				MapData.mapMatrix[x][z] = planeType;
			}
		}
		Debug.Log("Hi");

		MapData.mapMatrix[Random.Range(0,mapSize)][Random.Range(0,mapSize)] = mapSquares.Length; // Replace a position on the map with the village
		while (!templePlaced) {
			var randomX = Random.Range(0,mapSize);
			var randomZ = Random.Range(0,mapSize);
			if (MapData.mapMatrix[randomX][randomZ] != mapSquares.Length) { // If the current position isn't the village
				MapData.mapMatrix[randomX][randomZ] = mapSquares.Length + 1; // Replace that position with the temple
				templePlaced = true;
			}
		}
		MapData.mapCreated = true;
		LoadMap();
	}

	void LoadMap () {
		squareLength = mapSquares[0].renderer.bounds.size.x;
		for (int x = 0; x < mapSize; x++) {
			for (int z = 0; z < mapSize; z++) {
				Vector3 planePosition = new Vector3(this.transform.position.x + x*squareLength, this.transform.position.y, this.transform.position.z + z*squareLength);
				if (MapData.mapMatrix[x][z] < mapSquares.Length) {
					Instantiate(mapSquares[MapData.mapMatrix[x][z]], planePosition, Quaternion.identity);
				}
				else if (MapData.mapMatrix[x][z] == mapSquares.Length) {
					Instantiate(village, planePosition, Quaternion.identity);
				}
				else if (MapData.mapMatrix[x][z] == mapSquares.Length + 1)
					Instantiate(temple, planePosition, Quaternion.identity);
			}
		}
	}
}
