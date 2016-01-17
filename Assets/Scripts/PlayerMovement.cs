using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float movementSpeed, padding;
	private float xMin, xMax, yMin, yMax;

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
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(0) && !eventSystem.IsPointerOverGameObject()) {
			MoveWithFinger();

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

	public static void ToggleOverworldMode () {
		overworldMode = !overworldMode;
	}
}
