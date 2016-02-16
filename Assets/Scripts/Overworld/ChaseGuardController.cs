using UnityEngine;
using System.Collections;

public class ChaseGuardController : MonoBehaviour {
	public enum Direction {Up, Down, Left, Right};

	public float guardSpeed;
	public Direction startDirection;
	public InGameButton activatorButton;

	private GameObject guardBody;
	private Direction direction;
	private Vector3 origPos;
	private Vector3 newPos;

	// Use this for initialization
	void Start () {
		foreach (Transform childTransform in transform) {
			if (childTransform.gameObject.name == "Body") {
				guardBody = childTransform.gameObject;
			}
		}

		direction = startDirection;
		origPos = guardBody.transform.position;
		guardBody.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (activatorButton.ButtonIsPressed()) {
			if (!guardBody.activeSelf) {
				guardBody.SetActive(true);
			}

			if (direction == Direction.Up) {
			newPos = new Vector3 (guardBody.transform.position.x, guardBody.transform.position.y + Time.deltaTime * guardSpeed, guardBody.transform.position.z);
			} else if (direction == Direction.Down) {
				newPos = new Vector3 (guardBody.transform.position.x, guardBody.transform.position.y + Time.deltaTime * -guardSpeed, guardBody.transform.position.z);
			} else if (direction == Direction.Left) {
				newPos = new Vector3 (guardBody.transform.position.x + Time.deltaTime * -guardSpeed, guardBody.transform.position.y, guardBody.transform.position.z);
			} else if (direction == Direction.Right) {
				newPos = new Vector3 (guardBody.transform.position.x + Time.deltaTime * guardSpeed, guardBody.transform.position.y, guardBody.transform.position.z);
			}

			guardBody.transform.position = newPos;
		}

	}

	// Accessing triggers between children...here goes
	void OnTriggerEnter2D (Collider2D collider) {
		if (collider.gameObject.tag == "Turn") {
			if (collider.gameObject.name == "Up") {
				direction = Direction.Up;
			} else if (collider.gameObject.name == "Down") {
				direction = Direction.Down;
			} else if (collider.gameObject.name == "Left") {
				direction = Direction.Left;
			} else if (collider.gameObject.name == "Right") {
				direction = Direction.Right;
			} else if (collider.gameObject.name == "End") {
				ResetGuard();
			}
		}
	}

	void ResetGuard() {
		guardBody.transform.position = origPos;
		direction = startDirection;

		guardBody.SetActive(false);
		activatorButton.ResetButton();
	}
}
