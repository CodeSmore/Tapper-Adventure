using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	private GameObject overworld;
	private GameObject battle;

	private PlayerClass playerClass;
	private PlayerMovement playerMovement;

	public float distanceTilSpawnThreshold;
	private float probabilityOfMonsterAttackPerFrame = 0.01f;

	// Use this for initialization
	void Start () {
		overworld = GameObject.Find("Overworld");
		battle = GameObject.Find("Battle");
		playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
		playerClass = GameObject.FindObjectOfType<PlayerClass>();
		battle.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (playerMovement.GetDistanceTraveled() >= distanceTilSpawnThreshold && Random.value < probabilityOfMonsterAttackPerFrame && playerMovement.PlayerIsMoving()) {
			playerMovement.ResetDistanceTraveled();
			TransitionToBattle();
		}
	}

	public void TransitionToOverworld () {
		// disable battle, enable overworld
		battle.SetActive(false);
		overworld.SetActive(true);
	}

	public void TransitionToBattle () {
		// TODO spawn enemy

		// disable overworld, enable battle
		overworld.SetActive(false);
		battle.SetActive(true);
	}

	public void SaveGame () {
		PlayerPrefsManager.SaveGame(playerClass.GetPlayerLevel(), playerClass.GetCurrentExperiencePoints(), playerClass.GetCurrentHealth(), playerMovement.GetLastKnowPosition());
	}

	public void LoadGame () {
		playerClass.SetPlayerLevel(PlayerPrefsManager.GetPlayerLevel());
		playerClass.SetCurrentExperiencePoints(PlayerPrefsManager.GetPlayerCurrentExperiencePoints());
		playerClass.SetCurrentHealth(PlayerPrefsManager.GetPlayerCurrentHealth());
		playerMovement.SetPlayerPosition(PlayerPrefsManager.GetPlayerLastKnowPosition());
	}
}
