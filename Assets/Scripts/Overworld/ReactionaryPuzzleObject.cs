using UnityEngine;
using System.Collections;

public class ReactionaryPuzzleObject : MonoBehaviour {

	public InGameButton[] inGameButtons;
	public GameObject replacement;
	public GameObject playerResetPosition;
	private GameController gameController;
	public GameObject trigger;

	private bool stillPuzzling = true;
	private float gagTimer = 0;
	private int buttonArraySize;

	void Start () {
		buttonArraySize = inGameButtons.Length;
		gameController = GameObject.FindObjectOfType<GameController>();
	}

	// Update is called once per frame
	void Update () {
		if (trigger == null) {
			if (stillPuzzling) {
				stillPuzzling = false;
				foreach (InGameButton button in inGameButtons) {
					if (!button.IsButtonPressed()) {
						stillPuzzling = true;
					}
				}

				// Combination lock must be executed in order
				if (gameObject.tag == "Button Combination Lock") {
					for (int x = buttonArraySize - 1; x >= 1; x--) {
						if (inGameButtons[x].IsButtonPressed() && !inGameButtons[x-1].IsButtonPressed()) {
							// reset buttons, spawn monster, move player 

							GameObject.Find("Player").transform.position = playerResetPosition.transform.position;
							foreach (InGameButton button in inGameButtons) {
								button.ResetButton();
							}
							gameController.BeginBattle();

						}
					}
				}
			}
			if (!stillPuzzling && gameObject.tag != "Gag Puzzle") {
				CompletePuzzle();
			}
		} else {
			if (trigger.activeSelf == false) {
				CompletePuzzle();
			}
		}

		// gag puzzle locks a barrier after button is pressed, then unlocks it ten seconds later. Hilarity ensues!
		if (!stillPuzzling && gameObject.tag == "Gag Puzzle") {
			gagTimer += Time.deltaTime;

			if (gagTimer < 10) {
				GetComponent<SpriteRenderer>().enabled = true;
				GetComponent<BoxCollider2D>().enabled = true;
			} else {
				gameObject.SetActive(false);
			}
		}


	}

	void CompletePuzzle () {
		// delete the object (obstacle or place holder)
		gameObject.SetActive(false);
		if (this.tag == "Disabled Portal") {
			ActivatePortal();
		}
	}

	void ActivatePortal () {
		replacement.SetActive(true);
	}
}
