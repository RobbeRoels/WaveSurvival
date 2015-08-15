using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {
	//TODO: Rename to represent full functionality

	public bool roaming = true;
	public float minSpeed = 0.8f;
	public float maxSpeed = 1.2f;
	public float timer = 0.0f;
	public GameObject player;
	public float minWalkBeforeTurn = 2.0f;
	public float maxWalkBeforeTurn = 9.0f;
	public int damage = 5;
	public Sprite deadSprite;
	public float attackSpeed = 0.7f;
	
	private float speed;
	private float rotationSpeed;
	private Quaternion toRotation;
	private float timeBeforeTurn;
	private float direction = 30f;
	private bool turning = false;
	private bool died = false;
	private bool attacking;
	private float attackTimer = 0.0f;
	// Use this for initialization
	void Start () {
		timeBeforeTurn = Random.Range (minWalkBeforeTurn, maxWalkBeforeTurn);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (!Dead ()) {
			if (turning) {
				toRotation = Quaternion.Euler (0, 0, direction);
				if(timer < 4.0f){
					turning = false;
					timer = 0.0f;
				}
			}
			if (!turning) {
				transform.parent.position = transform.parent.position + transform.parent.right * (speed * Time.deltaTime);
				if (roaming) {
					speed = minSpeed;
					rotationSpeed = minSpeed;
					if (timer >= timeBeforeTurn) {
						direction = 30f + direction;
						toRotation = Quaternion.Euler (0, 0, 180 - direction);
						timer = 0.0f;
					}
				} else {
					speed = maxSpeed;
					rotationSpeed = maxSpeed *2;
					Vector3 vectorToTarget = player.transform.position - transform.parent.position;
					float angle = Mathf.Atan2 (vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
					toRotation = Quaternion.AngleAxis (angle, Vector3.forward);
				}

			}
			transform.parent.rotation = Quaternion.Lerp (transform.parent.rotation, toRotation, Time.deltaTime * rotationSpeed);
			timer += Time.deltaTime;
		} else {
			if(!died){
				died = true;
				GetComponentInParent<SpriteRenderer>().sprite = deadSprite;
				Destroy(GetComponentInParent<Rigidbody2D>());
				Destroy(GetComponentInParent<PolygonCollider2D>());
				for(int i = 0; i < GetComponentsInParent<PolygonCollider2D>().Length; i++)
				{
					Destroy(GetComponentsInParent<PolygonCollider2D>()[i]);
				}
			}
		}
		if (attacking) {
			if(attackTimer >=attackSpeed){
				player.GetComponent<HealthManager>().TakeDamage(damage);
				attackTimer = 0.0f;
			}
			attackTimer += Time.deltaTime;
		}

	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Env" || other.tag == "Enemy") {
			turning = true;
			timer = 0.0f;
			direction = 180 + direction;
			print(turning);
		}
		if (other.tag == "Player") {
			attacking = true;
			player.GetComponent<HealthManager>().TakeDamage(damage);
		}
	}
	void OnTriggerExit2D(Collider2D other){
		if (other.tag == "Player") {
			attacking = false;
		}
	}

	bool Dead (){
		return GetComponent<HealthManager> ().health <= 0;
	}
	

}
