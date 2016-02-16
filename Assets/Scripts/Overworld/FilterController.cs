using UnityEngine;
using System.Collections;

public class FilterController : MonoBehaviour {

	public InGameButton trigger;

	private PlayerMovement playerMovement;
	private Color filterColor;
	private SpriteRenderer filterSpriteRenderer;

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
			if (playerMovement.PlayerIsMoving()) {
				filterColor = new Color( filterColor.r, filterColor.g, filterColor.b, filterColor.a + Time.deltaTime * colorChangeRate);
			} else {
				filterColor = new Color( filterColor.r, filterColor.g, filterColor.b, Mathf.Clamp01(filterColor.a - Time.deltaTime * colorChangeRate));
			}
		}

		filterSpriteRenderer.color = filterColor;
	}
}
