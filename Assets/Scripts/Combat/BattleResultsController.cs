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

		resultsTimer = 0;
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
		}
	}

	// called after player 'taps to continue'
	public void EndOfBattlePreparations () {

		// reset the health bar
		enemyMonster.ResetHealth();

		tapToContinueObject.SetActive(false);

		// set to true so it's ready to go next battle
		enemyActionBar.gameObject.SetActive(true);

		enemyActionBar.ResetActionBar();
		Destroy(enemyMonster.gameObject);

		pauseButton.SetActive(true);
		gameObject.SetActive(false);
	}


	void OnMouseUp () {
		if (resultsTimer > enableTransitionTime && winBattleResults.activeSelf) {
			gameController.TransitionToWorld();
		}
	}

	// OnEnable and OnDisable are used to deactive and reactivate skill cooldowns so that they do NOT 
	// continue to cool down during battle results phase.
	void OnDisable () {
		foreach (SkillButtonController controller in skillButtonControllers) {
			if (controller.Unlocked()) {
				controller.SetCooldownActive(true);
			}	
		}

		levelUpHeader.SetActive(false);
		winBattleResults.SetActive(false);
		loseBattleResults.SetActive(false);
	}

	void OnEnable () {
		foreach (SkillButtonController controller in skillButtonControllers) {
			if (controller.Unlocked()) {
				controller.SetCooldownActive(false);
			}	
		}
	}

	// called when player health reaches zero
	public void LoseBattleResults () {
		// enable 'Lose Battle Results'
		loseBattleResults.SetActive(true);
	}

	// called from gameController when enemy health reaches zero
	public void UpdateBattleResults (float expGained, float totalExp, float expForNextLevel) {
		// enable 'Win Battle Results'
		winBattleResults.SetActive(true);

		expGainedText.text = expGained / expForNextLevel * 100 + "%";
		totalExpText.text = totalExp / expForNextLevel * 100 + "%";

		if (totalExp >= expForNextLevel) {
			levelUpHeader.SetActive(true);

			// original stats set before level-up
			levelOld.text = playerClass.GetPlayerLevel().ToString(); 
			HPOld.text = playerClass.GetMaxHealth().ToString();
			EPOld.text = playerClass.GetMaxEnergy().ToString();
			attackStatOld.text = playerClass.GetAttackStat().ToString();

			playerClass.LevelUp();

			// ends the cooldown phase of each earned skill button upon LevelUp
			foreach (SkillButtonController controller in skillButtonControllers) {
				if (controller.Unlocked()) {
					controller.ActivateButton();
					controller.EndCooldown();
				}	
			}
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
