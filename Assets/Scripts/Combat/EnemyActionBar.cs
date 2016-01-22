using UnityEngine;
using UnityEngine.UI; 
using System.Collections;

public class EnemyActionBar : MonoBehaviour {

	private float secondsBetweenActions;
	private float actionBarRatio;
	
	private Image actionBarImage;
	
	private EnemyMonster enemyMonster;
	private EnemyCombatController enemyCombatController;

	// Use this for initialization
	void Start () {
		enemyMonster = GameObject.FindObjectOfType<EnemyMonster>();
		enemyCombatController = GameObject.FindObjectOfType<EnemyCombatController>();

		actionBarImage = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!enemyMonster) {
			enemyMonster  = GameObject.FindObjectOfType<EnemyMonster>();
		} else {
			secondsBetweenActions = enemyMonster.GetSecondsBetweenActions();
			enemyMonster.IncrementActionTimer(Time.deltaTime);
			GetComponent<RectTransform>().anchoredPosition = new Vector2 (transform.position.x , enemyMonster.GetActionBarYPos());
			TakeAction ();
			HandleActionBar();
		}
	}
	
	void HandleActionBar () {
		actionBarRatio = enemyMonster.GetActionTimerValue() / secondsBetweenActions;

		actionBarImage.fillAmount = actionBarRatio;
	}

	void TakeAction () {
		if (enemyMonster.GetActionTimerValue() >= secondsBetweenActions) {
			enemyMonster.ResetActionTimer();
			enemyCombatController.Attack();
		}
	}

	public void ResetActionBar () {
		enemyMonster.ResetActionTimer();
		secondsBetweenActions = enemyMonster.GetSecondsBetweenActions();
		actionBarImage.fillAmount = 0;
	}
}
