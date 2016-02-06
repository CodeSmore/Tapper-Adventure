using UnityEngine;
using System.Collections;

public class InGameButton : MonoBehaviour {

	public bool isPressed = false;

	void OnTriggerEnter2D (Collider2D collider) {
		isPressed = true;
		GetComponent<SpriteRenderer>().color = Color.green;
	}

	public bool ButtonIsPressed () {
		return isPressed;
	}

	public void ResetButton () {
		isPressed = false;
		GetComponent<SpriteRenderer>().color = Color.red;
	}
}
