using UnityEngine;
using System.Collections;

public class EnemySpawnerController : MonoBehaviour {

	public GameObject grasslandEnemy1;
	public GameObject grasslandEnemy2;
	public GameObject grasslandEnemy3;
	public GameObject bridgeBoss;

	public GameObject caveEnemy1;
	public GameObject caveEnemy2;
	public GameObject caveEnemy3;
	public GameObject caveTabuz;
	public GameObject caveBoss;

	public GameObject someplaceEnemy;

	public GameObject forestEnemy1;

	public GameObject enchForestEnemy1;
	public GameObject enchForestEnemy2;
	public GameObject enchForestEnemy3;
	public GameObject enchForestBoss;

	public GameObject castleHighwayEnemy1;
	public GameObject castleHighwayEnemy2;

	public GameObject castleEnemy1;
	public GameObject castleEnemy2;
	public GameObject castleEnemy3;
	public GameObject castleBoss;





	public string spawnType = "";

	public void Spawn () {
		float rand = Random.value;
		GameObject enemy = new GameObject();

		if (spawnType == "Grassland") {
			if (rand < .15) {
				enemy = Instantiate(grasslandEnemy3) as GameObject;
			} else if (rand < .5) {
				enemy = Instantiate(grasslandEnemy2) as GameObject;
			} else {
				enemy = Instantiate(grasslandEnemy1) as GameObject;
			}
		} else if (spawnType == "Cave") {
			if (rand < .15) {
				enemy = Instantiate(caveEnemy3) as GameObject;
			} else if (rand < .5) {
				enemy = Instantiate(caveEnemy2) as GameObject;
			} else {
				enemy = Instantiate(caveEnemy1) as GameObject;
			}
		} else if (spawnType == "Someplace") {

		} else if (spawnType == "Forest") {

		} else if (spawnType == "Enchanted Forest") {

		} else if (spawnType == "Castle Highway") {

		} else if (spawnType == "Hero's Castle") {

		} 


		else if (spawnType == "Bridge Boss Encounter") {
			enemy = Instantiate (bridgeBoss) as GameObject;
			SetSpawnType("Grassland");
		} else if (spawnType == "Cave Boss Encounter") {
			enemy = Instantiate (caveBoss) as GameObject;
			SetSpawnType("Cave");
		} else if (spawnType == "Enchanted Forest Boss Encounter") {
			enemy = Instantiate (enchForestBoss) as GameObject;
			SetSpawnType("Enchanted Forest");
		} else if (spawnType == "Hero's Castle Boss Encounter") {
			enemy = Instantiate (castleBoss) as GameObject;
			SetSpawnType("Hero's Castle");
		}

		enemy.transform.parent = transform;
		Destroy (GameObject.Find("New Game Object"));
	}

	public void SetSpawnType (string newSpawnType) {
		spawnType = newSpawnType;
	}

	public string GetSpawnType () {
		return spawnType;
	}
}
