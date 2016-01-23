using UnityEngine;
using System.Collections;

public class EnemyCombatController : MonoBehaviour {

	private EnemyMonster enemyMonster;
	private PlayerClass playerClass;
	private GameObject battleResultsPanel;

	private bool enemyIsConsumed = false;

	void Awake () {
		battleResultsPanel = GameObject.FindObjectOfType<BattleResultsController>().gameObject;
		battleResultsPanel.SetActive(false);
	}

	// Use this for initialization
	void Start () {
		enemyMonster = GameObject.FindObjectOfType<EnemyMonster>();
		playerClass = GameObject.FindObjectOfType<PlayerClass>();
	}
	
	// Update is called once per frame
	void Update () {
		if (enemyMonster) {
			if (enemyMonster.GetCurrentHealth() <= 0 ) {
				EnemyDeath();				
			} else if (enemyIsConsumed) {
				enemyIsConsumed = false;
			}

		} else {
			enemyMonster = GameObject.FindObjectOfType<EnemyMonster>();

		}
	}

	void EnemyDeath () {
		Time.timeScale = 0;

		battleResultsPanel.SetActive(true);

		if (!enemyIsConsumed) {
			// player eats enemyMonster
			playerClass.Heal(enemyMonster.GetMaxHealth() * 0.1f);
			playerClass.GainExperience(enemyMonster.GetExperienceReward());
			battleResultsPanel.GetComponent<BattleResultsController>().UpdateBattleResults(enemyMonster.GetExperienceReward(), playerClass.GetCurrentExperiencePoints(), playerClass.GetExperiencePointsForNextLevel());

			enemyIsConsumed = true;
		}
	}

	public void Attack () {
		playerClass.TakeDamage (enemyMonster.GetActionDamage());

		if (enemyMonster.GetActionStatusEffect() != StatusEffect.None) {
			playerClass.SetCurrentStatus(enemyMonster.GetActionStatusEffect());
		}
	}

	public void KillMonster () {
		enemyMonster.KillMonster();
	}
}
