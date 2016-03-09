using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

public class BattleResultsController : MonoBehaviour {

	public Text expGainedText;
	public Text totalExpText;


	private PlayerClass playerClass;
	private EnemyMonster enemyMonster;
	private GameController gameController;
	private GameObject pauseButton;
	private EnemyActionBar enemyActionBar;
	private SkillButtonController[] skillButtonControllers;

	private GameObject winBattleResults;
	private GameObject loseBattleResults;

	// loseBattleResults buttons
	public GameObject loseAfterTimerObjects1;
	public GameObject loseAfterTimerObjects2;

	// Level Up Battle Results
	public GameObject levelUpHeader;
	public Text levelOld;
	public Text levelNew;
	public Text HPOld;
	public Text HPNew;
	public Text EPOld;
	public Text EPNew;
	public Text attackStatOld;
	public Text attackStatNew;
	public GameObject tapToContinueObject;


	private float resultsTimer;
	public float enableTransitionTime;

	// set to true when player 'taps to continue' so it can only be done once
	private bool continuing = false;

	void Awake () {
		enemyActionBar = GameObject.FindObjectOfType<EnemyActionBar>();
		playerClass = GameObject.FindObjectOfType<PlayerClass>();
		skillButtonControllers = GameObject.FindObjectsOfType<SkillButtonController>();
		enemyMonster = GameObject.FindObjectOfType<EnemyMonster>();

		winBattleResults = GameObject.Find("Win Battle Results");
		loseBattleResults = GameObject.Find("Lose Battle Results");
		winBattleResults.SetActive(false);
		loseBattleResults.SetActive(false);

		levelUpHeader.SetActive(false);
	}

	// Use this for initialization
	void Start () {
		gameController = GameObject.FindObjectOfType<GameController>();
		pauseButton = GameObject.Find("Pause Button");

		// text that informs player they can tap screen to continue
		tapToContinueObject.SetActive(false);
		loseAfterTimerObjects1.SetActive(false);
		loseAfterTimerObjects2.SetActive(false);

		resultsTimer = 0;
		continuing = false;
	}

	void Update () {
		// deactivate pause button when battle results are activated
		if (pauseButton.activeSelf) {
			pauseButton.SetActive(false);
		}


		if (!enemyMonster) {
			enemyMonster = GameObject.FindObjectOfType<EnemyMonster>();
		}

		resultsTimer += Time.deltaTime;

		// if enough time passes, let player tap-to-continue
		if (resultsTimer > enableTransitionTime && winBattleResults.activeSelf) {
			tapToContinueObject.SetActive(true);
		} else if (resultsTimer > enableTransitionTime && loseBattleResults.activeSelf) {
			// add buttons to load and quit
			loseAfterTimerObjects1.SetActive(true);

			if (resultsTimer > enableTransitionTime + 1.5f) {
				loseAfterTimerObjects2.SetActive(true);
			}
		}
	}

	// called after player 'taps to continue'
	public void EndOfBattlePreparations () {

		// reset the health bar
		enemyMonster.ResetHealth();

		tapToContinueObject.SetActive(false);
		loseAfterTimerObjects1.SetActive(false);
		loseAfterTimerObjects2.SetActive(false);

		// set to true so it's ready to go next battle
		enemyActionBar.gameObject.SetActive(true);

		enemyActionBar.ResetActionBar();
		//Destroy(enemyMonster.gameObject); taken out to test in new location for bug prevention

		pauseButton.SetActive(true);
		gameObject.SetActive(false);
	}


	void OnMouseUp () {
		if (resultsTimer > enableTransitionTime && winBattleResults.activeSelf && !continuing) {
			gameController.TransitionToWorld();

			continuing = true;
		}
	}

	// OnEnable and OnDisable are used to deactive and reactivate skill cooldowns so that they do NOT 
	// continue to cool down during battle results phase.
	void OnDisable () {
		foreach (SkillButtonController controller in skillButtonControllers) {
			if (controller.Unlocked()) {
				controller.enabled = true;
			}	
		}

		levelUpHeader.SetActive(false);
		winBattleResults.SetActive(false);
		loseBattleResults.SetActive(false);
	}

	void OnEnable () {
		foreach (SkillButtonController controller in skillButtonControllers) {
			if (controller.Unlocked()) {
				controller.enabled = false;
			}	
		}

		continuing = false;
	}

	// called when player health reaches zero
	public void LoadLoseBattleResults () {
		// enable 'Lose Battle Results'
		loseBattleResults.SetActive(true);
		enemyActionBar.gameObject.SetActive(false);

		// remove enemy status effects to avoid pois death after beating player
		enemyMonster.SetCurrentStatus(StatusEffect.None);

		// reset timer to keep screen up for 'enableTransitionTime' seconds
		resultsTimer = 0;
	}

	// called from gameController when enemy health reaches zero
	public void LoadWinBattleResults (float expGained, float totalExp, float expForNextLevel) {
		// enable 'Win Battle Results'
		winBattleResults.SetActive(true);

		// .ToString("0.##") rounds to the nearest tenths place, and displays '0' if it is zero (as opposed to not displaying anything as ("#.##") may)
		expGainedText.text = (expGained / expForNextLevel * 100).ToString("0.#") + "%";
		totalExpText.text = (totalExp / expForNextLevel * 100).ToString("0.#") + "%";

		if (playerClass.GetCurrentStatus() != StatusEffect.None) {
			if (playerClass.GetCurrentStatus() == StatusEffect.Pois || Random.value < 0.5f) {
				playerClass.SetCurrentStatus(StatusEffect.None);
			}
		}

		if (totalExp >= expForNextLevel) {
			levelUpHeader.SetActive(true);

			// original stats set before level-up
			levelOld.text = playerClass.GetPlayerLevel().ToString(); 
			HPOld.text = playerClass.GetMaxHealth().ToString();
			EPOld.text = playerClass.GetMaxEnergy().ToString();
			attackStatOld.text = playerClass.GetAttackStat().ToString();

			playerClass.LevelUp();


			// TODO create method that resets all relevant variables when a level-up occurs 
			// in order to avoid having to update them every update()


			// display level up and stat increases

			// post-level-up stats
			levelNew.text = playerClass.GetPlayerLevel().ToString(); 
			HPNew.text = playerClass.GetMaxHealth().ToString();
			EPNew.text = playerClass.GetMaxEnergy().ToString();
			attackStatNew.text = playerClass.GetAttackStat().ToString();
		} 

		// reset timer to keep screen up for 'enableTransitionTime' seconds
		resultsTimer = 0;
	}
}
