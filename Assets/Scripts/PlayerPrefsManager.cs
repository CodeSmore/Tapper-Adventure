using UnityEngine;
using System.Collections;

public class PlayerPrefsManager : MonoBehaviour {

	// TODO bools (ints of 0 for false and 1 for true) for world events
	// ex. HAS_KEY_TO_CASTLE_KEY

	const string PLAYER_LEVEL_KEY = "player_level";
	const string PLAYER_CURRENT_EXPERIENCE_POINTS_KEY = "player_current_experience_points";
	const string PLAYER_CURRENT_HEALTH_KEY = "player_current_health";
	const string PLAYER_CURRENT_ENERGY_KEY = "player_current_energy";
	const string PLAYER_CURRENT_COOLDOWN_SKILL_ONE_KEY = "player_current_cooldown_skill_one";
	const string PLAYER_CURRENT_COOLDOWN_SKILL_TWO_KEY = "player_current_cooldown_skill_two";
	const string PLAYER_CURRENT_COOLDOWN_SKILL_THREE_KEY = "player_current_cooldown_skill_three";
	const string PLAYER_LAST_POSITION_X_KEY = "player_last_position_x";
	const string PLAYER_LAST_POSITION_Y_KEY = "player_last_position_y";
	const string LOCATION_SPAWN_TYPE_KEY = "location_spawn_type";

	// Puzzle Objects
	const string CAVE_LOCK_BUTTON_1_KEY = "cave_lock_button_1";
	const string CAVE_LOCK_BUTTON_2_KEY = "cave_lock_button_2";
	const string CAVE_LOCK_BUTTON_3_KEY = "cave_lock_button_3";
	const string ENCH_FOREST_BARRIER_BUTTON_1_KEY = "ench_forest_barrier_button_1";
	const string ENCH_FOREST_BARRIER_BUTTON_2_KEY = "ench_forest_barrier_button_2";
	const string ENCH_FOREST_BARRIER_BUTTON_3_KEY = "ench_forest_barrier_button_3";
	// Bosses
	const string BRIDGE_BOSS_STATUS_KEY = "bridge_boss_status";
	const string CAVE_BOSS_STATUS_KEY = "cave_boss_status";
	const string FOREST_BOSS_STATUS_KEY = "forest_boss_status";
	const string CASTLE_BOSS_STATUS_KEY = "castle_boss_status";

	private PlayerClass playerClass;

	void Awake () {
		playerClass = GameObject.FindObjectOfType<PlayerClass>();
	}

	void Update () {
		if (!playerClass) {
			playerClass = GameObject.FindObjectOfType<PlayerClass>();
		}
	}

	public static void SaveGame (int level, float experiencePoints, float currentHealth, float currentEnergy, float timerSkill1, float timerSkill2, float timerSkill3, Vector3 lastKnowPos, string spawnType, int[] bosses, int[] puzzleObjects) {
		PlayerPrefs.SetInt(PLAYER_LEVEL_KEY, level);
		PlayerPrefs.SetFloat(PLAYER_CURRENT_EXPERIENCE_POINTS_KEY, experiencePoints);
		PlayerPrefs.SetFloat(PLAYER_CURRENT_HEALTH_KEY, currentHealth);
		PlayerPrefs.SetFloat(PLAYER_CURRENT_ENERGY_KEY, currentEnergy);
		PlayerPrefs.SetFloat(PLAYER_CURRENT_COOLDOWN_SKILL_ONE_KEY, timerSkill1);
		PlayerPrefs.SetFloat(PLAYER_CURRENT_COOLDOWN_SKILL_TWO_KEY, timerSkill2);
		PlayerPrefs.SetFloat(PLAYER_CURRENT_COOLDOWN_SKILL_THREE_KEY, timerSkill3);
		PlayerPrefs.SetFloat(PLAYER_LAST_POSITION_X_KEY, lastKnowPos.x);
		PlayerPrefs.SetFloat(PLAYER_LAST_POSITION_Y_KEY, lastKnowPos.y);
		PlayerPrefs.SetString(LOCATION_SPAWN_TYPE_KEY, spawnType);
		PlayerPrefs.SetInt(BRIDGE_BOSS_STATUS_KEY, bosses[0]);
		PlayerPrefs.SetInt(CAVE_BOSS_STATUS_KEY, bosses[1]);
		PlayerPrefs.SetInt(FOREST_BOSS_STATUS_KEY, bosses[2]);
		PlayerPrefs.SetInt(CASTLE_BOSS_STATUS_KEY, bosses[3]);

		// Puzzle Objects
		PlayerPrefs.SetInt(CAVE_LOCK_BUTTON_1_KEY, puzzleObjects[0]);
		PlayerPrefs.SetInt(CAVE_LOCK_BUTTON_2_KEY, puzzleObjects[1]);
		PlayerPrefs.SetInt(CAVE_LOCK_BUTTON_3_KEY, puzzleObjects[2]);
		PlayerPrefs.SetInt(ENCH_FOREST_BARRIER_BUTTON_1_KEY, puzzleObjects[3]);
		PlayerPrefs.SetInt(ENCH_FOREST_BARRIER_BUTTON_2_KEY, puzzleObjects[4]);
		PlayerPrefs.SetInt(ENCH_FOREST_BARRIER_BUTTON_3_KEY, puzzleObjects[5]);
	}

