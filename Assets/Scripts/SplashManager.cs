using UnityEngine;
using System.Collections;

public class SplashManager : MonoBehaviour {

	private float timer;
	private LevelManager levelManager;

	// Use this for initialization
	void Start () {
		timer = 0;
		levelManager = FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		
		if (timer >= 5 || timer >= 1 && Input.anyKeyDown) {
			levelManager.LoadNextLevel();
		}
	}
}
