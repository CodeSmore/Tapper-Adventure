using UnityEngine;
using System.Collections;

public class PauseMenuController : MonoBehaviour {

	GameObject pauseMenu;
	GameObject statusMenu;
	GameObject skillsMenu;

	// Use this for initialization
	void Start () {
		pauseMenu = GameObject.FindGameObjectWithTag("Pause Menu");
		pauseMenu.SetActive(false);
		statusMenu = GameObject.Find("Status Menu");
		statusMenu.SetActive(false);
		skillsMenu = GameObject.Find("Skills Menu");
		skillsMenu.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void TogglePauseMenu () {
		pauseMenu.SetActive(!pauseMenu.activeSelf);
		ToggleTimeScale();
	}

	public void ToggleStatusMenu () {
		pauseMenu.SetActive(!pauseMenu.activeSelf);
		statusMenu.SetActive(!statusMenu.activeSelf);
	}

	public void ToggleSkillsMenu () {
		statusMenu.SetActive(!statusMenu.activeSelf);
		skillsMenu.SetActive(!skillsMenu.activeSelf);
	}

	void ToggleTimeScale () {
		if (Time.timeScale == 0) {
			Time.timeScale = 1;
		} else {
			Time.timeScale = 0;
		}
	}
}
