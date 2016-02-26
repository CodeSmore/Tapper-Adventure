using UnityEngine;
using System.Collections;

public enum StatusEffect {None, Para, Pois, Slow};

public class PlayerClass : MonoBehaviour {

	[Header("Class Stats")]
	public Sprite monsterSprite;
	public string monsterName;
	public string monsterSpecies;
	public string monsterDescription;
	public float currentHealth;
	public float maxHealth;
	public StatusEffect currentStatus;
	public float currentEnergy;
	public float maxEnergy;
	public float energyRecoveryRate;
	public int playerLevel;
	public float currentExperiencePoints;
	public float attackStat;

	// basis of each stat level-up
	public float baseHealth;
	public float baseEnergy;
	public float baseAttackStat;


	[Header("=======", order = 0)]
	[Header("", order = 1)]
	[Header("Skills", order = 1)]
	[Header("-------", order = 1)]

	[Header("Skill 1", order = 2)]
	public Sprite skillSprite1;
	[Tooltip("Name of skill as a string")]
	public string skillName1;
	[Tooltip("Skill level as an int")]
	public int levelOfSkill1;
	[Tooltip("Base damage of skill as a float")]
	public float baseDamage1;
	[Tooltip("Cost in energy points to use skill")]
	public float energyCost1;
	[Tooltip("Cooldown time after skill use")]
	public float cooldownTime1;
	[Tooltip("Potential status effect of skill")]
	public StatusEffect statusEffectOfSkill1;
	[Tooltip("Chance of above status effect being applied")]
	public float chanceOfStatusEffect1;
	[Tooltip("Duration of above status effect in seconds")]
	public float statusEffectDurationInSeconds1;
	[Header("-------", order = 2)]

	[Header("Skill 2", order = 3)]
	public Sprite skillSprite2;
	[Tooltip("Name of skill as a string")]
	public string skillName2;
	[Tooltip("Skill level as an int")]
	public int levelOfSkill2;
	[Tooltip("Base damage of skill as a float")]
	public float baseDamage2;
	[Tooltip("Cost in energy points to use skill")]
	public float energyCost2;
	[Tooltip("Cooldown time after skill use")]
	public float cooldownTime2;
	[Tooltip("Potential status effect of skill")]
	public StatusEffect statusEffectOfSkill2;
	[Tooltip("Chance of above status effect being applied")]
	public float chanceOfStatusEffect2;
	[Tooltip("Duration of above status effect in seconds")]
	public float statusEffectDurationInSeconds2;
	[Header("-------", order = 3)]


	[Header("Skill 3", order = 4)]
	public Sprite skillSprite3;
	[Tooltip("Name of skill as a string")]
	public string skillName3;
	[Tooltip("Skill level as an int")]
	public int levelOfSkill3;
	[Tooltip("Base damage of skill as a float")]
	public float baseDamage3;
	[Tooltip("Cost in energy points to use skill")]
	public float energyCost3;
	[Tooltip("Cooldown time after skill use")]
	public float cooldownTime3;
	[Tooltip("Potential status effect of skill")]
	public StatusEffect statusEffectOfSkill3;
	[Tooltip("Chance of above status effect being applied")]
	public float chanceOfStatusEffect3;
	[Tooltip("Duration of above status effect in seconds")]
	public float statusEffectDurationInSeconds3;

	private Skill skill1;
	private Skill skill2;
	private Skill skill3;

	private bool skillUnlocked1;
	private bool skillUnlocked2;
	private bool skillUnlocked3;

	// skill button objects
	private GameObject skill1ButtonObject;
	private GameObject skill2ButtonObject;
	private GameObject skill3ButtonObject;

	// holds current cooldown timer values for skills
	private float cooldownTimerSkill1;
	private float cooldownTimerSkill2;
	private float cooldownTimerSkill3;


	private BossStatusController bossStatusController;

	void Update () {
		Debug.Log("Skill 1 cooldown: " + GetCooldownTimerSkill1());
	}

