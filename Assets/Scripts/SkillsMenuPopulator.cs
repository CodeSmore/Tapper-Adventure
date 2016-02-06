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

		if (Time.realtimeSinceStartup > 2) {
			if (!playerClass) {
				playerClass = GameObject.FindObjectOfType<PlayerClass>();
			}

			if (skill1 == null) {
				skill1 = playerClass.GetSkill1();
				skill2 = playerClass.GetSkill2();
				skill3 = playerClass.GetSkill3();
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

				image1.sprite = skill1.GetSprite();
				nameText1.text = skill1.GetName();
				damageText1.text = skill1.GetBaseDamage().ToString();
				costText1.text = skill1.GetEnergyCost().ToString();
				cooldownText1.text = skill1.GetCooldown().ToString();
				statusEffectText1.text = skill1.GetStatusEffect().ToString();
				chanceText1.text = (skill1.GetChanceOfEffect() * 100).ToString() + "%";
			} else {
				skillOneStats.SetActive(false);
			}


			if (playerClass.SkillTwoUnlocked()) {
				skillTwoStats.SetActive(true);

				image2.sprite = skill2.GetSprite();
				nameText2.text = skill2.GetName();
				damageText2.text = skill2.GetBaseDamage().ToString();
				costText2.text = skill2.GetEnergyCost().ToString();
				cooldownText2.text = skill2.GetCooldown().ToString();
				statusEffectText2.text = skill2.GetStatusEffect().ToString();
				chanceText2.text = (skill2.GetChanceOfEffect() * 100).ToString() + "%";
			} else {
				skillTwoStats.SetActive(false);
			}


			if (playerClass.SkillThreeUnlocked()) {
				skillThreeStats.SetActive(true);

				image3.sprite = skill3.GetSprite();
				nameText3.text = skill3.GetName();
				damageText3.text = skill3.GetBaseDamage().ToString();
				costText3.text = skill3.GetEnergyCost().ToString();
				cooldownText3.text = skill3.GetCooldown().ToString();
				statusEffectText3.text = skill3.GetStatusEffect().ToString();
				chanceText3.text = (skill3.GetChanceOfEffect() * 100).ToString() + "%";
			} else {
				skillThreeStats.SetActive(false);
			}
		}
	}
	
}
