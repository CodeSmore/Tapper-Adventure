using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseMenuController : MonoBehaviour {

	GameObject pauseMenu;
	GameObject statusMenu;
	GameObject skillsMenu;

	Button saveButton;
	Button loadButton;

	GameObject battle;
	GameObject world;

	// Use this for initialization
	void Start () {
		saveButton = GameObject.Find("Save Button").GetComponent<Button>();
		loadButton = GameObject.Find("Load Button").GetComponent<Button>();

		pauseMenu = GameObject.FindGameObjectWithTag("Pause Menu");
		pauseMenu.SetActive(false);
		statusMenu = GameObject.Find("Status Menu");
		statusMenu.SetActive(false);
		skillsMenu = GameObject.Find("Skills Menu");
		skillsMenu.SetActive(false);

		battle = GameObject.Find("Battle");
		world = GameObject.Find("World");
	}

	public void TogglePauseMenu () {
		pauseMenu.SetActive(!pauseMenu.activeSelf);
		ToggleTimeScale();

		if (world.activeSelf) {
			saveButton.interactable = true;
			loadButton.interactable = true;
		} else if (battle.activeSelf) {
			saveButton.interactable = false;
			loadButton.interactable = false;
		}
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
