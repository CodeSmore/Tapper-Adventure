using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
	
	// Clips used in game. instantiated from unity inspector
	public AudioClip startClip;
	public AudioClip gameClip;
	public AudioClip bossClip;
	public AudioClip endClip;
	
	// AudioSource of 'this'. Used to manipulate AudioSource in script.
	private AudioSource music;
	public bool paused = false;
	
	void Start () {
//		// Checks if a MusicPlayer was assigned to 'instance' AND if 
//		// this MusicPlayer assigned is the current 'this'.
//		// If so, destroy 'this' so there's only one and the original continues  
//		// w/o causing a skip from switching MusicPlayers
//		if (instance != null && instance != this) {
//			Destroy (gameObject);
//			print ("Duplicate music player self-destructing!");
//		} else {
		
		// Else...assign 'instance' to 'this' so the new MusicPlayer created once the 
		// 'Start Menu' scene is reloaded will be destroyed.

			
		// Done so 'this' will be carried over to next scene.
		// Otherwise, music doesn't play after 'Start Menu'.
			GameObject.DontDestroyOnLoad(gameObject);
			
			music = GetComponent<AudioSource>();
			
		// Extra: sounds attached to script are called "clip", hence music.clip
		// Assigns the first clip to be used, makes sure it'll loop, then plays it.
			music.clip = startClip;
			music.loop = true;
			music.Play ();
		// }
	}
	
	// Function/method/WHATEVER!!1111!1!!...that executes when a NEW scene loads.
	// (doesn't execute on intial scene loaded)
	void OnLevelWasLoaded (int level) {
		Debug.Log ("OnLevelWasLoaded works for level: " + level);
		
		// Verifies that 'music' exists. 
		// W/O it, a NullReferenceException error occurs when the 'Start Menu' 
		// attempts to load after the first playthrough.
		// OnLevelWasLoaded() appears to load after Awake(), but before Start()
		// Extra: Advised not to use this when order is of utmost importance. 
		// Here, it is not.
		if (paused == false) {
			if (music.clip != startClip && level == 1) {
				music.Stop ();
				music.clip = startClip;
				music.loop = true;
				music.Play ();
			}
			
			if (music && level > 3) {
				music.Stop ();
				
				// Changes 
				
				if (level == 4) {
					music.clip = gameClip;
				} else {
					music.clip = endClip;
				}
				
				music.loop = true;
				music.Play ();
			}
		} 
		
	}
	
	public void ToggleMusic () {
		if (paused == false) {
			music.Stop ();
			paused = true;
		} else {
			music.Play ();
			paused = false;
		}
		
	}
	
	public void PlayBossMusic () {
		if (paused == false) {
			music.Stop ();
			
			music.clip = bossClip;
			music.loop = true;
			music.Play ();
		}
	}
}
