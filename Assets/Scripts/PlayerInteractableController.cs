using UnityEngine;
using System.Collections;

public class PlayerInteractableController : MonoBehaviour {

	private EnemySpawnerController enemySpawnerController;

	// Use this for initialization
	void Start () {
		enemySpawnerController = GameObject.FindObjectOfType<EnemySpawnerController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D collider) {
		string triggerHit = collider.gameObject.name;

		enemySpawnerController.SetSpawnType(triggerHit);
	}
}
