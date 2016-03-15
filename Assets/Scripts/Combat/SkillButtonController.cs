using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SkillButtonController : MonoBehaviour {

	bool cooldownActive = false;
	float cooldownTimer = 0;
	float startCooldownTime;
	float skillCost;
	public bool unlocked = false;

	Button skillButtonComponent;
	Text cooldownTimerText;
	Image cooldownBackgroundImage;
	Image skillButtonDesign;
	PlayerClass playerClass;


	void Awake () {
		cooldownTimerText = GetComponentInChildren<Text>();
		playerClass = GameObject.FindObjectOfType<PlayerClass>();

		// in awake b/c these componenets are disabled immediately afterwards
		// causing NullReferenceExceptions
		cooldownBackgroundImage = transform.parent.FindChild("Cooldown Background").GetComponent<Image>();
		skillButtonDesign = gameObject.transform.FindChild("Design").GetComponent<Image>();
		skillButtonComponent = GetComponent<Button>();
	}
	// Use this for initialization
	void Start () {
		if (skillButtonComponent.interactable) {
			unlocked = true;
		}

		if (gameObject.name == "Skill 1 Button") {
			skillButtonDesign.sprite = playerClass.GetSkill1().GetSprite();
			skillCost = playerClass.GetSkill1().GetEnergyCost();
		} else if (gameObject.name == "Skill 2 Button") {
			skillButtonDesign.sprite = playerClass.GetSkill2().GetSprite();
			skillCost = playerClass.GetSkill2().GetEnergyCost();
		} else if (gameObject.name == "Skill 3 Button") {
			skillButtonDesign.sprite = playerClass.GetSkill3().GetSprite();
			skillCost = playerClass.GetSkill3().GetEnergyCost();
		}
	}

	void OnDisable () {
		if (gameObject.name == "Skill 1 Button") {
			// set value of cooldown timer in PlayerClass.cs
			playerClass.SetCooldownTimerSkill1(GetCooldownTimer());
		} else if (gameObject.name == "Skill 2 Button") {
			playerClass.SetCooldownTimerSkill2(GetCooldownTimer());
		} else if (gameObject.name == "Skill 3 Button") {
			playerClass.SetCooldownTimerSkill3(GetCooldownTimer());
		}
	}

	void OnEnable () {
		if (gameObject.name == "Skill 1 Button") {
			// set value of cooldown timer in PlayerClass.cs
			cooldownTimer = playerClass.GetCooldownTimerSkill1();
		} else if (gameObject.name == "Skill 2 Button") {
			cooldownTimer = playerClass.GetCooldownTimerSkill2();
		} else if (gameObject.name == "Skill 3 Button") {
			cooldownTimer = playerClass.GetCooldownTimerSkill3();
		}

		if (cooldownTimer != 0 && cooldownTimer < startCooldownTime) {
			cooldownActive = true;
		} else {
			FinishCooldown();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (playerClass.currentEnergy < skillCost) {
			// disable interactive
			skillButtonComponent.interactable = false;
		} else if (!cooldownActive) {
			skillButtonComponent.interactable = true;
		}

		if (cooldownActive && skillButtonComponent.interactable == false) {
			
			cooldownTimerText.text = Mathf.CeilToInt(startCooldownTime - cooldownTimer).ToString();
			cooldownTimer += Time.deltaTime;

			cooldownBackgroundImage.fillAmount = cooldownTimer / startCooldownTime;

			if (cooldownTimer >= startCooldownTime) {
				FinishCooldown();
			}
		} 
	}

	public void FinishCooldown () {
		cooldownActive = false;
		skillButtonComponent.interactable = true;
		cooldownTimerText.text = null;
		cooldownTimer = 0;
		cooldownBackgroundImage.fillAmount = 1;
	}

	public void StartCooldown (float cooldownTime) {
		skillButtonComponent.interactable = false;

		cooldownActive = true;
		startCooldownTime = cooldownTime;
	}

	public void EndCooldown () {
		cooldownTimer = startCooldownTime;
	}

	public void ActivateButton () {
		skillButtonComponent.interactable = true;
		cooldownBackgroundImage.color = new Color (cooldownBackgroundImage.color.r, cooldownBackgroundImage.color.g, cooldownBackgroundImage.color.b, 255);
		skillButtonDesign.color = new Color (skillButtonDesign.color.r, skillButtonDesign.color.g, skillButtonDesign.color.b, 255);
	}

	public void SetCooldownActive (bool active) {
		cooldownActive = active;
	}

	public float GetCooldownTimer () {
		return cooldownTimer;
	}

	public bool Unlocked () {
		return unlocked;
	}

	public void Unlock () {
		unlocked = true;
	}
}
