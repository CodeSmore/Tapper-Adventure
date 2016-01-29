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

	public void UpdateText (string textName) {
		if (textName == "Sample Talker") {
			textBoxText.text = "I AM PAPERCUT!!!!!!\n\nNow that you understand, go away!\n...or I'll kill you!!!\n...maybe...";
		} else if (textName == "Sample Talker 2") {
			textBoxText.text = "I AM ALSO PAPERCUT!!!!!!!\n\nI'll give you a papercut if you don't go away!!!\n...definitely...";
		} else if (textName == "Sample Talker 3") {
			textBoxText.text = "I AM JIM!!!!!!!!\n\nI just wish people would remember my name...";
		}
	}
}
