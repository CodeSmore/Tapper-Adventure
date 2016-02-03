using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StatusMenuPopulator : MonoBehaviour {

	private PlayerClass playerClass;

	public Image monsterImage;
	public Text nameText;
	public Text speciesText;
	public Text levelText;
	public Text expThisLevelText;
	public Text hpText;
	public Text epText;
	public Text baseAttackText;
	public Text monsterDescription;

	// Use this for initialization
	void Start () {
		
	}

	void OnEnable () {
		// TODO create name and summary/description fields for monster

		if (!playerClass) {
			playerClass = GameObject.FindObjectOfType<PlayerClass>();
		}

		monsterImage.sprite = playerClass.GetMonsterSprite();
		nameText.text = playerClass.GetName();
		speciesText.text = playerClass.GetSpecies();
		levelText.text = playerClass.GetPlayerLevel().ToString();

		float expPercentage = playerClass.GetCurrentExperiencePoints() / playerClass.GetExperiencePointsForNextLevel() * 100;
		expThisLevelText.text = expPercentage.ToString() + "%";
		hpText.text = playerClass.GetCurrentHealth().ToString() + " / " + playerClass.GetMaxHealth().ToString();
		epText.text = playerClass.GetCurrentEnergy().ToString() + " / " + playerClass.GetMaxEnergy().ToString();
		baseAttackText.text = playerClass.GetAttackStat().ToString();

		monsterDescription.text = playerClass.GetDescription();

	}
}
