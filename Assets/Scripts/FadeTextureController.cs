using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeTextureController : MonoBehaviour {

	public Image image;
	public Texture2D fadeTexture;
	public float fadeSpeed = 0.8f;
	public int drawDepth = -1000;
	
	public float alpha = 1.0f;
	public int fadeDir = -1;

	float timer;
	
	void Update () {
		alpha += fadeDir * fadeSpeed * Time.deltaTime;
		
		alpha = Mathf.Clamp (alpha, 0, 0.6f);
		
		
		image.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, alpha);

		// removes image after transition is complete

		if (alpha == 0) {
			timer += Time.deltaTime;

			if (timer >= 0.1f) {
				image.gameObject.SetActive(false);
			}
		}
	}
	
//	void OnGUI () {
//		alpha += fadeDir * fadeSpeed * Time.deltaTime;
//	
//	 	alpha = Mathf.Clamp (alpha, 0, 0.6f);
//		
//		GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, alpha);
//		GUI.depth = drawDepth;
//		GUI.DrawTexture ( new Rect (0, 0, Screen.width, Screen.height), fadeTexture );
//	}
	
	public float BeginFade (int direction) {
		timer = 0;
		image.gameObject.SetActive(true);
		fadeDir = direction;
		return (fadeSpeed);
	}
}
