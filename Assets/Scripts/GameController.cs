using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	private GameObject overworld;
	private GameObject battle;

	private PlayerMovement playerMovement;

	public float distanceTilSpawnThreshold;
	private float probabilityOfMonsterAttackPerFrame = 0.01f;

	// Use this for initialization
	void Start () {
		overworld = GameObject.Find("Overworld");
		battle = GameObject.Find("Battle");
		playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
		battle.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (playerMovement.GetDistanceTraveled() >= distanceTilSpawnThreshold && Random.value < probabilityOfMonsterAttackPerFrame) {
			playerMovement.ResetDistanceTraveled();
			TransitionToBattle();
		}
	}

	public void TransitionToOverworld () {
		// disable battle, enable overworld
		battle.SetActive(false);
		overworld.SetActive(true);
	}

	public void TransitionToBattle () {
		// TODO spawn enemy

		// disable overworld, enable battle
		overworld.SetActive(false);
		battle.SetActive(true);
	}

		
	
}
