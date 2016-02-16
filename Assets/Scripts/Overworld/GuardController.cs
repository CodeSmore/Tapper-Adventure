using UnityEngine;
using System.Collections;

public class GuardController : MonoBehaviour {

	public float movementSpeed;
	public bool isVertical;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 newPosition;

		if (isVertical) {
			newPosition = new Vector3 (transform.position.x, transform.position.y + movementSpeed * Time.deltaTime, transform.position.z);
		} else {
			newPosition = new Vector3 (transform.position.x + movementSpeed * Time.deltaTime, transform.position.y, transform.position.z);
		}

		transform.parent.transform.position = newPosition;
	}

	void OnTriggerEnter2D (Collider2D collider) {
		if (collider.gameObject.tag == "TurnAround") {
			movementSpeed *= -1;

			transform.parent.transform.RotateAround (transform.position, new Vector3 (0, 0, 1), 180);
		}
	}
}
