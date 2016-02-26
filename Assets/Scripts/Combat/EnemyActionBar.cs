using UnityEngine;
using UnityEngine.UI; 
using System.Collections;

public class EnemyActionBar : MonoBehaviour {

	private float secondsBetweenActions;
	private float actionBarRatio;
	private float randomChanceOfSecondSkill;
	private bool usingSecondSkill = false;
	private bool actionEnabled = false;
	private float colorTimer = 0;

	public float chanceToUseSecondSkill;
	
	private Image actionBarImage;
	private RectTransform actionBarRectTransform;
	
	private EnemyMonster enemyMonster;
	private EnemyCombatController enemyCombatController;

	// Use this for initialization
	void Start () {
		enemyMonster = GameObject.FindObjectOfType<EnemyMonster>();
		enemyCombatController = GameObject.FindObjectOfType<EnemyCombatController>();

		actionBarImage = GetComponent<Image>();
		actionBarRectTransform = GetComponent<RectTransform>();

		randomChanceOfSecondSkill = Random.value;
	}

	void OnDisable () {
		actionEnabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!enemyMonster) {
			enemyMonster  = GameObject.FindObjectOfType<EnemyMonster>();
		} else if (actionEnabled) {

			if (enemyMonster.HasSecondSkill() && randomChanceOfSecondSkill < chanceToUseSecondSkill) {
				usingSecondSkill = true;
				secondsBetweenActions = enemyMonster.GetSecondsBetweenActions2();
				// then use 2nd skill instead of the original
			} else {
				usingSecondSkill = false;
				secondsBetweenActions = enemyMonster.GetSecondsBetweenActions();
				// use original skill
			}


			// handles status effects
			if (enemyMonster.GetCurrentStatus() == StatusEffect.Slow) {
				enemyMonster.IncrementActionTimer(Time.deltaTime / 2);
			} else if (enemyMonster.GetCurrentStatus() != StatusEffect.Para) { // Para simply stops timer increment, so do nothing if paralyzed
				enemyMonster.IncrementActionTimer(Time.deltaTime);
			}


			if (actionBarRectTransform.anchoredPosition.y != enemyMonster.GetActionBarYPos()) {
				actionBarRectTransform.anchoredPosition = new Vector2 (transform.position.x , enemyMonster.GetActionBarYPos());
			}
			TakeAction ();
			HandleActionBar();
		}
	}
	
	void HandleActionBar () {
		actionBarRatio = enemyMonster.GetActionTimerValue() / secondsBetweenActions;

		actionBarImage.fillAmount = actionBarRatio;

		if (!usingSecondSkill) {
			// make color blue
			actionBarImage.color = Color.blue;
		} else {
			// if second skill, make it pretty :D
			colorTimer += Time.deltaTime;

			if (colorTimer >= 1) {
				colorTimer = 0;
			}

			if (colorTimer <= .5) {
				// transition to white
				float colorRatio = colorTimer * 2;
				actionBarImage.color = new Color (1, 1, colorRatio, 1);
			} else {
				// transition to yellow
				float colorRatio = 1 - (colorTimer - 0.5f) * 2;
				actionBarImage.color = new Color (1, 1, colorRatio, 1);
			}
		}
	}

	void TakeAction () {
		// when action timer reaches threshold...
		if (enemyMonster.GetActionTimerValue() >= secondsBetweenActions) {
			// attack!!
			if (!usingSecondSkill) {
				enemyCombatController.UseSkill1();
			} else {
				enemyCombatController.UseSkill2();
			}

			enemyMonster.ResetActionTimer();
			randomChanceOfSecondSkill = Random.value;
		}
	}

	public void ResetActionBar () {
		enemyMonster.ResetActionTimer();
		secondsBetweenActions = enemyMonster.GetSecondsBetweenActions();
		actionBarImage.fillAmount = 0;
		colorTimer = 0;
	}

	public void SetActionEnabled (bool trueOrFalse) {
		actionEnabled = trueOrFalse;
	}
}
