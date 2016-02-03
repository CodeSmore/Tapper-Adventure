using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyStatusController : MonoBehaviour {

	private EnemyMonster enemyMonster;

	private RectTransform statusRectTransform;
	private Text statusText = null;

	private StatusEffect currentStatus = StatusEffect.None;

	// TODO set when status is applied (PlayerCombatController.cs)
	private float remainingStatusTime;
	private float endStatusTime;
	private bool enableStatusTimer = false;

	void Awake () {
		statusText = GetComponent<Text>();
		statusRectTransform = GetComponent<RectTransform>();
	}


	// Update is called once per frame
	void Update () {
		// reinitialize enemyMonster variable each time, b/c after each battle, the previous one is destroyed.
		if (!enemyMonster) {
			enemyMonster = GameObject.FindObjectOfType<EnemyMonster>();
		} else {
			statusRectTransform.anchoredPosition = new Vector2 (transform.position.x , enemyMonster.GetHealthBarYPos());
			UpdateStatusEffect();

			if (enableStatusTimer) {
				remainingStatusTime -= Time.deltaTime;

				if (remainingStatusTime <= 0) {
					enemyMonster.SetCurrentStatus(StatusEffect.None);
					enableStatusTimer = false;
				}
			}
		}


	}

	void UpdateStatusEffect () {
		if (currentStatus != enemyMonster.GetCurrentStatus()) {
			currentStatus = enemyMonster.GetCurrentStatus();
		}
		
		if (currentStatus == StatusEffect.None) {
			statusText.text = null;
		} else if (currentStatus == StatusEffect.Para) {
			statusText.text = "Para";
			endStatusTime = 3;
		} else if (currentStatus == StatusEffect.Pois) {
			statusText.text = "Pois";
			endStatusTime = 10;
		} else if (currentStatus == StatusEffect.Slow) {
			statusText.text = "Slow";
			endStatusTime = enemyMonster.GetSecondsBetweenActions();
		} 
	}

	public void StartStatusEffectTimer () {
		enableStatusTimer = true;
		UpdateStatusEffect();
		remainingStatusTime = endStatusTime;
	}


}
