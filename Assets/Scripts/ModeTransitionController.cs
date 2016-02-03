using UnityEngine;
using System.Collections;

public class ModeTransitionController : MonoBehaviour { // Controls the transition between world, battle, and menu

	private GameObject world;
	private GameObject battle;
	private EnemyActionBar actionBar;
	private BattleResultsController battleResultsController;
	PlayerInteractableController playerInteractionController;
	private PlayerMovement playerMovement;

	private Vector3 destinationLocation;

	// Use this for initialization
	void Awake () {
		world = GameObject.Find("World");
		battle = GameObject.Find("Battle");
		actionBar = GameObject.FindObjectOfType<EnemyActionBar>();
		battleResultsController = GameObject.FindObjectOfType<BattleResultsController>();
		playerInteractionController = GameObject.FindObjectOfType<PlayerInteractableController>();
		playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
	}

	public void TransitionMode () {
		world.SetActive (!world.activeSelf);
		battle.SetActive (!battle.activeSelf);
	}

	public void EndBattlePreparations () {
		battleResultsController.EndOfBattlePreparations();
	}

	public void ActivateActionBar () {
		actionBar.SetActionEnabled (true);
	}

	public void TeleportPlayer () {
		playerInteractionController.TeleportPlayer();
	}

	public void EnableMovement () {
		if (world.activeSelf) {
			playerMovement.SetMovementIsEnabled(true);
			Debug.Log("Movement Enabled");
		}
	}
}
