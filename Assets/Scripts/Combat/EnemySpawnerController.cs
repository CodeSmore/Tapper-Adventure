using UnityEngine;
using System.Collections;

public class EnemySpawnerController : MonoBehaviour {

	public GameObject grassLandEnemy1;
	public GameObject grassLandEnemy2;
	public GameObject grassLandEnemy3;



	public GameObject bridgeBoss;

	public string spawnType = "";

	public void Spawn () {
		float rand = Random.value;
		GameObject enemy = new GameObject();

		if (spawnType == "Grassland") {
			if (rand < .15) {
				enemy = Instantiate(grassLandEnemy3) as GameObject;
			} else if (rand < .5) {
				enemy = Instantiate(grassLandEnemy2) as GameObject;
			} else {
				enemy = Instantiate(grassLandEnemy1) as GameObject;
			}
		} else if (spawnType == "Bridge Boss Encounter") {
			enemy = Instantiate (bridgeBoss) as GameObject;
		}

		enemy.transform.parent = transform;
		Destroy (GameObject.Find("New Game Object"));
	}

	public void SetSpawnType (string newSpawnType) {
		spawnType = newSpawnType;
	}
}
