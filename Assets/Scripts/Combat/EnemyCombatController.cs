using UnityEngine;
using System.Collections;

public class EnemyCombatController : MonoBehaviour {

	private EnemyMonster enemyMonster;
	private PlayerClass playerClass;
	private GameObject battleResultsPanel;
	private PlayerStatusController playerStatusController;
	private EnemyActionBar enemyActionBar;

	private bool enemyIsConsumed = false;

	void Awake () {
		battleResultsPanel = GameObject.FindObjectOfType<BattleResultsController>().gameObject;
		battleResultsPanel.SetActive(false);
		playerStatusController = GameObject.FindObjectOfType<PlayerStatusController>();
		enemyActionBar = GameObject.FindObjectOfType<EnemyActionBar>();
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

		} else {
			enemyMonster = GameObject.FindObjectOfType<EnemyMonster>();
		}
	}

	void EnemyDeath () {
		battleResultsPanel.SetActive(true);

		// disable actionBar
		enemyActionBar.gameObject.SetActive(false);

		if (!enemyIsConsumed) {
			// player eats enemyMonster
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

	public void KillMonster () {
		enemyMonster.KillMonster();
	}
}
