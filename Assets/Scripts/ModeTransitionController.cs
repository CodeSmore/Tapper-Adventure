using UnityEngine;
using System.Collections;

public class ModeTransitionController : MonoBehaviour { // Controls the transition between overworld, battle, and menu

	GameObject menu;

	// Use this for initialization
	void Awake () {
		menu = GameObject.Find("Pause Menu");
	}

	void Start () {
		menu.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void TransitionPauseMenu () {
		if (menu.activeSelf == true) {
			menu.SetActive(false);
		} else if (menu.activeSelf == false) {
			menu.SetActive(true);
		}
	}
}
