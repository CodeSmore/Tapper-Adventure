using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

	private GameObject world;
	private GameObject battle;

	private PlayerClass playerClass;
	private PlayerMovement playerMovement;
	private EnemySpawnerController enemySpawnerController;
	private GameObject transitionPanel;
	private BossStatusController bossStatusController;
	private PlayerInteractableController playerInteractableController;

	public float standardDistanceTilSpawnThreshold, oppressedDistanceTilSpawnThreshold, annoyingDistanceTilSpawnThreshold;
	private float distanceTilSpawnThreshold;
	private float probabilityOfMonsterAttackPerFrame = 0.01f;
	private float randomGeneratorTimer = 0;
	private float randomSpawnNumber = 0;

	// Use this for initialization
	void Start () {
		world = GameObject.Find("World");
		battle = GameObject.Find("Battle");
		playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
		playerClass = GameObject.FindObjectOfType<PlayerClass>();
		enemySpawnerController = GameObject.FindObjectOfType<EnemySpawnerController>();
		transitionPanel = GameObject.Find("Transition Panel");
		battle.SetActive(false);
		bossStatusController = GameObject.FindObjectOfType<BossStatusController>();
		playerInteractableController = GameObject.FindObjectOfType<PlayerInteractableController>();
	}
	
	// Update is called once per frame
	void Update () {
		if (playerInteractableController.IsTimeToAnnoy()) {
			distanceTilSpawnThreshold = annoyingDistanceTilSpawnThreshold;
		} else if (bossStatusController.IsOppressiveForceActive()) {
			distanceTilSpawnThreshold = oppressedDistanceTilSpawnThreshold;
		} else {
			distanceTilSpawnThreshold = standardDistanceTilSpawnThreshold;
		}

		randomGeneratorTimer += Time.deltaTime;
		if (randomGeneratorTimer > 1) {
			randomSpawnNumber = Random.value;
		}

		if (playerMovement.GetDistanceTraveled() >= distanceTilSpawnThreshold && randomSpawnNumber < probabilityOfMonsterAttackPerFrame && playerMovement.PlayerIsMoving()) {
			BeginBattle();
		}
	}

	public void BeginBattle () {
		playerMovement.ResetDistanceTraveled();
		TransitionToBattle();
	}

	public void TransitionToWorld () {
		transitionPanel.GetComponent<Image>().fillMethod = Image.FillMethod.Vertical;
		transitionPanel.GetComponent<Image>().fillOrigin = 1; // top
		transitionPanel.GetComponent<Animator>().SetTrigger("WorldTransitionTrigger");
	}

	public void TransitionToBattle () {
		playerMovement.SetMovementIsEnabled(false);
		// disable world, enable battle
		transitionPanel.GetComponent<Image>().fillMethod = Image.FillMethod.Radial360;
		transitionPanel.GetComponent<Animator>().SetTrigger("BattleTransitionTrigger");
		// disable energy gain and cooldown til end of trigger


		if (!GameObject.FindObjectOfType<EnemyMonster>()) {
			enemySpawnerController.Spawn();
		}
	}

	public void ToggleCurrentMode () {
		world.SetActive(!world.activeSelf);
		battle.SetActive(!battle.activeSelf);
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