	// Use this for initialization
	void Awake () {
		skill1 = new Skill (skillSprite1, skillName1, levelOfSkill1, baseDamage1, energyCost1, cooldownTime1, statusEffectOfSkill1, chanceOfStatusEffect1, statusEffectDurationInSeconds1);
		skill2 = new Skill (skillSprite2, skillName2, levelOfSkill2, baseDamage2, energyCost2, cooldownTime2, statusEffectOfSkill2, chanceOfStatusEffect2, statusEffectDurationInSeconds2);
		skill3 = new Skill (skillSprite3, skillName3, levelOfSkill3, baseDamage3, energyCost3, cooldownTime3, statusEffectOfSkill3, chanceOfStatusEffect3, statusEffectDurationInSeconds3);
		currentHealth = maxHealth;
		currentStatus = StatusEffect.None;

		bossStatusController = GameObject.FindObjectOfType<BossStatusController>();

		skill1ButtonObject = GameObject.Find("Skill 1");
		skill2ButtonObject = GameObject.Find("Skill 2");
		skill3ButtonObject = GameObject.Find("Skill 3");
	}

	public Skill GetSkill1 () {
		return skill1;
	}

	public Skill GetSkill2 () {
		return skill2;
	}

	public Skill GetSkill3 () {
		return skill3;
	}

	public int GetPlayerLevel () {
		return playerLevel;
	}

	public void LevelUp () {
		ResetCurrentExperiencePoints();
		playerLevel++;


		// increase stats
		attackStat = baseAttackStat + playerLevel - 1;
		maxHealth = baseHealth * playerLevel;
		maxEnergy = baseEnergy * playerLevel;

		// restore health and status
		Heal (maxHealth);
		currentStatus = StatusEffect.None;


		if (currentExperiencePoints >= GetExperiencePointsForNextLevel()) {
			LevelUp();
		}
	}

	public void ManageEarnedSkills () {
		// TODO move skill activiation to boss events
		// TODO CREATE boss events script to handle them
		int[] bossStatusArray = bossStatusController.GetBossStatus();

		// skill 3
		if (!skillUnlocked3) {
			if (bossStatusArray[2] == 0 && !skillUnlocked3) {
				// activate skill
				// enable button and cooldown background and disable dashed circle
				foreach (Transform thing in skill3ButtonObject.transform) {
					if (thing.gameObject.name == "Dashed Circle") {
						thing.gameObject.SetActive(false);
					} else {
						thing.gameObject.SetActive(true);
					}
				}
				skill3ButtonObject.GetComponentInChildren<SkillButtonController>().ActivateButton();
				skill3ButtonObject.GetComponentInChildren<SkillButtonController>().Unlock();
				skillUnlocked3 = true;
			} else {
				foreach (Transform thing in skill3ButtonObject.transform) {
					if (thing.gameObject.name == "Dashed Circle") {
						thing.gameObject.SetActive(true);
					} else {
						thing.gameObject.SetActive(false);
					}
				}
			}
		}


		// skill 2
		if (!skillUnlocked2) {
			if (bossStatusArray[1] == 0) {
				// activate skill
				foreach (Transform thing in skill2ButtonObject.transform) {
					if (thing.gameObject.name == "Dashed Circle") {
						thing.gameObject.SetActive(false);
					} else {
						thing.gameObject.SetActive(true);
					}
				}
				skill2ButtonObject.GetComponentInChildren<SkillButtonController>().ActivateButton();
				skill2ButtonObject.GetComponentInChildren<SkillButtonController>().Unlock();
				skillUnlocked2 = true;
			} else {
				foreach (Transform thing in skill2ButtonObject.transform) {
					if (thing.gameObject.name == "Dashed Circle") {
						thing.gameObject.SetActive(true);
					} else {
						thing.gameObject.SetActive(false);
					}
				}
			}
		}


		// skill 1
		if (!skillUnlocked1) {
			if (bossStatusArray[0] == 0) {
				// activate skill
				foreach (Transform thing in skill1ButtonObject.transform) {
					if (thing.gameObject.name == "Dashed Circle") {
						thing.gameObject.SetActive(false);
					} else {
						thing.gameObject.SetActive(true);
					}
				}
				skill1ButtonObject.GetComponentInChildren<SkillButtonController>().ActivateButton();
				skill1ButtonObject.GetComponentInChildren<SkillButtonController>().Unlock();
				skillUnlocked1 = true;
			} else {
				foreach (Transform thing in skill1ButtonObject.transform) {
					if (thing.gameObject.name == "Dashed Circle") {
						thing.gameObject.SetActive(true);
					} else {
						thing.gameObject.SetActive(false);
					}
				}
			}
		}
	}

	public void UpdateStats () {
		attackStat = baseAttackStat + playerLevel - 1;
		maxHealth = baseHealth * playerLevel;
		maxEnergy = baseEnergy * playerLevel;
	}

	public void SetPlayerLevel (int level) {
		playerLevel = level;
	}

	public float GetCurrentExperiencePoints () {
		return currentExperiencePoints;
	}

