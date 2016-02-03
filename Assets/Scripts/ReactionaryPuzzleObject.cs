using UnityEngine;
using System.Collections;

public class ReactionaryPuzzleObject : MonoBehaviour {

	public InGameButton[] inGameButtons;
	public GameObject replacement;

	private bool stillPuzzling = true;
	
	// Update is called once per frame
	void Update () {
		if (stillPuzzling) {
			stillPuzzling = false;
			foreach (InGameButton button in inGameButtons) {
				if (!button.ButtonIsPressed()) {
					stillPuzzling = true;
				}
			}

			if (!stillPuzzling) {
				CompletePuzzle();
			}
		} 
	}

	void CompletePuzzle () {
		if (this.tag == "Disabled Portal") {
			ActivatePortal();
		}
	}

	void ActivatePortal () {
		replacement.SetActive(true);
		Destroy(gameObject);
		Debug.Log("Portal Activated");
	}
}
