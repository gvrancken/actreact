﻿using UnityEngine;
using System.Collections;

public class restartScript : MonoBehaviour {

	public bool showRestartModal = false;
	public float restartWait = 5f;

	private float modalW = Screen.width * 0.5f;
	private float modalH = Screen.height * 0.5f;

	private float startTime = 0;
	private float elapsedTime = 0;
	
	void Update () {
		if (startTime > 0 && elapsedTime <= restartWait)
		{
			elapsedTime = Time.time - startTime;
			showRestartModal = true;
			return;
		} 
		if (elapsedTime > restartWait) {
			ShowPlayer();
		}
	
		showRestartModal = false;

	}

	void OnTriggerEnter2D(Collider2D c) {
		startTime = Time.time;
	}
	

	void OnGUI() {
		if (showRestartModal) {
			if (GUI.Button (new Rect ((Screen.width - modalW) / 2, (Screen.height - modalH) / 2, modalW, modalH), "Click or press space to restart")) {
				print ("Restart clicked");
				Application.LoadLevel(0);
			}
		}
	}

	void ShowPlayer() {
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		Vector2 playerPos = player.transform.position;
		Vector3 endPos = new Vector3(playerPos.x, playerPos.y, Camera.main.transform.position.z);
		Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position,endPos, 0.05f);
	}

}
