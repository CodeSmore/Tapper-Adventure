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
		} else if (interactableName == "Cave Sign (6)") {
			textBoxText.text = "Hmm, the path is blocked by three locks...\nOh well! Guess you'll just have to find the yellow switch for each one!!!\n\nYou can find at least one through each of the two portals.\n\nGood Luck!";
		} else if (interactableName == "Cave Sign (7)") {
			textBoxText.text = "Oh! Oh! The path is blocked by a combination lock! How exciiiiiiiting!\nSo...push the buttons in the correct order. If you mess up, an evil spirit might attack you...\nEither way, you'll have to start aaaaaaall over.\n\nGood Luck!";
		} else if (interactableName == "Cave Sign (8)") {
			textBoxText.text = "Hmm, this one is tricky. It requires a certain...finesse. \nTouch the white walls and you'll have to start all over. :P\n\nGood Luck!";
		} else if (interactableName == "Cave Sign (9)") {
			textBoxText.text = "Wtf is this!? It's not even a puzzle!! Oh well, just go hit that button.\nI dare ya!";
		} else if (interactableName == "Cave Sign (10)") {
			textBoxText.text = "Ooooooooooooooooooooooooooooooooooooooo\nSo many buttons!! :3\nHit the Buttons! Hit ALL the buttons!!\n\n...seriously, this took awhile...";
		} 
	}
}
