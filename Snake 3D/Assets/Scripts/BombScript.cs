using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
	protected Transform m_transform;
	public Transform explosionFX;
    // Start is called before the first frame update
    void Start()
    {
		m_transform = this.transform;
    }
		
	void OnTriggerEnter(Collider other) {

		if (other.gameObject.tag == "Player") {
			Instantiate(explosionFX, m_transform.position, Quaternion.identity);
			Destroy(gameObject);
		}
	}

}
