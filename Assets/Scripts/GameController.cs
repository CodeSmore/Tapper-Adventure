using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	private GameObject overworld;
	private GameObject battle;
	// Use this for initialization
	void Start () {
		overworld = GameObject.Find("Overworld");
		battle = GameObject.Find("Battle");

		battle.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void TransitionToOverworld () {
		// disable battle, enable overworld
		battle.SetActive(false);
		overworld.SetActive(true);
	}

	public void TransitionToBattle () {
		// disable overworld, enable battle
		overworld.SetActive(false);
		battle.SetActive(true);
	}
}
