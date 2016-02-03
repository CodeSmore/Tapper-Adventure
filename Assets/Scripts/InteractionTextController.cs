using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InteractionTextController : MonoBehaviour {
	private Text textBoxText;
	
	// Use this for initialization
	void Start () {
		textBoxText = GameObject.Find("Text Box").GetComponentInChildren<Text>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void UpdateText (string interactableName) {
		// GrassLand
		if (interactableName == "Sample Talker") {
			textBoxText.text = "I AM PAPERCUT!!!!!!\n\nNow that you understand, go away!\n...or I'll kill you!!!\n...maybe...";
		} 

		// Forest
		else if (interactableName == "Sample Talker 2") {
			textBoxText.text = "I AM ALSO PAPERCUT!!!!!!!\n\nI'll give you a papercut if you don't go away!!!\n...definitely...";
		} else if (interactableName == "Sample Talker 3") {
			textBoxText.text = "I AM JIM!!!!!!!!\n\nI just wish people would remember my name...";
		} 

		// Cave
		else if (interactableName == "Cave Sign (1)") {
			textBoxText.text = "An overpowering presence emanates from deep within. Whilst this aura remains in this cave, your movements will be slowed and monsters will be more likely to attack.";
		} else if (interactableName == "Cave Sign (2)") {
			textBoxText.text = "Dead ends make this cave seem twice as big! ^_^";
		} else if (interactableName == "Cave Sign (3)") {
			textBoxText.text = "Neither choice is wrong, but one is less right.";
		} else if (interactableName == "Cave Sign (4)") {
			textBoxText.text = "Dead ends: Double the time, half the fun! :D";
		} else if (interactableName == "Cave Sign (5)") {
			textBoxText.text = "Buttons, how fun! \nTo activate, just step on them.\n\nBy the way, did find the other one?";
		} 
	}
}
