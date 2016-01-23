using UnityEngine;
using System.Collections;

public class EnemySpawnerController : MonoBehaviour {

	public GameObject grassLandEnemy1;
	public GameObject grassLandEnemy2;
	public GameObject grassLandEnemy3;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (!GameObject.FindObjectOfType<EnemyMonster>()) {
			Spawn ();
		}
	}

	void Spawn () {
		float rand = Random.value;
		GameObject enemy = new GameObject();

		if (rand < .15) {
			enemy = Instantiate(grassLandEnemy3) as GameObject;
		} else if (rand < .5) {
			enemy = Instantiate(grassLandEnemy2) as GameObject;
		} else {
			enemy = Instantiate(grassLandEnemy1) as GameObject;
		}
		enemy.transform.parent = transform;

		Destroy (GameObject.Find("New Game Object"));
	}
}
