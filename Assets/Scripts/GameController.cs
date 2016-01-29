using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	private GameObject world;
	private GameObject battle;

	private PlayerClass playerClass;
	private PlayerMovement playerMovement;
	private EnemySpawnerController enemySpawnerController;

	public float distanceTilSpawnThreshold;
	private float probabilityOfMonsterAttackPerFrame = 0.01f;

	// Use this for initialization
	void Start () {
		world = GameObject.Find("World");
		battle = GameObject.Find("Battle");
		playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
		playerClass = GameObject.FindObjectOfType<PlayerClass>();
		enemySpawnerController = GameObject.FindObjectOfType<EnemySpawnerController>();
		battle.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (playerMovement.GetDistanceTraveled() >= distanceTilSpawnThreshold && Random.value < probabilityOfMonsterAttackPerFrame && playerMovement.PlayerIsMoving()) {
			playerMovement.ResetDistanceTraveled();
			TransitionToBattle();
		}
	}

	public void TransitionToWorld () {
		// disable battle, enable world
		battle.SetActive(false);
		world.SetActive(true);
	}

	public void TransitionToBattle () {
		// disable world, enable battle
		world.SetActive(false);
		battle.SetActive(true);

		// TODO spawn enemy
		if (!GameObject.FindObjectOfType<EnemyMonster>()) {
			enemySpawnerController.Spawn();
		}
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
