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
	private Vector3 doorwayDestinationVector3;

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
			// trigger animation
			gameObject.GetComponent<PlayerMovement>().SetMovementIsEnabled(false);
			transitionPanelAnimator.SetTrigger("DoorwayTransitionTrigger");
			// TODO animation then triggers this portion
			doorwayDestinationVector3 = collider.GetComponent<Doorway>().GetDestinationVector();
		}
	}

	public void TeleportPlayer () {
		transform.position = doorwayDestinationVector3;
	}

	void OnTriggerExit2D (Collider2D collider) {
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
