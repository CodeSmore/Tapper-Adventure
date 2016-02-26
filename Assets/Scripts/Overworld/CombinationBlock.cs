using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CombinationBlock : MonoBehaviour {

	private int currentValue = 0;
	private Text blockText;

	// Use this for initialization
	void Start () {
		blockText = GetComponentInChildren<Text>();
		UpdateBlockText();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void IncrementBlock () {
		if (currentValue == 9) {
			currentValue = 0;
		} else {
			currentValue++;
		}

		UpdateBlockText();
	}

	public void UpdateBlockText () {
		blockText.text = currentValue.ToString();
	}

	public int GetCurrentValue () {
		return currentValue;
	}
}
