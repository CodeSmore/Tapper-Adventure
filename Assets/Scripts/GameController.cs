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
	private ModeTransitionController modeTransitionController;
	private PuzzleObjectController puzzleObjectController;
	private UnityAdsExample unityAdsExample;

	public float standardDistanceTilSpawnThreshold, oppressedDistanceTilSpawnThreshold, annoyingDistanceTilSpawnThreshold;
	private float distanceTilSpawnThreshold;

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
		modeTransitionController = GameObject.FindObjectOfType<ModeTransitionController>();
		puzzleObjectController = GameObject.FindObjectOfType<PuzzleObjectController>();
		unityAdsExample = GameObject.FindObjectOfType<UnityAdsExample>();
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


		if (playerMovement.GetDistanceTraveled() >= distanceTilSpawnThreshold && playerMovement.PlayerIsMoving() && enemySpawnerController.GetSpawnType() != "NO SPAWN") {
			BeginBattle();
		}
	}

	public void BeginBattle () {
		playerMovement.ResetDistanceTraveled();
		modeTransitionController.EnableAllowTransition();
		TransitionToBattle();
	}

	public void TransitionToWorld () {
		transitionPanel.GetComponent<Image>().fillMethod = Image.FillMethod.Vertical;
		transitionPanel.GetComponent<Image>().fillOrigin = 1; // top
		modeTransitionController.EnableAllowTransition();
		transitionPanel.GetComponent<Animator>().SetTrigger("WorldTransitionTrigger");
	}

	public void TransitionToBattle () {
		playerMovement.SetMovementIsEnabled(false);
		// disable world, enable battle
		transitionPanel.GetComponent<Image>().fillMethod = Image.FillMethod.Radial360;
		modeTransitionController.EnableAllowTransition();
		transitionPanel.GetComponent<Animator>().SetTrigger("BattleTransitionTrigger");
		// disable energy gain and cooldown til end of trigger


		// NOTE: Question of efficiency.
		// It may be more efficient to have a vairable holding the 'Spawner' GameObject, then check to see if it has a child.
		// If not, THEN Spawn()
		if (!GameObject.FindObjectOfType<EnemyMonster>()) {
			enemySpawnerController.Spawn();
		}
	}

	public void ToggleCurrentMode () {
		world.SetActive(!world.activeSelf);
		battle.SetActive(!battle.activeSelf);
	}

	public void SaveGame () {
		PlayerPrefsManager.SaveGame(playerClass.GetPlayerLevel(), playerClass.GetCurrentExperiencePoints(), playerClass.GetCurrentHealth(), playerClass.GetCurrentEnergy(), playerClass.GetCooldownTimerSkill1(), 
									playerClass.GetCooldownTimerSkill2(), playerClass.GetCooldownTimerSkill3(), playerMovement.GetLastKnowPosition(), enemySpawnerController.GetSpawnType(), 
									bossStatusController.GetBossStatus(), puzzleObjectController.GetPuzzleObjectsStatus()
		);
	}

	public void LoadGame () {
		if (battle.activeSelf) {
			// destroy monster
			TransitionToWorld();
			// enable movement and reset distance traveled
		} 

		playerClass.SetPlayerLevel(PlayerPrefsManager.GetPlayerLevel());
		playerClass.UpdateStats();
		playerClass.SetCurrentExperiencePoints(PlayerPrefsManager.GetPlayerCurrentExperiencePoints());
		playerClass.SetCurrentHealth(PlayerPrefsManager.GetPlayerCurrentHealth());
		playerClass.SetCurrentEnergy(PlayerPrefsManager.GetPlayerCurrentEnergy());
		playerMovement.SetPlayerPosition(PlayerPrefsManager.GetPlayerLastKnowPosition());
		// reset b/c setting the position ^ above calculates distance traveled...
		playerMovement.ResetDistanceTraveled();
		enemySpawnerController.SetSpawnType(PlayerPrefsManager.GetLocationSpawnType());
		bossStatusController.LoadBossStatus(PlayerPrefsManager.GetBossStatus());
		playerClass.ManageEarnedSkills();

		// based on which skills are unlocked, set cooldown timer values
		playerClass.SetCooldownTimerSkill1(PlayerPrefsManager.GetPlayerCooldownSkill1());
		playerClass.SetCooldownTimerSkill2(PlayerPrefsManager.GetPlayerCooldownSkill2());
		playerClass.SetCooldownTimerSkill3(PlayerPrefsManager.GetPlayerCooldownSkill3());

		// Update puzzle objects
		puzzleObjectController.OnLoadUpdate(PlayerPrefsManager.GetCaveLockButtonsStatus(), PlayerPrefsManager.GetEnchantedForestBarrierButtonsStatus());
	}

	public void AdHeal () {
		unityAdsExample.ShowRewardedAd();
	}
}
