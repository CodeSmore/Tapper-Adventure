using UnityEngine;
using System.Collections;

public class BossStatusController : MonoBehaviour {
	// TODO replace bools with PlayerPrefsManager data

	bool isCaveBossAlive = true;

	public bool IsOppressiveForceActive () {
		if (gameObject.GetComponent<EnemySpawnerController>().GetSpawnType() == "Cave Interior") {
			return isCaveBossAlive;
		} else {
			return false;
		}
	}
}
