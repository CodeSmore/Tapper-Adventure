using UnityEngine;
using System.Collections;

public class PuzzleController : MonoBehaviour {

	public GameObject[] puzzleObjects;
	// Use this for initialization
	void Start () {
		foreach (GameObject puzzleObject in puzzleObjects) {
			puzzleObject.SetActive(false);
		}
	}
	
	void OnTriggerEnter2D (Collider2D collider) {
		if (collider.tag == "Player") {
			foreach (GameObject puzzleObject in puzzleObjects) {
				puzzleObject.SetActive(true);
			}
		}
	}

	void OnTriggerExit2D (Collider2D collider) {
		if (collider.tag == "Player") {
			foreach (GameObject puzzleObject in puzzleObjects) {
				puzzleObject.SetActive(false);
			}
		}
	}
}
