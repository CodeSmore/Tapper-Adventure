using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SkillsMenuPopulator : MonoBehaviour {

	private PlayerClass playerClass;
	private Skill skill1;
	private Skill skill2;
	private Skill skill3;
	private GameObject skillOneStats;
	private GameObject skillTwoStats;
	private GameObject skillThreeStats;

	[Header("Skill 1", order = 0)]
	[Header("--------", order = 1)]
	public Image image1;
	public Text nameText1;
	public Text damageText1;
	public Text costText1;
	public Text cooldownText1;
	public Text statusEffectText1;
	public Text chanceText1;

	[Header("Skill 2", order = 0)]
	[Header("--------", order = 1)]
	public Image image2;
	public Text nameText2;
	public Text damageText2;
	public Text costText2;
	public Text cooldownText2;
	public Text statusEffectText2;
	public Text chanceText2;

	[Header("Skill 3", order = 0)]
	[Header("--------", order = 1)]
	public Image image3;
	public Text nameText3;
	public Text damageText3;
	public Text costText3;
	public Text cooldownText3;
	public Text statusEffectText3;
	public Text chanceText3;



	void OnEnable () {
		// do stuff!
		if (!playerClass) {
			playerClass = GameObject.FindObjectOfType<PlayerClass>();
			skill1 = playerClass.skill1;
		}
		if (!skillOneStats) {
			skillOneStats = GameObject.Find("Skill 1 Stats");
		}
		if (!skillTwoStats) {
			skillTwoStats = GameObject.Find("Skill 2 Stats");
		}
		if (!skillThreeStats) {
			skillThreeStats = GameObject.Find("Skill 3 Stats");
		}



		if (playerClass.SkillOneUnlocked()) {
			skillOneStats.SetActive(true);


		} else {
			skillOneStats.SetActive(false);
		}

		if (playerClass.SkillTwoUnlocked()) {
			skillTwoStats.SetActive(true);
		} else {
			skillTwoStats.SetActive(false);
		}

		if (playerClass.SkillThreeUnlocked()) {
			skillThreeStats.SetActive(true);
		} else {
			skillThreeStats.SetActive(false);
		}

	}
}
