using UnityEngine;
using System.Collections;

public class QuitButtonTimerController : MonoBehaviour {

	public GameObject closeAppButton;
	public float targetAppearanceTime;

	private float buttonAppearanceTimer;
	private bool buttonHasAppeared = false;


	// Use this for initialization
	void Start () {
		closeAppButton.SetActive(false);
		Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update () {
		if (!buttonHasAppeared) {
			buttonAppearanceTimer += Time.deltaTime;

			if (buttonAppearanceTimer > targetAppearanceTime) {
				closeAppButton.SetActive(true);
				buttonHasAppeared = true;
			}
		}

	}
}
