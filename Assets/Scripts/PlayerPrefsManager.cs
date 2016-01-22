using UnityEngine;
using System.Collections;

public class PlayerPrefsManager : MonoBehaviour {

	// TODO bools (ints of 0 for false and 1 for true) for overworld events
	// ex. HAS_KEY_TO_CASTLE_KEY

	const string PLAYER_LEVEL_KEY = "player_level";
	const string PLAYER_CURRENT_EXPERIENCE_POINTS_KEY = "player_current_experience_points";
	const string PLAYER_CURRENT_HEALTH_KEY = "player_current_health";
	const string PLAYER_LAST_POSITION_X_KEY = "player_last_position_x";
	const string PLAYER_LAST_POSITION_Y_KEY = "player_last_position_y";


	private PlayerClass playerClass;

	void Awake () {
		playerClass = GameObject.FindObjectOfType<PlayerClass>();
	}

	void Update () {
		if (!playerClass) {
			playerClass = GameObject.FindObjectOfType<PlayerClass>();
		}
	}

	public static void SaveGame (int level, float experiencePoints, float currentHealth, Vector3 lastKnowPos) {
		PlayerPrefs.SetInt(PLAYER_LEVEL_KEY, level);
		PlayerPrefs.SetFloat(PLAYER_CURRENT_EXPERIENCE_POINTS_KEY, experiencePoints);
		PlayerPrefs.SetFloat(PLAYER_CURRENT_HEALTH_KEY, currentHealth);
		PlayerPrefs.SetFloat(PLAYER_LAST_POSITION_X_KEY, lastKnowPos.x);
		PlayerPrefs.SetFloat(PLAYER_LAST_POSITION_Y_KEY, lastKnowPos.y);
	}

	public static int GetPlayerLevel () {
		return PlayerPrefs.GetInt(PLAYER_LEVEL_KEY);
	}

	public static float GetPlayerCurrentExperiencePoints () {
		return PlayerPrefs.GetFloat(PLAYER_CURRENT_EXPERIENCE_POINTS_KEY);
	}

	public static float GetPlayerCurrentHealth () {
		return PlayerPrefs.GetFloat(PLAYER_CURRENT_HEALTH_KEY);
	}

	public static Vector3 GetPlayerLastKnowPosition () {
		Vector3 lastKnownPos = new Vector3 (PlayerPrefs.GetFloat(PLAYER_LAST_POSITION_X_KEY), PlayerPrefs.GetFloat(PLAYER_LAST_POSITION_Y_KEY), 0f);
		return lastKnownPos;
	}
}