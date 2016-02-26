using UnityEngine;
using System.Collections;

public class FilterController : MonoBehaviour {

	public InGameButton trigger;

	private PlayerMovement playerMovement;
	private Color filterColor;
	private SpriteRenderer filterSpriteRenderer;
	private float maxFilterAlpha = 0.4f, minFilterAlpha = 0f;

	public float colorChangeRate;

	// Use this for initialization
	void Start () {
		playerMovement = GameObject.FindObjectOfType<PlayerMovement>();

		filterSpriteRenderer = GetComponent<SpriteRenderer>();
		filterColor = filterSpriteRenderer.color;
	}
	
	// Update is called once per frame
	void Update () {
		if (trigger.ButtonIsPressed()) {
			if (gameObject.name == "Alarm Filter") {
				// if color reaches max/min, multiply direction by -1
				filterColor = new Color( filterColor.r, filterColor.g, filterColor.b, Mathf.Clamp(filterColor.a + Time.deltaTime * colorChangeRate, minFilterAlpha, maxFilterAlpha));

				if (filterColor.a >= maxFilterAlpha || filterColor.a <= minFilterAlpha) {
					colorChangeRate *= -1;
				}
			} else {
				if (playerMovement.PlayerIsMoving()) {
					filterColor = new Color( filterColor.r, filterColor.g, filterColor.b, filterColor.a + Time.deltaTime * colorChangeRate);
				} else {
					filterColor = new Color( filterColor.r, filterColor.g, filterColor.b, Mathf.Clamp01(filterColor.a - Time.deltaTime * colorChangeRate));
				}
			}
	
			filterSpriteRenderer.color = filterColor;
		}
	}
}
