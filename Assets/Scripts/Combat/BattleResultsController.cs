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

	// Use this for initialization
	void Start () {
		playerClass = GameObject.FindObjectOfType<PlayerClass>();
		enemyMonster = GameObject.FindObjectOfType<EnemyMonster>();
		gameController = GameObject.FindObjectOfType<GameController>();
		pauseButton = GameObject.Find("Pause Button");
		enemyActionBar = GameObject.FindObjectOfType<EnemyActionBar>();
		levelUpHeader.SetActive(false);
	}

	void Update () {
		if (pauseButton.activeSelf) {
			pauseButton.SetActive(false);
		}

		if (!enemyMonster) {
			enemyMonster = GameObject.FindObjectOfType<EnemyMonster>();
		}
	}

	void OnMouseUp () {
		enemyMonster.ResetHealth();
		gameObject.SetActive(false);

		Time.timeScale = 1;

		enemyActionBar.ResetActionBar();
		Destroy(enemyMonster.gameObject);

		pauseButton.SetActive(true);
		// switch to overworld
		gameController.TransitionToOverworld();
	}

	void OnDisable () {
		levelUpHeader.SetActive(false);
	}

	public void UpdateBattleResults (float expGained, float totalExp, float expForNextLevel) {
		expGainedText.text = expGained / expForNextLevel * 100 + "%";
		totalExpText.text = totalExp / expForNextLevel * 100 + "%";

		if (totalExp >= expForNextLevel) {
			levelUpHeader.SetActive(true);

			// original stats set before level-up
			levelOld.text = playerClass.GetPlayerLevel() + ""; // added '+ ""' due to error saying "cannot convert float/int to string"...such hogwash
			HPOld.text = playerClass.GetMaxHealth() + "";
			EPOld.text = playerClass.GetMaxEnergy() + "";
			attackStatOld.text = playerClass.GetAttackStat() + "";

			playerClass.LevelUp();
			// TODO create method that resets all relevant variables when a level-up occurs 
			// in order to avoid having to update them every update()


			// displayer level up and stat increases

			// post-level-up stats
			levelNew.text = playerClass.GetPlayerLevel() + ""; 
			HPNew.text = playerClass.GetMaxHealth() + "";
			EPNew.text = playerClass.GetMaxEnergy() + "";
			attackStatNew.text = playerClass.GetAttackStat() + "";
		}

	}
}
