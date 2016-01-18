using UnityEngine;
using System.Collections;

public class SoundController : MonoBehaviour {

	// Public AudioClips assigned in the Inspector
	public AudioClip playerFire;
	public AudioClip enemyFire;
	public AudioClip enemyDies;
	public AudioClip laserangFire;
	public AudioClip enemyDamage;
	public AudioClip playerDamage;
	public AudioClip playerShocked;
	
	private AudioSource audioSource;

	void Start () {
		audioSource = gameObject.GetComponent<AudioSource>();
	}
	
	public void PlayerFireSound () {
		AudioSource.PlayClipAtPoint (playerFire, transform.position);
		
		ChangeAudioSourcesTo2D ();
	}
	
	public void EnemyFireSound () {
		AudioSource.PlayClipAtPoint (enemyFire, transform.position);
		
		ChangeAudioSourcesTo2D ();
	}
	
	public void PlayerShockSound () {
		AudioSource.PlayClipAtPoint (playerShocked, transform.position, 0.3f);
		
		ChangeAudioSourcesTo2D ();
	}
	
	public void EnemyDeathSound () {
		AudioSource.PlayClipAtPoint (enemyDies, transform.position);
		
		ChangeAudioSourcesTo2D ();
	}
	
	public void PlayerLaserangFireSound () {
		AudioSource.PlayClipAtPoint (laserangFire, transform.position);
		
		ChangeAudioSourcesTo2D ();
	}
	
	public void EnemyDamageSound () {
		audioSource.clip = enemyDamage;
		audioSource.Play ();
	}
	
	public void PlayerDamageSound () {
		AudioSource.PlayClipAtPoint (playerDamage, transform.position);
		
		ChangeAudioSourcesTo2D ();
	}
	
	// Makes all AudioSources in scene produce 2D, as opposed to 3D.
	// Y'know, so the player can hear it...
	private void ChangeAudioSourcesTo2D () {
		AudioSource[] audioSourceArray;
		
		audioSourceArray = GameObject.FindObjectsOfType<AudioSource>();
		
		foreach (AudioSource source in audioSourceArray) {
			source.spatialBlend = 0;
		}
	}
		
}