	public static int GetPlayerLevel () {
		return PlayerPrefs.GetInt(PLAYER_LEVEL_KEY, 1);
	}

	public static float GetPlayerCurrentExperiencePoints () {
		return PlayerPrefs.GetFloat(PLAYER_CURRENT_EXPERIENCE_POINTS_KEY, 0);
	}

	public static float GetPlayerCurrentHealth () {
		return PlayerPrefs.GetFloat(PLAYER_CURRENT_HEALTH_KEY, 10);
	}

	public static float GetPlayerCurrentEnergy () {
		return PlayerPrefs.GetFloat(PLAYER_CURRENT_ENERGY_KEY, 0);
	}

	public static float GetPlayerCooldownSkill1 () {
		return PlayerPrefs.GetFloat(PLAYER_CURRENT_COOLDOWN_SKILL_ONE_KEY, 0);
	}

	public static float GetPlayerCooldownSkill2 () {
		return PlayerPrefs.GetFloat(PLAYER_CURRENT_COOLDOWN_SKILL_TWO_KEY, 0);
	}

	public static float GetPlayerCooldownSkill3 () {
		return PlayerPrefs.GetFloat(PLAYER_CURRENT_COOLDOWN_SKILL_THREE_KEY, 0);
	}

	public static Vector3 GetPlayerLastKnowPosition () {
		Vector3 lastKnownPos = new Vector3 (PlayerPrefs.GetFloat(PLAYER_LAST_POSITION_X_KEY, 0), PlayerPrefs.GetFloat(PLAYER_LAST_POSITION_Y_KEY), 0);
		return lastKnownPos;
	}

	public static string GetLocationSpawnType () {
		return PlayerPrefs.GetString(LOCATION_SPAWN_TYPE_KEY, "Grassland");
	}

	public static int[] GetBossStatus () {
		// 1 means it's alive, 0 means it'd dead
		int[] bossStatusArray = new int[4];
		bossStatusArray[0] = PlayerPrefs.GetInt(BRIDGE_BOSS_STATUS_KEY, 1);
		bossStatusArray[1] = PlayerPrefs.GetInt(CAVE_BOSS_STATUS_KEY, 1);
		bossStatusArray[2] = PlayerPrefs.GetInt(FOREST_BOSS_STATUS_KEY, 1);
		bossStatusArray[3] = PlayerPrefs.GetInt(CASTLE_BOSS_STATUS_KEY, 1);

		return bossStatusArray;
	}

	public static int[] GetCaveLockButtonsStatus () {
		int[] caveLockButtonsArray = new int[3];

		caveLockButtonsArray[0] = PlayerPrefs.GetInt(CAVE_LOCK_BUTTON_1_KEY, 0);
		caveLockButtonsArray[1] = PlayerPrefs.GetInt(CAVE_LOCK_BUTTON_2_KEY, 0);
		caveLockButtonsArray[2] = PlayerPrefs.GetInt(CAVE_LOCK_BUTTON_3_KEY, 0);

		Debug.Log(caveLockButtonsArray[0]);

		return caveLockButtonsArray;
	}

	public static int[] GetEnchantedForestBarrierButtonsStatus () {
		int[] enchForestLocksArray = new int[3];

		enchForestLocksArray[0] = PlayerPrefs.GetInt(ENCH_FOREST_BARRIER_BUTTON_1_KEY, 0);
		enchForestLocksArray[1] = PlayerPrefs.GetInt(ENCH_FOREST_BARRIER_BUTTON_2_KEY, 0);
		enchForestLocksArray[2] = PlayerPrefs.GetInt(ENCH_FOREST_BARRIER_BUTTON_3_KEY, 0);

		return enchForestLocksArray;
	}
}