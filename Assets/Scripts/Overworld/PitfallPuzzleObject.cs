using UnityEngine;
using System.Collections;

public class PitfallPuzzleObject : MonoBehaviour {

	public GameObject pit;
	// Use this for initialization
	void Start () {
		pit.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D collider) {
		pit.SetActive(true);

		GetComponent<BoxCollider2D>().enabled = false;
	}
}
