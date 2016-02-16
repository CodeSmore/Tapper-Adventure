using UnityEngine;
using System.Collections;

public class Doorway : MonoBehaviour {

	public GameObject destination;

	public Vector3 GetDestinationVector () {
		return destination.transform.position;
	}

	public string GetDestinationName () {
		return destination.name;
	}
}
