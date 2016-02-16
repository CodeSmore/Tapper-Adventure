using UnityEngine;
using System.Collections;

public class FlickeringGuardController : MonoBehaviour {

	public float secondsLightIsOn;
	public float secondsLightIsOff;

	private float flickerTimer = 0;

	private GameObject searchLight;

	// Use this for initialization
	void Start () {
		foreach (Transform childTransform in transform) {
			if (childTransform.gameObject.name == "SearchLight") {
				searchLight = childTransform.gameObject;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		flickerTimer += Time.deltaTime;

		if (flickerTimer < secondsLightIsOn) {
			searchLight.SetActive(true);
		} else if (flickerTimer < secondsLightIsOn + secondsLightIsOff) {
			searchLight.SetActive(false);
		} else {
			flickerTimer = 0;
		}
	}
}
