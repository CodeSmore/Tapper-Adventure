using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerInteractableController : MonoBehaviour {

	private EnemySpawnerController enemySpawnerController;
	private GameController gameController;
	private Button interactButton;

	private GameObject triggerHit;

	// Use this for initialization
	void Start () {
		enemySpawnerController = GameObject.FindObjectOfType<EnemySpawnerController>();
		gameController = GameObject.FindObjectOfType<GameController>();
		interactButton = GameObject.Find("Interact Button").GetComponent<Button>();
		interactButton.interactable = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D collider) {
		triggerHit = collider.gameObject;

		if (triggerHit.name == "Bridge Boss Encounter") {
			gameController.TransitionToBattle();
			collider.gameObject.SetActive(false);
		}

		if (triggerHit.tag == "Interactable") {
			interactButton.interactable = true;
		} else if (triggerHit.tag == "SpawnArea") {
			enemySpawnerController.SetSpawnType(triggerHit.name);
		}
	}

	void OnTriggerExit2D (Collider2D collider) {
		Debug.Log("Exiting Trigger");
		if (collider.gameObject.tag == "Interactable") {
			interactButton.interactable = false;
		}
	}

	public void Interact () {
		if (triggerHit.name == "Sample Talker") {
			Debug.Log("Talking to Papercut");
		}
	}
}
