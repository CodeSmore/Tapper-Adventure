using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float movementSpeed, padding;
	private float xMin, xMax, yMin, yMax;
	private float distanceTraveled;
	private Vector3 lastKnownPosition;
	private bool playerIsMoving;

	private Camera overworldCamera;
	private EventSystem eventSystem;

	public static bool overworldMode = true;

	// Use this for initialization
	void Start () {
		overworldCamera = GetComponentInChildren<Camera>();
		eventSystem = GameObject.FindObjectOfType<EventSystem>();

		xMin = 0 + padding;
		xMax = 18 - padding;
		yMin = 0 + padding;
		yMax = 8 - padding;

		lastKnownPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(0) && eventSystem.currentSelectedGameObject == null) {
			MoveWithFinger();
			CalculateDistanceTraveled();
		}
	}

	private void MoveWithFinger () {
		Vector2 mousePos = overworldCamera.ScreenToWorldPoint (Input.mousePosition);	

		// Standard Lerp for smooth movement
		Vector3 playerPos = Vector3.Lerp (
			gameObject.transform.position, 
			new Vector3 (
			mousePos.x, 
			mousePos.y, 
			transform.position.z
			),
			Time.deltaTime * movementSpeed
		);

		playerPos = new Vector3 (
			Mathf.Clamp (playerPos.x, xMin, xMax), 
			Mathf.Clamp (playerPos.y, yMin, yMax), 
			transform.position.z
		);

		
		transform.position = playerPos;
	}

	private void CalculateDistanceTraveled () {
		// distance = || origPos - newPos || / Mathf.Sqrt Pow((orig.x - new.x), 2) +
		Vector3 currentPosition = transform.position;
		if (lastKnownPosition != transform.position) {
			distanceTraveled += Mathf.Sqrt(Mathf.Pow((lastKnownPosition.x - currentPosition.x), 2) + Mathf.Pow((lastKnownPosition.y - currentPosition.y), 2));
			playerIsMoving = true;
		} else {
			playerIsMoving = false;
		}
		lastKnownPosition = transform.position;
	}

	public void ResetDistanceTraveled () {
		distanceTraveled = 0;
	}

	public float GetDistanceTraveled () {
		return distanceTraveled;
	}

	public static void ToggleOverworldMode () {
		overworldMode = !overworldMode;
	}

	public bool PlayerIsMoving () {
		return playerIsMoving;
	}

	public Vector3 GetLastKnowPosition () {
		return lastKnownPosition;
	}

	public void SetPlayerPosition (Vector3 pos) {
		transform.position = pos;
	}
}
