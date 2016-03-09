using UnityEngine;
using System.Collections;

public class InGameButton : MonoBehaviour {
	public bool isPressed = false;

	private BoxCollider2D[] colliders;

	void OnTriggerEnter2D (Collider2D collider) {
		PressButton ();
	}

	public void ResetButton () {
		isPressed = false;

		if (gameObject.tag == "Button") {
			GetComponent<SpriteRenderer>().color = Color.red;
		} else if (gameObject.tag == "Pressure Plate") {
			GetComponent<SpriteRenderer>().color = new Color (1, 1, 1, 0);
		}

		// enable the colliders
		colliders = gameObject.GetComponents<BoxCollider2D>();

		foreach (BoxCollider2D eachCollider in colliders) {
			eachCollider.enabled = true;
		}
	}

	public void PressButton () {
		isPressed = true;

		if (gameObject.tag == "Button") {
			GetComponent<SpriteRenderer>().color = Color.green;
		} else if (gameObject.tag == "Pressure Plate") {
			GetComponent<SpriteRenderer>().color = new Color (1, 1, 1, 0.25f);
		}

		// disable it's colliders
		colliders = gameObject.GetComponents<BoxCollider2D>();

		foreach (BoxCollider2D eachCollider in colliders) {
			eachCollider.enabled = false;
		}
	}

	public bool IsButtonPressed () {
		return isPressed;
	}

	public void SetIsButtonPressed (bool pressed) {
		isPressed = pressed;
	}
}
