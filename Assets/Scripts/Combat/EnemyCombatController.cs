using UnityEngine;
using System.Collections;

public class EnemyCombatController : MonoBehaviour {

	private EnemyMonster enemyMonster;
	private PlayerClass playerClass;
	private GameObject battleResultsPanel;
	private PlayerStatusController playerStatusController;
	private EnemyActionBar enemyActionBar;
	private GameObject battle;

	// necessary so that when the enemy dies, certain methods are only called ONCE
	private bool enemyIsConsumed = false;

	void Awake () {
		battleResultsPanel = GameObject.FindObjectOfType<BattleResultsController>().gameObject;
		battleResultsPanel.SetActive(false);
		playerStatusController = GameObject.FindObjectOfType<PlayerStatusController>();
		enemyActionBar = GameObject.FindObjectOfType<EnemyActionBar>();
		battle = GameObject.Find("Battle");
	}

	// Use this for initialization
	void Start () {
		enemyMonster = GameObject.FindObjectOfType<EnemyMonster>();
		playerClass = GameObject.FindObjectOfType<PlayerClass>();
	}
	
	// Update is called once per frame
	void Update () {
		if (enemyMonster) {
			if (enemyMonster.GetCurrentHealth() <= 0) {
				EnemyDeath();				
			} else if (enemyIsConsumed) {
				enemyIsConsumed = false;
			}

		} else if (battle.activeSelf) {
			enemyMonster = GameObject.FindObjectOfType<EnemyMonster>();
		}
	}

	void EnemyDeath () {
		if (!enemyIsConsumed) {
			// disable actionBar
			enemyActionBar.gameObject.SetActive(false);

			// player eats enemyMonster, heals, gains experience, and populates the battle results
			battleResultsPanel.SetActive(true);

			playerClass.Heal(enemyMonster.GetMaxHealth() * 0.1f);
			playerClass.GainExperience(enemyMonster.GetExperienceReward());
			battleResultsPanel.GetComponent<BattleResultsController>().UpdateBattleResults(enemyMonster.GetExperienceReward(), playerClass.GetCurrentExperiencePoints(), playerClass.GetExperiencePointsForNextLevel());

			enemyIsConsumed = true;
		}
	}

	public void UseSkill1 () {
		playerClass.TakeDamage (enemyMonster.GetActionDamage());

		if (enemyMonster.GetActionStatusEffect() != StatusEffect.None) {
			if (Random.value <= enemyMonster.GetStatusEffectChance()) {
				playerClass.SetCurrentStatus(enemyMonster.GetActionStatusEffect());
				playerStatusController.StartStatusEffectTimer();
			}
		}
	}

	public void UseSkill2 () {
		playerClass.TakeDamage (enemyMonster.GetActionDamage2());

		if (enemyMonster.GetActionStatusEffect2() != StatusEffect.None) {
			if (Random.value <= enemyMonster.GetStatusEffectChance2()) {
				playerClass.SetCurrentStatus(enemyMonster.GetActionStatusEffect2());
				playerStatusController.StartStatusEffectTimer();
			}
		}
	}

	// TODO change name or remove KillMonster from this script. It's redundant.
	public void KillMonster () {
		enemyMonster.KillMonster();
	}
}
