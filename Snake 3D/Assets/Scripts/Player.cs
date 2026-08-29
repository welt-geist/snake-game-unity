using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public GameObject preBody;
	private GameObject[] bodies;
	protected Transform m_transform;
	public Transform explosionFX;
	private float timer = 0f;
	private Vector3 forward = Vector3.forward;

	public int count;
	public bool isDead = false;

	private AudioSource eatSound;

	void Start () {
		m_transform = this.transform;
		bodies = new GameObject[100];
		bodies [0] = gameObject;
		bodies [1] = preBody;
		count = 1;

		eatSound = gameObject.GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void Update () {
		forward = currentForward();
		timer += Time.deltaTime;

		if (timer > 0.25f) {
			followHead ();
			transform.position += forward;
			timer = 0f;
		}
		if(Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Tab))
		{
			if(Time.timeScale == 1)
			{
				Time.timeScale = 0;
			} else if (Time.timeScale == 0){
				Time.timeScale = 1;
			}
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Apple") {
			grow ();
			eatSound.Play ();
		}

		if (other.gameObject.tag == "Wall" || other.gameObject.tag == "Bomb" || other.gameObject.tag =="Body") {
			forward = Vector3.zero;
			Instantiate(explosionFX, m_transform.position, Quaternion.identity);
			Destroy(this.gameObject);
			isDead = true;
		}
	}

	Vector3 currentForward() {
		if (Input.GetKeyDown (KeyCode.W) || Input.GetKeyDown (KeyCode.UpArrow)) {
			return Vector3.forward;
		} else if (Input.GetKeyDown (KeyCode.S) ||Input.GetKeyDown (KeyCode.DownArrow)) {
			return Vector3.back;
		} else if (Input.GetKeyDown (KeyCode.A) || Input.GetKeyDown (KeyCode.LeftArrow)) {
			return Vector3.left;
		} else if (Input.GetKeyDown (KeyCode.D) || Input.GetKeyDown (KeyCode.RightArrow)) {
			return Vector3.right;
		} else {
			return forward;
		}
	}

	void followHead() {
		if (!isDead) {
			for (int i = count - 1; i > 0; i--) {
				bodies [i].transform.position = bodies [i - 1].transform.position;
			}
		}
	}

	void grow() {
		GameObject newBody = GameObject.Instantiate (preBody);
		bodies [count] = newBody;
		count++;
	}
}