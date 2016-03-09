using UnityEngine;
using System.Collections;

public class EnemyCombatController : MonoBehaviour {

	private EnemyMonster enemyMonster;
	private PlayerClass playerClass;
	private GameObject battleResultsPanel;
	private PlayerStatusController playerStatusController;
	private EnemyActionBar enemyActionBar;
	private GameObject battle;
	private BossStatusController bossStatusController;
	private EnemySpawnerController enemySpawnerController;

	// necessary so that when the enemy dies, certain methods are only called ONCE
	private bool enemyIsConsumed = false;

	void Awake () {
		battleResultsPanel = GameObject.FindObjectOfType<BattleResultsController>().gameObject;
		battleResultsPanel.SetActive(false);
		playerStatusController = GameObject.FindObjectOfType<PlayerStatusController>();
		enemyActionBar = GameObject.FindObjectOfType<EnemyActionBar>();
		battle = GameObject.Find("Battle");
		bossStatusController = GameObject.FindObjectOfType<BossStatusController>();
		enemySpawnerController = GameObject.FindObjectOfType<EnemySpawnerController>();
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
				if (!enemyIsConsumed) {
					EnemyDeath();	
				}
			} else if (enemyIsConsumed) {
				enemyIsConsumed = false;
			}

		} else if (battle.activeSelf) {
			enemyMonster = GameObject.FindObjectOfType<EnemyMonster>();

			if (!enemyMonster) {
				// spawn new monster
				enemySpawnerController.Spawn();
				Debug.Log("Spawning Monster in backup");
			}
		}
	}

	void EnemyDeath () {
		// if it's a boss, unlock skill!
		if (enemyMonster.tag == "Boss") {
			bossStatusController.UpdateBossStatus();
		}

		// disable actionBar
		enemyActionBar.gameObject.SetActive(false);

		// player eats enemyMonster, heals, gains experience, and populates the battle results
		battleResultsPanel.SetActive(true);

		playerClass.Heal(enemyMonster.GetMaxHealth() * 0.1f);
		playerClass.GainExperience(enemyMonster.GetExperienceReward());
		battleResultsPanel.GetComponent<BattleResultsController>().LoadWinBattleResults(enemyMonster.GetExperienceReward(), playerClass.GetCurrentExperiencePoints(), playerClass.GetExperiencePointsForNextLevel());

		enemyIsConsumed = true;
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

	// Used by InstaKill button
	public void KillMonster () {
		enemyMonster.KillMonster();
	}
}
