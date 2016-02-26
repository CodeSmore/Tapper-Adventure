using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour {

	BossStatusController bossStatusController;
	// Use this for initialization
	void Start () {
		bossStatusController = GameObject.FindObjectOfType<BossStatusController>();
	}
	
	void OnDisable () {
		bossStatusController.UpdateBossStatus();
		Debug.Log("Destroyed");
	}
}
