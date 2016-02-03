using UnityEngine;
using System.Collections;

public class EnemyMonster : MonoBehaviour {

	[Header("Stats", order = 0)]
	public float currentHealth;
	public float maxHealth;
	public StatusEffect currentStatus = StatusEffect.None;

	public float experienceReward;
	public float HealthBarYPos;
	public float ActionBarYPos;

	[Header("-------", order = 0)]
	[Header("", order = 1)]
	[Header("Skill 1", order = 2)]

	public float actionDamage;
	public StatusEffect actionStatusEffect;
	public float statusEffectChance;
	public float secondsBetweenActions;

	[Header("-------", order = 0)]
	[Header("", order = 1)]
	public bool hasSecondAttack;

	[Header("", order = 0)]
	[Header("Skill 2", order = 1)]

	public float actionDamage2;
	public StatusEffect actionStatusEffect2;
	public float statusEffectChance2;
	public float secondsBetweenActions2;


	private float actionTimer;

	// Use this for initialization
	void Start () {
		ResetActionTimer();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public float GetCurrentHealth () {
		return currentHealth;
	}

	public float GetMaxHealth () {
		return maxHealth;
	}

	public StatusEffect GetCurrentStatus () {
		return currentStatus;
	}

	public void SetCurrentStatus (StatusEffect newStatus) {
		currentStatus = newStatus;
	}

	public float GetSecondsBetweenActions () {
		return secondsBetweenActions;
	}

	public float GetActionTimerValue () {
		return actionTimer;
	}

	public float GetActionDamage () {
		return actionDamage;
	}

	public StatusEffect GetActionStatusEffect () {
		return actionStatusEffect;
	}

	public float GetStatusEffectChance () {
		return statusEffectChance;
	}

	public void TakeDamage (float damage) {
		currentHealth -= damage;
	}

	public void ResetHealth () {
		currentHealth = maxHealth;
	}

	public void KillMonster () {
		currentHealth = 0;
	}

	public void ResetActionTimer () {
		actionTimer = 0;
	}

	public void IncrementActionTimer (float amount) {
		actionTimer += amount;
	}

	public float GetExperienceReward () {
		return experienceReward;
	}

	public float GetHealthBarYPos () {
		return HealthBarYPos;
	}

	public float GetActionBarYPos () {
		return ActionBarYPos;
	}

	public bool HasSecondSkill () {
		return hasSecondAttack;
	}

	public float GetSecondsBetweenActions2 () {
		return secondsBetweenActions2;
	}

	public float GetActionDamage2 () {
		return actionDamage2;
	}

	public StatusEffect GetActionStatusEffect2 () {
		return actionStatusEffect2;
	}

	public float GetStatusEffectChance2 () {
		return statusEffectChance2;
	}

	void OnDestroy () {}
}
