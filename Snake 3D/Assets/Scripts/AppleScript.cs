using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleScript : MonoBehaviour
{
	public GameObject Apple;

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
			Destroy (gameObject);
			randomPosition ();
		}
	}

	void randomPosition() {
		GameObject newApple = GameObject.Instantiate (Apple);

		float x = Random.Range(-5.5f, 15.5f);
		float z = Random.Range (-1.0f, 9.5f);

		newApple.transform.position = new Vector3 (x, 4.38f, z);
	}
}