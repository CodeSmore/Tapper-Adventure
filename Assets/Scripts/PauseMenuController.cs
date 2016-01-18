using UnityEngine;
using System.Collections;

public class PauseMenuController : MonoBehaviour {

	GameObject pauseMenu;

	// Use this for initialization
	void Start () {
		pauseMenu = GameObject.FindGameObjectWithTag("Pause Menu");
		pauseMenu.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void TogglePauseMenu () {
		pauseMenu.SetActive(!pauseMenu.activeSelf);

		Time.timeScale = 0;
		if (!pauseMenu.activeSelf) {
			Time.timeScale = 1;
		} else {
			Time.timeScale = 0;
		}
	}
}
