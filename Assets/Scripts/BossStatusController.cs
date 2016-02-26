using UnityEngine;
using System;
using System.Collections;

public class BossStatusController : MonoBehaviour {
	// TODO replace bools with PlayerPrefsManager data

	EnemySpawnerController enemySpawnerController;

	public GameObject bridgeBoss;
	public GameObject caveBoss;
	public GameObject forestBoss;
	public GameObject castleBoss;

	bool isBridgeBossAlive = true;
	bool isCaveBossAlive = true;
	bool isForestBossAlive = true;
	bool isCastleBossAlive = true;

	void Start () {
		enemySpawnerController = gameObject.GetComponent<EnemySpawnerController>();
		UpdateBossStatus();
	}

	public bool IsOppressiveForceActive () {
		UpdateBossStatus();

		if (enemySpawnerController.GetSpawnType() == "Cave") {
			return isCaveBossAlive;
		} else if (enemySpawnerController.GetSpawnType() == "Enchanted Forest") {
			return isForestBossAlive;
		} else if (enemySpawnerController.GetSpawnType() == "Hero's Castle") {
			return isCastleBossAlive;
		} else {
			return false;
		}
	}

	public void UpdateBossStatus () {
		if (!bridgeBoss) {
			isBridgeBossAlive = false;
		}

		if (!forestBoss) {
			isForestBossAlive = false;
		}

		if (!caveBoss) {
			isCaveBossAlive = false;
		}

		if (!castleBoss) {
			isCastleBossAlive = false;
		}
	}

	public void LoadBossStatus (int[] array) {
		isBridgeBossAlive = Convert.ToBoolean(array[0]);
		isCaveBossAlive = Convert.ToBoolean(array[1]);
		isForestBossAlive = Convert.ToBoolean(array[2]);
		isCastleBossAlive = Convert.ToBoolean(array[3]);

		if (!isBridgeBossAlive) {
			bridgeBoss.SetActive(false);
		}

		if (!isCaveBossAlive) {
			caveBoss.SetActive(false);
		}

		if (!isForestBossAlive) {
			forestBoss.SetActive(false);
		}

		if (!isCastleBossAlive) {
			castleBoss.SetActive(false);
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
}
