private var templePlaced : boolean = false;

private var mapSize : int = 10; // Number of map squares in the x and z directions; must be greater than 1
private var squareLength : int; // The x and z lengths of a square

var mapSquares : GameObject[]; // Array containing each type of map square that can be generated
var village : GameObject; // Only one can be spawned per map
var temple : GameObject; // Only one can be spawned per map
var character : GameObject; // Player character

var spawnHeight : int = 12; // Height above the ground that the player character spawns
var spawnOffset : int = 20;

function Start () {
	if (!character.GetComponent.<MapData>().mapCreated) {
		CreateMap();
	}
	else
		LoadMap();
	//LoadCharacter();
}

function CreateMap () {
	for (var x : int = 0; x < mapSize; x++) {
		for (var z : int = 0; z < mapSize; z++) {
			var planeType : int = Random.Range(0,mapSquares.length);
			character.GetComponent.<MapData>().mapMatrix[x,z] = planeType;
		}
	}
	character.GetComponent.<MapData>().mapMatrix[Random.Range(0,mapSize),Random.Range(0,mapSize)] = mapSquares.length; // Replace a position on the map with the village
	while (!templePlaced) {
		var randomX = Random.Range(0,mapSize);
		var randomZ = Random.Range(0,mapSize);
		if (character.GetComponent.<MapData>().mapMatrix[randomX,randomZ] != mapSquares.length) { // If the current position isn't the village
			character.GetComponent.<MapData>().mapMatrix[randomX,randomZ] = mapSquares.length + 1; // Replace that position with the temple
			templePlaced = true;
		}
	}
	character.GetComponent.<MapData>().mapCreated = true;
	LoadMap();
}

function LoadMap () {
	squareLength = mapSquares[0].renderer.bounds.size.x;
	for (var x : int = 0; x < mapSize; x++) {
		for (var z : uint = 0; z < mapSize; z++) {
			var planePosition : Vector3 = new Vector3(this.transform.position.x + x*squareLength, this.transform.position.y, this.transform.position.z + z*squareLength);
			if (character.GetComponent.<MapData>().mapMatrix[x,z] < mapSquares.length) {
				Instantiate(mapSquares[character.GetComponent.<MapData>().mapMatrix[x,z]], planePosition, Quaternion.identity);
			}
			else if (character.GetComponent.<MapData>().mapMatrix[x,z] == mapSquares.length) {
				Instantiate(village, planePosition, Quaternion.identity);
			}
			else if (character.GetComponent.<MapData>().mapMatrix[x,z] == mapSquares.length + 1)
				Instantiate(temple, planePosition, Quaternion.identity);
		}
	}
}