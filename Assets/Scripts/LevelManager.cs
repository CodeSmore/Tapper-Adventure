using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour {

	// Loads a new scene based on the entered name.
	public void LoadLevel(string name){
		SceneManager.LoadScene (name);
	}
	
	public void LoadLevel (int level) {
		SceneManager.LoadScene (level);
	}
	
	public void LoadNextLevel () {
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
	}

	// Quits the game. Only works in finished builds.
	public void QuitRequest(){
		Debug.Log ("Quit requested");
		Application.Quit ();
	}
}
