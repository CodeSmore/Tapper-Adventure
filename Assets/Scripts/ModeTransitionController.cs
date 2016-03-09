using UnityEngine;
using System.Collections;

public class ModeTransitionController : MonoBehaviour { // Controls the transition between world, battle, and menu

	private GameObject world;
	private GameObject battle;
	private EnemyActionBar actionBar;
	private BattleResultsController battleResultsController;
	PlayerInteractableController playerInteractionController;
	private PlayerMovement playerMovement;
	private EnemyMonster enemyMonster;

	private Vector3 destinationLocation;

	// TransitionToBattle trigger is triggered when, after the animation to transition back to overworld completes, player taps repeatedly on screen immediately.
	// No idea how trigger is being triggered as it's only called from GameController.cs method TransitionToBattle().
	// When triggered, no monster is normally spawned. I created a backup that spawns monster jic this is triggered, but it shouldn't happen at all now.

	private bool allowTransition = false;

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
		if (allowTransition) {
			world.SetActive (!world.activeSelf);
			battle.SetActive (!battle.activeSelf);

			// destroy monster here
			enemyMonster = GameObject.FindObjectOfType<EnemyMonster>();
			if (battle.activeSelf == false && enemyMonster /*exists*/) {
				Destroy (enemyMonster.gameObject);
			}

			allowTransition = false;
		}

	}

	public void EnableAllowTransition () {
		allowTransition = true;
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
			playerMovement.ResetDistanceTraveled();
		}
	}
}
