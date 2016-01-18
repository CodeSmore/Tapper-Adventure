using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class PlayerCombatController : MonoBehaviour {

	private PlayerClass playerClass;
	private EnemyMonster enemyMonster;
	private EventSystem eventSystem;

	// Use this for initialization
	void Start () {
		playerClass = GameObject.FindObjectOfType<PlayerClass>();	
		enemyMonster = GameObject.FindObjectOfType<EnemyMonster>();
		eventSystem = GameObject.FindObjectOfType<EventSystem>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0) && eventSystem.currentSelectedGameObject == null && !eventSystem.IsPointerOverGameObject()) {
			playerClass.ChargeEnergy();
		}
	}

	public void UseSkill1 () {
		float skillCost = playerClass.GetSkill1().GetEnergyCost();

		if (playerClass.GetCurrentEnergy() >= skillCost) {
			playerClass.UseEnergy(skillCost);

			float damage = playerClass.GetSkill1 ().GetBaseDamage();

			enemyMonster.TakeDamage(damage);
		}


		// TODO 
		// disable skill until cooldown is complete
		// use a cooldown timer for EACH skill
	}

	public void UseSkill2 () {}
	public void UseSkill3 () {}
}
