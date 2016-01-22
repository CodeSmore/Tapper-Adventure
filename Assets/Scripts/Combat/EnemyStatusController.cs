using UnityEngine;
using System.Collections;

public class EnemyStatusController : MonoBehaviour {

	private EnemyMonster enemyMonster;

	// Use this for initialization
	void Start () {
		enemyMonster = GameObject.FindObjectOfType<EnemyMonster>();
	}
	
	// Update is called once per frame
	void Update () {

		if (!enemyMonster) {
			enemyMonster = GameObject.FindObjectOfType<EnemyMonster>();
		}

		GetComponent<RectTransform>().anchoredPosition = new Vector2 (transform.position.x , enemyMonster.GetHealthBarYPos());

	}
}
