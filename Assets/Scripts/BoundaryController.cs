using UnityEngine;
using System.Collections;

public class BoundaryController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.gameObject.tag == "Player") {
			Debug.Log("player is in boudary");
		}
	}
}
