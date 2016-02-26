using UnityEngine;
using System.Collections;

public enum Direction {Up, Down, Left, Right, None};
public class LauncherController : MonoBehaviour {
	

	public float launchRate;
	private float fireTimer;
	public float probabilityOfSecondaryFire;
	public float rotationSpeed;
	public float launchSpeed;
	public Direction direction;
	public Transform pointOfFire;
	private GameObject projectileParentGameObject;

	public GameObject[] ammunition;

	// Use this for initialization
	void Start () {
		projectileParentGameObject = GameObject.Find("Active Puzzle Objects");

		// Creates variety for inital launches.
		// This is necessary because launchers are used in groups.
		if (Random.value < .5) {
			FireAmmunition();
		} else {
			fireTimer = launchRate / 2;
		}
	}
	
	// Update is called once per frame
	void Update () {
		fireTimer += Time.deltaTime;

		if (fireTimer >= launchRate) {
			FireAmmunition();
			fireTimer = 0;
		}
	}

	void FireAmmunition () {
		GameObject firedGameObject;

		if (ammunition.Length == 1) {
			firedGameObject = ammunition[0];
		} else {
			if (Random.value <= probabilityOfSecondaryFire) {
				firedGameObject = ammunition[1];
			} else {
				firedGameObject = ammunition[0];
			}
		}

		GameObject projectile = Instantiate (firedGameObject, pointOfFire.position, Quaternion.identity) as GameObject;
		projectile.GetComponent<Projectile>().PlanFlightPath(direction, rotationSpeed, launchSpeed);

		projectile.transform.SetParent(projectileParentGameObject.transform);
	}	
}
