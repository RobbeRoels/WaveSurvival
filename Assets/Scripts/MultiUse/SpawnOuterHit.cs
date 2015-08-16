﻿using UnityEngine;
using System.Collections;

public class SpawnOuterHit : MonoBehaviour {
	public SpawnController spawnController;
	

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Spawner") {
			spawnController.addSpawner(other.gameObject);
		}
		
	}
	
	void OnTriggerExit2D(Collider2D other){
		if (other.tag == "Spawner") {
			spawnController.removeSpawner(other.gameObject);
		}

	}
}