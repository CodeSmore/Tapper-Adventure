using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class PlayerCombatController : MonoBehaviour {

	private PlayerClass playerClass;
	private EnemyMonster enemyMonster;
	private EventSystem eventSystem;
	private EnemyStatusController enemyStatusController;

	// Use this for initialization
	void Start () {
		playerClass = GameObject.FindObjectOfType<PlayerClass>();	
		enemyMonster = GameObject.FindObjectOfType<EnemyMonster>();
		eventSystem = GameObject.FindObjectOfType<EventSystem>();
		enemyStatusController = GameObject.FindObjectOfType<EnemyStatusController>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!enemyMonster) {
			enemyMonster = GameObject.FindObjectOfType<EnemyMonster>();
		}

		if (Input.GetMouseButtonDown(0) && eventSystem.currentSelectedGameObject == null && !eventSystem.IsPointerOverGameObject()) {
			if (playerClass.GetCurrentStatus() == StatusEffect.Para) {
				if (Random.value < .4) { // if player is paralyzed, taps work only sometimes
					playerClass.ChargeEnergy();

				}
			} else {
				playerClass.ChargeEnergy();
			}
		}
	}

	public void UseSkill1 () {
		Skill skill = playerClass.GetSkill1();
		float skillCost = skill.GetEnergyCost();

		if (playerClass.GetCurrentEnergy() >= skillCost) {
			
			playerClass.UseEnergy(skillCost);

			float damage = skill.GetBaseDamage() * playerClass.GetAttackStat();

			if (Random.value < skill.GetChanceOfEffect()) {
				enemyMonster.SetCurrentStatus(skill.GetStatusEffect());
				enemyStatusController.StartStatusEffectTimer();
			}

			enemyMonster.TakeDamage(damage);

			// Cooldown
			GameObject.Find("Skill 1 Button").GetComponent<SkillButtonController>().StartCooldown(skill.GetCooldown());
		} 
	}

	public void UseSkill2 () {}
	public void UseSkill3 () {}
}
