using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour {
	
	public GameObject Enemy; //TODO: convert to array later.


	public void Spawn(){
		GameObject b = Instantiate (Enemy, transform.position, transform.rotation) as GameObject;
	}
}
