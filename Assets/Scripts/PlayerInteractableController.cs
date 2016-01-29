using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerInteractableController : MonoBehaviour {

	private EnemySpawnerController enemySpawnerController;
	private GameController gameController;
	private Button interactButton;
	private GameObject textBox;
	private InteractionTextController textController;

	private GameObject triggerHit;

	// Use this for initialization
	void Start () {
		enemySpawnerController = GameObject.FindObjectOfType<EnemySpawnerController>();
		gameController = GameObject.FindObjectOfType<GameController>();
		interactButton = GameObject.Find("Interact Button").GetComponent<Button>();
		interactButton.interactable = false;
		textBox = GameObject.Find("Text Box");
		textBox.SetActive(false);
		textController = GameObject.FindObjectOfType<InteractionTextController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D collider) {
		triggerHit = collider.gameObject;

		if (triggerHit.tag == "Interactable") {
			interactButton.interactable = true;
		} else if (triggerHit.tag == "SpawnArea") {
			enemySpawnerController.SetSpawnType(triggerHit.name);
		}

		if (triggerHit.name == "Bridge Boss Encounter") {
			gameController.TransitionToBattle();
			collider.gameObject.SetActive(false);
		}

		if (triggerHit.tag == "Doorway") {
			gameObject.transform.position = collider.GetComponent<Doorway>().GetDestinationVector();
		}
	}

	void OnTriggerExit2D (Collider2D collider) {
		Debug.Log("Exiting Trigger");
		if (collider.gameObject.tag == "Interactable") {
			interactButton.interactable = false;
		}
	}

	public void Interact () {
		textBox.SetActive(true);
		textController.UpdateText(triggerHit.name);
	}

	public void DeactivateTextBox () {
		textBox.SetActive(false);
	}
}
