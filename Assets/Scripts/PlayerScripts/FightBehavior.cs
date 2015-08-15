using UnityEngine;
using System.Collections;

public class FightBehavior : MonoBehaviour {
	public GameObject bullet;
	public ShootBehavior sBehavior;

	bool released = true;
	float timer = 10000f;
	// Use this for initialization
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButton ("Fire1") && released || Input.GetButton ("Fire1") && sBehavior.auto){
			released = false;
			if(timer >= sBehavior.delay){
				timer = 0.0f;
				if(sBehavior.fire){
					FireProjectiles();
				}else{
					MeleeAttack();
				}
			}
		}
		if (!Input.GetButton ("Fire1")) {
			released = true;
		}
		timer+=Time.deltaTime;
	}

	void FireProjectiles(){
		//Vector3 position = Input.mousePosition;
		GameObject b = Instantiate(bullet, transform.position, transform.rotation) as GameObject;
		b.GetComponent<Rigidbody2D> ().AddForce (b.transform.right * 500);
	}

	void MeleeAttack(){
		//TODO: Not implemented
	}

}
