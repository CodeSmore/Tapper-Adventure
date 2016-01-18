using UnityEngine;
using System.Collections;

public class EnemyCombatController : MonoBehaviour {

	private EnemyMonster enemyMonster;
	private EnemyActionBar enemyActionBar;
	private EnemyHealthBar enemyHealthBar;
	private GameController gameController;
	private PlayerClass playerClass;

	// Use this for initialization
	void Start () {
		enemyMonster = GameObject.FindObjectOfType<EnemyMonster>();
		enemyActionBar = GameObject.FindObjectOfType<EnemyActionBar>();
		enemyHealthBar = GameObject.FindObjectOfType<EnemyHealthBar>();
		gameController = GameObject.FindObjectOfType<GameController>();
		playerClass = GameObject.FindObjectOfType<PlayerClass>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!enemyActionBar) {
			enemyActionBar = GameObject.FindObjectOfType<EnemyActionBar>();
		}
		if (!enemyHealthBar) {
			enemyHealthBar = GameObject.FindObjectOfType<EnemyHealthBar>();
		}

		if (enemyMonster.GetCurrentHealth() <= 0) {
			// player eats enemyMonster
			playerClass.Heal(enemyMonster.GetMaxHealth() * 0.1f);
			// reset enemy health
			enemyMonster.ResetHealth();
			enemyActionBar.ResetActionBar();
			// switch to overworld
			gameController.TransitionToOverworld();
		}
	}

	public void Attack () {
		playerClass.TakeDamage (enemyMonster.GetActionDamage());
	}
}
