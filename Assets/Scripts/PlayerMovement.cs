using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float standardMovementSpeed, oppressiveMovementSpeed;
	private float distanceTraveled;
	public Vector3 lastKnownPosition;
	private bool playerIsMoving;
	private bool movementIsEnabled = true;

	private Camera worldCamera;
	private EventSystem eventSystem;
	private PlayerInteractableController playerInteratableController;
	private BossStatusController bossStatusController;

	public static bool worldMode = true;

	// Use this for initialization
	void Start () {
		worldCamera = GetComponentInChildren<Camera>();
		eventSystem = GameObject.FindObjectOfType<EventSystem>();
		playerInteratableController = GameObject.FindObjectOfType<PlayerInteractableController>();
		bossStatusController = GameObject.FindObjectOfType<BossStatusController>();

		lastKnownPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(0) && eventSystem.currentSelectedGameObject == null && movementIsEnabled) {
			playerIsMoving = true;

			MoveWithFinger();
			CalculateDistanceTraveled();

			if (playerInteratableController.isActiveAndEnabled) {
				playerInteratableController.DeactivateTextBox();
			}
		} else {
			playerIsMoving = false;
		}
	}

	private void MoveWithFinger () {

		Vector2 mousePos = worldCamera.ScreenToWorldPoint (Input.mousePosition);	
		float movementSpeed;

		if (bossStatusController.IsOppressiveForceActive()) {
			movementSpeed = oppressiveMovementSpeed;
		} else {
			movementSpeed = standardMovementSpeed;
		}

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
			
		transform.position = playerPos;
	}

	private void CalculateDistanceTraveled () {
		// distance = || origPos - newPos || / Mathf.Sqrt Pow((orig.x - new.x), 2) +
		Vector3 currentPosition = transform.position;

		distanceTraveled += Mathf.Sqrt(Mathf.Pow((lastKnownPosition.x - currentPosition.x), 2) + Mathf.Pow((lastKnownPosition.y - currentPosition.y), 2));
		
		lastKnownPosition = transform.position;
	}

	public void ResetDistanceTraveled () {
		distanceTraveled = 0;
		lastKnownPosition = transform.position;
	}

	public float GetDistanceTraveled () {
		return distanceTraveled;
	}

	public static void ToggleWorldMode () {
		worldMode = !worldMode;
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

	public void SetMovementIsEnabled (bool setBool) {
		movementIsEnabled = setBool;
	}
}
