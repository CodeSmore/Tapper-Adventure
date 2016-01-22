using UnityEngine;
using System.Collections;

public class EnemyMonster : MonoBehaviour {

	public float currentHealth;
	public float maxHealth;
	public StatusEffect currentStatus;
	public float secondsBetweenActions;
	private float actionTimer;
	public float actionDamage;
	public StatusEffect actionStatusEffect;
	public float statusEffectChance;
	public float experienceReward;

	public float HealthBarYPos;
	public float ActionBarYPos;


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
}
