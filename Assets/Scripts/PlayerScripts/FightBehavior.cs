using UnityEngine;
using System.Collections;

public class FightBehavior : MonoBehaviour {
	public GameObject bullet;
	public ShootBehavior sBehavior;
	

	bool reloading = false;
	float reloadTimer;
	bool released = true;
	float timer = 10000f;
	// Use this for initialization
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButton ("Fire1") && released || Input.GetButton ("Fire1") && sBehavior.auto){
			if(!reloading){
				released = false;
				if(timer >= sBehavior.delay){
					timer = 0.0f;
					if(sBehavior.fire){
						FireProjectiles();
					}else{
						MeleeAttack();
					}
				}
			}else{
				reloadTimer +=Time.deltaTime;
				reloading = reloadTimer>=sBehavior.reloadTime;
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
		b.GetComponent<Damage> ().damage = sBehavior.damagePerProjectile;
		b.GetComponent<Rigidbody2D> ().AddForce (b.transform.right * 500);

	}

	void MeleeAttack(){
		//TODO: Not implemented
	}

}
