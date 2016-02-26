using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InteractionTextController : MonoBehaviour {
	private Text textBoxText;
	private PlayerInteractableController playerInteractableController;
	
	// Use this for initialization
	void Start () {
		textBoxText = GameObject.Find("Text Box").GetComponentInChildren<Text>();
		playerInteractableController = GameObject.FindObjectOfType<PlayerInteractableController>();
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

		// Treasury
		else if (interactableName == "Treasury Sign (1)") {
			textBoxText.text = "ERROR 404: NOT FOUND\n\nJust kidding! This place is currently under construction. Come back later!";
		}

		// Hero's Castle
		else if (interactableName == "Hero's Castle Sign (1)") {
			textBoxText.text = "Welcome to the Hero's Castle!";
		} else if (interactableName == "Hero's Castle Sign (2)") {
			textBoxText.text = "And welcome to the entrance room. It seems they've prepared a special lock on the portal just for you!\n\nVenture to each of the six areas to find the combination to activate this portal. " +
								"You can change the number in each block by pressing 'Interact'.";
		} else if (interactableName == "Hero's Castle Sign (3)") {
			textBoxText.text = "Have you gotten used to the movement controls. I hope so, cause the guards set up some indoor cannons at the end of each hallway ahead to blow you back!";
		} else if (interactableName == "Hero's Castle Sign (4)") {
			textBoxText.text = "Oh, look; a doorway that doesn't take 5 minutes to take you to the next room! Progress my friend.\n\nSo, pick the correct door or else...you'll be wrong? Hmm, maybe they should spend less time on doors and more time on devising better puzzles...";
		} else if (interactableName == "Hero's Castle Sign (5)") {
			textBoxText.text = "You know the drill; press them in the correct order or prepare to be punished!!!";
		} else if (interactableName == "Hero's Castle Sign (6)") {
			textBoxText.text = "Hey you...you, buddy. So, you're in luck! It turns out one of the guards hid one of the combination digits under a cobblestone in this very room! \nWhere is it? How should I know?\nHmm, but he did mention it was 25 paces from the tile I'm standing.";
		} else if (interactableName == "Hero's Castle Sign (7)") {
			textBoxText.text = "Say my name. SAY MY NAME!!\n\nSorry, I meant STEP ON MY NAME!!!!";
		} else if (interactableName == "Hero's Castle Sign (8)") {
			textBoxText.text = "I don't want to seem crude, but this floor plan seems...a bit...perverse. \n\nBut something is definitly wrong here. How would you get out of a place like this?";
		} else if (interactableName == "Hero's Castle Sign (9)") {
			textBoxText.text = "Hey, you made it! So, this is it, The End!\n\nHit the quit button in the menu to find out more about Sketchy Games! Or to, quit and stuff.\n\nSee ya!";
		} 

		// Combination Room (4) Puzzle
		else if (interactableName == "Area Where Nothing Is Found") {
			// used for search puzzle where player searches floor for code. 
			// It avoids issues with flashing 'Interact' button, seeing false OnEnter/ExitTrigger2Ds, and interacting with the wrong object
			// Note: also allows me to put the colliders on top of each other and make it one gameObject
			if (playerInteractableController.GetNumberOfInteractableCollisions() == 1) { 
				textBoxText.text = "You see nothing of interest.";
			} else {
				textBoxText.text = "Under a loose cobblestone, you find a folded note with the number '" + GameObject.FindObjectOfType<CombinationController>().answers[3].ToString() + "' scribbled in it's center.";
			}
		} 

		// ERROR
		else {
			textBoxText.text = "ERROR: TEXT NOT AVALIABLE FOR INTERACTABLE";
		}
	}
}
