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
		if (interactableName == "Grassland Sign (1)") {
			textBoxText.text = "Hi, I'm a talking sign. I just print out my words because the game dev 'forgot' to give me vocal cords.\n\n...yeah, right. I'll 'forget' to warn the player about a trap later...";
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

		// Someplace
		else if (interactableName == "Someplace Sign (1)") {
			textBoxText.text = "Oh, h-hey. I didn't expect you'd make it this far...\n\nWelcome to Someplace!! or whatever...\n\nC'mon, cut me some slack! That cave was supposed to be a death trap.";
		}
		// Forest
		else if (interactableName == "Forest Sign (1)") {
			textBoxText.text = "Welcome to the Forest! \n\nBe wary. The enchanted forest within has begun to bleed into the regular forest. It's almost as if the forest is trying to keep everyone out.\n" + 
								"Btw, you can kill trees right? Just 'Interact' with them.";
		} else if (interactableName == "Forest Sign (2)") {
			textBoxText.text = "Yay! You made it to the Maze. Of. JUSTICE.\n\n...seriously? *fingers through script*\nOk, let's just call it the Lost Woods. \nIf you make a wrong turn, you have to start AAAAAALL over. ^_^";
		} else if (interactableName == "Forest Sign (3)") {
			textBoxText.text = "How did you get here? No, really, this part is blocked off.\n\nWho ARE you?!";
		} 

		// Enchanted Forest
		else if (interactableName == "Enchanted Forest Sign (1)") {
			textBoxText.text = "Hey, you made it to the Enchanted Forest!\n\nThis used to be a cool spot for bonfires and illicit activities, but an evil presence just up and killed everyone.\n\nSoooo, have fun!";
		} else if (interactableName == "Enchanted Forest Sign (2)") {
			textBoxText.text = "This room may seem bright now, but that'll change once you hit the pressure plate. After that, only by sitting still will you be able to find the right path.";
		} else if (interactableName == "Enchanted Forest Sign (3)") {
			textBoxText.text = "Pst, hey kid, wanna buy so- Oh, it's you again.\n\nSHHHH, keep it down. The Enchanted Forest's Guardian sent out her goons to search for intruders. Avoid their lights or they'll " +
								"kick you out.";
		} else if (interactableName == "Enchanted Forest Sign (4)") {
			textBoxText.text = "How's you battle prowess? Hopefully fantasmagorical!\n\nThis portal is sealed by three henchmen of the Overseer of the Forest. You'll have to defeat them before you reach their boss.";
		} else if (interactableName == "Enchanted Forest Sign (5)") {
			textBoxText.text = "Uh, ya might wanna hurry. \nI hear the guardian of this room has a rabid pet that'll chase ya down. I'm just sayin.";
		}
	}
}
