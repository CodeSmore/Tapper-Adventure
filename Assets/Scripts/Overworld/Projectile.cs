using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	

	private Direction direction = Direction.None;
	private Vector3 newPos;
	private Transform imageTransform;
	private float rotationSpeed = 0;
	private float movementSpeed = 0;

	// Use this for initialization
	void Start () {
		// can't use GetComponentInChildren because it'll just pull the transform from the parent :I
		foreach (Transform childTransform in transform) {
			imageTransform = childTransform;
		}

		// added random rotation on start to add variety
		imageTransform.RotateAround(transform.position, Vector3.forward, Random.Range(1, 50));

	}
	
	// Update is called once per frame
	void Update () {
		Move();
		Rotate();
	}

	public void PlanFlightPath (Direction directionFired, float rotSpeed, float launchSpeed) {
		direction = directionFired;
		rotationSpeed = rotSpeed;
		movementSpeed = launchSpeed;
	}

	private void Move () {
		if (direction != Direction.None) { // if statement is present in case Update() is called before PlanFlightPath (which is called right after being instantiated by 'Launcher' prefab.
			if (direction == Direction.Up) {
				newPos = new Vector3 (transform.position.x, transform.position.y + movementSpeed * Time.deltaTime, transform.position.z);
			}
			else if (direction == Direction.Down) {
				newPos = new Vector3 (transform.position.x, transform.position.y - movementSpeed * Time.deltaTime, transform.position.z);
			}
			else if (direction == Direction.Left) {
				newPos = new Vector3 (transform.position.x - movementSpeed * Time.deltaTime, transform.position.y, transform.position.z);
			}
			else if (direction == Direction.Right) {
				newPos = new Vector3 (transform.position.x + movementSpeed * Time.deltaTime, transform.position.y, transform.position.z);
			}

			transform.position = newPos;
		}
	}

	// rotates the IMAGE child object, so that collider just pushes and doesn't turn player.
	private void Rotate () {

		imageTransform.RotateAround(transform.position, Vector3.forward, rotationSpeed);
	}

	void OnTriggerEnter2D (Collider2D collider) {
		if (collider.gameObject.tag == "Shredder") {
			Destroy(gameObject);
		}
	} 
}
