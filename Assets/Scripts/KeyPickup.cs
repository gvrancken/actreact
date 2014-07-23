using UnityEngine;
using System.Collections;

public class KeyPickup : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D c) {

		if (c.CompareTag("Player")) {
			print ("picked up key");
			Destroy(gameObject);
		}
	}

}