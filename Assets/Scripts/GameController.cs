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
	private EnemyActionBar actionBar;

	public float distanceTilSpawnThreshold;
	private float probabilityOfMonsterAttackPerFrame = 0.01f;

	// Use this for initialization
	void Start () {
		world = GameObject.Find("World");
		battle = GameObject.Find("Battle");
		playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
		playerClass = GameObject.FindObjectOfType<PlayerClass>();
		enemySpawnerController = GameObject.FindObjectOfType<EnemySpawnerController>();
		transitionPanel = GameObject.Find("Transition Panel");
		actionBar = GameObject.FindObjectOfType<EnemyActionBar>();
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
