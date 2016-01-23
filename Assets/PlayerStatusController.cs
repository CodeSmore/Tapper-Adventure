using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerStatusController : MonoBehaviour {

	private Text statusText = null;
	private PlayerClass playerClass;

	private StatusEffect currentStatus = StatusEffect.None;

	private float remainingStatusTime;
	private float endStatusTime;
	private bool enableStatusTimer = false;

	void Start () {
		statusText = GetComponent<Text>();
	}

	// Update is called once per frame
	void Update () {
		if (!playerClass) {
			playerClass = GameObject.FindObjectOfType<PlayerClass>();
		}

		UpdateStatusEffect();

		if (enableStatusTimer) {
			remainingStatusTime -= Time.deltaTime;

			if (remainingStatusTime <= 0) {
				playerClass.SetCurrentStatus(StatusEffect.None);
				enableStatusTimer = false;
			}
		}
	}

	void UpdateStatusEffect () {
		if (currentStatus != playerClass.GetCurrentStatus()) {
			currentStatus = playerClass.GetCurrentStatus();
		}
		
		if (currentStatus == StatusEffect.None) {
			statusText.text = null;
		} else if (currentStatus == StatusEffect.Para) {
			statusText.text = "Para";
			endStatusTime = 3;
		} else if (currentStatus == StatusEffect.Pois) {
			statusText.text = "Pois";
			endStatusTime = 10;
		} 
	}

	public void StartStatusEffectTimer () {
		enableStatusTimer = true;
		UpdateStatusEffect();
		remainingStatusTime = endStatusTime;
	}
}