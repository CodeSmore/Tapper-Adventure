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
	private SkillButtonController[] skillButtonController;

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
		skillButtonController = GameObject.FindObjectsOfType<SkillButtonController>();
		levelUpHeader.SetActive(false);
	}

	// Use this for initialization
	void Start () {
		enemyMonster = GameObject.FindObjectOfType<EnemyMonster>();
		gameController = GameObject.FindObjectOfType<GameController>();
		pauseButton = GameObject.Find("Pause Button");
		tapToContinueObject.SetActive(false);

		resultsTimer = 0;
	}

	void Update () {
		if (pauseButton.activeSelf) {
			pauseButton.SetActive(false);
		}

		if (!enemyMonster) {
			enemyMonster = GameObject.FindObjectOfType<EnemyMonster>();
		}

		resultsTimer += Time.deltaTime;

		if (resultsTimer > enableTransitionTime) {
			tapToContinueObject.SetActive(true);
		}
	}

	void OnMouseUp () {
		if (resultsTimer > enableTransitionTime) {
			enemyMonster.ResetHealth();
			gameObject.SetActive(false);

			tapToContinueObject.SetActive(false);
			enemyActionBar.gameObject.SetActive(true);

			enemyActionBar.ResetActionBar();
			Destroy(enemyMonster.gameObject);

			pauseButton.SetActive(true);
			// switch to overworld
			gameController.TransitionToOverworld();
		}
	}

	void OnDisable () {
		foreach (SkillButtonController controller in skillButtonController) {
			if (controller.Unlocked()) {
				controller.SetCooldownActive(true);
			}	
		}


		levelUpHeader.SetActive(false);
	}

	void OnEnable () {
		foreach (SkillButtonController controller in skillButtonController) {
			if (controller.Unlocked()) {
				controller.SetCooldownActive(false);
			}	
		}
	}

	public void UpdateBattleResults (float expGained, float totalExp, float expForNextLevel) {
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

			foreach (SkillButtonController controller in skillButtonController) {
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

		// start timer to keep screen up for a second
		resultsTimer = 0;
	}
}
