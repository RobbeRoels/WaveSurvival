using UnityEngine;
using System.Collections;

public class TargetPlayer : MonoBehaviour {
	
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			EnemyMovement eM = transform.parent.GetComponentInChildren<EnemyMovement> ();
			eM.roaming = false;
		} else {
			//Do fucking nothing
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.tag == "Player") {
			EnemyMovement eM = transform.parent.GetComponentInChildren<EnemyMovement>();
			eM.roaming = true;
		} else {
			//Do fucking nothing
		}
	}

}
