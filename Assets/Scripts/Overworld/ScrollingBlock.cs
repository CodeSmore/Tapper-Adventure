using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScrollingBlock : MonoBehaviour {

	private int currentValue = 0;
	private Text blockText;

	// Use this for initialization
	void Start () {
		blockText = GetComponentInChildren<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		ScrollNumber(); 
	}

	void ScrollNumber () {
		if (currentValue == 9) {
			currentValue = 0;
		} else {
			currentValue++;
		}

		blockText.text = currentValue.ToString();
	}
}
