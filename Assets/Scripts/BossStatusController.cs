using UnityEngine;
using System;
using System.Collections;

public class BossStatusController : MonoBehaviour {
	// TODO replace bools with PlayerPrefsManager data

	EnemySpawnerController enemySpawnerController;
	PlayerClass playerClass;

	public GameObject bridgeBoss;
	public GameObject caveBoss;
	public GameObject forestBoss;
	public GameObject castleBoss;

	bool isBridgeBossAlive = true;
	bool isCaveBossAlive = true;
	bool isForestBossAlive = true;
	bool isCastleBossAlive = true;

	// TODO remove or make easier to distinguish in code
	public bool skillTestMode = true;

	void Start () {
		enemySpawnerController = gameObject.GetComponent<EnemySpawnerController>();
		playerClass = GameObject.FindObjectOfType<PlayerClass>();
	}

	public bool IsOppressiveForceActive () {

		if (enemySpawnerController.GetSpawnType() == "Cave" || enemySpawnerController.GetSpawnType() == "Tabuz Maze") {
			return isCaveBossAlive;
		} else if (enemySpawnerController.GetSpawnType() == "Enchanted Forest") {
			return isForestBossAlive;
		} else if (enemySpawnerController.GetSpawnType() == "Hero's Castle") {
			return isCastleBossAlive;
		} else {
			return false;
		}
	}

	public void LoadBossStatus (int[] array) {
		isBridgeBossAlive = Convert.ToBoolean(array[0]);
		isCaveBossAlive = Convert.ToBoolean(array[1]);
		isForestBossAlive = Convert.ToBoolean(array[2]);
		isCastleBossAlive = Convert.ToBoolean(array[3]);

		if (!isBridgeBossAlive) {
			bridgeBoss.SetActive(false);
		} else {
			bridgeBoss.SetActive(true);
			playerClass.SetSkill1Unlocked(false);
		}

		if (!isCaveBossAlive) {
			caveBoss.SetActive(false);
		} else {
			caveBoss.SetActive(true);
			playerClass.SetSkill2Unlocked(false);
		}

		if (!isForestBossAlive) {
			forestBoss.SetActive(false);
		} else {
			forestBoss.SetActive(true);
			playerClass.SetSkill3Unlocked(false);
		}

		if (!isCastleBossAlive) {
			castleBoss.SetActive(false);
		} else {
			castleBoss.SetActive(true);
		}

		// used for testing skills during debugging
		if (skillTestMode) {
			bridgeBoss.SetActive(false);
			caveBoss.SetActive(false);

			isBridgeBossAlive = false;
			isCaveBossAlive = false;
		}
	}

	public int[] GetBossStatus () {
		int[] bossStatusArray = new int[4];

		// convert bool values to ints for PlayerPrefs
		bossStatusArray[0] = isBridgeBossAlive ? 1:0;
		bossStatusArray[1] = isCaveBossAlive ? 1:0;
		bossStatusArray[2] = isForestBossAlive ? 1:0;
		bossStatusArray[3] = isCastleBossAlive ? 1:0;

		return bossStatusArray;
	}

	public void UpdateBossStatus() {
		if (!bridgeBoss.activeSelf) {
			isBridgeBossAlive = false;
		} else {
			isBridgeBossAlive = true;
		}

		if (!caveBoss.activeSelf) {
			isCaveBossAlive = false;
		} else {
			isCaveBossAlive = true;
		}

		if (!forestBoss.activeSelf) {
			isForestBossAlive = false;
		} else {
			isForestBossAlive = true;
		}

		if (!castleBoss.activeSelf) {
			isCastleBossAlive = false;
		} else {
			isCastleBossAlive = true;
		}
	}
}
