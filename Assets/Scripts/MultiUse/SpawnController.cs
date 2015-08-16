using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnController : MonoBehaviour {
	List<GameObject> spawners = new List< GameObject >();
	
	public void addSpawner(GameObject spawn) {
		spawners.Add (spawn);
	}

	public void removeSpawner(GameObject spawn) {
		spawners.Remove(spawn);
	}

	void Update () {
		//TODO: insert random spawn moment for random node.
	}
}
