using UnityEngine;
using System.Collections;

public class EnemySpawnerController : MonoBehaviour {

	public GameObject grasslandEnemy1;
	public GameObject grasslandEnemy2;
	public GameObject grasslandEnemy3;
	public GameObject forestEnemy1;



	public GameObject bridgeBoss;

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
		} else if (spawnType == "Forest") {
			enemy = Instantiate(forestEnemy1) as GameObject;
		} else if (spawnType == "Bridge Boss Encounter") {
			enemy = Instantiate (bridgeBoss) as GameObject;
		} else {
			enemy = Instantiate (bridgeBoss) as GameObject;
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
