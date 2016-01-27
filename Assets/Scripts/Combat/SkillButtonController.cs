using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SkillButtonController : MonoBehaviour {

	bool cooldownActive = false;
	float cooldownTimer = 0;
	float startCooldownTime;

	Button skillButtonComponent;
	Text cooldownTimerText;
	Image cooldownBackgroundImage;
	Image skillButtonDesign;

	// Use this for initialization
	void Start () {
		skillButtonComponent = GetComponent<Button>();
		cooldownBackgroundImage = transform.parent.FindChild("Cooldown Background").GetComponent<Image>();
		skillButtonDesign = gameObject.transform.FindChild("Design").GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		if (cooldownActive) {
			cooldownTimerText.text = Mathf.CeilToInt(startCooldownTime - cooldownTimer).ToString();
			cooldownTimer += Time.deltaTime;

			cooldownBackgroundImage.fillAmount = cooldownTimer / startCooldownTime;

			if (cooldownTimer >= startCooldownTime) {
				cooldownActive = false;
				skillButtonComponent.interactable = true;
				cooldownTimerText.text = null;
				cooldownTimer = 0;
			}
		}
	}

	public void StartCooldown (float cooldownTime) {
		skillButtonComponent.interactable = false;

		cooldownActive = true;
		cooldownTimerText = GetComponentInChildren<Text>();
		startCooldownTime = cooldownTime;
	}

	public void ActivateButton () {
		skillButtonComponent.interactable = true;
		cooldownBackgroundImage.color = new Color (cooldownBackgroundImage.color.r, cooldownBackgroundImage.color.g, cooldownBackgroundImage.color.b, 255);
		skillButtonDesign.color = new Color (skillButtonDesign.color.r, skillButtonDesign.color.g, skillButtonDesign.color.b, 255);
	}
}
