using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CombinationController : MonoBehaviour {

	public int[] answers;
	public CombinationBlock[] blocks;
	public GameObject[] answerBlocks;
	public GameObject[] combinationTargets;

	public bool combinationSolved = false;

	private PlayerInteractableController playerInteractableController;

	// Use this for initialization
	void Start () {
		playerInteractableController = GameObject.FindObjectOfType<PlayerInteractableController>();

		for (int i = 0; i < answerBlocks.Length; i++) {
			if (answerBlocks[i] != null) {
				answerBlocks[i].GetComponentInChildren<Text>().text = answers[i].ToString();
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (!combinationSolved) {
			CheckResults();
		}
	}

	void CheckResults () {
		combinationSolved = true;

		for (int i = 0; i < answers.Length; i++) {
			if (answers[i] != blocks[i].GetCurrentValue()) {
				combinationSolved = false;
			}
		}

		if (combinationSolved) {
			if (combinationTargets[0].tag == "Doorway") {
				combinationTargets[0].SetActive(true);
			} else {
				Debug.Log("I'm not supposed to be here...");
				foreach (GameObject target in combinationTargets) {
					target.SetActive(false);
				}
			}

			LockBlocks();
		}
	}

	void LockBlocks() {
		// disable interaction towards block and change their text colors to green
		foreach (CombinationBlock block in blocks) {
			block.GetComponentInChildren<Text>().color = Color.green;
			block.tag = "Untagged";

			// TODO disable trigger BoxCollider2D in block
			// NOTE not possible with foreach (BoxCollider2D.......) due to error

			if (playerInteractableController.GetNumberOfInteractableCollisions() == 1) {
				playerInteractableController.DisableInteractButton();
			}
		}
	}

	public bool CombinationSolved () {
		return combinationSolved;
	}
}
