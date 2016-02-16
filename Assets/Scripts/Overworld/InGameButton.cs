using UnityEngine;
using System.Collections;

public class InGameButton : MonoBehaviour {

	public bool isPressed = false;

	void OnTriggerEnter2D (Collider2D collider) {
		isPressed = true;

		if (gameObject.tag == "Button") {
			GetComponent<SpriteRenderer>().color = Color.green;
		} else if (gameObject.tag == "Pressure Plate") {
			GetComponent<SpriteRenderer>().color = new Color (1, 1, 1, 0.25f);
		}
	}

	public bool ButtonIsPressed () {
		return isPressed;
	}

	public void ResetButton () {
		isPressed = false;

		if (gameObject.tag == "Button") {
			GetComponent<SpriteRenderer>().color = Color.red;
		} else if (gameObject.tag == "Pressure Plate") {
			GetComponent<SpriteRenderer>().color = new Color (1, 1, 1, 0);
		}
	}
}