	public void ResetCurrentExperiencePoints () {
		currentExperiencePoints -= GetExperiencePointsForNextLevel();
	}

	public float GetExperiencePointsForNextLevel () {
		float expForNextLevel = 20 + 20 * (playerLevel - 1);

		return expForNextLevel;
	}

	public void SetCurrentExperiencePoints (float points) {
		currentExperiencePoints = points;	
	}

	public void GainExperience (float points) {
		currentExperiencePoints += points;
	}

	public void ChargeEnergy () {
		currentEnergy = Mathf.Clamp (currentEnergy + energyRecoveryRate, 0, maxEnergy);
	}

	public void UseEnergy (float amountUsed) {
		if (currentEnergy >= amountUsed)
			currentEnergy = Mathf.Clamp (currentEnergy - amountUsed, 0, maxEnergy);
	}

	public void Heal (float healAmount) {
		currentHealth = Mathf.Clamp (currentHealth + healAmount, 0, maxHealth);
	}

	public void TakeDamage (float damageDealt) {
		currentHealth = Mathf.Clamp (currentHealth - damageDealt, 0, maxHealth);
		// TODO 
		// if currentHealth <= 0, DIE!!!!!!!1!!!11111!!
	}

	public float GetMaxHealth () {
		return maxHealth;
	}

	public float GetCurrentHealth () {
		return currentHealth;
	}

	public void SetCurrentHealth (float health) {
		currentHealth = health;
	}

	public void SetCurrentEnergy (float energy) {
		currentEnergy = energy;
	}

	public float GetMaxEnergy () {
		return maxEnergy;
	}

	public float GetCurrentEnergy () {
		return currentEnergy;
	}

	public StatusEffect GetCurrentStatus () {
		return currentStatus;
	}

	public void SetCurrentStatus (StatusEffect newStatus) {
		currentStatus = newStatus;
	}

	public float GetAttackStat () {
		return attackStat;
	}

	public string GetName () {
		return monsterName;
	}

	public string GetSpecies () {
		return monsterSpecies;
	}

	public string GetDescription () {
		return monsterDescription;
	}

	public Sprite GetMonsterSprite () {
		return monsterSprite;
	}

	public bool SkillOneUnlocked () {
		return skillUnlocked1;
	}

	public bool SkillTwoUnlocked () {
		return skillUnlocked2;
	}

	public bool SkillThreeUnlocked () {
		return skillUnlocked3;
	}

	public void SetCooldownTimerSkill1 (float timer) {
		cooldownTimerSkill1 = timer;
	}

	public void SetCooldownTimerSkill2 (float timer) {
		cooldownTimerSkill2 = timer;
	}

	public void SetCooldownTimerSkill3 (float timer) {
		cooldownTimerSkill3 = timer;
	}

	public float GetCooldownTimerSkill1 () {
		return cooldownTimerSkill1;
	}

	public float GetCooldownTimerSkill2 () {
		return cooldownTimerSkill2;
	}

	public float GetCooldownTimerSkill3 () {
		return cooldownTimerSkill3;
	}
}

public class Skill {
	private Sprite sprite;
	private string name;
	private int level;
	private float baseDamage;
	private float energyCost;
	private float cooldown;
	private StatusEffect statusEffect;
	private float chanceOfEffect;
	private float durationOfEffect;

	public Skill (Sprite skillSprite = null, string theName = "", int theLevel = 1, float theBaseDamage = 1, float theEnergyCost = 1, float theCooldown = 0, StatusEffect theStatusEffect = StatusEffect.None, float theChanceOfEffect = 0, float theDurationOfEffect = 0) {
		sprite = skillSprite;
		name = theName;
		level = theLevel;
		baseDamage = theBaseDamage;
		energyCost = theEnergyCost;
		cooldown = theCooldown;
		statusEffect = theStatusEffect;
		chanceOfEffect = theChanceOfEffect;
		durationOfEffect = theDurationOfEffect;
	}

	public Sprite GetSprite () {
		return sprite;
	}
	public string GetName () {
		return name;
	}

	public int GetLevel () {
		return level;
	}

	public float GetBaseDamage () {
		return baseDamage;
	}

	public float GetEnergyCost () {
		return energyCost;
	}

	public float GetCooldown () {
		return cooldown;
	}

	public StatusEffect GetStatusEffect () {
		return statusEffect;
	}

	public float GetChanceOfEffect () {
		return chanceOfEffect;
	}

	public float GetDurationOfEffect () {
		return durationOfEffect;
	}
}
