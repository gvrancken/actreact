using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour {

	public bool checkForPlayer = false;

	private Transform player;


	void OnTriggerEnter2D(Collider2D c) {
		
		if (c.CompareTag("Player")) {
			player = c.transform;
			checkForPlayer = true;
		}
	}
	
	void OnTriggerExit2D(Collider2D c) {
		checkForPlayer = false;
	}

	void FixedUpdate() {
		if (checkForPlayer) {
			if (Mathf.Abs(player.position.x - transform.position.x) < 0.1) {
				print("open door");
			
			}
		}
	}

}
