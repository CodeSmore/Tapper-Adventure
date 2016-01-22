using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerEnergyBar : MonoBehaviour {

	private float currentEnergy;
	private float maxEnergy;
	private float energyRatio;
	
	private Image energyBarImage;
	private Text playerEnergyText;
	
	private PlayerClass playerClass;

	// Use this for initialization
	void Start () {
		playerClass = GameObject.FindObjectOfType<PlayerClass>();
		maxEnergy = playerClass.GetMaxEnergy();

		energyBarImage = GetComponent<Image>();
		playerEnergyText = GetComponentInChildren<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		currentEnergy = playerClass.GetCurrentEnergy();
		maxEnergy = playerClass.GetMaxEnergy();

		
		HandleEnergyBar ();
	}
	
	void HandleEnergyBar () {
		energyRatio = currentEnergy / maxEnergy;
		playerEnergyText.text = currentEnergy + " / " + maxEnergy;

		energyBarImage.fillAmount = energyRatio;
	}
}
