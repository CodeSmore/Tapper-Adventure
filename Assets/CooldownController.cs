using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CooldownController : MonoBehaviour {

	bool cooldownActive = false;
	Text cooldownTimerText;
	float cooldownTimer = 0;
	float startCooldownTime;
	Button buttonComponent;

	// Use this for initialization
	void Start () {
		buttonComponent = GetComponent<Button>();
	}
	
	// Update is called once per frame
	void Update () {
		if (cooldownActive) {
			cooldownTimerText.text = Mathf.CeilToInt(startCooldownTime - cooldownTimer).ToString();
			cooldownTimer += Time.deltaTime;

			transform.parent.FindChild("Cooldown Background").GetComponent<Image>().fillAmount = cooldownTimer / startCooldownTime;

			if (cooldownTimer >= startCooldownTime) {
				cooldownActive = false;
				buttonComponent.interactable = true;
				cooldownTimerText.text = null;
				cooldownTimer = 0;
			}
		}
	}

	public void StartCooldown (float cooldownTime) {
		buttonComponent.interactable = false;

		cooldownActive = true;
		cooldownTimerText = GetComponentInChildren<Text>();
		startCooldownTime = cooldownTime;
	}
}
