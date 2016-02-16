using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerInteractableController : MonoBehaviour {

	private EnemySpawnerController enemySpawnerController;
	private GameController gameController;
	private Button interactButton;
	private GameObject textBox;
	private InteractionTextController textController;
	private Animator transitionPanelAnimator;

	private GameObject triggerHit;
	private GameObject interactTrigger;
	private Vector3 doorwayDestinationVector3;
	private bool timeToAnnoy = false;

	// Use this for initialization
	void Start () {
		enemySpawnerController = GameObject.FindObjectOfType<EnemySpawnerController>();
		gameController = GameObject.FindObjectOfType<GameController>();
		interactButton = GameObject.Find("Interact Button").GetComponent<Button>();
		interactButton.interactable = false;
		textBox = GameObject.Find("Text Box");
		textBox.SetActive(false);
		textController = GameObject.FindObjectOfType<InteractionTextController>();
		transitionPanelAnimator = GameObject.Find("Transition Panel").GetComponent<Animator>();
	}

	void OnTriggerEnter2D (Collider2D collider) {
		triggerHit = collider.gameObject;

		// If player collides with SpawnArea collider, the SpawnType in enemySpawnerController is set
		// This is in OnTriggerEnter b/c it only needs updated when venue is changed
		if (triggerHit.tag == "SpawnArea") {
			enemySpawnerController.SetSpawnType(triggerHit.name);
		}

		if (triggerHit.tag == "BattleTrigger") {
			enemySpawnerController.SetSpawnType(triggerHit.name);
			gameController.BeginBattle();
			collider.gameObject.SetActive(false);
		}

		if (triggerHit.tag == "Doorway") {
			// trigger animation
			gameObject.GetComponent<PlayerMovement>().SetMovementIsEnabled(false);
			transitionPanelAnimator.SetTrigger("DoorwayTransitionTrigger");
			// TODO animation then triggers this portion
			doorwayDestinationVector3 = collider.GetComponent<Doorway>().GetDestinationVector();

			// if entering Tabuz Maze, increase spawn rate
			// This info is grabbed by GameController.cs
			if (triggerHit.name == "Bad Portal") {
				timeToAnnoy = true;
			} else {
				timeToAnnoy = false;
			}
		}
	}

	void OnTriggerStay2D (Collider2D collider) {
		interactTrigger = collider.gameObject;

		if (interactTrigger.tag == "Interactable" || interactTrigger.tag == "Destructable") {
			interactButton.interactable = true;
		} 
	}

	public void TeleportPlayer () {
		transform.position = doorwayDestinationVector3;
	}

	void OnTriggerExit2D (Collider2D collider) {
		if (collider.gameObject.tag == "Interactable" || collider.gameObject.tag == "Destructable") {
			interactButton.interactable = false;
		}
	}

	public void Interact () {
		if (interactTrigger.GetComponent<SpriteRenderer>().sprite.name == "Sign2") {
			textBox.SetActive(true);
			textController.UpdateText(interactTrigger.name);
		} else if (interactTrigger.tag == "Destructable") {
			Destroy(interactTrigger);
			interactButton.interactable = false;
		}

	}

	public void DeactivateTextBox () {
		textBox.SetActive(false);
	}

	public bool IsTimeToAnnoy () {
		return timeToAnnoy;
	}
}
